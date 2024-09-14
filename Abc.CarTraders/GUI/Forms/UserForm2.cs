using ABC.CarTraders.Entities;
using ABC.CarTraders.Enums;
using MRG.Controls.UI;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ABC.CarTraders.GUI.Forms
{
    public partial class UserForm2 : Form
    {
        #region Common
        public AppDbContext DbContext { get { return DashboardForm.DbContext; } }
        public Action<Log> WriteLog { get { return DashboardForm.WriteLog; } }
        public Func<Task> SaveToDatabase { get { return DashboardForm.SaveToDatabaseAsync; } }
        public User User { get { return DashboardForm.User; } }
        #endregion

        #region Form
        public UserForm2()
        {
            InitializeComponent();
            rdoMale.Tag = Sex.Male;
            rdoFemale.Tag = Sex.Female;

            cboRole.DataSource = new List<UserRole>()
            {
                UserRole.Admin,
                UserRole.Customer,
            };

            Email = null;
            UserPassword = null;
            UserName = null;
            UserEmail = null;
            UserPhoneNo = null;
            UserNotes = null;
        }

        public void LoadInitialData()
        {
            //cboVsRange.DataSource = UnitOfWork.VsRanges.GetAllCached().OrderBy(vsr => vsr.Name).ToList();
        }

        public void NewRecord()
        {
            Overwrite = false;

            OldUser = null;
            Text = "New User";
            StatusText = "Ready";

            Email = null;
            UserPassword = null;
            UserName = null;
            UserEmail = null;
            UserPhoneNo = null;
            UserNotes = null;

            pnlUsername.Enabled = true;
            btnPassword.Enabled = ValidateInsertPersmission();
            btnSave.Enabled = ValidateInsertPersmission();
            txtUsername.Focus();
        }

        public User OldUser { get; set; }
        public void ViewRecord(User user)
        {
            Overwrite = true;

            OldUser = user;
            Text = $"View User #{OldUser.Email}";
            StatusText = "Ready";

            //UserUsername = OldUser.Username;
            //UserPassword = OldUser.Password;
            //UserName = OldUser.Name;
            //UserSex = OldUser.Sex;
            UserEmail = OldUser.Email;
            UserPhoneNo = OldUser.PhoneNo;
            UserRole = OldUser.Role;
            UserNotes = OldUser.Notes;

            pnlUsername.Enabled = false;
            pnlRole.Enabled = User.Role <= UserRole.Admin;
            btnPassword.Enabled = ValidateUpdatePersmission();
            btnSave.Enabled = ValidateUpdatePersmission();
        }

        private void UserForm_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
        #endregion

        #region Fields
        public string Email
        {
            get
            {
                var str = txtUsername.Text.Trim();
                return str == string.Empty ? null : str;
            }
            set { txtUsername.Text = value; }
        }

        public string UserPassword { get; set; }

        private void btnPassword_Click(object sender, EventArgs e)
        {
            if (!ValidateUpdatePersmission()) return;

            using (var form = new PasswordForm())
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    UserPassword = User.GetHashSha1(form.Password2);
                }
            }
        }

        public string UserName
        {
            get
            {
                var str = txtName.Text.Trim();
                return str == string.Empty ? null : str;
            }
            set { txtName.Text = value; }
        }

        public Sex UserSex
        {
            get
            {
                var rdo = pnlSexHolder.Controls.OfType<RadioButton>().FirstOrDefault(x => x.Checked);
                return (Sex)rdo.Tag;
            }
            set
            {
                var rdo = pnlSexHolder.Controls.OfType<RadioButton>().FirstOrDefault(x => (Sex)x.Tag == value);
                rdo.Checked = true;
            }
        }

        public string UserEmail
        {
            get
            {
                var str = txtEMail.Text.Trim();
                return str == string.Empty ? null : str;
            }
            set { txtEMail.Text = value; }
        }

        public string UserPhoneNo
        {
            get
            {
                var str = txtPhoneNo.Text.Trim();
                return str == string.Empty ? null : str;
            }
            set { txtPhoneNo.Text = value; }
        }

        public UserRole UserRole
        {
            get
            {
                return (UserRole)cboRole.SelectedItem;
            }
            set
            {
                cboRole.SelectedItem = value;
            }
        }

        public string UserNotes
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
                MessageBox.Show("Data validation failed and the user cannot be saved.\nPlease check for invalid / empty data.", "VALIDATE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var newUser = new User()
            {
                //Username = UserUsername,
                //Password = UserPassword,
                //Name = UserName,
                //Sex = UserSex,
                //EMail = UserEmail,
                //PhoneNo = UserPhoneNo,
                //Role = UserRole,
                //Notes = UserNotes,
                //CreatedOn = DateTime.Now,
                //CreatedBy = User
            };

            if (Overwrite)
            {
                if (!ValidateUpdatePersmission()) return;
                UpdateRecord(OldUser, newUser);
            }
            else
            {
                if (!ValidateInsertPersmission()) return;
                if (await ValidateKeyAsync())
                {
                    AddRecord(newUser);
                }
            }
            StopProgress();
        }

        private bool ValidateInsertPersmission()
        {
            return (User.Role <= UserRole.Admin);
        }

        private bool ValidateUpdatePersmission()
        {
            return (User.Role <= UserRole.Admin) ||
                (User == OldUser);
        }

        private bool ValidateInput()
        {
            if (Email == null)
            {
                txtUsername.Focus();
                return false;
            }

            if (UserName == null)
            {
                txtName.Focus();
                return false;
            }

            if (UserPassword == null)
            {
                btnPassword.PerformClick();
                if(UserPassword == null) return false;
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
                    var tmp = await DbContext.Users.FirstOrDefaultAsync(x => x.Email == Email);
                    StopProgress();
                    if (tmp != null)
                    {
                        StatusText = "Key Exists";
                        var option = MessageBox.Show($"Email {Email} already exists. Do you want to view that record?", "DUPLICATE", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (option == DialogResult.Yes)
                        {
                            ViewRecord(tmp);
                            StatusText = "Ready";
                        }
                        else
                        {
                            txtUsername.Focus();
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
        private void AddRecord(User newUser)
        {
            DbContext.Users.Add(newUser);
            WriteLog.Invoke(new Log()
            {
                CreatedDate = DateTime.Now,
                CreatedUser = User,
                Title = "User",
                Action = LogAction.Insert,
                Text = $"Added a user (#{newUser.Email})"
            });
            StatusText = "Record Saved";

            var result = MessageBox.Show("User saved successfully.\nDo you want to add another user?", "SAVE", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result == DialogResult.Yes) btnNew.PerformClick();
            else ViewRecord(newUser);
        }

        private void UpdateRecord(User user, User newUser)
        {
            user.Password = newUser.Password;
            //user.Name = newUser.Name;
            //user.Sex = newUser.Sex;
            user.Email = newUser.Email;
            user.PhoneNo = newUser.PhoneNo;
            user.Role = newUser.Role;
            user.Notes = newUser.Notes;
            user.LastModifiedDate = DateTime.Now;
            user.LastModifiedUser = User;

            WriteLog.Invoke(new Log()
            {
                CreatedDate = DateTime.Now,
                CreatedUser = User,
                Title = "User",
                Action = LogAction.Update,
                Text = $"Updated a user (#{newUser.Email})"
            });
            StatusText = "Record Updated";

            MessageBox.Show("User updated successfully.", "UPDATE", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ViewRecord(user);
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

        private void UserForm_KeyDown(object sender, KeyEventArgs e)
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
