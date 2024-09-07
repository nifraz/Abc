namespace ABC.CarTraders.GUI.Forms
{
    partial class DatabaseForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DatabaseForm));
            this.pnlServerIp = new System.Windows.Forms.Panel();
            this.pnlServerIpHolder = new System.Windows.Forms.Panel();
            this.txtServerIp = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pnlUserId = new System.Windows.Forms.Panel();
            this.pnlUserIdHolder = new System.Windows.Forms.Panel();
            this.txtUserId = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlPassword = new System.Windows.Forms.Panel();
            this.pnlPasswordHolder = new System.Windows.Forms.Panel();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnPing = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.nudTimeout = new System.Windows.Forms.NumericUpDown();
            this.pnlTimeout = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.pnlTimeoutHolder = new System.Windows.Forms.Panel();
            this.pnlNudCodeHolder = new System.Windows.Forms.Panel();
            this.pnlPort = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.pnlPortHolder = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.nudPort = new System.Windows.Forms.NumericUpDown();
            this.pnlLoadingCircle = new System.Windows.Forms.Panel();
            this.lblProgress = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pnlDataHolder = new System.Windows.Forms.Panel();
            this.pnlServerIp.SuspendLayout();
            this.pnlServerIpHolder.SuspendLayout();
            this.pnlUserId.SuspendLayout();
            this.pnlUserIdHolder.SuspendLayout();
            this.pnlPassword.SuspendLayout();
            this.pnlPasswordHolder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTimeout)).BeginInit();
            this.pnlTimeout.SuspendLayout();
            this.pnlTimeoutHolder.SuspendLayout();
            this.pnlNudCodeHolder.SuspendLayout();
            this.pnlPort.SuspendLayout();
            this.pnlPortHolder.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPort)).BeginInit();
            this.pnlDataHolder.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlServerIp
            // 
            this.pnlServerIp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlServerIp.BackColor = System.Drawing.Color.DarkGray;
            this.pnlServerIp.Controls.Add(this.pnlServerIpHolder);
            this.pnlServerIp.Controls.Add(this.label2);
            this.pnlServerIp.Location = new System.Drawing.Point(0, 0);
            this.pnlServerIp.Name = "pnlServerIp";
            this.pnlServerIp.Size = new System.Drawing.Size(200, 25);
            this.pnlServerIp.TabIndex = 1;
            // 
            // pnlServerIpHolder
            // 
            this.pnlServerIpHolder.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlServerIpHolder.BackColor = System.Drawing.Color.White;
            this.pnlServerIpHolder.Controls.Add(this.txtServerIp);
            this.pnlServerIpHolder.Cursor = System.Windows.Forms.Cursors.Default;
            this.pnlServerIpHolder.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlServerIpHolder.Location = new System.Drawing.Point(73, 0);
            this.pnlServerIpHolder.Name = "pnlServerIpHolder";
            this.pnlServerIpHolder.Size = new System.Drawing.Size(127, 24);
            this.pnlServerIpHolder.TabIndex = 0;
            // 
            // txtServerIp
            // 
            this.txtServerIp.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtServerIp.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtServerIp.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtServerIp.ForeColor = System.Drawing.Color.Black;
            this.txtServerIp.Location = new System.Drawing.Point(5, 5);
            this.txtServerIp.MaxLength = 255;
            this.txtServerIp.Name = "txtServerIp";
            this.txtServerIp.Size = new System.Drawing.Size(122, 16);
            this.txtServerIp.TabIndex = 0;
            this.txtServerIp.Text = "localhost";
            this.toolTip1.SetToolTip(this.txtServerIp, "A valid IP address");
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Cursor = System.Windows.Forms.Cursors.Default;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label2.Location = new System.Drawing.Point(3, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Server IP*";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlUserId
            // 
            this.pnlUserId.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlUserId.BackColor = System.Drawing.Color.DarkGray;
            this.pnlUserId.Controls.Add(this.pnlUserIdHolder);
            this.pnlUserId.Controls.Add(this.label1);
            this.pnlUserId.Location = new System.Drawing.Point(0, 60);
            this.pnlUserId.Name = "pnlUserId";
            this.pnlUserId.Size = new System.Drawing.Size(225, 25);
            this.pnlUserId.TabIndex = 4;
            // 
            // pnlUserIdHolder
            // 
            this.pnlUserIdHolder.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlUserIdHolder.BackColor = System.Drawing.Color.White;
            this.pnlUserIdHolder.Controls.Add(this.txtUserId);
            this.pnlUserIdHolder.Cursor = System.Windows.Forms.Cursors.Default;
            this.pnlUserIdHolder.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlUserIdHolder.Location = new System.Drawing.Point(73, 0);
            this.pnlUserIdHolder.Name = "pnlUserIdHolder";
            this.pnlUserIdHolder.Size = new System.Drawing.Size(152, 24);
            this.pnlUserIdHolder.TabIndex = 0;
            // 
            // txtUserId
            // 
            this.txtUserId.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUserId.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtUserId.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtUserId.ForeColor = System.Drawing.Color.Black;
            this.txtUserId.Location = new System.Drawing.Point(5, 5);
            this.txtUserId.MaxLength = 255;
            this.txtUserId.Name = "txtUserId";
            this.txtUserId.Size = new System.Drawing.Size(147, 16);
            this.txtUserId.TabIndex = 0;
            this.txtUserId.Text = "sa";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Cursor = System.Windows.Forms.Cursors.Default;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.Location = new System.Drawing.Point(3, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "User ID*";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlPassword
            // 
            this.pnlPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlPassword.BackColor = System.Drawing.Color.DarkGray;
            this.pnlPassword.Controls.Add(this.pnlPasswordHolder);
            this.pnlPassword.Controls.Add(this.label3);
            this.pnlPassword.Location = new System.Drawing.Point(0, 90);
            this.pnlPassword.Name = "pnlPassword";
            this.pnlPassword.Size = new System.Drawing.Size(225, 25);
            this.pnlPassword.TabIndex = 5;
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
            this.pnlPasswordHolder.Size = new System.Drawing.Size(152, 24);
            this.pnlPasswordHolder.TabIndex = 0;
            // 
            // txtPassword
            // 
            this.txtPassword.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPassword.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtPassword.ForeColor = System.Drawing.Color.Black;
            this.txtPassword.Location = new System.Drawing.Point(5, 5);
            this.txtPassword.MaxLength = 255;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(147, 16);
            this.txtPassword.TabIndex = 0;
            this.txtPassword.Text = "1234";
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Cursor = System.Windows.Forms.Cursors.Default;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label3.Location = new System.Drawing.Point(3, 5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 15);
            this.label3.TabIndex = 3;
            this.label3.Text = "Password*";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnPing
            // 
            this.btnPing.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPing.BackColor = System.Drawing.Color.Silver;
            this.btnPing.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPing.FlatAppearance.BorderSize = 0;
            this.btnPing.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPing.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnPing.ForeColor = System.Drawing.Color.Black;
            this.btnPing.Image = global::ABC.CarTraders.Properties.Resources.wired_network_connection_dark_15px;
            this.btnPing.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPing.Location = new System.Drawing.Point(200, 0);
            this.btnPing.Name = "btnPing";
            this.btnPing.Size = new System.Drawing.Size(25, 25);
            this.btnPing.TabIndex = 2;
            this.toolTip1.SetToolTip(this.btnPing, "Ping server");
            this.btnPing.UseVisualStyleBackColor = false;
            this.btnPing.Click += new System.EventHandler(this.btnPing_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnSave.ForeColor = System.Drawing.Color.Black;
            this.btnSave.Image = global::ABC.CarTraders.Properties.Resources.save_dark_15px;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(165, 150);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(60, 25);
            this.btnSave.TabIndex = 16;
            this.btnSave.Text = "SAVE";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTip1.SetToolTip(this.btnSave, "Save (Ctrl+S)");
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // nudTimeout
            // 
            this.nudTimeout.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nudTimeout.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.nudTimeout.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.nudTimeout.Location = new System.Drawing.Point(0, 0);
            this.nudTimeout.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.nudTimeout.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.nudTimeout.Name = "nudTimeout";
            this.nudTimeout.Size = new System.Drawing.Size(146, 19);
            this.nudTimeout.TabIndex = 0;
            this.toolTip1.SetToolTip(this.nudTimeout, "Connection timeout in seconds");
            this.nudTimeout.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // pnlTimeout
            // 
            this.pnlTimeout.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlTimeout.BackColor = System.Drawing.Color.DarkGray;
            this.pnlTimeout.Controls.Add(this.label5);
            this.pnlTimeout.Controls.Add(this.pnlTimeoutHolder);
            this.pnlTimeout.Location = new System.Drawing.Point(0, 120);
            this.pnlTimeout.Name = "pnlTimeout";
            this.pnlTimeout.Size = new System.Drawing.Size(225, 25);
            this.pnlTimeout.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Cursor = System.Windows.Forms.Cursors.Default;
            this.label5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label5.Location = new System.Drawing.Point(3, 5);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 15);
            this.label5.TabIndex = 3;
            this.label5.Text = "Timeout*";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlTimeoutHolder
            // 
            this.pnlTimeoutHolder.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlTimeoutHolder.BackColor = System.Drawing.Color.White;
            this.pnlTimeoutHolder.Controls.Add(this.pnlNudCodeHolder);
            this.pnlTimeoutHolder.Cursor = System.Windows.Forms.Cursors.Default;
            this.pnlTimeoutHolder.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlTimeoutHolder.Location = new System.Drawing.Point(73, 0);
            this.pnlTimeoutHolder.Name = "pnlTimeoutHolder";
            this.pnlTimeoutHolder.Size = new System.Drawing.Size(152, 24);
            this.pnlTimeoutHolder.TabIndex = 0;
            // 
            // pnlNudCodeHolder
            // 
            this.pnlNudCodeHolder.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlNudCodeHolder.Controls.Add(this.nudTimeout);
            this.pnlNudCodeHolder.Location = new System.Drawing.Point(5, 5);
            this.pnlNudCodeHolder.Name = "pnlNudCodeHolder";
            this.pnlNudCodeHolder.Size = new System.Drawing.Size(144, 19);
            this.pnlNudCodeHolder.TabIndex = 0;
            // 
            // pnlPort
            // 
            this.pnlPort.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlPort.BackColor = System.Drawing.Color.DarkGray;
            this.pnlPort.Controls.Add(this.label4);
            this.pnlPort.Controls.Add(this.pnlPortHolder);
            this.pnlPort.Location = new System.Drawing.Point(0, 30);
            this.pnlPort.Name = "pnlPort";
            this.pnlPort.Size = new System.Drawing.Size(225, 25);
            this.pnlPort.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Cursor = System.Windows.Forms.Cursors.Default;
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label4.Location = new System.Drawing.Point(3, 5);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 15);
            this.label4.TabIndex = 3;
            this.label4.Text = "Port*";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlPortHolder
            // 
            this.pnlPortHolder.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlPortHolder.BackColor = System.Drawing.Color.White;
            this.pnlPortHolder.Controls.Add(this.panel3);
            this.pnlPortHolder.Cursor = System.Windows.Forms.Cursors.Default;
            this.pnlPortHolder.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlPortHolder.Location = new System.Drawing.Point(73, 0);
            this.pnlPortHolder.Name = "pnlPortHolder";
            this.pnlPortHolder.Size = new System.Drawing.Size(152, 24);
            this.pnlPortHolder.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.Controls.Add(this.nudPort);
            this.panel3.Location = new System.Drawing.Point(5, 5);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(144, 19);
            this.panel3.TabIndex = 0;
            // 
            // nudPort
            // 
            this.nudPort.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nudPort.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.nudPort.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.nudPort.Location = new System.Drawing.Point(0, 0);
            this.nudPort.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.nudPort.Minimum = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.nudPort.Name = "nudPort";
            this.nudPort.Size = new System.Drawing.Size(146, 19);
            this.nudPort.TabIndex = 0;
            this.nudPort.Value = new decimal(new int[] {
            1433,
            0,
            0,
            0});
            // 
            // pnlLoadingCircle
            // 
            this.pnlLoadingCircle.Location = new System.Drawing.Point(2, 153);
            this.pnlLoadingCircle.Name = "pnlLoadingCircle";
            this.pnlLoadingCircle.Size = new System.Drawing.Size(20, 20);
            this.pnlLoadingCircle.TabIndex = 15;
            this.pnlLoadingCircle.Visible = false;
            // 
            // lblProgress
            // 
            this.lblProgress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblProgress.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblProgress.ForeColor = System.Drawing.Color.Black;
            this.lblProgress.Image = global::ABC.CarTraders.Properties.Resources.ok_dark_15px;
            this.lblProgress.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblProgress.Location = new System.Drawing.Point(3, 155);
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Size = new System.Drawing.Size(156, 15);
            this.lblProgress.TabIndex = 14;
            this.lblProgress.Text = "      Ready";
            this.lblProgress.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlDataHolder
            // 
            this.pnlDataHolder.BackColor = System.Drawing.Color.Transparent;
            this.pnlDataHolder.Controls.Add(this.btnSave);
            this.pnlDataHolder.Controls.Add(this.pnlServerIp);
            this.pnlDataHolder.Controls.Add(this.pnlLoadingCircle);
            this.pnlDataHolder.Controls.Add(this.pnlPassword);
            this.pnlDataHolder.Controls.Add(this.lblProgress);
            this.pnlDataHolder.Controls.Add(this.pnlUserId);
            this.pnlDataHolder.Controls.Add(this.pnlPort);
            this.pnlDataHolder.Controls.Add(this.pnlTimeout);
            this.pnlDataHolder.Controls.Add(this.btnPing);
            this.pnlDataHolder.Location = new System.Drawing.Point(5, 5);
            this.pnlDataHolder.Name = "pnlDataHolder";
            this.pnlDataHolder.Size = new System.Drawing.Size(225, 175);
            this.pnlDataHolder.TabIndex = 1;
            // 
            // DatabaseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(235, 185);
            this.Controls.Add(this.pnlDataHolder);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DatabaseForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Database";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DatabaseForm_KeyDown);
            this.pnlServerIp.ResumeLayout(false);
            this.pnlServerIp.PerformLayout();
            this.pnlServerIpHolder.ResumeLayout(false);
            this.pnlServerIpHolder.PerformLayout();
            this.pnlUserId.ResumeLayout(false);
            this.pnlUserId.PerformLayout();
            this.pnlUserIdHolder.ResumeLayout(false);
            this.pnlUserIdHolder.PerformLayout();
            this.pnlPassword.ResumeLayout(false);
            this.pnlPassword.PerformLayout();
            this.pnlPasswordHolder.ResumeLayout(false);
            this.pnlPasswordHolder.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTimeout)).EndInit();
            this.pnlTimeout.ResumeLayout(false);
            this.pnlTimeout.PerformLayout();
            this.pnlTimeoutHolder.ResumeLayout(false);
            this.pnlNudCodeHolder.ResumeLayout(false);
            this.pnlPort.ResumeLayout(false);
            this.pnlPort.PerformLayout();
            this.pnlPortHolder.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudPort)).EndInit();
            this.pnlDataHolder.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pnlServerIp;
        private System.Windows.Forms.Panel pnlServerIpHolder;
        private System.Windows.Forms.TextBox txtServerIp;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel pnlUserId;
        private System.Windows.Forms.Panel pnlUserIdHolder;
        private System.Windows.Forms.TextBox txtUserId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnlPassword;
        private System.Windows.Forms.Panel pnlPasswordHolder;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button btnPing;
        private System.Windows.Forms.Panel pnlTimeout;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel pnlTimeoutHolder;
        private System.Windows.Forms.Panel pnlNudCodeHolder;
        private System.Windows.Forms.NumericUpDown nudTimeout;
        private System.Windows.Forms.Panel pnlPort;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel pnlPortHolder;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.NumericUpDown nudPort;
        private System.Windows.Forms.Panel pnlLoadingCircle;
        private System.Windows.Forms.Label lblProgress;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel pnlDataHolder;
        private System.Windows.Forms.Button btnSave;
    }
}