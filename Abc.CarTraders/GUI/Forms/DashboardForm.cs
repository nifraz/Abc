using ABC.CarTraders.Entities;
using ABC.CarTraders.GUI.Sections;
using Material.Styles;
using MRG.Controls.UI;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ABC.CarTraders.GUI.Forms
{
    public partial class DashboardForm : Form, IColoredControl
    {
        public static AppDbContext DbContext { get; set; }
        public static User User { get; set; }

        public static IEnumerable<ColorScheme> ColorSchemes { get; set; } = new List<ColorScheme>()
        {
            ColorScheme.Red,
            ColorScheme.Pink,
            ColorScheme.Purple,
            ColorScheme.DeepPurple,
            ColorScheme.Indigo,
            ColorScheme.Blue,
            ColorScheme.LightBlue,
            ColorScheme.Cyan,
            ColorScheme.Teal,
            ColorScheme.Green,
            ColorScheme.LightGreen,
            ColorScheme.Lime,
            ColorScheme.Yellow,
            ColorScheme.Amber,
            ColorScheme.Orange,
            ColorScheme.DeepOrange,
            ColorScheme.Brown,
            ColorScheme.Grey,
            ColorScheme.BlueGrey
        }.OrderBy(clr => clr.Title);
        public static int ColorIndex
        {
            get { return AppSettings.ColorIndex; }
            set { AppSettings.ColorIndex = value; }
        }

        private Button CurrentButton { get; set; }
        private IColoredControl _currentControl;

        public DashboardForm()
        {
            InitializeComponent();
            pnlLoadingCircle.Controls.Add(LoadingCircle);

            AssignActions();
            tagRegionMetaData();

            CurrentButton = btnLogout;

            btnLogout.Click += (o, args) => LogoutAsync();
            btnLog.Click += (o, args) =>
            {
                //CurrentButton.BackColor = ColorScheme.Color9;
                pnlFooter.BackColor = ColorScheme.Color3;
                rtbOutput.BackColor = ColorScheme.Color3;
                lblTime.ForeColor = System.Drawing.Color.Black;
            };
            ColorSchemeChanged += DashboardForm_ColorSchemeChanged;
            ColorScheme = ColorSchemes.ElementAt(ColorIndex);

            timerClock_Tick(null, null);
            //rtbOutput.Text = "Department of Animal Production & Health\n";
            //rtbOutput.AppendText("========================================");
            rtbOutput.Clear();
            rtbOutput.AppendText($"[{DateTime.Now.ToLongDateString()}]");

            LogoutAsync();
            //btnCalendar.PerformClick();
        }

        private ColorScheme _colorScheme;

        public ColorScheme ColorScheme
        {
            get { return _colorScheme; }
            set
            {
                _colorScheme = value;
                toolTip1.SetToolTip(btnColorScheme, $"Color (Ctrl+D) : {ColorScheme.Title}");
                ColorSchemeChanged?.Invoke(this, value);
            }
        }

        public event EventHandler<ColorScheme> ColorSchemeChanged;

        private void DashboardForm_ColorSchemeChanged(object sender, ColorScheme scheme)
        {
            if(scheme == null) return;

            BackColor = scheme.Color3;
            pnlTop.BackColor = scheme.Color9;
            pnlSideBar.BackColor = scheme.Color9;
            pnlControlsHolder.BackColor = scheme.Color0;
            pnlFooter.BackColor = scheme.Color9;
            rtbOutput.BackColor = scheme.Color9;
            lblTime.ForeColor = System.Drawing.Color.White;

            statisticsSection1.ColorScheme = scheme;
            userSection1.ColorScheme = scheme;
            carSection1.ColorScheme = scheme;
            carPartSection1.ColorScheme = scheme;
            loginSection1.ColorScheme = scheme;
            logSection1.ColorScheme = scheme;

            // buttons
            btnStatistics.BackColor = scheme.Color7;
            btnUser.BackColor = scheme.Color7;
            btnCar.BackColor = scheme.Color7;
            btnCarPart.BackColor = scheme.Color7;
            btnLogout.BackColor = scheme.Color7;

            btnToDatabase.BackColor = scheme.Color9;
            btnColorScheme.BackColor = scheme.Color9;
            btnAbout.BackColor = scheme.Color9;
            btnFullscreen.BackColor = scheme.Color9;

            btnRefreshAll.BackColor = scheme.Color9;

            btnLog.BackColor = scheme.Color9;

            SetCurrentSection();

            Refresh();
        }

        public async Task LoadInitialAsync()
        {
            statisticsSection1.LoadInitialData();
            userSection1.LoadInitialData();
            carSection1.LoadInitialData();
            carPartSection1.LoadInitialData();
            logSection1.LoadInitialData();
        }

        private void btnSection_Click(object sender, EventArgs e)
        {
            ResetColors();
            HideControls();

            CurrentButton = (Button) sender;

            SetCurrentSection();
        }

        private void SetCurrentSection()
        {
            var tag = (ButtonTag)CurrentButton.Tag;

            _currentControl = tag.RegionControl;

            Text = $"ABC ({tag.Title})";
            toolTip1.SetToolTip(this, tag.Description);

            CurrentButton.Image = tag.ButtonImageDark;
            CurrentButton.BackColor = ColorScheme.Color3;
            if (CurrentButton == btnLog)
            {
                pnlFooter.BackColor = ColorScheme.Color3;
                rtbOutput.BackColor = ColorScheme.Color3;
                lblTime.ForeColor = System.Drawing.Color.Black;
            }
            ((Control)_currentControl).Show();
        }

        private static Action<Log> WriteLogDelegate;
        public static void WriteLog(Log log)
        {
            WriteLogDelegate?.Invoke(log);
        }
        private static Func<Task> SaveToDatabaseDelegate;
        public async static Task SaveToDatabaseAsync()
        {
            await SaveToDatabaseDelegate?.Invoke();
        }
        private static Func<Task> LoginDelegate;
        public async static Task LoginAsync()
        {
            await LoginDelegate?.Invoke();
        }
        private static Func<Task> LogoutDelegate;
        public async static Task LogoutAsync()
        {
            await LogoutDelegate?.Invoke();
        }
        private static Action ExitDelegate;
        public static void Exit()
        {
            ExitDelegate?.Invoke();
        }
        private static Func<Task> RefreshAsyncDelegate;
        public async static Task RefreshAsync()
        {
            await RefreshAsyncDelegate?.Invoke();
        }

        private void AssignActions()
        {
            WriteLogDelegate = (l) =>
            {
                if (l == null) return;
                rtbOutput.AppendText("\n");
                rtbOutput.AppendText($"[{l.CreatedDate.ToLongTimeString()}]");
                rtbOutput.AppendText($"{l.CreatedUser?.Email}");
                //rtbOutput.Select(rtbOutput.TextLength, 0);
                //rtbOutput.SelectionColor = System.Drawing.Color.White;
                //rtbOutput.SelectionFont = new Font(rtbOutput.Font, FontStyle.Regular);
                rtbOutput.AppendText($">{l.Text}");

                if (DbContext == null) return;
                DbContext.Logs.Add(l);
            };
            SaveToDatabaseDelegate = async () =>
            {
                //await CompleteAsync();
            };

            LoginDelegate = async () =>
            {
                LoadInitialAsync();
                EnableButtons();
                btnToDatabase.Enabled = true;
                WriteLog(new Log()
                {
                    CreatedDate = DateTime.Now,
                    CreatedUserId = User?.Id,
                    Title = "Login",
                    Action = LogAction.Auth,
                    Text = $"Logged in"
                });
                await DbContext.SaveChangesAsync();
                btnStatistics.PerformClick();
            };

            LogoutDelegate = async () =>
            {
                DisableButtons();
                if (DbContext != null)
                {
                    WriteLog(new Log()
                    {
                        CreatedDate = DateTime.Now,
                        CreatedUserId = User?.Id,
                        Title = "Login",
                        Action = LogAction.Auth,
                        Text = $"Logged out"
                    });
                    await DbContext.SaveChangesAsync();
                }
                loginSection1.Focus();
            };
            ExitDelegate = Close;

            RefreshAsyncDelegate = async () =>
            {
                SetButtonPermission();
                await statisticsSection1.RefreshAsync();
                await userSection1.RefreshAsync();
                await carSection1.RefreshAsync();
                await carPartSection1.RefreshAsync();
                await logSection1.RefreshAsync();
            };
        }

        private void SetButtonPermission()
        {
            btnUser.Enabled = User != null && User.Role >= Enums.UserRole.Admin;
        }

        private void tagRegionMetaData()
        {
            btnStatistics.Tag = new ButtonTag()
            {
                ButtonImageDark = Properties.Resources.plot_dark_25px,
                ButtonImageLight = Properties.Resources.plot_light_25px,
                Title = "Statistics",
                Description = "View Calving Statistics",
                RegionControl = statisticsSection1,
            };
            btnUser.Tag = new ButtonTag()
            {
                ButtonImageDark = Properties.Resources.user_dark_25px,
                ButtonImageLight = Properties.Resources.user_light_25px,
                Title = "User",
                Description = "Manage User Data",
                RegionControl = userSection1,
            };
            btnCar.Tag = new ButtonTag()
            {
                ButtonImageDark = Properties.Resources.car_dark_25px,
                ButtonImageLight = Properties.Resources.car_light_25px,
                Title = "Car",
                Description = "Manage Cars",
                RegionControl = carSection1
            };
            btnCarPart.Tag = new ButtonTag()
            {
                ButtonImageDark = Properties.Resources.carpart_dark_25px,
                ButtonImageLight = Properties.Resources.carpart_light_25px,
                Title = "Car Part",
                Description = "Manage Car Parts",
                RegionControl = carPartSection1
            };
            btnLogout.Tag = new ButtonTag()
            {
                ButtonImageDark = Properties.Resources.logout_rounded_left_dark_25px,
                ButtonImageLight = Properties.Resources.logout_rounded_left_light_25px,
                Title = "Login",
                Description = "Login Page",
                RegionControl = loginSection1,
            };
            btnLog.Tag = new ButtonTag()
            {
                ButtonImageDark = Properties.Resources.todo_list_dark_20px,
                ButtonImageLight = Properties.Resources.todo_list_light_20px,
                Title = "Calendar",
                Description = "View Logs & Events",
                RegionControl = logSection1,
            };

        }

        private bool isFullScreen = false;
        private void btnFullscreen_Click(object sender, EventArgs e)
        {
            pnlControlsHolder.Visible = false;

            if (isFullScreen)
            {
                //this.TopMost = false;
                this.FormBorderStyle = FormBorderStyle.Sizable;
                this.WindowState = FormWindowState.Normal;
                btnFullscreen.Image = Properties.Resources.expand_light_20px;
                toolTip1.SetToolTip(btnFullscreen, "Fullscreen (Shift+Alt+Enter)");
            }
            else
            {
                //this.TopMost = true;
                this.FormBorderStyle = FormBorderStyle.None;
                this.WindowState = FormWindowState.Maximized;
                btnFullscreen.Image = Properties.Resources.collapse_light_20px;
                toolTip1.SetToolTip(btnFullscreen, "Window (Shift+Alt+Enter)");

            }

            isFullScreen = !isFullScreen;

            pnlControlsHolder.Visible = true;
        }

        private void HideControls()
        {
            statisticsSection1.Visible = false;
            userSection1.Visible = false;
            carSection1.Visible = false;
            carPartSection1.Visible = false;
            loginSection1.Visible = false;
            logSection1.Visible = false;
        }
        private void EnableButtons()
        {
            btnRefreshAll.Enabled = true;
            pnlSideBar.Enabled = true;
            btnLog.Enabled = true;
            btnRefreshAll.Enabled = true;
        }
        private void DisableButtons()
        {
            btnRefreshAll.Enabled = false;
            pnlSideBar.Enabled = false;
            btnLog.Enabled = false;
            btnRefreshAll.Enabled = false;
        }
        private void ResetColors()
        {
            btnStatistics.Image = global::ABC.CarTraders.Properties.Resources.plot_light_25px;
            btnUser.Image = global::ABC.CarTraders.Properties.Resources.user_light_25px;
            btnCar.Image = global::ABC.CarTraders.Properties.Resources.car_light_25px;
            btnCarPart.Image = global::ABC.CarTraders.Properties.Resources.carpart_light_25px;
            btnLogout.Image = global::ABC.CarTraders.Properties.Resources.logout_rounded_left_light_25px;
            btnLog.Image = global::ABC.CarTraders.Properties.Resources.todo_list_light_20px;

            btnStatistics.BackColor = ColorScheme.Color7;
            btnUser.BackColor = ColorScheme.Color7;
            btnCar.BackColor = ColorScheme.Color7;
            btnCarPart.BackColor = ColorScheme.Color7;
            btnLogout.BackColor = ColorScheme.Color7;
            btnLog.BackColor = ColorScheme.Color9;

            pnlFooter.BackColor = ColorScheme.Color9;
            rtbOutput.BackColor = ColorScheme.Color9;
            lblTime.ForeColor = System.Drawing.Color.White;
        }

        private void timerClock_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToShortTimeString();
        }

        private void lblTime_MouseEnter(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(lblTime, DateTime.Now.ToLongDateString());
        }

        private void rtbOutput_TextChanged(object sender, EventArgs e)
        {
            rtbOutput.SelectionStart = rtbOutput.Text.Length;
            rtbOutput.ScrollToCaret();
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            using (var form = new AboutForm())
            {
                form.ShowDialog();
            }
        }

        private async void DashboardForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DbContext == null) return;

            //if (MessageBox.Show("Do you want to upload your work to the database?\nClicking \'No\' will discard any changes since last upload.", "EXIT", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            //{
            //    await SaveToDatabaseAsync();
            //}

            DbContext.Dispose();
        }

        private void btnColorScheme_Click(object sender, EventArgs e)
        {
            ColorIndex = (ColorIndex + 1) % ColorSchemes.Count();
            ColorScheme = ColorSchemes.ElementAt(ColorIndex);
        }

        private async void btnUploadToDatabase_Click(object sender, EventArgs e)
        {
            if (DbContext == null) return;
            //await CompleteAsync();
        }

        //private async Task CompleteAsync()
        //{
        //    var result = DialogResult.Retry;
        //    while (result == DialogResult.Retry)
        //    {
        //        try
        //        {
        //            StartProgress("Saving...");
        //            var n = await DbContext.SaveChangesAsync();
        //            if (n > 0)
        //            {
        //                WriteLog(new Log()
        //                {
        //                    CreatedDate = DateTime.Now,
        //                    CreatedUserId = User?.Id,
        //                    Title = "Database",
        //                    Action = LogAction.Save,
        //                    Text = $"Saved changes to database ({n} record(s) affected)"
        //                });
        //                await DbContext.SaveChangesAsync();
        //            }
        //            StopProgress();
        //            MessageBox.Show("Changes successfully uploaded to the Database.", "UPLOAD", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //            break;
        //        }
        //        catch (DbEntityValidationException ex)
        //        {
        //            var sb = new StringBuilder(string.Empty);
                    
        //            foreach (DbEntityValidationResult item in ex.EntityValidationErrors)
        //            {
        //                var entry = item.Entry;
        //                var entityTypeName = entry.Entity.GetType().Name;

        //                sb.Append($"Error(s) in {entityTypeName} :\n");

        //                foreach (var subItem in item.ValidationErrors)
        //                {
        //                    sb.Append($"\t\"{subItem.ErrorMessage}\" occured at {subItem.PropertyName}.\n");
        //                }
        //            }
        //            StopProgress();
        //            result = MessageBox.Show($"Below data caused errors while uploading to the Database.\n{sb.ToString()}\nAbort : Cancel the operation\nRetry : Try again\nIgnore : Rollback the changes", "ERROR", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
        //            if (result == DialogResult.Ignore)
        //            {
        //                var option = MessageBox.Show("Do you want to revert the changes that caused the error(s)?\nChanges will be lost.", "CONFIRM", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
        //                if (option == DialogResult.Yes)
        //                {
        //                    var entries = ex.EntityValidationErrors.Select(r => r.Entry);
        //                    foreach (var entry in entries)
        //                    {
        //                        switch (entry.State)
        //                        {
        //                            case EntityState.Added:
        //                                entry.State = EntityState.Detached;
        //                                break;
        //                            case EntityState.Modified:
        //                                entry.CurrentValues.SetValues(entry.OriginalValues);
        //                                entry.State = EntityState.Unchanged;
        //                                break;
        //                            case EntityState.Deleted:
        //                                entry.State = EntityState.Unchanged;
        //                                break;
        //                        }
        //                    }
        //                }
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            StopProgress();
        //            result = MessageBox.Show($"An error occurred while uploading data to the Database.\n{ex.Message}\n{ex.InnerException?.Message}\nPlease try again.", "ERROR", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
        //        }
        //    }
        //}


        #region Progress
        public Stopwatch Stopwatch { get; set; } = new Stopwatch();
        public string ProgressText { get; set; }
        public LoadingCircle LoadingCircle { get; set; } = new LoadingCircle()
        {
            Color = System.Drawing.Color.White,
            NumberSpoke = 60,
            SpokeThickness = 1,
            InnerCircleRadius = 9,
            OuterCircleRadius = 12,
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
            lblTitle.Text = $"{ProgressText} (00:00)";
            timer1.Enabled = true;
            DisableButtons();
            pnlControlsHolder.Enabled = false;
            Refresh();
        }

        private void StopProgress()
        {
            Stopwatch.Stop();
            pnlLoadingCircle.Visible = false;
            LoadingCircle.Active = false;
            timer1.Enabled = false;
            EnableButtons();
            pnlControlsHolder.Enabled = true;
            lblTitle.Text = $"Department of Animal Production and Health";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            var elapsed = Stopwatch.Elapsed;
            lblTitle.Text = $"{ProgressText} ({elapsed.Minutes:00}:{elapsed.Seconds:00})";
        }
        #endregion

        //keyboard shortcuts
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            //if (keyData == (Keys.Control | Keys.N))
            //{
            //    MessageBox.Show("Ctrl+N = Nifraz!\nContact nifraz@live.com");
            //    return true;
            //}
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void DashboardForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control)
            {
                switch (e.KeyCode)
                {
                    case Keys.S:
                        if (e.Shift)
                        {
                            btnToDatabase.PerformClick();
                            e.SuppressKeyPress = true;
                        } 
                        break;
                    case Keys.D0:
                        btnLog.PerformClick();
                        e.SuppressKeyPress = true;
                        break;
                    case Keys.D1:
                        btnStatistics.PerformClick();
                        e.SuppressKeyPress = true;
                        break;
                    case Keys.D2:
                        btnUser.PerformClick();
                        e.SuppressKeyPress = true;
                        break;
                    case Keys.D3:
                        btnCar.PerformClick();
                        e.SuppressKeyPress = true;
                        break;
                    case Keys.D4:
                        btnCarPart.PerformClick();
                        e.SuppressKeyPress = true;
                        break;
                    case Keys.L:
                        btnLogout.PerformClick();
                        e.SuppressKeyPress = true;
                        break;
                    case Keys.I:
                        btnAbout.PerformClick();
                        e.SuppressKeyPress = true;
                        break;
                    case Keys.D:
                        btnColorScheme.PerformClick();
                        e.SuppressKeyPress = true;
                        break;
                    case Keys.R:
                        btnRefreshAll.PerformClick();
                        e.SuppressKeyPress = true;
                        break;
                }
            }

            if (e.Shift && e.Alt && (e.KeyCode == Keys.Enter))
            {
                btnFullscreen.PerformClick();
                e.SuppressKeyPress = true;
            }
        }

        private async void btnRefreshAll_Click(object sender, EventArgs e)
        {
            StartProgress("Refreshing...");
            await RefreshAsync();
            StopProgress();
        }
    }
}
