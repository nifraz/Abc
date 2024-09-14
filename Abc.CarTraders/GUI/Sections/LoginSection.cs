using ABC.CarTraders.Entities;
using ABC.CarTraders.GUI.Forms;
using Material.Styles;
using MRG.Controls.UI;
using System;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ABC.CarTraders.GUI.Sections
{
    public partial class LoginSection : UserControl, IColoredControl
    {//DbConcurrencyException
        #region Common
        public AppDbContext DbContext
        {
            get { return DashboardForm.DbContext; }
            set { DashboardForm.DbContext = value;}
        }
        
        //private Func<Log, Task> WriteLogAsync { get { return DashboardForm.WriteLogAsync; } }
        private Func<Task> LoginAsync { get { return DashboardForm.LoginAsync; } }
        private Action Exit { get { return DashboardForm.Exit; } }
        private Func<Task> RefreshAsync { get { return DashboardForm.RefreshAsync; } }
        public User User
        {
            get{ return DashboardForm.User; }
            set{ DashboardForm.User = value; }
        }
        private static string LastUsername
        {
            get { return AppSettings.LastUsername; }
            set { AppSettings.LastUsername = value; }
        }
        private string ServerIp
        {
            get { return AppSettings.ServerIp; }
            set { AppSettings.ServerIp = value; }
        }
        public int Port
        {
            get { return AppSettings.Port; }
            set { AppSettings.Port = value; }
        }

        private string DbUserId
        {
            get { return AppSettings.DbUserId; }
            set { AppSettings.DbUserId = value; }
        }
        private string DbPassword
        {
            get { return AppSettings.DbPassword; }
            set { AppSettings.DbPassword = value; }
        }
        public int ConnectionTimeout
        {
            get { return AppSettings.ConnectionTimeout; }
            set { AppSettings.ConnectionTimeout = value; }
        }

        #endregion

        #region Control
        public LoginSection()
        {
            InitializeComponent();
            pnlLoadingCircle.Controls.Add(LoadingCircle);
            ColorSchemeChanged += LoginSection_ColorSchemeChanged;
            ResetFields();
        }

        private ColorScheme _colorScheme;
        public ColorScheme ColorScheme
        {
            get { return _colorScheme; }
            set
            {
                _colorScheme = value;
                ColorSchemeChanged?.Invoke(this, value);
            }
        }

        public event EventHandler<ColorScheme> ColorSchemeChanged;

        private void LoginSection_ColorSchemeChanged(object sender, ColorScheme e)
        {
            if (e == null) return;

            BackColor = e.Color4;

            pnlMain.BackColor = e.Color9;
            pnlMainHolder.BackColor = e.Color1;

            pnlUsername.BackColor = e.Color3;
            pnlPassword.BackColor = e.Color3;

            // Buttons
            btnDatabaseSettings.BackColor = e.Color9;
            btnExit.BackColor = e.Color9;
            btnLogin.BackColor = e.Color2;
        }
        #endregion

        #region Fields
        private string Email
        {
            get
            {
                var str = txtEmail.Text.Trim();
                return str == string.Empty ? null : str;
            }
            set { txtEmail.Text = value; }
        }

        private string Password
        {
            get
            {
                var str = txtPassword.Text.Trim();
                return str == string.Empty ? null : str;
            }
            set { txtPassword.Text = value; }
        }

        private void LoginControl_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    e.SuppressKeyPress = true;
                    e.Handled = true;
                    btnLogin.PerformClick();
                    break;
                case Keys.Escape:
                    e.SuppressKeyPress = true;
                    e.Handled = true;
                    btnExit.PerformClick();
                    break;
            }
            
        }

        public void ResetFields()
        {
            Email = LastUsername;
            Password = string.Empty;
            LoginAttempts = 0;
            txtPassword.Focus();
        }
        #endregion

        #region Actions
        private void btnExit_Click(object sender, EventArgs e)
        {
            Exit?.Invoke();
        }
        private void btnDatabaseSettings_Click(object sender, EventArgs e)
        {
            using (var form = new DatabaseForm())
            {
                form.ShowDialog();
            }
        }

        public int LoginAttempts { get; set; } = 0;

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            if (!await PingServer()) return;

            if (!await InitializeAsync()) return;

            if (!await AuthenticateAsync(Email, Password)) return;

            await CacheLocalAsync();
            await RefreshDataAsync();

            StopProgress();

            LastUsername = Email;
            await LoginAsync?.Invoke();
            ResetFields();
        }

        public async Task<bool> PingServer()
        {
            var result = DialogResult.Retry;
            while (result == DialogResult.Retry)
            {
                try
                {
                    StartProgress($"Pinging Server {ServerIp}...");
                    await Ping(ServerIp, ConnectionTimeout);
                    return true;
                }
                catch (Exception ex)
                {
                    StopProgress();
                    StatusText = "Error Occurred";
                    result = MessageBox.Show($"{ex.Message}\nDetails : {ex.InnerException?.Message}", "ERROR", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);

                    if (result == DialogResult.Retry)
                    {
                        btnDatabaseSettings.PerformClick();
                    }
                }
            }
            StatusText = "Ready";
            return false;
        }

        public static async Task Ping(string server, int timeout)
        {
            using (var ping = new Ping())
            {
                var reply = await ping.SendPingAsync(server, timeout * 1000);
                if (reply.Status == IPStatus.Success)
                {
                    return;
                }
                throw new Exception($"Ping to the Server IP {server} failed.\nPing Status : {reply.Status}");
            }
        }

        private async Task<bool> InitializeAsync()
        {
            
            var result = DialogResult.Retry;
            while (result == DialogResult.Retry)
            {
                var connectionString = new SqlConnectionStringBuilder()
                {
                    DataSource = $"{ServerIp},{Port}",
                    InitialCatalog = "AbcCarTraders",
                    IntegratedSecurity = false,
                    MultipleActiveResultSets = true,
                    ApplicationName = "AbcCarTraders",
                    UserID = DbUserId,
                    Password = DbPassword,
                    ConnectTimeout = ConnectionTimeout
                }.ToString();
                DbContext = new AppDbContext(connectionString);

                try
                {
                    StartProgress("Initializing Connection...");
                    await Task.Run(() => DbContext.Users.FirstOrDefaultAsync(x => x.Id == 1));
                    return true;
                }
                catch (Exception ex)
                {
                    StopProgress();
                    StatusText = "Error Occurred";
                    result = MessageBox.Show($"An error occurred while initializing connection to the Database.\n{ex.Message}\nPlease try again.", "ERROR", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);

                    if (result == DialogResult.Retry)
                    {
                        btnDatabaseSettings.PerformClick();
                    }
                }
            }
            StatusText = "Ready";
            return false;
        }

        private async Task<bool> AuthenticateAsync(string email, string password)
        {
            var result = DialogResult.Retry;
            while (result == DialogResult.Retry)
            {
                try
                {
                    StartProgress("Authenticating...");
                    var hashedPassword = User.GetHashSha1(Password);
                    User = await DbContext.Users.FirstOrDefaultAsync(x => x.Email.Equals(Email) && x.Password.Equals(hashedPassword));

                    if (User != null) return true;

                    StopProgress();
                    MessageBox.Show($"Username or Password incorrect.\n({3-++LoginAttempts} attempts remaining)", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    if (LoginAttempts >= 3)
                    {
                        MessageBox.Show($"Too many failed login attempts, the program will exit now.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        btnExit.PerformClick();
                    }
                    txtPassword.Focus();
                    return false;
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

        private async Task<bool> CacheLocalAsync()
        {
            var result = DialogResult.Retry;
            while (result == DialogResult.Retry)
            {
                try
                {
                    StartProgress("Caching Local Data...");
                    //await DbContext.CacheLocalAsync();
                    //StopProgress();
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
        private async Task<bool> RefreshDataAsync()
        {
            var result = DialogResult.Retry;
            while (result == DialogResult.Retry)
            {
                try
                {
                    StartProgress("Refreshing Data...");
                    await RefreshAsync();
                    //StopProgress();
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
        private bool ValidateInput()
        {
            if (LastUsername == null)
            {
                StatusText = "Username Required";
                txtEmail.Focus();
                return false;
            }
            if (Password == null)
            {
                StatusText = "Password Required";
                txtPassword.Focus();
                return false;
            }
            return true;
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
            pnlMainHolder.Enabled = false;
        }

        private void StopProgress()
        {
            Stopwatch.Stop();
            pnlLoadingCircle.Visible = false;
            LoadingCircle.Active = false;
            timer1.Enabled = false;
            pnlMainHolder.Enabled = true;
            StatusText = $"Ready";
            Refresh();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            var elapsed = Stopwatch.Elapsed;
            StatusText = $"{ProgressText} ({elapsed.Minutes:00}:{elapsed.Seconds:00})";
            //btnLogin.Text = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", elapsed.Hours, elapsed.Minutes, elapsed.Seconds, elapsed.Milliseconds / 10);
        }
        #endregion

        private async void linkRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!await PingServer()) return;

            if (!await InitializeAsync()) return;

            using (var form = new UserForm())
            {
                form.LoadInitialData();
                form.Register();
                form.ShowDialog();
            }

            StopProgress();
        }
    }
}
