using ABC.CarTraders.Entities;
using ABC.CarTraders.Enums;
using MRG.Controls.UI;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ABC.CarTraders.GUI.Forms
{
    public partial class UserForm : Form
    {
        #region Common
        public AppDbContext DbContext { get { return DashboardForm.DbContext; } }
        public Action<Log> WriteLog { get { return DashboardForm.WriteLog; } }
        public Func<Task> SaveToDatabase { get { return DashboardForm.SaveToDatabaseAsync; } }
        public User User { get { return DashboardForm.User; } }
        #endregion

        #region Form
        public UserForm()
        {
            InitializeComponent();
            rdoMale.Tag = Sex.Male;
            rdoFemale.Tag = Sex.Female;

            cboRole.DataSource = new List<UserRole>()
            {
                UserRole.Guest,
                UserRole.Customer,
                UserRole.Staff,
                UserRole.Admin,
            };

            cboPaymentMethod.DataSource = new List<PaymentMethod>()
            {
                Enums.PaymentMethod.Cash,
                Enums.PaymentMethod.CreditCard,
                Enums.PaymentMethod.BankTransfer,
            };

            Email = null;
            Password = null;
            FullName = null;
            Sex = Sex.Male;
            PhoneNo = null;
            Role = UserRole.Guest;
            Address = null;
            DateOfBirth = null;
            PaymentMethod = null;
            Image = null;
            Notes = null;
        }

        public void LoadInitialData()
        {
            //cboVsRange.DataSource = UnitOfWork.VsRanges.GetAllCached().OrderBy(vsr => vsr.Name).ToList();
        }

        public void NewRecord()
        {
            Overwrite = false;

            btnSave.Text = "SAVE";
            OldRecord = null;
            Text = $"New {nameof(User)}";
            StatusText = "Ready";

            Email = null;
            Password = null;
            FullName = null;
            Sex = Sex.Male;
            PhoneNo = null;
            Role = UserRole.Guest;
            Address = null;
            DateOfBirth = null;
            PaymentMethod = null;
            Image = null;
            Notes = null;

            pnlEMail.Enabled = true;
            pnlRole.Enabled = true;
            btnPassword.Enabled = ValidateInsertPersmission();
            btnSave.Enabled = ValidateInsertPersmission();
            txtEMail.Focus();
        }

        public void Register()
        {
            Overwrite = false;

            btnSave.Text = "REGISTER";
            OldRecord = null;
            Text = $"New {nameof(User)}";
            StatusText = "Ready";

            Email = null;
            Password = null;
            FullName = null;
            Sex = Sex.Male;
            PhoneNo = null;
            Role = UserRole.Customer;
            Address = null;
            DateOfBirth = null;
            PaymentMethod = Enums.PaymentMethod.Cash;
            Image = null;
            Notes = null;

            pnlEMail.Enabled = true;
            pnlRole.Enabled = false;
            btnPassword.Enabled = true;
            btnSave.Enabled = true;
            txtEMail.Focus();
        }

        public User OldRecord { get; set; }
        public void ViewRecord(User record)
        {
            Overwrite = true;

            btnSave.Text = "UPDATE";
            OldRecord = record;
            Text = $"View {nameof(User)} ({OldRecord.Email})";
            StatusText = "Ready";

            Email = OldRecord.Email;
            Password = OldRecord.Password;
            FullName = OldRecord.FullName;
            Sex = OldRecord.Sex;
            PhoneNo = OldRecord.PhoneNo;
            Role = OldRecord.Role;
            Address = OldRecord.Address;
            DateOfBirth = OldRecord.DateOfBirth;
            PaymentMethod = OldRecord.PaymentMethod;
            Image = OldRecord.Image;
            Notes = OldRecord.Notes;

            pnlEMail.Enabled = false;
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
                var str = txtEMail.Text.Trim();
                return str == string.Empty ? null : str;
            }
            set { txtEMail.Text = value; }
        }

        public string Password { get; set; }

        private void btnPassword_Click(object sender, EventArgs e)
        {
            if (!ValidateUpdatePersmission()) return;

            using (var form = new PasswordForm())
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    Password = User.GetHashSha1(form.Password2);
                }
            }
        }

        public string FullName
        {
            get
            {
                var str = txtFullName.Text.Trim();
                return str == string.Empty ? null : str;
            }
            set { txtFullName.Text = value; }
        }

        public Sex Sex
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

        public string PhoneNo
        {
            get
            {
                var str = txtPhoneNo.Text.Trim();
                return str == string.Empty ? null : str;
            }
            set { txtPhoneNo.Text = value; }
        }

        public UserRole Role
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

        public string Address
        {
            get
            {
                var str = txtAddress.Text.Trim();
                return str == string.Empty ? null : str;
            }
            set { txtAddress.Text = value; }
        }

        public DateTime? DateOfBirth
        {
            get
            {
                return dtpDateOfBirth.Value;
            }
            set { dtpDateOfBirth.Value = value ?? DateTime.Now; }
        }

        public PaymentMethod? PaymentMethod
        {
            get
            {
                return (PaymentMethod)cboPaymentMethod.SelectedItem;
            }
            set
            {
                cboPaymentMethod.SelectedItem = value;
            }
        }

        public byte[] Image
        {
            get
            {
                if (picImage.Image != null)
                {
                    return Helper.GetImageBytesFromPictureBox(picImage);
                }
                var filePath = txtImagePath.Text;
                if (string.IsNullOrWhiteSpace(filePath))
                {
                    return null;
                }
                return File.ReadAllBytes(filePath);
            }
            set
            {
                if (value != null)
                {
                    picImage.Image = Helper.LoadImageFromDatabase(value);
                }
                else
                {
                    picImage.Image = null; // No image available
                }
            }
        }

        public string Notes
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
                Email = Email,
                Password = Password,
                FullName = FullName,
                Sex = Sex,
                PhoneNo = PhoneNo,
                Role = UserRole.Guest,
                Address = Address,
                DateOfBirth = DateOfBirth,
                PaymentMethod = PaymentMethod,
                Image = Image,
                Notes = Notes,
                CreatedDate = DateTime.Now,
            };

            if (Overwrite)
            {
                if (!ValidateUpdatePersmission()) return;
                UpdateRecordAsync(OldRecord, newUser);
            }
            else
            {
                if (!ValidateInsertPersmission()) return;
                if (await ValidateKeyAsync())
                {
                    StartProgress("Registering...");
                    await AddRecordAsync(newUser);
                }
            }
            StopProgress();
        }

        private bool ValidateInsertPersmission()
        {
            return (User == null || User.Role <= UserRole.Admin);
        }

        private bool ValidateUpdatePersmission()
        {
            //return (User.Role <= UserRole.Admin) ||
            //(User == OldRecord);
            return true;
        }

        private bool ValidateInput()
        {
            if (Email == null || !Helper.IsValidEmail(Email))
            {
                txtEMail.Focus();
                return false;
            }

            if (FullName == null)
            {
                txtFullName.Focus();
                return false;
            }

            if (Password == null)
            {
                btnPassword.PerformClick();
                if(Password == null) return false;
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
                    StartProgress("Checking Email...");
                    var tmp = await DbContext.Users.FirstOrDefaultAsync(x => x.Email == Email);
                    StopProgress();
                    if (tmp != null)
                    {
                        StatusText = "Email Exists";
                        MessageBox.Show($"Email {Email} already exists. Please try again with a different Email.", "DUPLICATE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtEMail.Focus();
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
        private async Task AddRecordAsync(User newUser)
        {
            DbContext.Users.Add(newUser);
            WriteLog.Invoke(new Log()
            {
                CreatedDate = DateTime.Now,
                CreatedUserId = User?.Id,
                Title = "User",
                Action = LogAction.Insert,
                Text = $"Registered a user ({newUser.Email})"
            });
            try
            {
                var entries = DbContext.ChangeTracker.Entries(); //remove
                await DbContext.SaveChangesAsync();
                StatusText = "Record Saved";

                MessageBox.Show("Registration was saved successfully. Please login.", "SAVE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
            catch (Exception ex)
            {
                StopProgress();
                StatusText = "Error Occurred";
                MessageBox.Show($"An error occurred while retrieving data from the Database.\n{ex.Message}\nPlease try again.", "ERROR", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            }
            //if (result == DialogResult.Yes) btnNew.PerformClick();
            //else ViewRecord(newUser);
        }

        private async Task UpdateRecordAsync(User user, User newUser)
        {
            user.Password = newUser.Password;
            user.FullName = newUser.FullName;
            user.Sex = newUser.Sex;
            user.PhoneNo = newUser.PhoneNo;
            user.Role = newUser.Role;
            user.Address = newUser.Address;
            user.DateOfBirth = newUser.DateOfBirth;
            user.PaymentMethod = newUser.PaymentMethod;
            user.Image = newUser.Image;
            user.Notes = newUser.Notes;
            user.LastModifiedDate = DateTime.Now;
            user.LastModifiedUser = User;

            WriteLog.Invoke(new Log()
            {
                CreatedDate = DateTime.Now,
                CreatedUserId = User?.Id,
                Title = "User",
                Action = LogAction.Update,
                Text = $"Updated a user (#{newUser.Email})"
            });
            StatusText = "Record Updated";
            await DbContext.SaveChangesAsync();
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
            //if (e.Control)
            //{
            //    switch (e.KeyCode)
            //    {
            //        case Keys.S:
            //            if (e.Shift) btnToDatabase.PerformClick();
            //            else btnSave.PerformClick();
            //            e.SuppressKeyPress = true;
            //            break;
            //        case Keys.N:
            //            btnNew.PerformClick();
            //            e.SuppressKeyPress = true;
            //            break;
            //    }
            //}
        }

        private void btnBrowseImage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Get the file path
                    txtImagePath.Text = openFileDialog.FileName;

                    // Display the image in the PictureBox
                    picImage.Image = System.Drawing.Image.FromFile(txtImagePath.Text);

                    //// Convert the image to byte array and store in the CarPicture property
                    //byte[] imageBytes = File.ReadAllBytes(filePath);

                    //// Assuming you have a Car object called car
                    //car.CarPicture = imageBytes;
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtImagePath.Text = null;
            picImage.Image = null;
        }
    }
}
