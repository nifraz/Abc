using ABC.CarTraders.Entities;
using ABC.CarTraders.Enums;
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
    public partial class CarForm : Form
    {
        #region Common
        public AppDbContext DbContext { get { return DashboardForm.DbContext; } }
        public Action<Log> WriteLog { get { return DashboardForm.WriteLog; } }
        public Func<Task> SaveToDatabase { get { return DashboardForm.SaveToDatabaseAsync; } }
        public User User { get { return DashboardForm.User; } }
        #endregion

        #region Form
        public CarForm()
        {
            InitializeComponent();
            pnlLoadingCircle.Controls.Add(LoadingCircle);

            //rdoGovernment.Tag = TechnicianType.Government;
            //rdoPrivate.Tag = TechnicianType.Private;
            //rdoActive.Tag = TechnicianStatus.Active;
            //rdoRetired.Tag = TechnicianStatus.Retired;
            //rdoCancelled.Tag = TechnicianStatus.Cancelled;

            //TechnicianCode = 1;
            //TechnicianName = null;
            //TechnicianNicNo = null;
            //TechnicianPhoneNo = null;

            //TechnicianVsRange = null;
            //TechnicianInstitute = null;

            //TechnicianIssuedDate = DateTime.Today;
            //TechnicianType = TechnicianType.Government;
            //TechnicianStatus = TechnicianStatus.Active;
            //TechnicianNotes = null;

            //btnNew.Focus();
        }

        public void LoadInitialData()
        {
            //cboVsRange.DataSource = UnitOfWork.VsRanges.GetAllCached().OrderBy(vsr => vsr.Name).ToList();
            ////cboVsRange.DisplayMember = "Name";
            //cboInstitute.DataSource = UnitOfWork.Institutes.GetAllCached().OrderBy(i => i.Name).ToList();
            //cboInstitute.DisplayMember = "Name";
        }

        public void NewRecord()
        {
            Overwrite = false;

            OldCar = null;
            Text = "New Car";
            StatusText = "Ready";

            ModelName = null;
            //TechnicianNicNo = null;
            //TechnicianPhoneNo = null;
            Notes = null;

            pnlCode.Enabled = true;
            btnLastCode.Enabled = true;
            btnSave.Enabled = ValidateInsertPersmission();
            nudCode.Focus();
        }

        public Car OldCar { get; set; }
        public void ViewRecord(Car car)
        {
            Overwrite = true;

            OldCar = car;
            Text = $"View Car #{OldCar.Id}";
            StatusText = "Ready";

            //TechnicianCode = OldCustomer.Code;
            //TechnicianName = OldCustomer.Name;
            //TechnicianNicNo = OldCustomer.NicNo;
            //TechnicianPhoneNo = OldCustomer.PhoneNo;
            //TechnicianVsRange = OldCustomer.VsRange;
            //TechnicianInstitute = OldCustomer.Institute;
            //TechnicianIssuedDate = OldCustomer.IssuedDate;
            //TechnicianType = OldCustomer.Type;
            //TechnicianStatus = OldCustomer.Status;
            //TechnicianNotes = OldCustomer.Notes;

            //pnlCode.Enabled = false;
            //btnLastCode.Enabled = false;
            btnSave.Enabled = ValidateUpdatePersmission();
            txtModelName.Focus();
        }

        private void CarForm_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
        #endregion

        #region Fields
        public string ModelName
        {
            get
            {
                var str = txtModelName.Text.Trim();
                return str == string.Empty ? null : str;
            }
            set { txtModelName.Text = value; }
        }

        public decimal Price
        {
            get { return nudPrice.Value; }
            set { nudPrice.Value = value; }
        }

        public int Year
        {
            get { return (int)nudYear.Value; }
            set { nudYear.Value = value; }
        }

        private void btnThisYear_Click(object sender, EventArgs e)
        {
            nudYear.Value = DateTime.Today.Year;
        }
        public string Notes
        {
            get
            {
                var notes = txtNotes.Text.Trim();
                return notes == string.Empty ? null : notes;
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

            var newTechnician = new User()
            {
                //Code = TechnicianCode,
                //Name = TechnicianName,
                //NicNo = TechnicianNicNo,
                //PhoneNo = TechnicianPhoneNo,
                //VsRange = TechnicianVsRange,
                //Institute = TechnicianInstitute,
                //IssuedDate = TechnicianIssuedDate,
                //Type = TechnicianType,
                //Status = TechnicianStatus,
                //Notes = TechnicianNotes,
                //CreatedOn = DateTime.Now,
                //CreatedBy = User
            };

            //if (Overwrite)
            //{
            //    if (!ValidateUpdatePersmission()) return;
            //    if (OldCustomer.Code != TechnicianCode)
            //    {
            //        MessageBox.Show("You cannot change the Tech. Code of an existing Car!\nThis operation is disabled to protect data integrity.", "CAUTION", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //        return;
            //    }
            //    UpdateRecord(OldCustomer, newTechnician);
            //}
            //else
            //{
            //    if (!ValidateInsertPersmission()) return;
            //    if (await ValidateKeyAsync())
            //    {
            //        AddRecord(newTechnician);
            //    }
            //}
            //StopProgress();
        }

        private bool ValidateInsertPersmission()
        {
            //return (User.Role <= UserRole.Trainee);
            return true;
        }

        private bool ValidateUpdatePersmission()
        {
            //return (User.Role <= UserRole.Staff) ||
            //    (User == OldCustomer?.User.CreatedBy);
            return true;
        }

        private bool ValidateInput()
        {
            if (ModelName == null)
            {
                txtModelName.Focus();
                return false;
            }
            return true;
        }

        //private async Task<bool> ValidateKeyAsync()
        //{
        //    var result = DialogResult.Retry;
        //    while (result == DialogResult.Retry)
        //    {
        //        try
        //        {
        //            StartProgress("Checking Key...");
        //            var tmp = await UnitOfWork.Technicians.GetAsync(TechnicianCode);
        //            StopProgress();
        //            if (tmp != null)
        //            {
        //                StatusText = "Key Exists";
        //                var option = MessageBox.Show($"Car Code {TechnicianCode} already exists. Do you want to view that record?", "DUPLICATE", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
        //                if (option == DialogResult.Yes)
        //                {
        //                    ViewRecord(tmp);
        //                    StatusText = "Ready";
        //                }
        //                else
        //                {
        //                    nudCode.Focus();
        //                }
        //                return false;
        //            }
        //            return true;
        //        }
        //        catch (Exception ex)
        //        {
        //            StopProgress();
        //            StatusText = "Error Occurred";
        //            result = MessageBox.Show($"An error occurred while retrieving data from the Database.\n{ex.Message}\nPlease try again.", "ERROR", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
        //        }
        //    }
        //    StatusText = "Ready";
        //    return false;
        //}

        public bool Overwrite { get; set; }
        //private void AddRecord(Customer newTechnician)
        //{
        //    UnitOfWork.Technicians.Add(newTechnician);
        //    WriteLog.Invoke(new Log()
        //    {
        //        Time = DateTime.Now,
        //        User = User,
        //        Title = "Car",
        //        Action = LogAction.Insert,
        //        Text = $"Added a technician (#{newTechnician.Code})"
        //    });
        //    StatusText = "Record Saved";

        //    var result = MessageBox.Show("Car saved successfully.\nDo you want to add another technician?", "SAVE", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
        //    if (result == DialogResult.Yes) btnNew.PerformClick();
        //    else ViewRecord(newTechnician);
        //}

        //private void UpdateRecord(Car technician, Car newTechnician)
        //{
        //    technician.VsRange = newTechnician.VsRange;
        //    technician.Institute = newTechnician.Institute;
        //    technician.Name = newTechnician.Name;
        //    technician.NicNo = newTechnician.NicNo;
        //    technician.PhoneNo = newTechnician.PhoneNo;
        //    technician.IssuedDate = newTechnician.IssuedDate;
        //    technician.Type = newTechnician.Type;
        //    technician.Status = newTechnician.Status;
        //    technician.Notes = newTechnician.Notes;
        //    technician.ModifiedOn = DateTime.Now;
        //    technician.ModifiedBy = User;

        //    WriteLog.Invoke(new Log()
        //    {
        //        Time = DateTime.Now,
        //        User = User,
        //        Title = "Car",
        //        Action = LogAction.Update,
        //        Text =$"Updated a technician (#{newTechnician.Code})"
        //    });
        //    StatusText = "Record Updated";

        //    MessageBox.Show("Car updated successfully.", "UPDATE", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    ViewRecord(technician);
        //}
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
