using ABC.CarTraders.Core;
using ABC.CarTraders.Core.Domain;
using MRG.Controls.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ABC.CarTraders.GUI.Forms
{
    public partial class InstituteForm : Form
    {
        #region Common
        public IUnitOfWork UnitOfWork { get { return DashboardForm.UnitOfWork; } }
        public Action<Log> WriteLog { get { return DashboardForm.WriteLog; } }
        public Func<Task> SaveToDatabase { get { return DashboardForm.SaveToDatabaseAsync; } }
        public User User { get { return DashboardForm.User; } }
        #endregion

        #region Form
        public InstituteForm()
        {
            InitializeComponent();
            pnlLoadingCircle.Controls.Add(LoadingCircle);

            InstituteName = null;
            InstituteNotes = null;
        }

        public void LoadInitialData()
        {
            
        }

        public void NewRecord()
        {
            Overwrite = false;

            OldInstitute = null;
            Text = "New Institute";
            StatusText = "Ready";

            InstituteName = null;
            InstituteNotes = null;

            pnlName.Enabled = true;
            //btnConvert.Enabled = false;
            btnSave.Enabled = ValidateInsertPersmission();
            txtName.Focus();
        }

        public Institute OldInstitute { get; set; }
        public void ViewRecord(Institute vsRange)
        {
            Overwrite = true;

            OldInstitute = vsRange;
            Text = $"View Institute #{OldInstitute.Name}";
            StatusText = "Ready";

            InstituteName = OldInstitute.Name;
            InstituteNotes = OldInstitute.Notes;

            pnlName.Enabled = false;
            //btnConvert.Enabled = true;
            btnSave.Enabled = ValidateUpdatePersmission();
        }

        private void InstituteForm_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
        #endregion

        #region Fields
        public string InstituteName
        {
            get
            {
                var str = txtName.Text.Trim();
                return str == string.Empty ? null : str;
            }
            set { txtName.Text = value; }
        }
        public string InstituteNotes
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
            //SaveIfChanged();
            NewRecord();
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
            {
                StatusText = "Data Required";
                MessageBox.Show("Data validation failed and the Institute cannot be saved.\nPlease check for invalid / empty data.", "VALIDATE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var newInstitute = new Institute()
            {
                Name = InstituteName,
                Notes = InstituteNotes,
                CreatedOn = DateTime.Now,
                CreatedBy = User
            };

            if (Overwrite)
            {
                if (!ValidateUpdatePersmission()) return;
                UpdateRecord(OldInstitute, newInstitute);
            }
            else
            {
                if (!ValidateInsertPersmission()) return;
                if (await ValidateKeyAsync())
                {
                    AddRecord(newInstitute);
                }
            }
            StopProgress();
        }

        private bool ValidateInsertPersmission()
        {
            return (User.Role <= UserRole.Staff);
        }

        private bool ValidateUpdatePersmission()
        {
            return (User.Role <= UserRole.Doctor) ||
                (User == OldInstitute?.CreatedBy);
        }

        private bool ValidateInput()
        {
            if (InstituteName == null)
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
                    var tmp = await UnitOfWork.Institutes.GetAsync(InstituteName);
                    StopProgress();
                    if (tmp != null)
                    {
                        StatusText = "Key Exists";
                        var option = MessageBox.Show($"Institute {InstituteName} already exists. Do you want to view that record?", "DUPLICATE", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (option == DialogResult.Yes)
                        {
                            ViewRecord(tmp);
                            StatusText = "Ready";
                        }
                        else
                        {
                            txtName.Focus();
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
        private void AddRecord(Institute newInstitute)
        {
            UnitOfWork.Institutes.Add(newInstitute);
            WriteLog.Invoke(new Log()
            {
                Time = DateTime.Now,
                User = User,
                Title = "Institute",
                Action = LogAction.Insert,
                Text = $"Added an institute (#{newInstitute.Name})"
            });
            StatusText = "Record Saved";

            var result = MessageBox.Show("Institute saved successfully.\nDo you want to add another Institute?", "SAVE", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result == DialogResult.Yes) btnNew.PerformClick();
            else ViewRecord(newInstitute);
        }

        private void UpdateRecord(Institute institute, Institute newInstitute)
        {
            institute.Name = newInstitute.Name;
            institute.Notes = newInstitute.Notes;
            institute.ModifiedOn = DateTime.Now;
            institute.ModifiedBy = User;

            WriteLog.Invoke(new Log()
            {
                Time = DateTime.Now,
                User = User,
                Title = "Institute",
                Action = LogAction.Update,
                Text = $"Updated an institute (#{newInstitute.Name})"
            });
            StatusText = "Record Updated";

            MessageBox.Show("Institute updated successfully.", "UPDATE", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ViewRecord(institute);
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

        private void InstituteForm_KeyDown(object sender, KeyEventArgs e)
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

        private void btnConvert_Click(object sender, EventArgs e)
        {
            //using (var form = new InstituteToVsRangeForm())
            //{
            //    form.LoadInitialData();
            //    form.ViewRecord(OldInstitute);
            //    form.ShowDialog();
            //}
        }
    }
}
