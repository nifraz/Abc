using ABC.CarTraders.Core.Domain;
using ABC.CarTraders.GUI.Sections;
using MRG.Controls.UI;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ABC.CarTraders.GUI.Forms
{
    public partial class DatabaseForm : Form
    {
        public User User { get { return DashboardForm.User; } }
        public DatabaseForm()
        {
            InitializeComponent();
            pnlLoadingCircle.Controls.Add(LoadingCircle);

            ServerIp = AppSettings.ServerIp;
            UserId = AppSettings.DbUserId;
            Password = AppSettings.DbPassword;

            btnSave.Enabled = ValidateUpdatePersmission();
        }

        #region Fields
        public string ServerIp
        {
            get
            {
                var str = txtServerIp.Text.Trim();
                return str == string.Empty ? null : str;
            }
            set { txtServerIp.Text = value; }
        }
        public int Port
        {
            get { return (int)nudPort.Value; }
            set { nudPort.Value = value; }
        }
        public string UserId
        {
            get
            {
                var str = txtUserId.Text.Trim();
                return str == string.Empty ? null : str;
            }
            set { txtUserId.Text = value; }
        }
        public string Password
        {
            get
            {
                var str = txtPassword.Text.Trim();
                return str == string.Empty ? null : str;
            }
            set { txtPassword.Text = value; }
        }
        public int Timeout
        {
            get { return (int)nudTimeout.Value; }
            set { nudTimeout.Value = value; }
        }
        #endregion

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
            {
                StatusText = "Data Required";
                MessageBox.Show("Data validation failed and cannot be saved.\nPlease check for invalid / empty data.", "VALIDATE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            } 

            AppSettings.ServerIp = ServerIp;
            AppSettings.DbUserId = UserId;
            AppSettings.DbPassword = Password;

            Close();
        }

        private bool ValidateUpdatePersmission()
        {
            return true;
        }

        private bool ValidateInput()
        {
            if (ServerIp == null)
            {
                txtServerIp.Focus();
                return false;
            }
            if (UserId == null)
            {
                txtUserId.Focus();
                return false;
            }
            if (Password == null)
            {
                txtPassword.Focus();
                return false;
            }
            return true;
        }

        private async void btnPing_Click(object sender, EventArgs e)
        {
            await PingServer();
        }

        public async Task PingServer()
        {
            var result = DialogResult.Retry;
            while (result == DialogResult.Retry)
            {
                try
                {
                    StartProgress($"Pinging Server {ServerIp}...");
                    await LoginSection.Ping(ServerIp, Timeout);
                    StopProgress();
                    StatusText = "Ping Succeeded";
                    MessageBox.Show($"Ping succeeded to server IP {ServerIp}.", "PING", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                }
                catch (Exception ex)
                {
                    StopProgress();
                    result = MessageBox.Show($"{ex.Message}\nDetails : {ex.InnerException?.Message}", "ERROR", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                    if (result == DialogResult.Cancel)
                    {
                        //revert
                    }
                }
            }
        }

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
            StatusText = $"Ready";
            Refresh();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }
        #endregion

        private void DatabaseForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control)
            {
                switch (e.KeyCode)
                {
                    case Keys.S:
                        btnSave.PerformClick();
                        e.SuppressKeyPress = true;
                        break;
                }
            }
        }
    }
}
