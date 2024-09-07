using ABC.CarTraders.Core;
using ABC.CarTraders.Core.Domain;
using Material.Styles;
using MRG.Controls.UI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ABC.CarTraders.GUI.Forms
{
    public partial class CalvingSheetForm : Form
    {
        #region Common
        public IUnitOfWork UnitOfWork { get { return DashboardForm.UnitOfWork; } }
        public Action<Log> WriteLogAction { get { return DashboardForm.WriteLog; } }
        public Func<Task> SaveToDatabaseAsyncFunc { get { return DashboardForm.SaveToDatabaseAsync; } }
        public User User { get { return DashboardForm.User; } }
        #endregion

        #region Form
        public CalvingSheetForm()
        {
            InitializeComponent();
            pnlLoadingCircle.Controls.Add(LoadingCircle);

            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.TopLeftHeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.TopLeftHeaderCell.Value = "*";
            dataGridView1.TopLeftHeaderCell.ToolTipText = "(Click to select all)";
            dataGridView1.TopLeftHeaderCell.Style.BackColor = Color.DarkGray;
            dataGridView1.AdvancedRowHeadersBorderStyle.Right = DataGridViewAdvancedCellBorderStyle.Single;
            dataGridView1.AdvancedColumnHeadersBorderStyle.Bottom = DataGridViewAdvancedCellBorderStyle.Single;

            CalvingSheetTechnicianCode = 0;
            CalvingSheetYear = DateTime.Today.Year;
            CalvingSheetMonth = (byte)DateTime.Today.Month;
            CalvingSheetVsRange = null;
            CalvingSheetInstitute = null;
            CalvingSheetNotes = null;
        }

        public void NewRecord()
        {
            Overwrite = false;

            OldCalvingSheet = null;
            Text = "New Calving Sheet";
            StatusText = "Ready";

            CalvingSheetCalvingRecords = new List<CalvingRecord>();
            CalvingSheetNotes = null;
            btnRefresh.Enabled = false;
            btnSave.Enabled = ValidateInsertPersmission();
            nudTechnicianCode.Focus();
        }

        public CalvingSheet OldCalvingSheet { get; set; }
        public async Task ViewRecordAsync(CalvingSheet calvingSheet)
        {
            Overwrite = true;

            OldCalvingSheet = calvingSheet;
            var sheetId = OldCalvingSheet.Id == 0 ? "?" : OldCalvingSheet.Id.ToString();
            Text = $"View Calving Sheet #{sheetId}";
            StatusText = "Ready";

            CalvingSheetTechnicianCode = OldCalvingSheet.TechnicianCode;
            await SetTechnicianDataAsync();
            CalvingSheetMonth = OldCalvingSheet.Month;
            CalvingSheetYear = OldCalvingSheet.Year;
            CalvingSheetVsRange = OldCalvingSheet.VsRange;
            CalvingSheetInstitute = OldCalvingSheet.Institute;
            CalvingSheetCalvingRecords = OldCalvingSheet.CalvingRecords.OrderBy(cr => cr.No);
            CalvingSheetNotes = OldCalvingSheet.Notes;
            btnRefresh.Enabled = true;
            btnSave.Enabled = ValidateUpdatePersmission();
        }

        public async Task ViewRecordAsync(CalvingRecord calvingRecord)
        {
            await ViewRecordAsync(calvingRecord.CalvingSheet);

            DataGridViewRow row = dataGridView1.Rows
                .Cast<DataGridViewRow>()
                .Where(r => int.Parse(r.HeaderCell.FormattedValue.ToString()) == calvingRecord.No)
                .First();

            var rowIndex = row.Index;
            dataGridView1.ClearSelection();
            dataGridView1.Rows[rowIndex].Selected = true;
            dataGridView1.CurrentCell = dataGridView1.Rows[rowIndex].Cells[0];
            dataGridView1.Focus();
        }

        public void LoadInitialData()
        {
            cboVsRange.DataSource = UnitOfWork.VsRanges.GetAllCached().OrderBy(vsr => vsr.Name).ToList();
            //cboVsRange.DisplayMember = "Name";
            cboInstitute.DataSource = UnitOfWork.Institutes.GetAllCached().OrderBy(i => i.Name).ToList();
            //cboInstitute.DisplayMember = "Name";
        }

        private void CalvingSheetForm_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
        #endregion

        #region Fields
        public int? CalvingSheetTechnicianCode
        {
            get
            {
                if (nudTechnicianCode.Value != 0)
                {
                    return (int)nudTechnicianCode.Value;
                }
                return null;
            }
            set { nudTechnicianCode.Value = value ?? 0; }
        }

        private async void nudTechnicianCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                e.Handled = true;
                await SetTechnicianDataAsync();
            }
            nudTechnicianCode.Focus();
        }

        private async void btnFindTechnician_Click(object sender, EventArgs e)
        {
            await SetTechnicianDataAsync();
        }

        private async Task SetTechnicianDataAsync()
        {
            if (CalvingSheetTechnicianCode == null)
            {
                CalvingSheetTechnician = null;
                CalvingSheetTechnicianName = "(Unknown)";
                CalvingSheetTechnicianPhoneNo = "(Unknown)";
                return;
            }

            var result = DialogResult.Retry;
            while (result == DialogResult.Retry)
            {
                try
                {
                    StartProgress("Getting Technician Record...");
                    var technician = await UnitOfWork.Technicians.GetAsync(CalvingSheetTechnicianCode.Value);
                    StopProgress();

                    if (technician == null)
                    {
                        StatusText = "Technician Not Found";
                        CalvingSheetTechnician = null;
                        CalvingSheetTechnicianName = "(Not Found)";
                        CalvingSheetTechnicianPhoneNo = "(Not Found)";
                        MessageBox.Show($"Technician code {CalvingSheetTechnicianCode.Value} not found in Database.\nPlease check the code.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        StatusText = "Ready";
                        CalvingSheetTechnician = technician;
                        CalvingSheetTechnicianName = CalvingSheetTechnician.Name;
                        CalvingSheetTechnicianPhoneNo = CalvingSheetTechnician.PhoneNo;
                    }
                    break;
                }
                catch (Exception ex)
                {
                    StopProgress();
                    StatusText = "Error Occurred";
                    result = MessageBox.Show($"An error occurred while retrieving data from the Database.\n{ex.Message}\nPlease try again.", "ERROR", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                }
            }
            StatusText = "Ready";
        }

        public string CalvingSheetTechnicianName
        {
            set { txtName.Text = value; }
        }

        public string CalvingSheetTechnicianPhoneNo
        {
            set { txtPhoneNo.Text = value; }
        }

        public Technician CalvingSheetTechnician { get; set; }

        private void nudTechnicianCode_ValueChanged(object sender, EventArgs e)
        {
            CalvingSheetTechnician = null;
            txtName.Text = null;
            txtPhoneNo.Text = null;
        }

        private void btnTechnician_Click(object sender, EventArgs e)
        {
            if (CalvingSheetTechnician == null) return;

            using (var form = new TechnicianForm())
            {
                form.LoadInitialData();
                form.ViewRecord(CalvingSheetTechnician);
                form.ShowDialog();
            }
        }

        private void btnCall_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Insert SIM card :(", "NO SIM", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        public byte CalvingSheetMonth
        {
            get { return (byte)nudMonth.Value; }
            set { nudMonth.Value = value; }
        }

        public int CalvingSheetYear
        {
            get { return (int)nudYear.Value; }
            set { nudYear.Value = value; }
        }
        private void chkVsRange_CheckedChanged(object sender, EventArgs e)
        {
            pnlCboVsRangeHolder.Enabled = chkVsRange.Checked;
            pnlCboVsRangeHolder.Visible = chkVsRange.Checked;
            pnlDistrict.Visible = chkVsRange.Checked;

            if (chkVsRange.Checked)
            {
                chkInstitute.Checked = false;
                CalvingSheetDistrict = $"{CalvingSheetVsRange?.District?.Name} ({CalvingSheetVsRange?.District?.Province?.Name} Prov.)";
            }
        }

        public VsRange CalvingSheetVsRange
        {
            get
            {
                if (chkVsRange.Checked)
                {
                    return cboVsRange.SelectedItem as VsRange;
                }
                return null;
            }
            set
            {
                cboVsRange.SelectedItem = value ?? cboVsRange.SelectedItem;
                chkVsRange.Checked = value != null;
            }
        }

        private void cboVsRange_SelectedValueChanged(object sender, EventArgs e)
        {
            if (CalvingSheetVsRange == null) return;
            CalvingSheetDistrict = $"{CalvingSheetVsRange.District.Name} ({CalvingSheetVsRange.District.Province.Name} Prov.)";
        }

        private void btnVsRange_Click(object sender, EventArgs e)
        {
            if (CalvingSheetVsRange == null) return;

            using (var form = new VsRangeForm())
            {
                form.LoadInitialData();
                form.ViewRecord(CalvingSheetVsRange);
                form.ShowDialog();
            }
        }

        public string CalvingSheetDistrict
        {
            set { txtDistrict.Text = value; }
        }

        private void chkInstitute_CheckedChanged(object sender, EventArgs e)
        {
            pnlCboInstituteHolder.Enabled = chkInstitute.Checked;
            pnlCboInstituteHolder.Visible = chkInstitute.Checked;
            //pnlDistrict.Visible = !chkVsRange.Checked;

            if (chkInstitute.Checked) chkVsRange.Checked = false;
        }
        public Institute CalvingSheetInstitute
        {
            get
            {
                if (chkInstitute.Checked)
                {
                    return cboInstitute.SelectedItem as Institute;
                }
                return null;
            }
            set
            {
                cboInstitute.SelectedItem = value ?? cboInstitute.SelectedItem;
                chkInstitute.Checked = value != null;
            }
        }

        private void cboInstitute_SelectedValueChanged(object sender, EventArgs e)
        {
            
        }

        private void btnInstitute_Click(object sender, EventArgs e)
        {
            if (CalvingSheetInstitute == null) return;

            using (var form = new InstituteForm())
            {
                form.LoadInitialData();
                form.ViewRecord(CalvingSheetInstitute);
                form.ShowDialog();
            }
        }

        

        public IEnumerable<CalvingRecord> CalvingSheetCalvingRecords
        {
            get
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    var no = row.HeaderCell.FormattedValue.ToString();
                    var aiDD = row.Cells[0].FormattedValue.ToString();
                    var aiMM = row.Cells[1].FormattedValue.ToString();
                    var aiYY = row.Cells[2].FormattedValue.ToString();
                    var semenCode = row.Cells[3].FormattedValue.ToString();
                    var cowVsCode = row.Cells[4].FormattedValue.ToString();
                    var cowFarmNo = row.Cells[5].FormattedValue.ToString();
                    var cowAnimalNo = row.Cells[6].FormattedValue.ToString();
                    var calfVsCode = row.Cells[7].FormattedValue.ToString();
                    var calfFarmNo = row.Cells[8].FormattedValue.ToString();
                    var calfAnimalNo = row.Cells[9].FormattedValue.ToString();
                    var calvingDD = row.Cells[10].FormattedValue.ToString();
                    var calvingMM = row.Cells[11].FormattedValue.ToString();
                    var calvingYY = row.Cells[12].FormattedValue.ToString();
                    var sex = row.Cells[13].FormattedValue.ToString();

                    var aiDate = string.IsNullOrEmpty(aiDD) && string.IsNullOrEmpty(aiMM) && string.IsNullOrEmpty(aiYY) ? null : new DateTime(2000 + int.Parse(aiYY), int.Parse(aiMM), int.Parse(aiDD)) as DateTime?;

                    var calvingDate = string.IsNullOrEmpty(calvingDD) && string.IsNullOrEmpty(calvingMM) && string.IsNullOrEmpty(calvingYY) ? null : new DateTime(2000 + int.Parse(calvingYY), int.Parse(calvingMM), int.Parse(calvingDD)) as DateTime?;

                    yield return new CalvingRecord()
                    {
                        No = string.IsNullOrEmpty(no) ? (byte)0 : byte.Parse(no),
                        AiDate = aiDate,
                        SemenCode = string.IsNullOrEmpty(semenCode) ? null : int.Parse(semenCode) as int?,
                        CowVsCode = string.IsNullOrEmpty(cowVsCode) ? null : int.Parse(cowVsCode) as int?,
                        CowFarmNo = string.IsNullOrEmpty(cowFarmNo) ? null : int.Parse(cowFarmNo) as int?,
                        CowAnimalNo = string.IsNullOrEmpty(cowAnimalNo) ? null : int.Parse(cowAnimalNo) as int?,
                        CalfVsCode = string.IsNullOrEmpty(calfVsCode) ? null : int.Parse(calfVsCode) as int?,
                        CalfFarmNo = string.IsNullOrEmpty(calfFarmNo) ? null : int.Parse(calfFarmNo) as int?,
                        CalfAnimalNo = string.IsNullOrEmpty(calfAnimalNo) ? null : int.Parse(calfAnimalNo) as int?,
                        CalvingDate = calvingDate,
                        Sex = string.IsNullOrEmpty(sex) ? (byte)0 : byte.Parse(sex)
                    };
                }
            }
            set
            {
                dataGridView1.Rows.Clear();
                foreach (var item in value)
                {
                    AddNewRow(item);
                }
            }
        }

        public string CalvingSheetNotes
        {
            get
            {
                var str = txtNotes.Text.Trim();
                return str == string.Empty ? null : str;
            }
            set { txtNotes.Text = value; }
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
            //StatusText = $"Ready";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            var elapsed = Stopwatch.Elapsed;
            StatusText = $"{ProgressText} ({elapsed.Minutes:00}:{elapsed.Seconds:00})";
        }

        #endregion

        #region Actions
        private void btnAddRow_Click(object sender, EventArgs e)
        {
            AddNewRow(null);
        }
        private void AddNewRow(CalvingRecord calvingRecord)
        {
            if (calvingRecord == null)
            {
                int max = dataGridView1.Rows.Cast<DataGridViewRow>()
                    .Select(r => r.HeaderCell.FormattedValue.ToString())
                    .DefaultIfEmpty("0")
                    .Max(r => int.TryParse(r, out max) ? max : 0);
                if (max >= 99)
                {
                    MessageBox.Show("Only 99 records maximum allowed per sheet.", "ADD", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var row = dataGridView1.Rows.Add
                (
                    null,
                    null,
                    null,
                    null,
                    null,
                    null,
                    null,
                    null,
                    null,
                    null,
                    null,
                    null,
                    null,
                    null
                );
                dataGridView1.Rows[row].HeaderCell.Value = (max + 1).ToString("00");
                StatusText = $"Row Added";
            }
            else
            {
                var row = dataGridView1.Rows.Add
                (
                    calvingRecord.AiDD,
                    calvingRecord.AiMM,
                    calvingRecord.AiYY,
                    calvingRecord.SemenCode,
                    calvingRecord.CowVsCode,
                    calvingRecord.CowFarmNo,
                    calvingRecord.CowAnimalNo,
                    calvingRecord.CalfVsCode,
                    calvingRecord.CalfFarmNo,
                    calvingRecord.CalfAnimalNo,
                    calvingRecord.CalvingDD,
                    calvingRecord.CalvingMM,
                    calvingRecord.CalvingYY,
                    calvingRecord.Sex
                );
                dataGridView1.Rows[row].HeaderCell.Value = calvingRecord.No.ToString("00");
            }
            dataGridView1.Focus();
        }
        private void btnDeleteRow_Click(object sender, EventArgs e)
        {
            DeleteSelectedRows();
        }

        public DataGridViewSelectedCellCollection SelectedCells
        {
            get
            {
                return dataGridView1.SelectedCells;
            }
        }

        public IEnumerable<DataGridViewRow> SelectedRows
        {
            get
            {
                return dataGridView1.SelectedCells.Cast<DataGridViewCell>()
                                           .Select(cell => cell.OwningRow)
                                           .Distinct();
            }
        }

        public IEnumerable<DataGridViewColumn> SelectedColumns
        {
            get
            {
                return dataGridView1.SelectedCells.Cast<DataGridViewCell>()
                                           .Select(cell => cell.OwningColumn)
                                           .Distinct();
            }
        }

        private void DeleteSelectedRows()
        {
            var selectedRows = SelectedRows.ToList();
            var rowCount = selectedRows.Count();

            if (rowCount <= 0) return;
            foreach (DataGridViewRow row in selectedRows)
            {
                dataGridView1.Rows.Remove(row);
            }
            StatusText = $"{rowCount} Row(s) Deleted";
            dataGridView1.Focus();
        }

        private async void btnValidateData_Click(object sender, EventArgs e)
        {
            await ValidateInputAsync();
            ValidateData();
        }

        private void ValidateData()
        {
            var problemCount = 0;

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                var aiDD = row.Cells[0].FormattedValue.ToString();
                var aiMM = row.Cells[1].FormattedValue.ToString();
                var aiYY = row.Cells[2].FormattedValue.ToString();

                var calvingDD = row.Cells[10].FormattedValue.ToString();
                var calvingMM = row.Cells[11].FormattedValue.ToString();
                var calvingYY = row.Cells[12].FormattedValue.ToString();

                var aiDate = string.IsNullOrEmpty(aiDD) || string.IsNullOrEmpty(aiMM) || string.IsNullOrEmpty(aiYY) ? null : IsValidDate(aiYY, aiMM, aiDD) ? new DateTime(2000 + int.Parse(aiYY), int.Parse(aiMM), int.Parse(aiDD)) as DateTime? : null;

                var calvingDate = string.IsNullOrEmpty(calvingDD) || string.IsNullOrEmpty(calvingMM) || string.IsNullOrEmpty(calvingYY) ? null : IsValidDate(calvingYY, calvingMM, calvingDD) ? new DateTime(2000 + int.Parse(calvingYY), int.Parse(calvingMM), int.Parse(calvingDD)) as DateTime? : null;

                if (aiDate != null && calvingDate != null)
                {
                    var diff = (calvingDate - aiDate).Value.Days;

                    if (diff < 275 || diff > 300)
                    {
                        problemCount++;
                        //dataGridView1.CurrentCell = row.Cells[10];

                        for (int i = 0; i < 13; i++)
                        {
                            if (i > 2 && i < 10) continue;
                            row.Cells[i].Style.BackColor = ColorScheme.Amber.Color1;
                            row.Cells[i].Style.SelectionBackColor = ColorScheme.Amber.Color5;
                            row.Cells[i].ToolTipText = $"AI-Calving difference must be between 275-300 days (current:{diff})";
                        }
                    }
                    else
                    {
                        for (int i = 0; i < 13; i++)
                        {
                            if (i > 2 && i < 10) continue;
                            row.Cells[i].Style.BackColor = Color.White;
                            row.Cells[i].Style.SelectionBackColor = SystemColors.Highlight;
                            row.Cells[i].ToolTipText = string.Empty;
                        }
                    }
                }

            }
            if (problemCount == 0)
            {
                StatusText = "Data Validation Passed";
            }

            else
            {
                StatusText = $"{problemCount} problematic record(s) found";
            }
            dataGridView1.Focus();
        }

        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            if (OldCalvingSheet == null) return;
            await ViewRecordAsync(OldCalvingSheet);
            StatusText = "Ready";
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            NewRecord();
        }

        
        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (!await ValidateInputAsync())
            {
                StatusText = "Data Required";
                MessageBox.Show("Data validation failed and the sheet cannot be saved.\nPlease check for invalid / empty data.", "VALIDATE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var newCalvingSheet = new CalvingSheet()
            {
                Technician = CalvingSheetTechnician,
                VsRange = CalvingSheetVsRange,
                Institute = CalvingSheetInstitute,
                Year = CalvingSheetYear,
                Month = CalvingSheetMonth,
                Notes = CalvingSheetNotes,
                CalvingRecords = new HashSet<CalvingRecord>(),

                CreatedOn = DateTime.Now,
                CreatedBy = User
            };

            if (Overwrite)
            {
                if (!ValidateUpdatePersmission()) return;
                await UpdateRecord(OldCalvingSheet, newCalvingSheet);
            }
            else
            {
                if (!ValidateInsertPersmission()) return;
                AddRecord(newCalvingSheet);
            }
        }

        private bool ValidateInsertPersmission()
        {
            return (User.Role <= UserRole.Trainee);
        }

        private bool ValidateUpdatePersmission()
        {
            return (User.Role <= UserRole.Staff) ||
                (User == OldCalvingSheet?.CreatedBy);
        }

        private async Task<bool> ValidateInputAsync()
        {
            var errorCount = 0;

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                //AI Date
                var aiYY = row.Cells[2].FormattedValue.ToString();
                var aiMM = row.Cells[1].FormattedValue.ToString();
                var aiDD = row.Cells[0].FormattedValue.ToString();

                var aiDateHasData = !(string.IsNullOrEmpty(aiYY) && string.IsNullOrEmpty(aiMM) && string.IsNullOrEmpty(aiDD));

                if (aiDateHasData)
                {
                    var emptyCount = 0;
                    for (int i = 0; i < 3; i++)
                    {
                        if (string.IsNullOrEmpty(row.Cells[i].FormattedValue.ToString()))
                        {
                            emptyCount++;
                            errorCount++;
                            dataGridView1.CurrentCell = row.Cells[i];

                            row.Cells[i].Style.BackColor = ColorScheme.Red.Color1;
                            row.Cells[i].Style.SelectionBackColor = ColorScheme.Red.Color5;
                            row.Cells[i].ToolTipText = "Value Required";
                        }
                        else
                        {
                            row.Cells[i].Style.BackColor = Color.White;
                            row.Cells[i].Style.SelectionBackColor = SystemColors.Highlight;
                            row.Cells[i].ToolTipText = string.Empty;
                        }
                    }

                    if (emptyCount == 0)
                    {
                        if (!IsValidDate(aiYY, aiMM, aiDD))
                        {
                            errorCount++;
                            dataGridView1.CurrentCell = row.Cells[0];

                            for (int i = 0; i < 3; i++)
                            {
                                row.Cells[i].Style.BackColor = ColorScheme.Red.Color1;
                                row.Cells[i].Style.SelectionBackColor = ColorScheme.Red.Color5;
                                row.Cells[i].ToolTipText = "Invalid Date";
                            }
                        }
                        else
                        {
                            for (int i = 0; i < 3; i++)
                            {
                                row.Cells[i].Style.BackColor = Color.White;
                                row.Cells[i].Style.SelectionBackColor = SystemColors.Highlight;
                                row.Cells[i].ToolTipText = string.Empty;
                            }
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < 3; i++)
                    {
                        row.Cells[i].Style.BackColor = Color.White;
                        row.Cells[i].Style.SelectionBackColor = SystemColors.Highlight;
                        row.Cells[i].ToolTipText = string.Empty;
                    }
                }

                //Calving Date
                var calvingYY = row.Cells[12].FormattedValue.ToString();
                var calvingMM = row.Cells[11].FormattedValue.ToString();
                var calvingDD = row.Cells[10].FormattedValue.ToString();

                var calvingDateHasData = !(string.IsNullOrEmpty(calvingYY) && string.IsNullOrEmpty(calvingMM) && string.IsNullOrEmpty(calvingDD));

                if (calvingDateHasData)
                {
                    var emptyCount = 0;
                    for (int i = 10; i < 13; i++)
                    {
                        if (string.IsNullOrEmpty(row.Cells[i].FormattedValue.ToString()))
                        {
                            emptyCount++;
                            errorCount++;
                            dataGridView1.CurrentCell = row.Cells[i];

                            row.Cells[i].Style.BackColor = ColorScheme.Red.Color1;
                            row.Cells[i].Style.SelectionBackColor = ColorScheme.Red.Color5;
                            row.Cells[i].ToolTipText = "Value Required";
                        }
                        else
                        {
                            row.Cells[i].Style.BackColor = Color.White;
                            row.Cells[i].Style.SelectionBackColor = SystemColors.Highlight;
                            row.Cells[i].ToolTipText = string.Empty;
                        }
                    }

                    if (emptyCount == 0)
                    {
                        if (!IsValidDate(calvingYY, calvingMM, calvingDD))
                        {
                            errorCount++;
                            dataGridView1.CurrentCell = row.Cells[10];

                            for (int i = 10; i < 13; i++)
                            {
                                row.Cells[i].Style.BackColor = ColorScheme.Red.Color1;
                                row.Cells[i].Style.SelectionBackColor = ColorScheme.Red.Color5;
                                row.Cells[i].ToolTipText = "Invalid Date";
                            }
                        }
                        else
                        {
                            for (int i = 10; i < 13; i++)
                            {
                                row.Cells[i].Style.BackColor = Color.White;
                                row.Cells[i].Style.SelectionBackColor = SystemColors.Highlight;
                                row.Cells[i].ToolTipText = string.Empty;
                            }
                        }
                    }
                }
                else
                {
                    for (int i = 10; i < 13; i++)
                    {
                        row.Cells[i].Style.BackColor = Color.White;
                        row.Cells[i].Style.SelectionBackColor = SystemColors.Highlight;
                        row.Cells[i].ToolTipText = string.Empty;
                    }
                }

                //Sex
                var sex = row.Cells[13].FormattedValue.ToString();
                var sexHasData = !string.IsNullOrEmpty(sex);

                if (sexHasData)
                {
                    var sexValue = int.Parse(sex);
                    var isValidSex = sexValue <= 1 && sexValue >= 0;

                    if (!isValidSex)
                    {
                        errorCount++;
                        dataGridView1.CurrentCell = row.Cells[13];
                        row.Cells[13].Style.BackColor = ColorScheme.Red.Color1;
                        row.Cells[13].Style.SelectionBackColor = ColorScheme.Red.Color5;
                        row.Cells[13].ToolTipText = "Invalid Sex (must be either 1 or 0)";
                    }
                    else
                    {
                        row.Cells[13].Style.BackColor = Color.White;
                        row.Cells[13].Style.SelectionBackColor = SystemColors.Highlight;
                        row.Cells[13].ToolTipText = string.Empty;
                    }
                }
                else
                {
                    errorCount++;
                    dataGridView1.CurrentCell = row.Cells[13];
                    row.Cells[13].Style.BackColor = ColorScheme.Red.Color1;
                    row.Cells[13].Style.SelectionBackColor = ColorScheme.Red.Color5;
                    row.Cells[13].ToolTipText = "Value Required";
                }
            }

            if(errorCount > 0) dataGridView1.Focus();

            //Technician
            await SetTechnicianDataAsync();
            if (CalvingSheetTechnicianCode != null && CalvingSheetTechnician == null)
            {
                errorCount++;
                nudTechnicianCode.Focus();
            }


            if (errorCount == 0)
            {
                StatusText = "Validation Succeeded";
                return true;
            }
            else
            {
                StatusText = "Validation Failed";
                return false;
            }
        }

        public bool IsValidDate(string yy, string mm, string dd)
        {
            var year = 2000 + int.Parse(yy);
            var month = int.Parse(mm);
            var day = int.Parse(dd);
            return year >= 1 && year <= 9999
                    && month >= 1 && month <= 12
                    && day >= 1 && day <= DateTime.DaysInMonth(year, month);
        }

        public bool Overwrite { get; set; }
        private async void AddRecord(CalvingSheet newCalvingSheet)
        {
            UnitOfWork.CalvingSheets.Add(newCalvingSheet);

            WriteLogAction.Invoke(new Log()
            {
                Time = DateTime.Now,
                User = User,
                Title = "Calving sheet",
                Action = LogAction.Insert,
                Text = $"Added a calving sheet"
            });
            AddCalvingRecords(newCalvingSheet);
            StatusText = "Calving Sheet Saved";

            var result = MessageBox.Show("Calving sheet saved successfully.\nDo you want to add another sheet?", "SAVE", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result == DialogResult.Yes) btnNew.PerformClick();
            else await ViewRecordAsync(newCalvingSheet);
        }

        private void AddCalvingRecords(CalvingSheet calvingSheet)
        {
            foreach (var calvingRecord in CalvingSheetCalvingRecords)
            {
                calvingSheet.CalvingRecords.Add(calvingRecord);
            }

            WriteLogAction.Invoke(new Log()
            {
                Time = DateTime.Now,
                User = User,
                Title = "Calving record",
                Action = LogAction.Insert,
                Text = $"Processed {calvingSheet.CalvingRecords.Count()} calving record(s)"
            });
            //StatusText = "Calving Records Updated";
        }

        private async Task UpdateRecord(CalvingSheet calvingSheet, CalvingSheet newCalvingSheet)
        {
            calvingSheet.Technician = newCalvingSheet.Technician;
            calvingSheet.VsRange = newCalvingSheet.VsRange;
            calvingSheet.Institute = newCalvingSheet.Institute;
            calvingSheet.Year = newCalvingSheet.Year;
            calvingSheet.Month = newCalvingSheet.Month;
            calvingSheet.Notes = newCalvingSheet.Notes;
            calvingSheet.ModifiedOn = DateTime.Now;
            calvingSheet.ModifiedBy = User;

            WriteLogAction.Invoke(new Log()
            {
                Time = DateTime.Now,
                User = User,
                Title = "Calving sheet",
                Action = LogAction.Update,
                Text = $"Updated a calving sheet"
            });
            DeleteCalvingRecords(calvingSheet);
            AddCalvingRecords(calvingSheet);
            StatusText = "Calving Sheet Updated";
            MessageBox.Show("Calving sheet updated successfully.", "UPDATE", MessageBoxButtons.OK, MessageBoxIcon.Information);
            await ViewRecordAsync(calvingSheet);
        }

        private void DeleteCalvingRecords(CalvingSheet calvingSheet)
        {
            UnitOfWork.CalvingRecords.RemoveRange(calvingSheet.CalvingRecords);
        }
        #endregion

        #region Datagrid
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            btnAddRow.Enabled = true;
            btnDeleteRow.Enabled = dataGridView1.SelectedRows.Count > 0;
            btnCopyToRight.Enabled = dataGridView1.SelectedCells.Count > 0;
            btnCopyToDown.Enabled = dataGridView1.SelectedCells.Count > 0;
            btnClear.Enabled = dataGridView1.SelectedCells.Count > 0;
            btnValidateData.Enabled = true;
        }

        private void dataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            
        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("Data Error!");
        }

        private void dataGridView1_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            Rectangle rtHeader = dataGridView1.DisplayRectangle;
            rtHeader.Height = dataGridView1.ColumnHeadersHeight / 2;
            dataGridView1.Invalidate(rtHeader);
        }

        private void dataGridView1_Scroll(object sender, ScrollEventArgs e)
        {
            Rectangle rtHeader = dataGridView1.DisplayRectangle;
            rtHeader.Height = dataGridView1.ColumnHeadersHeight / 2;
            dataGridView1.Invalidate(rtHeader);
        }

        public string[] topColumns { get; set; } = { "AI Date", "Semen", "Cow ID", "Calf ID", "Calving Date", "Sex" };
        public int[] topColumnWidths { get; set; } = { 40 * 3, 60 * 7, 40 * 3, 80 };
        public int[] topColumnSpans { get; set; } = { 3, 1, 3, 3, 3, 1 };
        private void dataGridView1_Paint(object sender, PaintEventArgs e)
        {
            for (int i = 0, j = 0; i < topColumns.Length; i++)
            {
                Rectangle r1 = dataGridView1.GetCellDisplayRectangle(j, -1, true);
                int w2 = (dataGridView1.GetCellDisplayRectangle(j, -1, true).Width * (topColumnSpans[i] - 1)) + topColumnSpans[i];

                r1.X += 1;
                r1.Y += 1;

                r1.Width = r1.Width + w2 - (topColumnSpans[i] + 3);
                r1.Height = r1.Height / 2 - 2;

                e.Graphics.FillRectangle(new SolidBrush(Color.Silver), r1);
                e.Graphics.DrawString(
                    topColumns[i],
                    dataGridView1.ColumnHeadersDefaultCellStyle.Font,
                    new SolidBrush(Color.Black),
                    r1,
                    new StringFormat()
                    {
                        Alignment = StringAlignment.Center,
                        LineAlignment = StringAlignment.Center
                    }
                );
                j += topColumnSpans[i];
            }
        }

        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex == -1 && e.ColumnIndex > -1)
            {
                Rectangle r2 = e.CellBounds;
                r2.Y += e.CellBounds.Height / 2;
                r2.Height = e.CellBounds.Height / 2;
                e.PaintBackground(r2, true);
                e.PaintContent(r2);
                e.Handled = true;
            }
        }

        #endregion

        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= dataGridView1Cell_KeyPress;
            var tb = e.Control as TextBox;
            if (tb != null)
            {
                tb.KeyPress += dataGridView1Cell_KeyPress;
            }
        }

        private void dataGridView1Cell_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                //return;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //
        }

        private void btnCopyToRight_Click(object sender, EventArgs e)
        {
            foreach (var row in SelectedRows)
            {
                if (string.IsNullOrEmpty(row.Cells[7].FormattedValue.ToString()))
                {
                    row.Cells[7].Value = row.Cells[4].Value;
                }

                if (string.IsNullOrEmpty(row.Cells[8].FormattedValue.ToString()))
                {
                    row.Cells[8].Value = row.Cells[5].Value;
                }
            }
        }

        private void btnCopyToDown_Click(object sender, EventArgs e)
        {
            var selectedColumns = SelectedColumns;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Index == 0) continue;
                foreach (DataGridViewColumn column in selectedColumns)
                {
                    if (string.IsNullOrEmpty(row.Cells[column.Index].FormattedValue.ToString()))
                    {
                        row.Cells[column.Index].Value = dataGridView1.Rows[row.Index - 1].Cells[column.Index].Value;
                    }
                    
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewCell cell in SelectedCells)
            {
                cell.Value = null;
            }
        }

        private void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //dataGridView1.ClearSelection();
            //foreach (var row in dataGridView1.Rows)
            //{

            //}
            //for (int i = 0; i < dataGridView1.Columns.Count; ++i)
            //{
            //    dataGridView1.Rows[e.RowIndex].Cells[i].Selected = true;
            //}
            //base.OnRowHeaderMouseClick(e);
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //dataGridView1.ClearSelection();
            //for (int i = 0; i < dataGridView1.Rows.Count; ++i)
            //{
            //    dataGridView1.Rows[i].Cells[e.ColumnIndex].Selected = true;
            //}
            //base.OnColumnHeaderMouseClick(e);
        }

        private async void btnToDatabase_Click(object sender, EventArgs e)
        {
            StartProgress("Applying Changes to Database...");
            await SaveToDatabaseAsyncFunc?.Invoke();
            StopProgress();
            StatusText = "Ready";
        }

        private void CalvingSheetForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control)
            {
                switch (e.KeyCode)
                {
                    case Keys.S:
                        if (e.Shift) btnToDatabase.PerformClick();
                        else btnSave.PerformClick();
                        e.SuppressKeyPress = true;
                        break;
                    case Keys.N:
                        btnNew.PerformClick();
                        e.SuppressKeyPress = true;
                        break;
                }
            }
        }

    }
}
