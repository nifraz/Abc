using ABC.CarTraders.Entities;
using ABC.CarTraders.Enums;
using MRG.Controls.UI;
using System;
using System.Data.Entity;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ABC.CarTraders.GUI.Forms
{
    public partial class CarPartForm : Form
    {
        #region Common
        public AppDbContext DbContext { get { return DashboardForm.DbContext; } }
        public Action<Log> WriteLog { get { return DashboardForm.WriteLog; } }
        public Func<Task> SaveToDatabase { get { return DashboardForm.SaveToDatabaseAsync; } }
        public User User { get { return DashboardForm.User; } }
        #endregion

        #region Form
        public CarPartForm()
        {
            InitializeComponent();

            //cboType.DataSource = new List<CarType>()
            //{
            //    CarType.Sedan,
            //    CarType.SUV,
            //    CarType.Truck,
            //    CarType.Coupe,
            //    CarType.Convertible,
            //    CarType.Hatchback,
            //};

            PartName = null;
            Price = 0.00M;
            Stock = 1;
            Image = null;
            Notes = null;
        }

        public async Task LoadInitialDataAsync()
        {
            cboCar.DataSource = await DbContext.Cars
                .ToListAsync();
        }

        public void NewRecord()
        {
            Overwrite = false;

            btnSave.Text = "SAVE";
            OldRecord = null;
            Text = $"New {nameof(CarPart)}";
            StatusText = "Ready";

            PartName = null;
            Price = 0.00M;
            Stock = 1;
            Image = null;
            Notes = null;

            pnlRole.Enabled = true;
            btnSave.Enabled = ValidateInsertPersmission();
            txtPartName.Focus();
        }

        public CarPart OldRecord { get; set; }
        public void ViewRecord(CarPart record)
        {
            Overwrite = true;

            btnSave.Text = "UPDATE";
            OldRecord = record;
            Text = $"View {nameof(CarPart)} ({OldRecord.PartName})";
            StatusText = "Ready";

            PartName = OldRecord.PartName;
            Price = OldRecord.Price;
            Stock = OldRecord.Stock;
            Image = OldRecord.Image;
            Notes = OldRecord.Notes;

            btnSave.Enabled = ValidateUpdatePersmission();
        }

        private void UserForm_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
        #endregion

        #region Fields
        public string PartName
        {
            get
            {
                var str = txtPartName.Text.Trim();
                return str == string.Empty ? null : str;
            }
            set { txtPartName.Text = value; }
        }

        public decimal Price
        {
            get
            {
                return nudPrice.Value;
            }
            set { nudPrice.Value = value; }
        }

        public int Stock
        {
            get
            {
                return (int)nudStock.Value;
            }
            set { nudStock.Value = value; }
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
                MessageBox.Show("Data validation failed and the record cannot be saved.\nPlease check for invalid / empty data.", "VALIDATE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var newRecord = new CarPart()
            {
                PartName = PartName,
                Price = Price,
                Stock = Stock,
                Image = Image,
                Notes = Notes,
                CreatedDate = DateTime.Now,
            };

            if (Overwrite)
            {
                if (!ValidateUpdatePersmission()) return;
                await UpdateRecordAsync(OldRecord, newRecord);
            }
            else
            {
                if (!ValidateInsertPersmission()) return;
                StartProgress("Saving...");
                await AddRecordAsync(newRecord);
            }
            StopProgress();
        }

        private bool ValidateInsertPersmission()
        {
            return (User == null || User.Role >= UserRole.Staff);
        }

        private bool ValidateUpdatePersmission()
        {
            return (User == null || User.Role >= UserRole.Staff);
        }

        private bool ValidateInput()
        {
            if (PartName == null)
            {
                txtPartName.Focus();
                return false;
            }

            return true;
        }

        public bool Overwrite { get; set; }
        private async Task AddRecordAsync(CarPart newRecord)
        {
            DbContext.CarParts.Add(newRecord);
            WriteLog.Invoke(new Log()
            {
                CreatedDate = DateTime.Now,
                CreatedUserId = User?.Id,
                Title = "CarPart",
                Action = LogAction.Insert,
                Text = $"Saved a car part ({newRecord.PartName})"
            });
            try
            {
                await DbContext.SaveChangesAsync();
                StatusText = "Record Saved";

                MessageBox.Show("CarPart saved successfully..", "SAVE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ViewRecord(newRecord);
            }
            catch (Exception ex)
            {
                StopProgress();
                StatusText = "Error Occurred";
                MessageBox.Show($"An error occurred while saving the record.\n{ex.Message}\nPlease try again.", "ERROR", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            }
            //if (result == DialogResult.Yes) btnNew.PerformClick();
            //else ViewRecord(newUser);
        }

        private async Task UpdateRecordAsync(CarPart record, CarPart newRecord)
        {
            record.PartName = newRecord.PartName;
            record.Price = newRecord.Price;
            record.Stock = newRecord.Stock;
            record.Image = newRecord.Image;
            record.Notes = newRecord.Notes;
            record.LastModifiedDate = DateTime.Now;
            record.LastModifiedUserId = User?.Id;

            WriteLog.Invoke(new Log()
            {
                CreatedDate = DateTime.Now,
                CreatedUserId = User?.Id,
                Title = "CarPart",
                Action = LogAction.Update,
                Text = $"Updated a car part ({newRecord.PartName})"
            });
            StatusText = "Record Updated";
            await DbContext.SaveChangesAsync();
            MessageBox.Show("CarPart updated successfully.", "UPDATE", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ViewRecord(record);
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
