using System;
using System.Windows.Forms;
using Material.Styles;
using ABC.CarTraders.Core;
using ABC.CarTraders.GUI.Forms;
using ABC.CarTraders.Core.Domain;
using System.Collections.Generic;
using System.Linq;
using PagedList;
using System.Diagnostics;
using MRG.Controls.UI;
using System.Drawing;
using System.Threading.Tasks;
using System.ComponentModel;

namespace ABC.CarTraders.GUI.Sections
{
    public partial class CalvingRecordSection : UserControl, IColoredControl
    {
        #region Common
        private IUnitOfWork UnitOfWork { get { return DashboardForm.UnitOfWork; } }
        private Action<Log> WriteLog { get { return DashboardForm.WriteLog; } }
        private User User { get { return DashboardForm.User; } }
        #endregion

        public CalvingRecordSection()
        {
            InitializeComponent();
            pnlLoadingCircle.Controls.Add(LoadingCircle);
            dataGridView1.AutoGenerateColumns = false;

            cboRangeField.DataSource = new List<string>() { "AI Date", "Calving Date" };
            cboProvince.DataSource = new List<string>() { "All" };
            cboDistrict.DataSource = new List<string>() { "All" };
            cboVsRange.DataSource = new List<string>() { "All" };
            cboInstitute.DataSource = new List<string>() { "All" };
            cboSortField.DataSource = new List<string>() { "Sheet ID / No", "Province", "District", "VS Range" };
            cboSortDirection.DataSource = new List<string>() { "Ascending", "Descending" };

            RangeStart = DateTime.Today;
            RangeEnd = DateTime.Today.AddDays(1).AddSeconds(-1);

            RangeStart = null;
            RangeEnd = null;

            CalvingRecordTechnicianCode = null;
            CalvingRecordSemenCode = null;

            SortField = "Sheet ID / No";
            SortDirection = "Descending";

            nudPageNumber.MouseWheel += nudPageNumber_MouseWheel;
            ColorSchemeChanged += CalvingRecordSection_ColorSchemeChanged;
        }

        private ColorScheme _colorScheme;

        public ColorScheme ColorScheme
        {
            get { return _colorScheme; }
            set
            {
                _colorScheme = value;
                ColorSchemeChanged?.Invoke(this, value);
            }
        }

        public event EventHandler<ColorScheme> ColorSchemeChanged;
        private void CalvingRecordSection_ColorSchemeChanged(object sender, ColorScheme e)
        {
            if (e == null) return;

            BackColor = e.Color4;

            pnlMain.BackColor = e.Color9;
            btnExport.BackColor = e.Color9;
            pnlMainHolder.BackColor = e.Color0;

            pnlDgv.BackColor = e.Color3;
            dataGridView1.BackgroundColor = e.Color0;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = e.Color3;
            dataGridView1.ColumnHeadersDefaultCellStyle.SelectionBackColor = e.Color3;
            dataGridView1.DefaultCellStyle.SelectionBackColor = e.Color1;
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.Black;

            btnAdd.BackColor = e.Color2;
            btnEdit.BackColor = e.Color2;
            btnDelete.BackColor = e.Color2;

            btnFirstPage.BackColor = e.Color2;
            btnPreviousPage.BackColor = e.Color2;
            pnlPageIndicator.BackColor = e.Color3;
            btnNextPage.BackColor = e.Color2;
            btnLastPage.BackColor = e.Color2;
            btnRefresh.BackColor = e.Color2;

            pnlRange.BackColor = e.Color9;
            btnLastYear.BackColor = e.Color9;
            btnThisYear.BackColor = e.Color9;
            btnRangeClear.BackColor = e.Color9;
            pnlRangeHolder.BackColor = e.Color0;
            pnlRangeField.BackColor = e.Color3;
            pnlRangeStart.BackColor = e.Color3;
            pnlRangeEnd.BackColor = e.Color3;

            pnlFilter.BackColor = e.Color9;
            btnFilterClear.BackColor = e.Color9;
            pnlFilterHolder.BackColor = e.Color0;
            pnlFilter1.BackColor = e.Color3;
            pnlFilter2.BackColor = e.Color3;
            pnlFilter3.BackColor = e.Color3;
            pnlFilter4.BackColor = e.Color3;
            pnlFilter5.BackColor = e.Color3;
            pnlFilter6.BackColor = e.Color3;

            pnlSort.BackColor = e.Color9;
            pnlSortHolder.BackColor = e.Color0;
            pnlSortField.BackColor = e.Color3;
            pnlSortDirection.BackColor = e.Color3;
        }

        public void LoadInitialData()
        {
            cboProvince.SelectedValueChanged -= cboProvince_SelectedValueChanged;
            cboDistrict.SelectedValueChanged -= cboDistrict_SelectedValueChanged;
            cboVsRange.SelectedValueChanged -= cboVsRange_SelectedValueChanged;
            cboInstitute.SelectedValueChanged -= cboInstitute_SelectedValueChanged;

            var provinces = new List<string>() { "All" };
            provinces.AddRange(UnitOfWork.Provinces.GetAllCached().OrderBy(p => p.Name).Select(p => p.Name));
            cboProvince.DataSource = provinces;

            var districts = new List<string>() { "All" };
            districts.AddRange(UnitOfWork.Districts.GetAllCached().OrderBy(d => d.Name).Select(d => d.Name));
            cboDistrict.DataSource = districts;

            var vsRanges = new List<string>() { "All" };
            vsRanges.AddRange(UnitOfWork.VsRanges.GetAllCached().OrderBy(vsr => vsr.Name).Select(vsr => vsr.Name));
            cboVsRange.DataSource = vsRanges;

            var institutes = new List<string>() { "All" };
            institutes.AddRange(UnitOfWork.Institutes.GetAllCached().OrderBy(i => i.Name).Select(i => i.Name));
            cboInstitute.DataSource = institutes;

            cboProvince.SelectedValueChanged += cboProvince_SelectedValueChanged;
            cboDistrict.SelectedValueChanged += cboDistrict_SelectedValueChanged;
            cboVsRange.SelectedValueChanged += cboVsRange_SelectedValueChanged;
            cboInstitute.SelectedValueChanged += cboInstitute_SelectedValueChanged;
        }

        #region Data & Actions
        private string MainTitleText { set { lblMainTitle.Text = $"      {value}"; } }
        private void lblMainTitle_DoubleClick(object sender, EventArgs e)
        {
            dataGridView1.SelectAll();
        }

        private async void btnExport_Click(object sender, EventArgs e)
        {
            await ExportToExcelAsync();
        }

        public async Task ExportToExcelAsync()
        {
            if (UnitOfWork == null) return;
            var result = DialogResult.Retry;
            while (result == DialogResult.Retry)
            {
                try
                {
                    StartProgress("Exporting to Excel...");
                    var path = await UnitOfWork.CalvingRecords.ExportToExcelAsync(RangeField, RangeStart, RangeEnd, CalvingRecordProvince, CalvingRecordDistrict, CalvingRecordVsRange, CalvingRecordInstitute, CalvingRecordTechnicianCode, CalvingRecordSemenCode, SortField, SortDirection);
                    StopProgress();
                    StatusText = "Data Exported";
                    var option = MessageBox.Show($"Calving record data successfully exported to \"{path}\".\nDo you want to open the exported file now?", "EXPORT", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (option == DialogResult.Yes)
                    {
                        MessageBox.Show("Please close any opened Excel files before proceeding.\nClick OK to continue opening the file.", "EXCEL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Process.Start(path);
                    }
                    else
                    {
                        Process.Start(AppSettings.ABCFolderPath);
                    }
                    dataGridView1_SelectionChanged(null, null);
                    break;
                }
                catch (Exception ex)
                {
                    StopProgress();
                    StatusText = "Error Occurred";
                    result = MessageBox.Show($"An error occurred while exporting data from the Database to the Excel file.\n{ex.Message}\nPlease try again.", "ERROR", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                }
            }
            dataGridView1_SelectionChanged(null, null);
        }

        private IList<CalvingRecord> SelectedRecords
        {
            get
            {
                return dataGridView1.SelectedRows.Cast<DataGridViewRow>().Select(dgvr => dgvr.DataBoundItem as CalvingRecord).ToList();
            }
        }

        private CalvingRecord SelectedRecord
        {
            get
            {
                return dataGridView1.CurrentRow.DataBoundItem as CalvingRecord;
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            btnEdit.Enabled = dataGridView1.SelectedRows.Count == 1;
            btnDelete.Enabled = dataGridView1.SelectedRows.Count > 0 && ValidateDeletePermission();
            lblProgress.Text = $"      {dataGridView1.SelectedRows.Count} record(s) selected";
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F2:
                    btnEdit.PerformClick();
                    break;
                case Keys.Delete:
                    btnDelete.PerformClick();
                    break;
            }
            e.Handled = true;
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (btnEdit.Enabled) btnEdit.PerformClick();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (var form = new CalvingSheetForm())
            {
                form.LoadInitialData();
                form.NewRecord();
                form.ShowDialog();
            }
        }

        private async void btnEdit_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count != 1) return;

            using (var form = new CalvingSheetForm())
            {
                form.LoadInitialData();
                StartProgress("Loading...");
                await form.ViewRecordAsync(SelectedRecord);
                StopProgress();
                form.ShowDialog();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0) return;
            if (!ValidateDeletePermission()) return;
            var option = MessageBox.Show($"Do you want to delete the selected {dataGridView1.SelectedRows.Count} Calving record(s)?", "DELETE", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (option == DialogResult.Yes)
            {
                DeleteRecords();
            }
        }

        private bool ValidateDeletePermission()
        {
            return (User.Role <= UserRole.Staff);
        }

        private void DeleteRecords()
        {
            if (UnitOfWork == null) return;

            var calvingRecords = SelectedRecords.OrderBy(cr => cr.CalvingSheetId).ThenBy(cr => cr.No);
            var calvingRecordCount = calvingRecords.Count();
            var calvingRecordIds = string.Join(",", calvingRecords.Select(cr => $"{cr.CalvingSheetId}-{cr.No}"));

            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                dataGridView1.Rows.Remove(row);
            }

            WriteLog.Invoke(new Log()
            {
                Time = DateTime.Now,
                User = User,
                Title = "Calving Record",
                Action = LogAction.Delete,
                Text = $"Deleted {calvingRecordCount} calving record(s) (#{calvingRecordIds})"
            });
        }

        private int TotalRecords { get; set; } = 0;
        private int OldPageNumber { get; set; } = 1;
        private int PageSize { get { return 100; } }

        private void btnFirstPage_Click(object sender, EventArgs e)
        {
            PageNumber = 1;
        }

        private void btnPreviousPage_Click(object sender, EventArgs e)
        {
            if (PagedList.HasPreviousPage)
            {
                PageNumber--;
            }
        }
        private int PageNumber
        {
            get { return (int)nudPageNumber.Value; }
            set { nudPageNumber.Value = value; }
        }
        private async void nudPageNumber_ValueChanged(object sender, EventArgs e)
        {
            await RefreshAsync();
            nudPageNumber.Focus();
        }

        private void nudPageNumber_MouseWheel(object sender, MouseEventArgs e)
        {
            ((HandledMouseEventArgs)e).Handled = true;
        }

        private void btnNextPage_Click(object sender, EventArgs e)
        {
            if (PagedList.HasNextPage)
            {
                PageNumber++;
            }
        }

        private void btnLastPage_Click(object sender, EventArgs e)
        {
            PageNumber = PagedList.PageCount;
        }

        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            await RefreshAsync();
        }

        private IPagedList<CalvingRecord> PagedList { get; set; }

        public async Task RefreshAsync()
        {
            if (UnitOfWork == null) return;
            var result = DialogResult.Retry;
            while (result == DialogResult.Retry)
            {
                try
                {
                    StartProgress("Refreshing...");
                    PagedList = await UnitOfWork.CalvingRecords.GetPagedListAsync(RangeField, RangeStart, RangeEnd, CalvingRecordProvince, CalvingRecordDistrict, CalvingRecordVsRange, CalvingRecordInstitute, CalvingRecordTechnicianCode, CalvingRecordSemenCode, SortField, SortDirection, PageNumber, PageSize);
                    StopProgress();

                    dataGridView1.DataSource = new BindingList<CalvingRecord>(PagedList.ToList());
                    btnFirstPage.Enabled = PagedList.PageNumber > 1;
                    btnPreviousPage.Enabled = PagedList.HasPreviousPage;
                    btnNextPage.Enabled = PagedList.HasNextPage;
                    btnLastPage.Enabled = PagedList.PageNumber < PagedList.PageCount;
                    nudPageNumber.Maximum = PagedList.PageCount < 1 ? 1 : PagedList.PageCount;
                    lblPages.Text = $"/ {PagedList.PageCount}";
                    MainTitleText = $"Calving Records [{PagedList.FirstItemOnPage} - {PagedList.LastItemOnPage} / {PagedList.TotalItemCount}]";

                    OldPageNumber = PageNumber;
                    break;
                }
                catch (Exception ex)
                {
                    StopProgress();
                    StatusText = "Error Occurred";
                    result = MessageBox.Show($"An error occurred while retrieving data from the Database.\n{ex.Message}\nPlease try again.", "ERROR", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                    if (result == DialogResult.Cancel)
                    {
                        PageNumber = OldPageNumber;
                    }
                }
            }
            dataGridView1_SelectionChanged(null, null);
        }
        #endregion

        #region Range
        private string RangeField
        {
            get { return cboRangeField.SelectedItem as string; }
            set { cboRangeField.SelectedItem = value; }
        }

        private DateTime? RangeStart
        {
            get
            {
                if (chkRangeStart.Checked)
                {
                    return dtpRangeStart.Value;
                }
                return null;
            }
            set
            {
                dtpRangeStart.ValueChanged -= dtpRangeStart_ValueChanged;
                dtpRangeStart.Value = value ?? dtpRangeStart.Value;
                dtpRangeStart.ValueChanged += dtpRangeStart_ValueChanged;

                chkRangeStart.CheckedChanged -= chkRangeStart_CheckedChanged;
                chkRangeStart.Checked = value != null;
                chkRangeStart.CheckedChanged += chkRangeStart_CheckedChanged;

                pnlDtpRangeStartHolder.Visible = chkRangeStart.Checked;
            }
        }

        private DateTime? RangeEnd
        {
            get
            {
                if (chkRangeEnd.Checked)
                {
                    return dtpRangeEnd.Value;
                }
                return null;
            }
            set
            {
                dtpRangeEnd.ValueChanged -= dtpRangeEnd_ValueChanged;
                dtpRangeEnd.Value = value ?? dtpRangeEnd.Value;
                dtpRangeEnd.ValueChanged += dtpRangeEnd_ValueChanged;

                chkRangeEnd.CheckedChanged -= chkRangeEnd_CheckedChanged;
                chkRangeEnd.Checked = value != null;
                chkRangeEnd.CheckedChanged += chkRangeEnd_CheckedChanged;

                pnlDtpRangeEndHolder.Visible = chkRangeEnd.Checked;
            }
        }

        private async void btnLastYear_Click(object sender, EventArgs e)
        {
            RangeStart = new DateTime(DateTime.Today.Year - 1, 1, 1, 0, 0, 0);
            RangeEnd = new DateTime(DateTime.Today.Year - 1, 12, 31, 23, 59, 59);

            await RefreshAsync();
            btnLastYear.Focus();
        }

        private async void btnThisYear_Click(object sender, EventArgs e)
        {
            RangeStart = new DateTime(DateTime.Today.Year, 1, 1, 0, 0, 0);
            RangeEnd = new DateTime(DateTime.Today.Year, 12, 31, 23, 59, 59);

            await RefreshAsync();
            btnThisYear.Focus();
        }

        private async void btnRangeClear_Click(object sender, EventArgs e)
        {
            if (RangeStart == null && RangeEnd == null) return;

            RangeStart = null;
            RangeEnd = null;

            await RefreshAsync();
            btnRangeClear.Focus();
        }

        private async void cboRangeField_SelectedValueChanged(object sender, EventArgs e)
        {
            if (RangeStart == null && RangeEnd == null) return;

            await RefreshAsync();
            cboRangeField.Focus();
        }

        private async void chkRangeStart_CheckedChanged(object sender, EventArgs e)
        {
            pnlDtpRangeStartHolder.Visible = chkRangeStart.Checked;

            await RefreshAsync();
            chkRangeStart.Focus();
        }

        private async void dtpRangeStart_ValueChanged(object sender, EventArgs e)
        {
            await RefreshAsync();
            dtpRangeStart.Focus();
        }

        private async void chkRangeEnd_CheckedChanged(object sender, EventArgs e)
        {
            pnlDtpRangeEndHolder.Visible = chkRangeEnd.Checked;

            await RefreshAsync();
            chkRangeEnd.Focus();
        }

        private async void dtpRangeEnd_ValueChanged(object sender, EventArgs e)
        {
            await RefreshAsync();
            dtpRangeEnd.Focus();
        }
        #endregion

        #region Filter
        private Province CalvingRecordProvince
        {
            get
            {
                if (cboProvince.Text != "All")
                {
                    return UnitOfWork.Provinces.GetAllCached().SingleOrDefault(p => p.Name == cboProvince.Text);
                }
                return null;
            }
            set
            {
                cboProvince.SelectedValueChanged -= cboProvince_SelectedValueChanged;
                cboProvince.SelectedItem = value == null ? "All" : value.ToString();
                cboProvince.SelectedValueChanged += cboProvince_SelectedValueChanged;
            }
        }

        private District CalvingRecordDistrict
        {
            get
            {
                if (cboDistrict.Text != "All")
                {
                    return UnitOfWork.Districts.GetAllCached().SingleOrDefault(d => d.Name == cboDistrict.Text);
                }
                return null;
            }
            set
            {
                cboDistrict.SelectedValueChanged -= cboDistrict_SelectedValueChanged;
                cboDistrict.SelectedItem = value == null ? "All" : value.ToString();
                cboDistrict.SelectedValueChanged += cboDistrict_SelectedValueChanged;
            }
        }

        private VsRange CalvingRecordVsRange
        {
            get
            {
                if (cboVsRange.Text != "All")
                {
                    return UnitOfWork.VsRanges.GetAllCached().SingleOrDefault(d => d.Name == cboVsRange.Text);
                }
                return null;
            }
            set
            {
                cboVsRange.SelectedValueChanged -= cboVsRange_SelectedValueChanged;
                cboVsRange.SelectedItem = value == null ? "All" : value.ToString();
                cboVsRange.SelectedValueChanged += cboVsRange_SelectedValueChanged;
            }
        }

        private Institute CalvingRecordInstitute
        {
            get
            {
                if (cboInstitute.Text != "All")
                {
                    return UnitOfWork.Institutes.GetAllCached().SingleOrDefault(d => d.Name == cboInstitute.Text);
                }
                return null;
            }
            set
            {
                cboInstitute.SelectedValueChanged -= cboInstitute_SelectedValueChanged;
                cboInstitute.SelectedItem = value == null ? "All" : value.ToString();
                cboInstitute.SelectedValueChanged += cboInstitute_SelectedValueChanged;
            }
        }

        private int? CalvingRecordTechnicianCode
        {
            get
            {
                return rdoTechnicianAll.Checked ? null : (int?)nudTechnicianCode.Value;
            }
            set
            {
                //nudTechnicianCode.ValueChanged -= nudTechnicianCode_ValueChanged;
                nudTechnicianCode.Value = value ?? 0;
                //nudTechnicianCode.ValueChanged += nudTechnicianCode_ValueChanged;

                rdoTechnicianAll.CheckedChanged -= rdoTechnicianAll_CheckedChanged;
                rdoTechnicianCode.CheckedChanged -= rdoTechnicianCode_CheckedChanged;
                rdoTechnicianAll.Checked = value == null;
                rdoTechnicianCode.Checked = value != null;
                pnlNudTechnicianCodeHolder.Enabled = value != null;
                rdoTechnicianAll.CheckedChanged += rdoTechnicianAll_CheckedChanged;
                rdoTechnicianCode.CheckedChanged += rdoTechnicianCode_CheckedChanged;
            }
        }

        private int? CalvingRecordSemenCode
        {
            get
            {
                return rdoSemenAll.Checked ? null : (int?)nudSemenCode.Value;
            }
            set
            {
                //nudSemenCode.ValueChanged -= nudSemenCode_ValueChanged;
                nudSemenCode.Value = value ?? 0;
                //nudSemenCode.ValueChanged += nudSemenCode_ValueChanged;

                rdoSemenAll.CheckedChanged -= rdoSemenAll_CheckedChanged;
                rdoSemenCode.CheckedChanged -= rdoSemenCode_CheckedChanged;
                rdoSemenAll.Checked = value == null;
                rdoSemenCode.Checked = value != null;
                pnlNudSemenCodeHolder.Enabled = value != null;
                rdoSemenAll.CheckedChanged += rdoSemenAll_CheckedChanged;
                rdoSemenCode.CheckedChanged += rdoSemenCode_CheckedChanged;
            }
        }

        private async void btnFilterClear_Click(object sender, EventArgs e)
        {
            if (CalvingRecordProvince == null && CalvingRecordDistrict == null && CalvingRecordVsRange == null && CalvingRecordInstitute == null && CalvingRecordTechnicianCode == null && CalvingRecordSemenCode == null) return;

            CalvingRecordProvince = null;
            CalvingRecordDistrict = null;
            CalvingRecordVsRange = null;
            CalvingRecordInstitute = null;
            CalvingRecordTechnicianCode = null;
            CalvingRecordSemenCode = null;

            await RefreshAsync();
            btnFilterClear.Focus();
        }

        private void cboProvince_SelectedValueChanged(object sender, EventArgs e)
        {
            if (UnitOfWork == null) return;
            var districts = new List<string>() { "All" };
            if (cboProvince.Text.Equals("All"))
            {
                districts.AddRange(UnitOfWork.Districts.GetAllCached().OrderBy(d => d.Name).Select(d => d.Name));
            }
            else
            {
                districts.AddRange(UnitOfWork.Districts.GetAllCached().Where(d => d.Province.Name.Equals(cboProvince.Text)).OrderBy(d => d.Name).Select(d => d.Name));
            }

            cboDistrict.DataSource = districts;
        }

        private void cboDistrict_SelectedValueChanged(object sender, EventArgs e)
        {
            if (UnitOfWork == null) return;
            var vsRanges = new List<string>() { "All" };
            if (cboDistrict.Text.Equals("All"))
            {
                if (cboProvince.Text.Equals("All"))
                {
                    vsRanges.AddRange(UnitOfWork.VsRanges.GetAllCached().OrderBy(vsr => vsr.Name).Select(vsr => vsr.Name));
                }
                else
                {
                    vsRanges.AddRange(UnitOfWork.VsRanges.GetAllCached().Where(vsr => vsr.Province.Name.Equals(cboProvince.Text)).OrderBy(vsr => vsr.Name).Select(vsr => vsr.Name));
                }
            }
            else
            {
                vsRanges.AddRange(UnitOfWork.VsRanges.GetAllCached().Where(vsr => vsr.District.Name.Equals(cboDistrict.Text)).OrderBy(vsr => vsr.Name).Select(vsr => vsr.Name));
            }

            cboVsRange.DataSource = vsRanges;
        }

        private async void cboVsRange_SelectedValueChanged(object sender, EventArgs e)
        {
            await RefreshAsync();
            cboVsRange.Focus();
        }

        private async void cboInstitute_SelectedValueChanged(object sender, EventArgs e)
        {
            await RefreshAsync();
            cboInstitute.Focus();
        }

        private async void rdoTechnicianAll_CheckedChanged(object sender, EventArgs e)
        {
            if (CalvingRecordTechnicianCode != null) return;
            pnlNudTechnicianCodeHolder.Enabled = false;
            await RefreshAsync();
            rdoTechnicianAll.Focus();
        }

        private async void rdoTechnicianCode_CheckedChanged(object sender, EventArgs e)
        {
            if (CalvingRecordTechnicianCode == null) return;
            pnlNudTechnicianCodeHolder.Enabled = true;
            await RefreshAsync();
            nudTechnicianCode.Focus();
        }

        private async void nudTechnicianCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                e.Handled = true;
                await RefreshAsync();
            }
            nudTechnicianCode.Focus();
        }

        private async void rdoSemenAll_CheckedChanged(object sender, EventArgs e)
        {
            if (CalvingRecordSemenCode != null) return;
            pnlNudSemenCodeHolder.Enabled = false;
            await RefreshAsync();
            rdoSemenAll.Focus();
        }

        private async void rdoSemenCode_CheckedChanged(object sender, EventArgs e)
        {
            if (CalvingRecordSemenCode == null) return;
            pnlNudSemenCodeHolder.Enabled = true;
            await RefreshAsync();
            nudSemenCode.Focus();
        }

        private async void nudSemenCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                e.Handled = true;
                await RefreshAsync();
            }
            nudSemenCode.Focus();
        }
        #endregion

        #region Sort
        private string SortField
        {
            get { return cboSortField.SelectedItem as string; }
            set { cboSortField.SelectedItem = value; }
        }

        private string SortDirection
        {
            get { return cboSortDirection.SelectedItem as string; }
            set { cboSortDirection.SelectedItem = value; }
        }

        private async void cboSortField_SelectedValueChanged(object sender, EventArgs e)
        {
            await RefreshAsync();
            cboSortField.Focus();
        }

        private async void cboSortDirection_SelectedValueChanged(object sender, EventArgs e)
        {
            await RefreshAsync();
            cboSortDirection.Focus();
        }
        #endregion

        #region Progress
        public Stopwatch Stopwatch { get; set; } = new Stopwatch();
        public string StatusText { set { lblProgress.Text = $"      {value}"; } }
        public string ProgressText { get; set; }
        public LoadingCircle LoadingCircle { get; set; } = new LoadingCircle()
        {
            Color = Color.Black,
            NumberSpoke = 36,
            SpokeThickness = 1,
            InnerCircleRadius = 5,
            OuterCircleRadius = 6,
            RotationSpeed = 20,
            Dock = DockStyle.Fill
        };
        private void StartProgress(string text)
        {
            Stopwatch.Reset();
            Stopwatch.Start();
            pnlLoadingCircle.Visible = true;
            LoadingCircle.Active = true;
            ProgressText = text;
            StatusText = $"{ProgressText} (00:00)";
            timer1.Enabled = true;

            Enabled = false;
        }

        private void StopProgress()
        {
            Stopwatch.Stop();
            pnlLoadingCircle.Visible = false;
            LoadingCircle.Active = false;
            timer1.Enabled = false;

            Enabled = true;

            dataGridView1_SelectionChanged(null, null);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            var elapsed = Stopwatch.Elapsed;
            StatusText = $"{ProgressText} ({elapsed.Minutes:00}:{elapsed.Seconds:00})";
        }
        #endregion
    }
}
