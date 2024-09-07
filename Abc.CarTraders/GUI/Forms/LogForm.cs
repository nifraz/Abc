using ABC.CarTraders.Core.Domain;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ABC.CarTraders.GUI.Forms
{
    public partial class LogForm : Form
    {
        #region Form
        public LogForm()
        {
            InitializeComponent();

            cboAction.DataSource = new List<LogAction>()
            {
                LogAction.Auth,
                LogAction.Select,
                LogAction.Insert,
                LogAction.Update,
                LogAction.Delete,
                LogAction.Save
            };

            LogId = null;
            LogUser = null;
            LogTime = DateTime.Today;
            LogTitle = null;
            LogAction = LogAction.Select;
            LogText = null;
        }

        public void LoadInitialData()
        {
            //cboVsRange.DataSource = UnitOfWork.VsRanges.GetAllCached().OrderBy(vsr => vsr.Name).ToList();
        }

        public void NewRecord()
        {
            //Overwrite = false;

            OldLog = null;
            //TempVsRage = new VsRange
            //{
            //    District = VsRangeDistrict,
            //    No = VsRangeNo,
            //    Name = VsRangeName,
            //    Notes = VsRangeNotes
            //};
            Text = "New Log";
            //StatusText = "Ready";
            //toolTip1.SetToolTip(btnSave, "Add");

            //VsRangeName = null;
            //VsRangeNotes = null;

            //pnlDistrict.Enabled = true;
            //pnlVsCode.Enabled = true;
            //btnSetNewKey.Enabled = true;
            //btnSave.Enabled = ValidateInsertPersmission();
            //nudCode.Focus();
        }

        public Log OldLog { get; set; }
        public void ViewRecord(Log log)
        {
            //Overwrite = true;

            OldLog = log;
            Text = $"View Log #{OldLog.Id}";
            //toolTip1.SetToolTip(btnSave, "Update");

            LogId = OldLog.Id.ToString();
            LogUser = OldLog.Username;
            LogTime = OldLog.Time;
            LogTitle = OldLog.Title;
            LogAction = OldLog.Action;
            LogText = OldLog.Text;

            pnlId.Enabled = false;
            pnlUser.Enabled = false;
            pnlTime.Enabled = false;
            pnlTitle.Enabled = false;
            pnlAction.Enabled = false;
            pnlText.Enabled = false;

            //pnlDistrict.Enabled = false;
            //pnlVsCode.Enabled = false;
            //btnSetNewKey.Enabled = false;
            //btnSave.Enabled = ValidateUpdatePersmission();
            //btnNew.Focus();
        }

        private void LogForm_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
        #endregion

        #region Fields
        public string LogId
        {
            get
            {
                var str = txtId.Text.Trim();
                return str == string.Empty ? null : str;
            }
            set { txtId.Text = value; }
        }
        public string LogUser
        {
            get
            {
                var str = txtUser.Text.Trim();
                return str == string.Empty ? null : str;
            }
            set { txtUser.Text = value; }
        }
        public DateTime LogTime
        {
            get { return dtpTime.Value; }
            set { dtpTime.Value = value; }
        }
        public string LogTitle
        {
            get
            {
                var str = txtTitle.Text.Trim();
                return str == string.Empty ? null : str;
            }
            set { txtTitle.Text = value; }
        }
        public LogAction LogAction
        {
            get
            {
                return (LogAction)cboAction.SelectedItem;
            }
            set
            {
                cboAction.SelectedItem = value;
            }
        }
        public string LogText
        {
            get
            {
                var str = txtText.Text.Trim();
                return str == string.Empty ? null : str;
            }
            set { txtText.Text = value; }
        }
        #endregion
    }
}
