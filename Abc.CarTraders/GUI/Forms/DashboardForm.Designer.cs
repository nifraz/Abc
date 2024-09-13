using ABC.CarTraders.GUI.Sections;

namespace ABC.CarTraders.GUI.Forms
{
    partial class DashboardForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Diagnostics.Stopwatch stopwatch1 = new System.Diagnostics.Stopwatch();
            System.Diagnostics.Stopwatch stopwatch2 = new System.Diagnostics.Stopwatch();
            System.Diagnostics.Stopwatch stopwatch3 = new System.Diagnostics.Stopwatch();
            System.Diagnostics.Stopwatch stopwatch4 = new System.Diagnostics.Stopwatch();
            System.Diagnostics.Stopwatch stopwatch5 = new System.Diagnostics.Stopwatch();
            System.Diagnostics.Stopwatch stopwatch6 = new System.Diagnostics.Stopwatch();
            System.Diagnostics.Stopwatch stopwatch7 = new System.Diagnostics.Stopwatch();
            System.Diagnostics.Stopwatch stopwatch8 = new System.Diagnostics.Stopwatch();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DashboardForm));
            this.pnlSideBar = new System.Windows.Forms.Panel();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnStatistics = new System.Windows.Forms.Button();
            this.btnUser = new System.Windows.Forms.Button();
            this.btnSemen = new System.Windows.Forms.Button();
            this.btnInstitute = new System.Windows.Forms.Button();
            this.btnTechnician = new System.Windows.Forms.Button();
            this.btnCalvingRecord = new System.Windows.Forms.Button();
            this.btnCalvingSheet = new System.Windows.Forms.Button();
            this.btnVsRange = new System.Windows.Forms.Button();
            this.pnlControlsHolder = new System.Windows.Forms.Panel();
            this.loginSection1 = new ABC.CarTraders.GUI.Sections.LoginSection();
            this.statisticsSection1 = new ABC.CarTraders.GUI.Sections.StatisticsSection();
            this.userSection1 = new ABC.CarTraders.GUI.Sections.UserSection();
            this.carSection1 = new ABC.CarTraders.GUI.Sections.CarSection();
            this.logSection1 = new ABC.CarTraders.GUI.Sections.LogSection();
            this.btnAbout = new System.Windows.Forms.Button();
            this.btnFullscreen = new System.Windows.Forms.Button();
            this.lblTime = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.lblIcon = new System.Windows.Forms.Label();
            this.btnColorScheme = new System.Windows.Forms.Button();
            this.btnLog = new System.Windows.Forms.Button();
            this.btnToDatabase = new System.Windows.Forms.Button();
            this.btnRefreshAll = new System.Windows.Forms.Button();
            this.rtbOutput = new System.Windows.Forms.RichTextBox();
            this.timerClock = new System.Windows.Forms.Timer(this.components);
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlLoadingCircle = new System.Windows.Forms.Panel();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pnlSideBar.SuspendLayout();
            this.pnlControlsHolder.SuspendLayout();
            this.pnlFooter.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlSideBar
            // 
            this.pnlSideBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pnlSideBar.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.pnlSideBar.Controls.Add(this.btnLogout);
            this.pnlSideBar.Controls.Add(this.btnStatistics);
            this.pnlSideBar.Controls.Add(this.btnUser);
            this.pnlSideBar.Controls.Add(this.btnSemen);
            this.pnlSideBar.Controls.Add(this.btnInstitute);
            this.pnlSideBar.Controls.Add(this.btnTechnician);
            this.pnlSideBar.Controls.Add(this.btnCalvingRecord);
            this.pnlSideBar.Controls.Add(this.btnCalvingSheet);
            this.pnlSideBar.Controls.Add(this.btnVsRange);
            this.pnlSideBar.Location = new System.Drawing.Point(0, 40);
            this.pnlSideBar.Name = "pnlSideBar";
            this.pnlSideBar.Size = new System.Drawing.Size(40, 495);
            this.pnlSideBar.TabIndex = 2;
            // 
            // btnLogout
            // 
            this.btnLogout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnLogout.BackColor = System.Drawing.SystemColors.Control;
            this.btnLogout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogout.ForeColor = System.Drawing.Color.White;
            this.btnLogout.Image = global::ABC.CarTraders.Properties.Resources.logout_rounded_left_dark_25px;
            this.btnLogout.Location = new System.Drawing.Point(0, 455);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(40, 40);
            this.btnLogout.TabIndex = 9;
            this.toolTip1.SetToolTip(this.btnLogout, "Logout (Ctrl+L)");
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnSection_Click);
            // 
            // btnStatistics
            // 
            this.btnStatistics.BackColor = System.Drawing.SystemColors.ControlDark;
            this.btnStatistics.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStatistics.FlatAppearance.BorderSize = 0;
            this.btnStatistics.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStatistics.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStatistics.ForeColor = System.Drawing.Color.White;
            this.btnStatistics.Image = global::ABC.CarTraders.Properties.Resources.plot_light_25px;
            this.btnStatistics.Location = new System.Drawing.Point(0, 0);
            this.btnStatistics.Name = "btnStatistics";
            this.btnStatistics.Size = new System.Drawing.Size(40, 40);
            this.btnStatistics.TabIndex = 1;
            this.toolTip1.SetToolTip(this.btnStatistics, "Statistics (Ctrl+1)");
            this.btnStatistics.UseVisualStyleBackColor = false;
            this.btnStatistics.Click += new System.EventHandler(this.btnSection_Click);
            // 
            // btnUser
            // 
            this.btnUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUser.BackColor = System.Drawing.SystemColors.ControlDark;
            this.btnUser.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUser.FlatAppearance.BorderSize = 0;
            this.btnUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUser.ForeColor = System.Drawing.Color.White;
            this.btnUser.Image = global::ABC.CarTraders.Properties.Resources.user_light_25px;
            this.btnUser.Location = new System.Drawing.Point(0, 41);
            this.btnUser.Name = "btnUser";
            this.btnUser.Size = new System.Drawing.Size(40, 40);
            this.btnUser.TabIndex = 2;
            this.toolTip1.SetToolTip(this.btnUser, "User (Ctrl+2)");
            this.btnUser.UseVisualStyleBackColor = false;
            this.btnUser.Click += new System.EventHandler(this.btnSection_Click);
            // 
            // btnSemen
            // 
            this.btnSemen.BackColor = System.Drawing.SystemColors.ControlDark;
            this.btnSemen.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSemen.FlatAppearance.BorderSize = 0;
            this.btnSemen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSemen.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSemen.ForeColor = System.Drawing.Color.White;
            this.btnSemen.Image = global::ABC.CarTraders.Properties.Resources.bull_light_25px;
            this.btnSemen.Location = new System.Drawing.Point(0, 164);
            this.btnSemen.Name = "btnSemen";
            this.btnSemen.Size = new System.Drawing.Size(40, 40);
            this.btnSemen.TabIndex = 5;
            this.toolTip1.SetToolTip(this.btnSemen, "Semen (Ctrl+5)");
            this.btnSemen.UseVisualStyleBackColor = false;
            this.btnSemen.Click += new System.EventHandler(this.btnSection_Click);
            // 
            // btnInstitute
            // 
            this.btnInstitute.BackColor = System.Drawing.SystemColors.ControlDark;
            this.btnInstitute.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnInstitute.FlatAppearance.BorderSize = 0;
            this.btnInstitute.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInstitute.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInstitute.ForeColor = System.Drawing.Color.White;
            this.btnInstitute.Image = global::ABC.CarTraders.Properties.Resources.company_light_25px;
            this.btnInstitute.Location = new System.Drawing.Point(0, 123);
            this.btnInstitute.Name = "btnInstitute";
            this.btnInstitute.Size = new System.Drawing.Size(40, 40);
            this.btnInstitute.TabIndex = 4;
            this.toolTip1.SetToolTip(this.btnInstitute, "Institute (Ctrl+4)");
            this.btnInstitute.UseVisualStyleBackColor = false;
            this.btnInstitute.Click += new System.EventHandler(this.btnSection_Click);
            // 
            // btnTechnician
            // 
            this.btnTechnician.BackColor = System.Drawing.SystemColors.ControlDark;
            this.btnTechnician.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTechnician.FlatAppearance.BorderSize = 0;
            this.btnTechnician.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTechnician.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTechnician.ForeColor = System.Drawing.Color.White;
            this.btnTechnician.Image = global::ABC.CarTraders.Properties.Resources.worker_light_25px;
            this.btnTechnician.Location = new System.Drawing.Point(0, 205);
            this.btnTechnician.Name = "btnTechnician";
            this.btnTechnician.Size = new System.Drawing.Size(40, 40);
            this.btnTechnician.TabIndex = 6;
            this.toolTip1.SetToolTip(this.btnTechnician, "Technician (Ctrl+6)");
            this.btnTechnician.UseVisualStyleBackColor = false;
            this.btnTechnician.Click += new System.EventHandler(this.btnSection_Click);
            // 
            // btnCalvingRecord
            // 
            this.btnCalvingRecord.BackColor = System.Drawing.SystemColors.ControlDark;
            this.btnCalvingRecord.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCalvingRecord.FlatAppearance.BorderSize = 0;
            this.btnCalvingRecord.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCalvingRecord.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCalvingRecord.ForeColor = System.Drawing.Color.White;
            this.btnCalvingRecord.Image = global::ABC.CarTraders.Properties.Resources.list_view_light_25px;
            this.btnCalvingRecord.Location = new System.Drawing.Point(0, 287);
            this.btnCalvingRecord.Name = "btnCalvingRecord";
            this.btnCalvingRecord.Size = new System.Drawing.Size(40, 40);
            this.btnCalvingRecord.TabIndex = 8;
            this.toolTip1.SetToolTip(this.btnCalvingRecord, "Calving Record (Ctrl+8)");
            this.btnCalvingRecord.UseVisualStyleBackColor = false;
            this.btnCalvingRecord.Click += new System.EventHandler(this.btnSection_Click);
            // 
            // btnCalvingSheet
            // 
            this.btnCalvingSheet.BackColor = System.Drawing.SystemColors.ControlDark;
            this.btnCalvingSheet.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCalvingSheet.FlatAppearance.BorderSize = 0;
            this.btnCalvingSheet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCalvingSheet.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCalvingSheet.ForeColor = System.Drawing.Color.White;
            this.btnCalvingSheet.Image = global::ABC.CarTraders.Properties.Resources.spreadsheet_file_light_25px;
            this.btnCalvingSheet.Location = new System.Drawing.Point(0, 246);
            this.btnCalvingSheet.Name = "btnCalvingSheet";
            this.btnCalvingSheet.Size = new System.Drawing.Size(40, 40);
            this.btnCalvingSheet.TabIndex = 7;
            this.toolTip1.SetToolTip(this.btnCalvingSheet, "Calving Sheet (Ctrl+7)");
            this.btnCalvingSheet.UseVisualStyleBackColor = false;
            this.btnCalvingSheet.Click += new System.EventHandler(this.btnSection_Click);
            // 
            // btnVsRange
            // 
            this.btnVsRange.BackColor = System.Drawing.SystemColors.ControlDark;
            this.btnVsRange.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVsRange.FlatAppearance.BorderSize = 0;
            this.btnVsRange.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVsRange.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVsRange.ForeColor = System.Drawing.Color.White;
            this.btnVsRange.Image = global::ABC.CarTraders.Properties.Resources.map_marker_light_25px;
            this.btnVsRange.Location = new System.Drawing.Point(0, 82);
            this.btnVsRange.Name = "btnVsRange";
            this.btnVsRange.Size = new System.Drawing.Size(40, 40);
            this.btnVsRange.TabIndex = 3;
            this.btnVsRange.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolTip1.SetToolTip(this.btnVsRange, "VS Range (Ctrl+3)");
            this.btnVsRange.UseVisualStyleBackColor = false;
            this.btnVsRange.Click += new System.EventHandler(this.btnSection_Click);
            // 
            // pnlControlsHolder
            // 
            this.pnlControlsHolder.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlControlsHolder.BackColor = System.Drawing.SystemColors.Control;
            this.pnlControlsHolder.Controls.Add(this.loginSection1);
            this.pnlControlsHolder.Controls.Add(this.statisticsSection1);
            this.pnlControlsHolder.Controls.Add(this.userSection1);
            this.pnlControlsHolder.Controls.Add(this.carSection1);
            this.pnlControlsHolder.Controls.Add(this.logSection1);
            this.pnlControlsHolder.Location = new System.Drawing.Point(45, 45);
            this.pnlControlsHolder.Name = "pnlControlsHolder";
            this.pnlControlsHolder.Size = new System.Drawing.Size(834, 485);
            this.pnlControlsHolder.TabIndex = 0;
            // 
            // loginSection1
            // 
            this.loginSection1.BackColor = System.Drawing.SystemColors.Control;
            this.loginSection1.ColorScheme = null;
            this.loginSection1.ConnectionTimeout = 10;
            this.loginSection1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.loginSection1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loginSection1.Location = new System.Drawing.Point(0, 0);
            this.loginSection1.LoginAttempts = 0;
            this.loginSection1.Margin = new System.Windows.Forms.Padding(0);
            this.loginSection1.Name = "loginSection1";
            this.loginSection1.Port = 1433;
            this.loginSection1.ProgressText = null;
            this.loginSection1.Size = new System.Drawing.Size(834, 485);
            this.loginSection1.Stopwatch = stopwatch1;
            this.loginSection1.TabIndex = 1;
            this.loginSection1.DbContext = null;
            this.loginSection1.User = null;
            // 
            // statisticsSection1
            // 
            this.statisticsSection1.BackColor = System.Drawing.SystemColors.Control;
            this.statisticsSection1.ColorScheme = null;
            this.statisticsSection1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.statisticsSection1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statisticsSection1.Location = new System.Drawing.Point(0, 0);
            this.statisticsSection1.Name = "statisticsSection1";
            this.statisticsSection1.ProgressText = null;
            this.statisticsSection1.Size = new System.Drawing.Size(834, 485);
            this.statisticsSection1.Stopwatch = stopwatch2;
            this.statisticsSection1.TabIndex = 1;
            // 
            // userSection1
            // 
            this.userSection1.ColorScheme = null;
            this.userSection1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userSection1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userSection1.Location = new System.Drawing.Point(0, 0);
            this.userSection1.Name = "userSection1";
            this.userSection1.ProgressText = null;
            this.userSection1.Size = new System.Drawing.Size(834, 485);
            this.userSection1.Stopwatch = stopwatch3;
            this.userSection1.TabIndex = 1;
            this.userSection1.Visible = false;
            // 
            // calvingSheetSection1
            // 
            this.carSection1.ColorScheme = null;
            this.carSection1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.carSection1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.carSection1.Location = new System.Drawing.Point(0, 0);
            this.carSection1.Margin = new System.Windows.Forms.Padding(0);
            this.carSection1.Name = "calvingSheetSection1";
            this.carSection1.ProgressText = null;
            this.carSection1.Size = new System.Drawing.Size(834, 485);
            this.carSection1.Stopwatch = stopwatch6;
            this.carSection1.TabIndex = 1;
            this.carSection1.Visible = false;
            // 
            // logSection1
            // 
            this.logSection1.ColorScheme = null;
            this.logSection1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logSection1.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.logSection1.Location = new System.Drawing.Point(0, 0);
            this.logSection1.Name = "logSection1";
            this.logSection1.ProgressText = null;
            this.logSection1.Size = new System.Drawing.Size(834, 485);
            this.logSection1.Stopwatch = stopwatch8;
            this.logSection1.TabIndex = 4;
            this.logSection1.Visible = false;
            // 
            // btnAbout
            // 
            this.btnAbout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAbout.BackColor = System.Drawing.Color.Transparent;
            this.btnAbout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAbout.FlatAppearance.BorderSize = 0;
            this.btnAbout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAbout.ForeColor = System.Drawing.Color.White;
            this.btnAbout.Image = global::ABC.CarTraders.Properties.Resources.info_light_20px;
            this.btnAbout.Location = new System.Drawing.Point(804, 0);
            this.btnAbout.Name = "btnAbout";
            this.btnAbout.Size = new System.Drawing.Size(40, 40);
            this.btnAbout.TabIndex = 3;
            this.toolTip1.SetToolTip(this.btnAbout, "About (Ctrl+I)");
            this.btnAbout.UseVisualStyleBackColor = false;
            this.btnAbout.Click += new System.EventHandler(this.btnAbout_Click);
            // 
            // btnFullscreen
            // 
            this.btnFullscreen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFullscreen.BackColor = System.Drawing.Color.Transparent;
            this.btnFullscreen.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFullscreen.FlatAppearance.BorderSize = 0;
            this.btnFullscreen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFullscreen.ForeColor = System.Drawing.Color.White;
            this.btnFullscreen.Image = global::ABC.CarTraders.Properties.Resources.expand_light_20px;
            this.btnFullscreen.Location = new System.Drawing.Point(844, 0);
            this.btnFullscreen.Name = "btnFullscreen";
            this.btnFullscreen.Size = new System.Drawing.Size(40, 40);
            this.btnFullscreen.TabIndex = 4;
            this.toolTip1.SetToolTip(this.btnFullscreen, "Fullscreen (Shift+Alt+Enter)");
            this.btnFullscreen.UseVisualStyleBackColor = false;
            this.btnFullscreen.Click += new System.EventHandler(this.btnFullscreen_Click);
            // 
            // lblTime
            // 
            this.lblTime.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTime.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold);
            this.lblTime.ForeColor = System.Drawing.Color.White;
            this.lblTime.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTime.Location = new System.Drawing.Point(759, 0);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(80, 40);
            this.lblTime.TabIndex = 0;
            this.lblTime.Text = "12:00 AM";
            this.lblTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblTime.MouseEnter += new System.EventHandler(this.lblTime_MouseEnter);
            // 
            // toolTip1
            // 
            this.toolTip1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            // 
            // lblIcon
            // 
            this.lblIcon.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblIcon.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIcon.ForeColor = System.Drawing.Color.White;
            this.lblIcon.Image = global::ABC.CarTraders.Properties.Resources.daph_light;
            this.lblIcon.Location = new System.Drawing.Point(0, 0);
            this.lblIcon.Name = "lblIcon";
            this.lblIcon.Size = new System.Drawing.Size(40, 40);
            this.lblIcon.TabIndex = 0;
            this.toolTip1.SetToolTip(this.lblIcon, "ABC");
            // 
            // btnColorScheme
            // 
            this.btnColorScheme.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnColorScheme.BackColor = System.Drawing.Color.Transparent;
            this.btnColorScheme.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnColorScheme.FlatAppearance.BorderSize = 0;
            this.btnColorScheme.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnColorScheme.ForeColor = System.Drawing.Color.White;
            this.btnColorScheme.Image = global::ABC.CarTraders.Properties.Resources.paint_palette_light_20px;
            this.btnColorScheme.Location = new System.Drawing.Point(764, 0);
            this.btnColorScheme.Name = "btnColorScheme";
            this.btnColorScheme.Size = new System.Drawing.Size(40, 40);
            this.btnColorScheme.TabIndex = 2;
            this.toolTip1.SetToolTip(this.btnColorScheme, "Color (Ctrl+D)");
            this.btnColorScheme.UseVisualStyleBackColor = false;
            this.btnColorScheme.Click += new System.EventHandler(this.btnColorScheme_Click);
            // 
            // btnLog
            // 
            this.btnLog.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btnLog.BackColor = System.Drawing.Color.Transparent;
            this.btnLog.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLog.FlatAppearance.BorderSize = 0;
            this.btnLog.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLog.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnLog.ForeColor = System.Drawing.Color.White;
            this.btnLog.Image = global::ABC.CarTraders.Properties.Resources.todo_list_light_20px;
            this.btnLog.Location = new System.Drawing.Point(0, 0);
            this.btnLog.Name = "btnLog";
            this.btnLog.Size = new System.Drawing.Size(40, 40);
            this.btnLog.TabIndex = 1;
            this.toolTip1.SetToolTip(this.btnLog, "Log (Ctrl+0)");
            this.btnLog.UseVisualStyleBackColor = false;
            this.btnLog.Click += new System.EventHandler(this.btnSection_Click);
            // 
            // btnToDatabase
            // 
            this.btnToDatabase.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnToDatabase.BackColor = System.Drawing.Color.Transparent;
            this.btnToDatabase.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnToDatabase.FlatAppearance.BorderSize = 0;
            this.btnToDatabase.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnToDatabase.ForeColor = System.Drawing.Color.White;
            this.btnToDatabase.Image = global::ABC.CarTraders.Properties.Resources.database_restore_light_20px;
            this.btnToDatabase.Location = new System.Drawing.Point(724, 0);
            this.btnToDatabase.Name = "btnToDatabase";
            this.btnToDatabase.Size = new System.Drawing.Size(40, 40);
            this.btnToDatabase.TabIndex = 1;
            this.toolTip1.SetToolTip(this.btnToDatabase, "Upload to Database (Ctrl+Shift+S)");
            this.btnToDatabase.UseVisualStyleBackColor = false;
            this.btnToDatabase.Click += new System.EventHandler(this.btnUploadToDatabase_Click);
            // 
            // btnRefreshAll
            // 
            this.btnRefreshAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefreshAll.BackColor = System.Drawing.Color.Transparent;
            this.btnRefreshAll.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefreshAll.FlatAppearance.BorderSize = 0;
            this.btnRefreshAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefreshAll.ForeColor = System.Drawing.Color.White;
            this.btnRefreshAll.Image = global::ABC.CarTraders.Properties.Resources.available_updates_light_20px;
            this.btnRefreshAll.Location = new System.Drawing.Point(844, 0);
            this.btnRefreshAll.Name = "btnRefreshAll";
            this.btnRefreshAll.Size = new System.Drawing.Size(40, 40);
            this.btnRefreshAll.TabIndex = 16;
            this.toolTip1.SetToolTip(this.btnRefreshAll, "Refresh All Data (Ctrl+R)");
            this.btnRefreshAll.UseVisualStyleBackColor = false;
            this.btnRefreshAll.Click += new System.EventHandler(this.btnRefreshAll_Click);
            // 
            // rtbOutput
            // 
            this.rtbOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbOutput.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.rtbOutput.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbOutput.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbOutput.ForeColor = System.Drawing.Color.White;
            this.rtbOutput.Location = new System.Drawing.Point(43, 0);
            this.rtbOutput.Name = "rtbOutput";
            this.rtbOutput.ReadOnly = true;
            this.rtbOutput.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.rtbOutput.Size = new System.Drawing.Size(773, 40);
            this.rtbOutput.TabIndex = 2;
            this.rtbOutput.Text = "Log1\nLog2\nLog3";
            this.rtbOutput.TextChanged += new System.EventHandler(this.rtbOutput_TextChanged);
            // 
            // timerClock
            // 
            this.timerClock.Enabled = true;
            this.timerClock.Interval = 1000;
            this.timerClock.Tick += new System.EventHandler(this.timerClock_Tick);
            // 
            // pnlFooter
            // 
            this.pnlFooter.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.pnlFooter.Controls.Add(this.btnRefreshAll);
            this.pnlFooter.Controls.Add(this.btnLog);
            this.pnlFooter.Controls.Add(this.lblTime);
            this.pnlFooter.Controls.Add(this.rtbOutput);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(0, 535);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(884, 40);
            this.pnlFooter.TabIndex = 3;
            // 
            // lblTitle
            // 
            this.lblTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTitle.Location = new System.Drawing.Point(41, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(118, 20);
            this.lblTitle.TabIndex = 14;
            this.lblTitle.Text = "ABC Car Traders";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlLoadingCircle
            // 
            this.pnlLoadingCircle.Location = new System.Drawing.Point(4, 5);
            this.pnlLoadingCircle.Name = "pnlLoadingCircle";
            this.pnlLoadingCircle.Size = new System.Drawing.Size(30, 30);
            this.pnlLoadingCircle.TabIndex = 15;
            this.pnlLoadingCircle.Visible = false;
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.pnlTop.Controls.Add(this.pnlLoadingCircle);
            this.pnlTop.Controls.Add(this.lblTitle);
            this.pnlTop.Controls.Add(this.btnToDatabase);
            this.pnlTop.Controls.Add(this.btnFullscreen);
            this.pnlTop.Controls.Add(this.btnColorScheme);
            this.pnlTop.Controls.Add(this.btnAbout);
            this.pnlTop.Controls.Add(this.lblIcon);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(884, 40);
            this.pnlTop.TabIndex = 1;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // DashboardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(884, 575);
            this.Controls.Add(this.pnlTop);
            this.Controls.Add(this.pnlControlsHolder);
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.pnlSideBar);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(620, 487);
            this.Name = "DashboardForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login - ABC";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DashboardForm_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DashboardForm_KeyDown);
            this.pnlSideBar.ResumeLayout(false);
            this.pnlControlsHolder.ResumeLayout(false);
            this.pnlFooter.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlSideBar;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnTechnician;
        private System.Windows.Forms.Button btnCalvingSheet;
        private System.Windows.Forms.Button btnVsRange;
        private System.Windows.Forms.Panel pnlControlsHolder;
        private System.Windows.Forms.Button btnFullscreen;
        private System.Windows.Forms.Button btnAbout;
        private System.Windows.Forms.ToolTip toolTip1;
        private LoginSection loginSection1;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Timer timerClock;
        private System.Windows.Forms.Button btnStatistics;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.RichTextBox rtbOutput;
        private CarSection carSection1;
        private System.Windows.Forms.Button btnSemen;
        private System.Windows.Forms.Button btnInstitute;
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblIcon;
        private StatisticsSection statisticsSection1;
        private System.Windows.Forms.Button btnColorScheme;
        private System.Windows.Forms.Button btnLog;
        private System.Windows.Forms.Button btnToDatabase;
        private System.Windows.Forms.Panel pnlLoadingCircle;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btnUser;
        private UserSection userSection1;
        private LogSection logSection1;
        private System.Windows.Forms.Button btnCalvingRecord;
        private System.Windows.Forms.Button btnRefreshAll;
    }
}

