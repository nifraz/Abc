using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Material.Styles;
using ABC.CarTraders.GUI.Forms;
using ABC.CarTraders.Core.Domain;
using System.Diagnostics;
using MRG.Controls.UI;
using PagedList;
using ABC.CarTraders.Core;

namespace ABC.CarTraders.GUI.Sections
{
    public partial class LogSection : UserControl, IColoredControl
    {
        #region Common
        private IUnitOfWork UnitOfWork { get { return DashboardForm.UnitOfWork; } }
        private Action<Log> WriteLog { get { return DashboardForm.WriteLog; } }
        private User User { get { return DashboardForm.User; } }
        #endregion

        #region Control
        public LogSection()
        {
            InitializeComponent();
            pnlLoadingCircle.Controls.Add(LoadingCircle);
            dataGridView1.AutoGenerateColumns = false;

            cboRangeField.DataSource = new List<string>() { "Time" };
            cboAction.DataSource = new List<string>() { "All", "Auth", "Select", "Insert", "Update", "Delete" };
            cboUser.DataSource = new List<string>() { "All" };
            cboFindField.DataSource = new List<string>() { "Username", "Title", "Text" };
            cboSortField.DataSource = new List<string>() { "ID", "Username", "Time", "Title" };
            cboSortDirection.DataSource = new List<string>() { "Ascending", "Descending" };

            RangeStart = DateTime.Today;
            RangeEnd = DateTime.Today.AddDays(1).AddSeconds(-1);

            RangeStart = null;
            RangeEnd = null;

            SortField = "ID";
            SortDirection = "Descending";

            nudPageNumber.MouseWheel += nudPageNumber_MouseWheel;
            ColorSchemeChanged += LogSection_ColorSchemeChanged;
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

        private void LogSection_ColorSchemeChanged(object sender, ColorScheme e)
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

            pnlFind.BackColor = e.Color9;
            btnFindClear.BackColor = e.Color9;
            pnlFindHolder.BackColor = e.Color0;
            pnlFindField.BackColor = e.Color3;
            pnlFindText.BackColor = e.Color3;

            pnlSort.BackColor = e.Color9;
            pnlSortHolder.BackColor = e.Color0;
            pnlSortField.BackColor = e.Color3;
            pnlSortDirection.BackColor = e.Color3;
        }

        public void LoadInitialData()
        {
            cboUser.SelectedValueChanged -= cboUser_SelectedValueChanged;

            var users = new List<string>() { "All" };
            users.AddRange(UnitOfWork.Users.GetAllCached().OrderBy(u => u.Username).Select(u => u.Username));
            cboUser.DataSource = users;

            cboUser.SelectedValueChanged += cboUser_SelectedValueChanged;
        }
        #endregion

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
                    var path = await UnitOfWork.Logs.ExportToExcelAsync(RangeField, RangeStart, RangeEnd, LogAction, LogUser, FindField, FindText, SortField, SortDirection);
                    StopProgress();
                    StatusText = "Data Exported";
                    var option = MessageBox.Show($"Log data successfully exported to \"{path}\".\nDo you want to open the exported file now?", "EXPORT", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
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

        private IList<Log> SelectedRecords
        {
            get
            {
                return dataGridView1.SelectedRows.Cast<DataGridViewRow>().Select(dgvr => dgvr.DataBoundItem as Log).ToList();
            }
        }

        private Log SelectedRecord
        {
            get
            {
                return dataGridView1.CurrentRow.DataBoundItem as Log;
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            btnEdit.Enabled = dataGridView1.SelectedRows.Count == 1;
            btnDelete.Enabled = dataGridView1.SelectedRows.Count > 0 && ValidateDeletePermission();
            StatusText = $"{dataGridView1.SelectedRows.Count} record(s) selected";
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
            btnEdit.PerformClick();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (var form = new LogForm())
            {
                form.LoadInitialData();
                form.NewRecord();
                form.ShowDialog();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count != 1) return;

            using (var form = new LogForm())
            {
                form.LoadInitialData();
                form.ViewRecord(SelectedRecord);
                form.ShowDialog();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0) return;
            if (!ValidateDeletePermission()) return;
            var option = MessageBox.Show($"Do you want to delete the selected {dataGridView1.SelectedRows.Count} VS Range record(s)?", "DELETE", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (option == DialogResult.Yes)
            {
                DeleteRecords();
            }
        }

        private bool ValidateDeletePermission()
        {
            return (User.Role <= UserRole.Admin) && false;
        }

        private void DeleteRecords()
        {
            if (UnitOfWork == null) return;

            var logs = SelectedRecords.OrderBy(l => l.Id);
            var logCount = logs.Count();
            var logIds = string.Join(",", logs.Select(l => l.Id));
            UnitOfWork.Logs.RemoveRange(logs);

            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                dataGridView1.Rows.Remove(row);
            }

            WriteLog.Invoke(new Log()
            {
                Time = DateTime.Now,
                User = User,
                Title = "Log",
                Action = Core.Domain.LogAction.Delete,
                Text = $"Deleted {logCount} log(s) (#{logIds})"
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

        private IPagedList<Log> PagedList { get; set; }

        public async Task RefreshAsync()
        {
            if (UnitOfWork == null) return;
            var result = DialogResult.Retry;
            while (result == DialogResult.Retry)
            {
                try
                {
                    StartProgress("Refreshing...");
                    PagedList = await UnitOfWork.Logs.GetPagedListAsync(RangeField, RangeStart, RangeEnd, LogAction, LogUser, FindField, FindText, SortField, SortDirection, PageNumber, PageSize);
                    StopProgress();

                    dataGridView1.DataSource = new BindingList<Log>(PagedList.ToList());
                    btnFirstPage.Enabled = PagedList.PageNumber > 1;
                    btnPreviousPage.Enabled = PagedList.HasPreviousPage;
                    btnNextPage.Enabled = PagedList.HasNextPage;
                    btnLastPage.Enabled = PagedList.PageNumber < PagedList.PageCount;
                    nudPageNumber.Maximum = PagedList.PageCount < 1 ? 1 : PagedList.PageCount;
                    lblPages.Text = $"/ {PagedList.PageCount}";
                    MainTitleText = $"Logs [{PagedList.FirstItemOnPage} - {PagedList.LastItemOnPage} / {PagedList.TotalItemCount}]";

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
        private LogAction? LogAction
        {
            get
            {
                if (cboAction.Text != "All")
                {
                    LogAction v;
                    if (Enum.TryParse(cboAction.Text, out v))
                    {
                        return v;
                    }
                }
                return null;
            }
            set
            {
                cboAction.SelectedValueChanged -= cboAction_SelectedValueChanged;
                cboAction.SelectedItem = value == null ? "All" : value.ToString();
                cboAction.SelectedValueChanged += cboAction_SelectedValueChanged;
            }
        }

        private User LogUser
        {
            get
            {
                if (cboUser.Text != "All")
                {
                    return UnitOfWork.Users.GetAllCached().SingleOrDefault(u => u.Username == cboUser.Text);
                }
                return null;
            }
            set
            {
                cboUser.SelectedValueChanged -= cboUser_SelectedValueChanged;
                cboUser.SelectedItem = value == null ? "All" : value.ToString();
                cboUser.SelectedValueChanged += cboUser_SelectedValueChanged;
            }
        }

        private async void btnFilterClear_Click(object sender, EventArgs e)
        {
            if (LogAction == null && LogUser == null) return;

            LogAction = null;
            LogUser = null;

            await RefreshAsync();
            btnFilterClear.Focus();
        }

        private async void cboAction_SelectedValueChanged(object sender, EventArgs e)
        {
            await RefreshAsync();
            cboAction.Focus();
        }

        private async void cboUser_SelectedValueChanged(object sender, EventArgs e)
        {
            await RefreshAsync();
            cboUser.Focus();
        }
        #endregion

        #region Find
        private string FindField
        {
            get { return cboFindField.SelectedItem as string; }
            set { cboFindField.SelectedItem = value; }
        }
        private string FindText
        {
            get
            {
                var str = txtFindText.Text.Trim();
                return str == string.Empty ? null : str;
            }
            set { txtFindText.Text = value; }
        }
        private async void btnFindClear_Click(object sender, EventArgs e)
        {
            if (FindText == null) return;

            FindText = null;

            await RefreshAsync();
            btnFindClear.Focus();
        }

        private async void cboFindField_SelectedValueChanged(object sender, EventArgs e)
        {
            if (FindText == null) return;

            await RefreshAsync();
            cboFindField.Focus();
        }

        private async void txtFindText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                await RefreshAsync();
            }
            txtFindText.Focus();
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
