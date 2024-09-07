using ABC.CarTraders.Core;
using ABC.CarTraders.Core.Domain;
using MRG.Controls.UI;
using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ABC.CarTraders.GUI.Forms
{
    public partial class TechnicianForm : Form
    {
        #region Common
        public IUnitOfWork UnitOfWork { get { return DashboardForm.UnitOfWork; } }
        public Action<Log> WriteLog { get { return DashboardForm.WriteLog; } }
        public Func<Task> SaveToDatabase { get { return DashboardForm.SaveToDatabaseAsync; } }
        public User User { get { return DashboardForm.User; } }
        #endregion

        #region Form
        public TechnicianForm()
        {
            InitializeComponent();
            pnlLoadingCircle.Controls.Add(LoadingCircle);

            rdoGovernment.Tag = TechnicianType.Government;
            rdoPrivate.Tag = TechnicianType.Private;
            rdoActive.Tag = TechnicianStatus.Active;
            rdoRetired.Tag = TechnicianStatus.Retired;
            rdoCancelled.Tag = TechnicianStatus.Cancelled;

            TechnicianCode = 1;
            TechnicianName = null;
            TechnicianNicNo = null;
            TechnicianPhoneNo = null;

            TechnicianVsRange = null;
            TechnicianInstitute = null;

            TechnicianIssuedDate = DateTime.Today;
            TechnicianType = TechnicianType.Government;
            TechnicianStatus = TechnicianStatus.Active;
            TechnicianNotes = null;

            //btnNew.Focus();
        }

        public void LoadInitialData()
        {
            cboVsRange.DataSource = UnitOfWork.VsRanges.GetAllCached().OrderBy(vsr => vsr.Name).ToList();
            //cboVsRange.DisplayMember = "Name";
            cboInstitute.DataSource = UnitOfWork.Institutes.GetAllCached().OrderBy(i => i.Name).ToList();
            //cboInstitute.DisplayMember = "Name";
        }

        public void NewRecord()
        {
            Overwrite = false;

            OldTechnician = null;
            Text = "New Technician";
            StatusText = "Ready";

            TechnicianName = null;
            TechnicianNicNo = null;
            TechnicianPhoneNo = null;
            TechnicianNotes = null;

            pnlCode.Enabled = true;
            btnLastCode.Enabled = true;
            btnSave.Enabled = ValidateInsertPersmission();
            nudCode.Focus();
        }

        public Technician OldTechnician { get; set; }
        public void ViewRecord(Technician technician)
        {
            Overwrite = true;

            OldTechnician = technician;
            Text = $"View Technician #{OldTechnician.Code}";
            StatusText = "Ready";

            TechnicianCode = OldTechnician.Code;
            TechnicianName = OldTechnician.Name;
            TechnicianNicNo = OldTechnician.NicNo;
            TechnicianPhoneNo = OldTechnician.PhoneNo;
            TechnicianVsRange = OldTechnician.VsRange;
            TechnicianInstitute = OldTechnician.Institute;
            TechnicianIssuedDate = OldTechnician.IssuedDate;
            TechnicianType = OldTechnician.Type;
            TechnicianStatus = OldTechnician.Status;
            TechnicianNotes = OldTechnician.Notes;

            //pnlCode.Enabled = false;
            //btnLastCode.Enabled = false;
            btnSave.Enabled = ValidateUpdatePersmission();
            txtName.Focus();
        }

        private void TechnicianForm_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
        #endregion

        #region Fields
        public int TechnicianCode
        {
            get { return (int)nudCode.Value; }
            set { nudCode.Value = value; }
        }

        private async void btnFind_Click(object sender, EventArgs e)
        {
            var technician = await UnitOfWork.Technicians.GetAsync(TechnicianCode);
            if (technician != default)
            {
                ViewRecord(technician);
            }
            else
            {
                MessageBox.Show($"Technician Code {TechnicianCode} does not exist in the Database.", "NOT FOUND", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private async void btnLastCode_Click(object sender, EventArgs e)
        {
            var n = await GetLastKeyRecordAsync();
            StopProgress();

            TechnicianCode = n == 0 ? 1 : n;
            nudCode.Focus();
        }

        private async Task<int> GetLastKeyRecordAsync()
        {
            var result = DialogResult.Retry;
            while (result == DialogResult.Retry)
            {
                try
                {
                    StartProgress("Getting Code...");
                    var n = await UnitOfWork.Technicians.GetMaxCodeAsync(TechnicianType);
                    StatusText = "Code Retrieved";
                    return n;
                }
                catch (Exception ex)
                {
                    StopProgress();
                    StatusText = "Error Occurred";
                    result = MessageBox.Show($"An error occurred while retrieving data from the Database.\n{ex.Message}\nPlease try again.", "ERROR", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                }
            }
            StatusText = "Ready";
            return 0;
        }
        public string TechnicianName
        {
            get
            {
                var str = txtName.Text.Trim();
                return str == string.Empty ? null : str;
            }
            set { txtName.Text = value; }
        }
        public string TechnicianNicNo
        {
            get
            {
                var str = txtNicNo.Text.Trim();
                return str == string.Empty ? null : str;
            }
            set { txtNicNo.Text = value; }
        }
        public string TechnicianPhoneNo
        {
            get
            {
                var str = txtPhoneNo.Text.Trim();
                return str == string.Empty ? null : str;
            }
            set { txtPhoneNo.Text = value; }
        }
        private void chkVsRange_CheckedChanged(object sender, EventArgs e)
        {
            pnlCboVsRangeHolder.Enabled = chkVsRange.Checked;
            pnlCboVsRangeHolder.Visible = chkVsRange.Checked;

            if (chkVsRange.Checked) chkInstitute.Checked = false;
        }
        public VsRange TechnicianVsRange
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
        private void chkInstitute_CheckedChanged(object sender, EventArgs e)
        {
            pnlCboInstituteHolder.Enabled = chkInstitute.Checked;
            pnlCboInstituteHolder.Visible = chkInstitute.Checked;

            if (chkInstitute.Checked) chkVsRange.Checked = false;
        }
        public Institute TechnicianInstitute
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
        private void chkIssuedDate_CheckedChanged(object sender, EventArgs e)
        {
            pnlDtpIssuedDateHolder.Enabled = chkIssuedDate.Checked;
            pnlDtpIssuedDateHolder.Visible = chkIssuedDate.Checked;
        }
        public DateTime? TechnicianIssuedDate
        {
            get
            {
                if (chkIssuedDate.Checked)
                {
                    return dtpIssuedDate.Value;
                }
                return null;
            }
            set
            {
                dtpIssuedDate.Value = value ?? DateTime.Today;
                chkIssuedDate.Checked = value != null;
            }
        }
        private void btnToday_Click(object sender, EventArgs e)
        {
            TechnicianIssuedDate = DateTime.Today;
        }
        public TechnicianType TechnicianType
        {
            get
            {
                var rdo = pnlTypeHolder.Controls.OfType<RadioButton>().FirstOrDefault(x => x.Checked);
                return (TechnicianType)rdo.Tag;
            }
            set
            {
                var rdo = pnlTypeHolder.Controls.OfType<RadioButton>().FirstOrDefault(x => (TechnicianType)x.Tag == value);
                rdo.Checked = true;
            }
        }
        public TechnicianStatus TechnicianStatus
        {
            get
            {
                var rdo = pnlStatusHolder.Controls.OfType<RadioButton>().FirstOrDefault(x => x.Checked);
                return (TechnicianStatus)rdo.Tag;
            }
            set
            {
                var rdo = pnlStatusHolder.Controls.OfType<RadioButton>().FirstOrDefault(x => (TechnicianStatus)x.Tag == value);
                rdo.Checked = true;
            }
        }
        public string TechnicianNotes
        {
            get
            {
                var str = txtNotes.Text.Trim();
                return str == string.Empty ? null : str;
            }
            set { txtNotes.Text = value; }
        }
        #endregion

        #region Actions
        private void btnNew_Click(object sender, EventArgs e)
        {
            NewRecord();
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
            {
                StatusText = "Data Required";
                MessageBox.Show("Data validation failed and the technician cannot be saved.\nPlease check for invalid / empty data.", "VALIDATE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var newTechnician = new Technician()
            {
                Code = TechnicianCode,
                Name = TechnicianName,
                NicNo = TechnicianNicNo,
                PhoneNo = TechnicianPhoneNo,
                VsRange = TechnicianVsRange,
                Institute = TechnicianInstitute,
                IssuedDate = TechnicianIssuedDate,
                Type = TechnicianType,
                Status = TechnicianStatus,
                Notes = TechnicianNotes,
                CreatedOn = DateTime.Now,
                CreatedBy = User
            };

            if (Overwrite)
            {
                if (!ValidateUpdatePersmission()) return;
                if (OldTechnician.Code != TechnicianCode)
                {
                    MessageBox.Show("You cannot change the Tech. Code of an existing Technician!\nThis operation is disabled to protect data integrity.", "CAUTION", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                UpdateRecord(OldTechnician, newTechnician);
            }
            else
            {
                if (!ValidateInsertPersmission()) return;
                if (await ValidateKeyAsync())
                {
                    AddRecord(newTechnician);
                }
            }
            StopProgress();
        }

        private bool ValidateInsertPersmission()
        {
            return (User.Role <= UserRole.Trainee);
        }

        private bool ValidateUpdatePersmission()
        {
            return (User.Role <= UserRole.Staff) ||
                (User == OldTechnician?.CreatedBy);
        }

        private bool ValidateInput()
        {
            if (TechnicianName == null)
            {
                txtName.Focus();
                return false;
            }
            return true;
        }

        private async Task<bool> ValidateKeyAsync()
        {
            var result = DialogResult.Retry;
            while (result == DialogResult.Retry)
            {
                try
                {
                    StartProgress("Checking Key...");
                    var tmp = await UnitOfWork.Technicians.GetAsync(TechnicianCode);
                    StopProgress();
                    if (tmp != null)
                    {
                        StatusText = "Key Exists";
                        var option = MessageBox.Show($"Technician Code {TechnicianCode} already exists. Do you want to view that record?", "DUPLICATE", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (option == DialogResult.Yes)
                        {
                            ViewRecord(tmp);
                            StatusText = "Ready";
                        }
                        else
                        {
                            nudCode.Focus();
                        }
                        return false;
                    }
                    return true;
                }
                catch (Exception ex)
                {
                    StopProgress();
                    StatusText = "Error Occurred";
                    result = MessageBox.Show($"An error occurred while retrieving data from the Database.\n{ex.Message}\nPlease try again.", "ERROR", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                }
            }
            StatusText = "Ready";
            return false;
        }

        public bool Overwrite { get; set; }
        private void AddRecord(Technician newTechnician)
        {
            UnitOfWork.Technicians.Add(newTechnician);
            WriteLog.Invoke(new Log()
            {
                Time = DateTime.Now,
                User = User,
                Title = "Technician",
                Action = LogAction.Insert,
                Text = $"Added a technician (#{newTechnician.Code})"
            });
            StatusText = "Record Saved";

            var result = MessageBox.Show("Technician saved successfully.\nDo you want to add another technician?", "SAVE", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result == DialogResult.Yes) btnNew.PerformClick();
            else ViewRecord(newTechnician);
        }

        private void UpdateRecord(Technician technician, Technician newTechnician)
        {
            technician.VsRange = newTechnician.VsRange;
            technician.Institute = newTechnician.Institute;
            technician.Name = newTechnician.Name;
            technician.NicNo = newTechnician.NicNo;
            technician.PhoneNo = newTechnician.PhoneNo;
            technician.IssuedDate = newTechnician.IssuedDate;
            technician.Type = newTechnician.Type;
            technician.Status = newTechnician.Status;
            technician.Notes = newTechnician.Notes;
            technician.ModifiedOn = DateTime.Now;
            technician.ModifiedBy = User;

            WriteLog.Invoke(new Log()
            {
                Time = DateTime.Now,
                User = User,
                Title = "Technician",
                Action = LogAction.Update,
                Text =$"Updated a technician (#{newTechnician.Code})"
            });
            StatusText = "Record Updated";

            MessageBox.Show("Technician updated successfully.", "UPDATE", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ViewRecord(technician);
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

        private async void btnToDatabase_Click(object sender, EventArgs e)
        {
            StartProgress("Applying Changes to Database...");
            await SaveToDatabase?.Invoke();
            StopProgress();
            StatusText = "Ready";
        }

        private void TechnicianForm_KeyDown(object sender, KeyEventArgs e)
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
