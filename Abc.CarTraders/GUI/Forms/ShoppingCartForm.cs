using ABC.CarTraders.Entities;
using ABC.CarTraders.Enums;
using DocumentFormat.OpenXml.Bibliography;
using DocumentFormat.OpenXml.ExtendedProperties;
using DocumentFormat.OpenXml.InkML;
using MRG.Controls.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
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
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DefaultCellStyle.SelectionBackColor = dataGridView1.DefaultCellStyle.BackColor;
            dataGridView1.DefaultCellStyle.SelectionForeColor = dataGridView1.DefaultCellStyle.ForeColor;

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
            Text = $"New {nameof(Order)}";
            StatusText = "Ready";
        }

        public void NewRecord(Order record)
        {
            Overwrite = false;

            lblCustomerName.Text = record.CreatedUser?.FullName;
            dataGridView1.DataSource = new BindingList<OrderItem>(record.OrderItems);
            lblGrandTotal.Text = record.OrderItems
                .Sum(x => x.TotalPrice)
                .ToString("N");

            btnSave.Text = "PLACE";
            OldRecord = record;
            Text = $"New {nameof(Order)}";
            StatusText = "Ready";
        }

        public Order OldRecord { get; set; }
        public void ViewRecord(Order record)
        {
            Overwrite = true;

            lblCustomerName.Text = record.CreatedUser?.FullName;
            dataGridView1.DataSource = new BindingList<OrderItem>(record.OrderItems);
            lblGrandTotal.Text = record.OrderItems
                .Sum(x => x.TotalPrice)
                .ToString("N");

            btnSave.Text = "UPDATE";
            OldRecord = record;
            Text = $"View {nameof(Order)}";
            StatusText = "Ready";

            btnSave.Enabled = ValidateUpdatePersmission();
        }

        private void UserForm_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
        #endregion

        #region Fields
        
        #endregion

        #region Actions

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
            {
                StatusText = "Data Required";
                MessageBox.Show("Data validation failed and the record cannot be saved.\nPlease check for invalid / empty data.", "VALIDATE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var newRecord = OldRecord;
            newRecord.CreatedUser = null;
            newRecord.CreatedDate = DateTime.Now;
            newRecord.CreatedUserId = User?.Id;
            newRecord.OrderItems.ForEach(x =>
            {
                x.Car = null;
                x.CarPart = null;
                x.CreatedUser = null;
            });
            newRecord.TotalPrice = newRecord.OrderItems
                .Sum(x => x.TotalPrice);

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
            return (User == null || User.Role >= UserRole.Customer);
        }

        private bool ValidateUpdatePersmission()
        {
            return (User == null || User.Role >= UserRole.Customer);
        }

        private bool ValidateInput()
        {
            //if (ModelName == null)
            //{
            //    txtModelName.Focus();
            //    return false;
            //}

            return true;
        }

        public bool Overwrite { get; set; }
        private async Task AddRecordAsync(Order newRecord)
        {
            DbContext.Orders.Add(newRecord);
            WriteLog.Invoke(new Log()
            {
                CreatedDate = DateTime.Now,
                CreatedUserId = User?.Id,
                Title = "Order",
                Action = LogAction.Insert,
                Text = $"Saved an order"
            });
            try
            {
                await DbContext.SaveChangesAsync();
                StatusText = "Record Saved";

                MessageBox.Show("Order saved successfully..", "SAVE", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private async Task UpdateRecordAsync(Order record, Order newRecord)
        {
            //record.ModelName = newRecord.ModelName;
            //record.Price = newRecord.Price;
            //record.Year = newRecord.Year;
            //record.Type = newRecord.Type;
            //record.EngineDetails = newRecord.EngineDetails;
            //record.Color = newRecord.Color;
            //record.Stock = newRecord.Stock;
            //record.Image = newRecord.Image;
            //record.Notes = newRecord.Notes;
            record.LastModifiedDate = DateTime.Now;
            record.LastModifiedUserId = User?.Id;

            WriteLog.Invoke(new Log()
            {
                CreatedDate = DateTime.Now,
                CreatedUserId = User?.Id,
                Title = "Order",
                Action = LogAction.Update,
                Text = $"Updated a order"
            });
            StatusText = "Record Updated";
            await DbContext.SaveChangesAsync();
            MessageBox.Show("Order updated successfully.", "UPDATE", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

    }
}
