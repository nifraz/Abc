using ABC.CarTraders.Core;
using ABC.CarTraders.Core.Domain;
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
    public partial class VsRangeForm : Form
    {
        #region Common
        public IUnitOfWork UnitOfWork { get { return DashboardForm.UnitOfWork; } }
        public Action<Log> WriteLog { get { return DashboardForm.WriteLog; } }
        public Func<Task> SaveToDatabase { get { return DashboardForm.SaveToDatabaseAsync; } }
        public User User { get { return DashboardForm.User; } }
        #endregion

        #region Form
        public VsRangeForm()
        {
            InitializeComponent();
            pnlLoadingCircle.Controls.Add(LoadingCircle);

            VsRangeDistrict = null;
            VsRangeCode = 1101;
            VsRangeName = null;
            VsRangeNotes = null;

            //btnNew.Focus();
        }

        public void NewRecord()
        {
            Overwrite = false;

            OldVsRange = null;
            Text = "New VS Range";
            StatusText = "Ready";

            VsRangeName = null;
            VsRangeNotes = null;

            pnlDistrict.Enabled = true;
            pnlVsCode.Enabled = true;
            btnLastCode.Enabled = true;
            btnSave.Enabled = ValidateInsertPersmission();
            nudCode.Focus();
        }

        public VsRange OldVsRange { get; set; }
        public void ViewRecord(VsRange vsRange)
        {
            Overwrite = true;

            OldVsRange = vsRange;
            Text = $"View VS Range #{OldVsRange.Code}";
            StatusText = "Ready";

            VsRangeProvince = OldVsRange.Province;
            VsRangeDistrict = OldVsRange.District;
            VsRangeCode = OldVsRange.Code;
            VsRangeName = OldVsRange.Name;
            VsRangeNotes = OldVsRange.Notes;

            //pnlProvince.Enabled = false;
            //pnlDistrict.Enabled = false;
            //pnlVsCode.Enabled = false;
            //btnLastCode.Enabled = false;
            btnSave.Enabled = ValidateUpdatePersmission();
            txtName.Focus();
        }

        public void LoadInitialData()
        {
            cboProvince.SelectedValueChanged -= cboProvince_SelectedValueChanged;
            cboDistrict.SelectedValueChanged -= cboDistrict_SelectedValueChanged;

            var provinces = new List<string>() { "All" };
            provinces.AddRange(UnitOfWork.Provinces.GetAllCached().OrderBy(p => p.Name).Select(p => p.Name));
            cboProvince.DataSource = provinces;

            var districts = new List<string>() { "All" };
            districts.AddRange(UnitOfWork.Districts.GetAllCached().OrderBy(d => d.Name).Select(d => d.Name));
            cboDistrict.DataSource = districts;

            cboProvince.SelectedValueChanged += cboProvince_SelectedValueChanged;
            cboDistrict.SelectedValueChanged += cboDistrict_SelectedValueChanged;
        }

        private void VsRangeForm_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
        #endregion

        #region Fields
        private Province VsRangeProvince
        {
            get
            {
                if (cboProvince.Text != "All")
                {
                    return UnitOfWork.Provinces.GetAllCached().SingleOrDefault(p => p.Name == cboProvince.Text);
                }
                return null;
            }
            set
            {
                cboProvince.SelectedValueChanged -= cboProvince_SelectedValueChanged;
                cboProvince.SelectedItem = value == null ? "All" : value.ToString();
                cboProvince.SelectedValueChanged += cboProvince_SelectedValueChanged;
            }
        }
        private void cboProvince_SelectedValueChanged(object sender, EventArgs e)
        {
            if (UnitOfWork == null) return;
            var districts = new List<string>() { "All" };
            if (cboProvince.Text.Equals("All"))
            {
                districts.AddRange(UnitOfWork.Districts.GetAllCached().OrderBy(d => d.Name).Select(d => d.Name));
            }
            else
            {
                districts.AddRange(UnitOfWork.Districts.GetAllCached().Where(d => d.Province.Name.Equals(cboProvince.Text)).OrderBy(d => d.Name).Select(d => d.Name));
            }

            cboDistrict.DataSource = districts;
        }

        private District VsRangeDistrict
        {
            get
            {
                if (cboDistrict.Text != "All")
                {
                    return UnitOfWork.Districts.GetAllCached().SingleOrDefault(d => d.Name == cboDistrict.Text);
                }
                return null;
            }
            set
            {
                cboDistrict.SelectedValueChanged -= cboDistrict_SelectedValueChanged;
                cboDistrict.SelectedItem = value == null ? "All" : value.ToString();
                cboDistrict.SelectedValueChanged += cboDistrict_SelectedValueChanged;
            }
        }
        private void cboDistrict_SelectedValueChanged(object sender, EventArgs e)
        {
            if (UnitOfWork == null) return;
            var vsRanges = new List<string>() { "All" };
            if (cboDistrict.Text.Equals("All"))
            {
                if (cboProvince.Text.Equals("All"))
                {
                    vsRanges.AddRange(UnitOfWork.VsRanges.GetAllCached().OrderBy(vsr => vsr.Name).Select(vsr => vsr.Name));
                }
                else
                {
                    vsRanges.AddRange(UnitOfWork.VsRanges.GetAllCached().Where(vsr => vsr.Province.Name.Equals(cboProvince.Text)).OrderBy(vsr => vsr.Name).Select(vsr => vsr.Name));
                }
            }
            else
            {
                vsRanges.AddRange(UnitOfWork.VsRanges.GetAllCached().Where(vsr => vsr.District.Name.Equals(cboDistrict.Text)).OrderBy(vsr => vsr.Name).Select(vsr => vsr.Name));
            }

            SetVsCode();
        }

        public byte ProvinceNo
        {
            get { return (byte)(VsRangeCode / 1000); }
        }

        public byte ProvinceCode
        {
            get { return (byte)(VsRangeCode / 1000); }
        }

        public byte DistrictNo
        {
            get { return (byte)((VsRangeCode / 100) % 10); }
        }

        public byte DistrictCode
        {
            get { return (byte)((VsRangeCode / 100)); }
        }

        public byte VsRangeNo
        {
            get { return (byte)(VsRangeCode % 100); }
            set { VsRangeCode = (DistrictCode * 100) + value; }
        }

        public int VsRangeCode
        {
            get { return (int)nudCode.Value; }
            set { nudCode.Value = value; }
        }

        private void SetVsCode()
        {
            var no = VsRangeNo;
            if (VsRangeDistrict != default)
            {
                nudCode.Minimum = ((VsRangeDistrict.Code * 100) + 1);
                nudCode.Maximum = ((VsRangeDistrict.Code * 100) + 99);
            }
            else
            {
                if (VsRangeProvince == default)
                {
                    nudCode.Minimum = 1001;
                    nudCode.Maximum = 9999;
                }
                else
                {
                    nudCode.Minimum = ((VsRangeProvince.Code * 1000) + 1);
                    nudCode.Maximum = ((VsRangeProvince.Code * 1000) + 999);
                }
            }

            VsRangeNo = no;
        }

        private async void btnFind_Click(object sender, EventArgs e)
        {
            var vsRange = await UnitOfWork.VsRanges.GetAsync(VsRangeDistrict.Province.No, VsRangeDistrict.No, VsRangeNo);
            if (vsRange != default)
            {
                ViewRecord(vsRange);
            }
            else
            {
                MessageBox.Show($"VS Code {VsRangeCode} does not exist in the Database.", "NOT FOUND", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private async Task<int> FindAsync()
        {
            var result = DialogResult.Retry;
            while (result == DialogResult.Retry)
            {
                try
                {
                    StartProgress("Getting Code...");
                    var n = await UnitOfWork.VsRanges.GetMaxNoAsync(VsRangeDistrict);
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

        private async void btnLastCode_Click(object sender, EventArgs e)
        {
            var n = await GetLastKeyRecordAsync();
            StopProgress();

            VsRangeNo = n == 0 ? (byte)1 : (byte)n;
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
                    var n = await UnitOfWork.VsRanges.GetMaxNoAsync(VsRangeDistrict);
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

        public string VsRangeName
        {
            get
            {
                var str = txtName.Text.Trim();
                return str == string.Empty ? null : str;
            }
            set { txtName.Text = value; }
        }
        public string VsRangeNotes
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
                MessageBox.Show("Data validation failed and the VS Range cannot be saved.\nPlease check for invalid / empty data.", "VALIDATE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (!await ValidateVsCodeAsync())
            {
                StatusText = "Data Required";
                MessageBox.Show("Invalid VS Code.", "VALIDATE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                nudCode.Focus();
                return;
            }

            var newVsRange = new VsRange()
            {
                ProvinceNo = ProvinceNo,
                DistrictNo = DistrictNo,
                No = VsRangeNo,
                Name = VsRangeName,
                Notes = VsRangeNotes,
                CreatedOn = DateTime.Now,
                CreatedBy = User
            };

            if (Overwrite)
            {
                if (!ValidateUpdatePersmission()) return;
                if (OldVsRange.Code != VsRangeCode)
                {
                    MessageBox.Show("You cannot change the VS Code of an existing VS Range!\nThis operation is disabled to protect data integrity.", "CAUTION", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                if (await ValidateNameAsync())
                {
                    UpdateRecord(OldVsRange, newVsRange);
                }
            }
            else
            {
                if (!ValidateInsertPersmission()) return;
                if (await ValidateKeyAsync() && await ValidateNameAsync())
                {
                    AddRecord(newVsRange);
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
                (User == OldVsRange?.CreatedBy);
        }

        private bool ValidateInput()
        {
            if (VsRangeName == null)
            {
                txtName.Focus();
                return false;
            }
            return true;
        }

        private async Task<bool> ValidateVsCodeAsync()
        {
            return await UnitOfWork.Districts.GetAsync(ProvinceNo, DistrictNo) != default;
        }

        private async Task<bool> ValidateKeyAsync()
        {
            var result = DialogResult.Retry;
            while (result == DialogResult.Retry)
            {
                try
                {
                    StartProgress("Checking Key...");
                    var tmp = await UnitOfWork.VsRanges.GetAsync(VsRangeDistrict.Province.No, VsRangeDistrict.No, VsRangeNo);
                    if (tmp != null)
                    {
                        StopProgress();
                        StatusText = "Key Exists";
                        var option = MessageBox.Show($"VS Code {VsRangeCode} already exists (saved for VS Range {tmp.Name}). Do you want to view that record? Or please try a different Code.", "DUPLICATE", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
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

        private async Task<bool> ValidateNameAsync()
        {
            var result = DialogResult.Retry;
            while (result == DialogResult.Retry)
            {
                try
                {
                    StartProgress("Checking Name...");
                    var tmp = await UnitOfWork.VsRanges.FindAsync(vsr => vsr.Name.Equals(VsRangeName));
                    StopProgress();
                    if (tmp != null && tmp != OldVsRange)
                    {
                        StatusText = "Name Exists";
                        var option = MessageBox.Show($"VS Name {VsRangeName} already exists. Do you want to view that record? Or please try a different name.", "DUPLICATE", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
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
        private void AddRecord(VsRange newVsRange)
        {
            UnitOfWork.VsRanges.Add(newVsRange);
            WriteLog.Invoke(new Log()
            {
                Time = DateTime.Now,
                User = User,
                Title = "VS Range",
                Action = LogAction.Insert,
                Text = $"Added a vs range (#{newVsRange.Code})"
            });
            StatusText = "Record Saved";

            var result = MessageBox.Show("VS Range saved successfully.\nDo you want to add another VS Range?", "SAVE", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result == DialogResult.Yes) btnNew.PerformClick();
            else ViewRecord(newVsRange);
        }

        private void UpdateRecord(VsRange vsRange, VsRange newVsRange)
        {
            vsRange.Name = newVsRange.Name;
            vsRange.Notes = newVsRange.Notes;
            vsRange.ModifiedOn = DateTime.Now;
            vsRange.ModifiedBy = User;

            WriteLog.Invoke(new Log()
            {
                Time = DateTime.Now,
                User = User,
                Title = "VS Range",
                Action = LogAction.Update,
                Text = $"Updated a vs range (#{newVsRange.Code})"
            });
            StatusText = "Record Updated";

            MessageBox.Show("VS Range updated successfully.", "UPDATE", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ViewRecord(vsRange);
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

        private void VsRangeForm_KeyDown(object sender, KeyEventArgs e)
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

        //private VsRange TempVsRage { get; set; }
        //private void SaveIfChanged()
        //{
        //    if (Changed)
        //    {
        //        var option = MessageBox.Show("Accept Changes?", "CONFIRM", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
        //        if (option == DialogResult.Yes)
        //        {
        //            btnSave.PerformClick();
        //        }
        //    }
        //}
        //private bool Changed
        //{
        //    get
        //    {
        //        if (Overwrite)
        //        {
        //            return
        //                (!VsRangeName.Equals(VsRange.Name)) ||
        //                (!VsRangeNotes.Equals(VsRange.Notes));
        //        }
        //        else
        //        {
        //            return
        //                (!VsRangeDistrict.Equals(TempVsRage.District)) ||
        //                (!VsRangeNo.Equals(TempVsRage.No)) ||
        //                (!VsRangeName.Equals(TempVsRage.Name)) ||
        //                (!VsRangeNotes.Equals(TempVsRage.Notes));
        //        }
        //    }
        //}


    }
}
