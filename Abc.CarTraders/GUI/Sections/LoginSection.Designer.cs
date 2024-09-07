namespace ABC.CarTraders.GUI.Sections
{
    partial class LoginSection
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.pnlMainHolder = new System.Windows.Forms.Panel();
            this.pnlLoadingCircle = new System.Windows.Forms.Panel();
            this.lblProgress = new System.Windows.Forms.Label();
            this.pnlPassword = new System.Windows.Forms.Panel();
            this.pnlPasswordHolder = new System.Windows.Forms.Panel();
            this.lblPassword = new System.Windows.Forms.Label();
            this.pnlUsername = new System.Windows.Forms.Panel();
            this.pnlUsernameHolder = new System.Windows.Forms.Panel();
            this.lblUsername = new System.Windows.Forms.Label();
            this.btnLogin = new System.Windows.Forms.Button();
            this.btnDatabaseSettings = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pnlMain = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.pnlMainHolder.SuspendLayout();
            this.pnlPassword.SuspendLayout();
            this.pnlPasswordHolder.SuspendLayout();
            this.pnlUsername.SuspendLayout();
            this.pnlUsernameHolder.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtUsername
            // 
            this.txtUsername.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUsername.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtUsername.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtUsername.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtUsername.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtUsername.ForeColor = System.Drawing.Color.Black;
            this.txtUsername.Location = new System.Drawing.Point(6, 5);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(211, 16);
            this.txtUsername.TabIndex = 0;
            this.txtUsername.Text = "user";
            this.txtUsername.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LoginControl_KeyDown);
            // 
            // txtPassword
            // 
            this.txtPassword.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPassword.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtPassword.ForeColor = System.Drawing.Color.Black;
            this.txtPassword.Location = new System.Drawing.Point(6, 5);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(211, 16);
            this.txtPassword.TabIndex = 0;
            this.txtPassword.UseSystemPasswordChar = true;
            this.txtPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LoginControl_KeyDown);
            // 
            // pnlMainHolder
            // 
            this.pnlMainHolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlMainHolder.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlMainHolder.Controls.Add(this.pnlLoadingCircle);
            this.pnlMainHolder.Controls.Add(this.lblProgress);
            this.pnlMainHolder.Controls.Add(this.pnlPassword);
            this.pnlMainHolder.Controls.Add(this.pnlUsername);
            this.pnlMainHolder.Controls.Add(this.btnLogin);
            this.pnlMainHolder.Location = new System.Drawing.Point(0, 25);
            this.pnlMainHolder.Name = "pnlMainHolder";
            this.pnlMainHolder.Size = new System.Drawing.Size(300, 95);
            this.pnlMainHolder.TabIndex = 0;
            // 
            // pnlLoadingCircle
            // 
            this.pnlLoadingCircle.Location = new System.Drawing.Point(7, 68);
            this.pnlLoadingCircle.Name = "pnlLoadingCircle";
            this.pnlLoadingCircle.Size = new System.Drawing.Size(20, 20);
            this.pnlLoadingCircle.TabIndex = 6;
            this.pnlLoadingCircle.Visible = false;
            // 
            // lblProgress
            // 
            this.lblProgress.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblProgress.ForeColor = System.Drawing.Color.Black;
            this.lblProgress.Image = global::ABC.CarTraders.Properties.Resources.ok_dark_15px;
            this.lblProgress.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblProgress.Location = new System.Drawing.Point(8, 70);
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Size = new System.Drawing.Size(211, 15);
            this.lblProgress.TabIndex = 1;
            this.lblProgress.Text = "      Ready";
            this.lblProgress.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlPassword
            // 
            this.pnlPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlPassword.BackColor = System.Drawing.Color.Silver;
            this.pnlPassword.Controls.Add(this.pnlPasswordHolder);
            this.pnlPassword.Controls.Add(this.lblPassword);
            this.pnlPassword.Location = new System.Drawing.Point(5, 35);
            this.pnlPassword.Name = "pnlPassword";
            this.pnlPassword.Size = new System.Drawing.Size(290, 25);
            this.pnlPassword.TabIndex = 2;
            // 
            // pnlPasswordHolder
            // 
            this.pnlPasswordHolder.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlPasswordHolder.BackColor = System.Drawing.Color.White;
            this.pnlPasswordHolder.Controls.Add(this.txtPassword);
            this.pnlPasswordHolder.Cursor = System.Windows.Forms.Cursors.Default;
            this.pnlPasswordHolder.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlPasswordHolder.Location = new System.Drawing.Point(73, 0);
            this.pnlPasswordHolder.Name = "pnlPasswordHolder";
            this.pnlPasswordHolder.Size = new System.Drawing.Size(217, 24);
            this.pnlPasswordHolder.TabIndex = 1;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblPassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblPassword.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblPassword.ForeColor = System.Drawing.Color.Black;
            this.lblPassword.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblPassword.Location = new System.Drawing.Point(3, 5);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(57, 15);
            this.lblPassword.TabIndex = 3;
            this.lblPassword.Text = "Password";
            this.lblPassword.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlUsername
            // 
            this.pnlUsername.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlUsername.BackColor = System.Drawing.Color.Silver;
            this.pnlUsername.Controls.Add(this.pnlUsernameHolder);
            this.pnlUsername.Controls.Add(this.lblUsername);
            this.pnlUsername.Location = new System.Drawing.Point(5, 5);
            this.pnlUsername.Name = "pnlUsername";
            this.pnlUsername.Size = new System.Drawing.Size(290, 25);
            this.pnlUsername.TabIndex = 1;
            // 
            // pnlUsernameHolder
            // 
            this.pnlUsernameHolder.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlUsernameHolder.BackColor = System.Drawing.Color.White;
            this.pnlUsernameHolder.Controls.Add(this.txtUsername);
            this.pnlUsernameHolder.Cursor = System.Windows.Forms.Cursors.Default;
            this.pnlUsernameHolder.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlUsernameHolder.Location = new System.Drawing.Point(73, 0);
            this.pnlUsernameHolder.Name = "pnlUsernameHolder";
            this.pnlUsernameHolder.Size = new System.Drawing.Size(217, 24);
            this.pnlUsernameHolder.TabIndex = 0;
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblUsername.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblUsername.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblUsername.ForeColor = System.Drawing.Color.Black;
            this.lblUsername.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblUsername.Location = new System.Drawing.Point(3, 5);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(60, 15);
            this.lblUsername.TabIndex = 3;
            this.lblUsername.Text = "Username";
            this.lblUsername.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnLogin
            // 
            this.btnLogin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLogin.BackColor = System.Drawing.Color.Gainsboro;
            this.btnLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogin.FlatAppearance.BorderSize = 0;
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnLogin.ForeColor = System.Drawing.Color.Black;
            this.btnLogin.Image = global::ABC.CarTraders.Properties.Resources.login_dark_15px;
            this.btnLogin.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLogin.Location = new System.Drawing.Point(225, 65);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(70, 25);
            this.btnLogin.TabIndex = 3;
            this.btnLogin.Text = "LOGIN";
            this.btnLogin.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTip1.SetToolTip(this.btnLogin, "Login");
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // btnDatabaseSettings
            // 
            this.btnDatabaseSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDatabaseSettings.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnDatabaseSettings.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDatabaseSettings.FlatAppearance.BorderSize = 0;
            this.btnDatabaseSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDatabaseSettings.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnDatabaseSettings.ForeColor = System.Drawing.Color.Black;
            this.btnDatabaseSettings.Image = global::ABC.CarTraders.Properties.Resources.database_light_15px;
            this.btnDatabaseSettings.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDatabaseSettings.Location = new System.Drawing.Point(250, 0);
            this.btnDatabaseSettings.Name = "btnDatabaseSettings";
            this.btnDatabaseSettings.Size = new System.Drawing.Size(25, 25);
            this.btnDatabaseSettings.TabIndex = 1;
            this.btnDatabaseSettings.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTip1.SetToolTip(this.btnDatabaseSettings, "Database");
            this.btnDatabaseSettings.UseVisualStyleBackColor = false;
            this.btnDatabaseSettings.Click += new System.EventHandler(this.btnDatabaseSettings_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // pnlMain
            // 
            this.pnlMain.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pnlMain.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.pnlMain.Controls.Add(this.label1);
            this.pnlMain.Controls.Add(this.btnExit);
            this.pnlMain.Controls.Add(this.btnDatabaseSettings);
            this.pnlMain.Controls.Add(this.pnlMainHolder);
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(300, 120);
            this.pnlMain.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Image = global::ABC.CarTraders.Properties.Resources.lock_light_15px;
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.Location = new System.Drawing.Point(3, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "      Enter Your Credentials";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.btnExit.ForeColor = System.Drawing.Color.White;
            this.btnExit.Image = global::ABC.CarTraders.Properties.Resources.close_light_15px;
            this.btnExit.Location = new System.Drawing.Point(275, 0);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(25, 25);
            this.btnExit.TabIndex = 2;
            this.btnExit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTip1.SetToolTip(this.btnExit, "Exit");
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // LoginSection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlMain);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "LoginSection";
            this.Size = new System.Drawing.Size(300, 120);
            this.pnlMainHolder.ResumeLayout(false);
            this.pnlPassword.ResumeLayout(false);
            this.pnlPassword.PerformLayout();
            this.pnlPasswordHolder.ResumeLayout(false);
            this.pnlPasswordHolder.PerformLayout();
            this.pnlUsername.ResumeLayout(false);
            this.pnlUsername.PerformLayout();
            this.pnlUsernameHolder.ResumeLayout(false);
            this.pnlUsernameHolder.PerformLayout();
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Panel pnlMainHolder;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Panel pnlPasswordHolder;
        private System.Windows.Forms.Panel pnlUsernameHolder;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button btnDatabaseSettings;
        private System.Windows.Forms.Panel pnlUsername;
        private System.Windows.Forms.Panel pnlPassword;
        private System.Windows.Forms.Label lblProgress;
        private System.Windows.Forms.Panel pnlLoadingCircle;
    }
}
