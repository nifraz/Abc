using ABC.CarTraders.Entities;
using ABC.CarTraders.Enums;
using MRG.Controls.UI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ABC.CarTraders.GUI.Forms
{
    public partial class ShoppingCartForm : Form
    {
        #region Common
        public AppDbContext DbContext { get { return DashboardForm.DbContext; } }
        public Action<Log> WriteLog { get { return DashboardForm.WriteLog; } }
        public Func<Task> SaveToDatabase { get { return DashboardForm.SaveToDatabaseAsync; } }
        public User User { get { return DashboardForm.User; } }
        #endregion

        #region Form
        public ShoppingCartForm()
        {
            InitializeComponent();

            cboType.DataSource = new List<CarType>()
            {
                CarType.Sedan,
                CarType.SUV,
                CarType.Truck,
                CarType.Coupe,
                CarType.Convertible,
                CarType.Hatchback,
            };

            ModelName = null;
            Price = 0.00M;
            Year = 2024;
            Type = CarType.Sedan;
            EngineDetails = null;
            Color = "Black";
            Stock = 1;
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
            Text = $"New {nameof(Car)}";
            StatusText = "Ready";

            ModelName = null;
            Price = 0.00M;
            Year = 2024;
            Type = CarType.Sedan;
            EngineDetails = null;
            Color = "Black";
            Stock = 1;
            Image = null;
            Notes = null;

            pnlRole.Enabled = true;
            btnSave.Enabled = ValidateInsertPersmission();
            txtModelName.Focus();
        }

        public Car OldRecord { get; set; }
        public void ViewRecord(Car record)
        {
            Overwrite = true;

            btnSave.Text = "UPDATE";
            OldRecord = record;
            Text = $"View {nameof(Car)} ({OldRecord.ModelName})";
            StatusText = "Ready";

            ModelName = OldRecord.ModelName;
            Price = OldRecord.Price;
            Year = OldRecord.Year;
            Type = OldRecord.Type;
            EngineDetails = OldRecord.EngineDetails;
            Color = OldRecord.Color;
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
            get
            {
                return nudPrice.Value;
            }
            set { nudPrice.Value = value; }
        }

        public int Year
        {
            get
            {
                return (int)nudYear.Value;
            }
            set { nudYear.Value = value; }
        }

        public CarType Type
        {
            get
            {
                return (CarType)cboType.SelectedItem;
            }
            set
            {
                cboType.SelectedItem = value;
            }
        }

        public string EngineDetails
        {
            get
            {
                var str = txtEngineDetails.Text.Trim();
                return str == string.Empty ? null : str;
            }
            set { txtEngineDetails.Text = value; }
        }

        public string Color
        {
            get
            {
                var str = cboColor.Text.Trim();
                return str == string.Empty ? null : str;
            }
            set { cboColor.Text = value; }
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

            var newRecord = new Car()
            {
                ModelName = ModelName,
                Price = Price,
                Year = Year,
                Type = Type,
                EngineDetails = EngineDetails,
                Color = Color,
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
            if (ModelName == null)
            {
                txtModelName.Focus();
                return false;
            }

            return true;
        }

        public bool Overwrite { get; set; }
        private async Task AddRecordAsync(Car newRecord)
        {
            DbContext.Cars.Add(newRecord);
            WriteLog.Invoke(new Log()
            {
                CreatedDate = DateTime.Now,
                CreatedUserId = User?.Id,
                Title = "Car",
                Action = LogAction.Insert,
                Text = $"Saved a car ({newRecord.ModelName})"
            });
            try
            {
                await DbContext.SaveChangesAsync();
                StatusText = "Record Saved";

                MessageBox.Show("Car saved successfully..", "SAVE", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private async Task UpdateRecordAsync(Car record, Car newRecord)
        {
            record.ModelName = newRecord.ModelName;
            record.Price = newRecord.Price;
            record.Year = newRecord.Year;
            record.Type = newRecord.Type;
            record.EngineDetails = newRecord.EngineDetails;
            record.Color = newRecord.Color;
            record.Stock = newRecord.Stock;
            record.Image = newRecord.Image;
            record.Notes = newRecord.Notes;
            record.LastModifiedDate = DateTime.Now;
            record.LastModifiedUserId = User?.Id;

            WriteLog.Invoke(new Log()
            {
                CreatedDate = DateTime.Now,
                CreatedUserId = User?.Id,
                Title = "Car",
                Action = LogAction.Update,
                Text = $"Updated a car ({newRecord.ModelName})"
            });
            StatusText = "Record Updated";
            await DbContext.SaveChangesAsync();
            MessageBox.Show("Car updated successfully.", "UPDATE", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ViewRecord(record);
        }
        #endregion

        #region Progress
        public Stopwatch Stopwatch { get; set; } = new Stopwatch();
        public string StatusText { set { lblProgress.Text = $"      {value}"; } }
        public string ProgressText { get; set; }
        public LoadingCircle LoadingCircle { get; set; } = new LoadingCircle()
        {
            Color = System.Drawing.Color.Black,
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
