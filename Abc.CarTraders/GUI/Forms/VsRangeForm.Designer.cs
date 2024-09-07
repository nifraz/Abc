namespace ABC.CarTraders.GUI.Forms
{
    partial class VsRangeForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VsRangeForm));
            this.pnlVsCode = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlVsCodeHolder = new System.Windows.Forms.Panel();
            this.pnlNudCodeHolder = new System.Windows.Forms.Panel();
            this.nudCode = new System.Windows.Forms.NumericUpDown();
            this.pnlName = new System.Windows.Forms.Panel();
            this.pnlNameHolder = new System.Windows.Forms.Panel();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pnlDistrict = new System.Windows.Forms.Panel();
            this.pnlDistrictHolder = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cboDistrict = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnLastCode = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnToDatabase = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnFind = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lblProgress = new System.Windows.Forms.Label();
            this.pnlNotes = new System.Windows.Forms.Panel();
            this.pnlNotesHolder = new System.Windows.Forms.Panel();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.pnlLoadingCircle = new System.Windows.Forms.Panel();
            this.pnlDataHolder = new System.Windows.Forms.Panel();
            this.pnlProvince = new System.Windows.Forms.Panel();
            this.pnlFilter1Holder = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.cboProvince = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.pnlVsCode.SuspendLayout();
            this.pnlVsCodeHolder.SuspendLayout();
            this.pnlNudCodeHolder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCode)).BeginInit();
            this.pnlName.SuspendLayout();
            this.pnlNameHolder.SuspendLayout();
            this.pnlDistrict.SuspendLayout();
            this.pnlDistrictHolder.SuspendLayout();
            this.panel2.SuspendLayout();
            this.pnlNotes.SuspendLayout();
            this.pnlNotesHolder.SuspendLayout();
            this.pnlDataHolder.SuspendLayout();
            this.pnlProvince.SuspendLayout();
            this.pnlFilter1Holder.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlVsCode
            // 
            this.pnlVsCode.BackColor = System.Drawing.Color.DarkGray;
            this.pnlVsCode.Controls.Add(this.label1);
            this.pnlVsCode.Controls.Add(this.pnlVsCodeHolder);
            this.pnlVsCode.Location = new System.Drawing.Point(0, 60);
            this.pnlVsCode.Name = "pnlVsCode";
            this.pnlVsCode.Size = new System.Drawing.Size(122, 25);
            this.pnlVsCode.TabIndex = 3;
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
            this.label1.Size = new System.Drawing.Size(40, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "Code*";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlVsCodeHolder
            // 
            this.pnlVsCodeHolder.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlVsCodeHolder.BackColor = System.Drawing.Color.White;
            this.pnlVsCodeHolder.Controls.Add(this.pnlNudCodeHolder);
            this.pnlVsCodeHolder.Cursor = System.Windows.Forms.Cursors.Default;
            this.pnlVsCodeHolder.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlVsCodeHolder.Location = new System.Drawing.Point(73, 0);
            this.pnlVsCodeHolder.Name = "pnlVsCodeHolder";
            this.pnlVsCodeHolder.Size = new System.Drawing.Size(49, 24);
            this.pnlVsCodeHolder.TabIndex = 0;
            // 
            // pnlNudCodeHolder
            // 
            this.pnlNudCodeHolder.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlNudCodeHolder.Controls.Add(this.nudCode);
            this.pnlNudCodeHolder.Location = new System.Drawing.Point(5, 5);
            this.pnlNudCodeHolder.Name = "pnlNudCodeHolder";
            this.pnlNudCodeHolder.Size = new System.Drawing.Size(41, 19);
            this.pnlNudCodeHolder.TabIndex = 58;
            // 
            // nudCode
            // 
            this.nudCode.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nudCode.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.nudCode.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.nudCode.Location = new System.Drawing.Point(0, 0);
            this.nudCode.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.nudCode.Minimum = new decimal(new int[] {
            1101,
            0,
            0,
            0});
            this.nudCode.Name = "nudCode";
            this.nudCode.Size = new System.Drawing.Size(43, 19);
            this.nudCode.TabIndex = 0;
            this.nudCode.Value = new decimal(new int[] {
            1101,
            0,
            0,
            0});
            // 
            // pnlName
            // 
            this.pnlName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlName.BackColor = System.Drawing.Color.DarkGray;
            this.pnlName.Controls.Add(this.pnlNameHolder);
            this.pnlName.Controls.Add(this.label2);
            this.pnlName.Location = new System.Drawing.Point(177, 60);
            this.pnlName.Name = "pnlName";
            this.pnlName.Size = new System.Drawing.Size(223, 25);
            this.pnlName.TabIndex = 5;
            // 
            // pnlNameHolder
            // 
            this.pnlNameHolder.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlNameHolder.BackColor = System.Drawing.Color.White;
            this.pnlNameHolder.Controls.Add(this.txtName);
            this.pnlNameHolder.Cursor = System.Windows.Forms.Cursors.Default;
            this.pnlNameHolder.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlNameHolder.Location = new System.Drawing.Point(73, 0);
            this.pnlNameHolder.Name = "pnlNameHolder";
            this.pnlNameHolder.Size = new System.Drawing.Size(150, 24);
            this.pnlNameHolder.TabIndex = 0;
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtName.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtName.ForeColor = System.Drawing.Color.Black;
            this.txtName.Location = new System.Drawing.Point(5, 5);
            this.txtName.MaxLength = 255;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(143, 16);
            this.txtName.TabIndex = 0;
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
            this.label2.Size = new System.Drawing.Size(44, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Name*";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlDistrict
            // 
            this.pnlDistrict.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlDistrict.BackColor = System.Drawing.Color.DarkGray;
            this.pnlDistrict.Controls.Add(this.pnlDistrictHolder);
            this.pnlDistrict.Controls.Add(this.label4);
            this.pnlDistrict.Location = new System.Drawing.Point(0, 30);
            this.pnlDistrict.Name = "pnlDistrict";
            this.pnlDistrict.Size = new System.Drawing.Size(400, 25);
            this.pnlDistrict.TabIndex = 2;
            // 
            // pnlDistrictHolder
            // 
            this.pnlDistrictHolder.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlDistrictHolder.BackColor = System.Drawing.Color.White;
            this.pnlDistrictHolder.Controls.Add(this.panel2);
            this.pnlDistrictHolder.Cursor = System.Windows.Forms.Cursors.Default;
            this.pnlDistrictHolder.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.pnlDistrictHolder.Location = new System.Drawing.Point(73, 0);
            this.pnlDistrictHolder.Name = "pnlDistrictHolder";
            this.pnlDistrictHolder.Size = new System.Drawing.Size(327, 24);
            this.pnlDistrictHolder.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.cboDistrict);
            this.panel2.Location = new System.Drawing.Point(3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(322, 21);
            this.panel2.TabIndex = 9;
            // 
            // cboDistrict
            // 
            this.cboDistrict.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboDistrict.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboDistrict.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboDistrict.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDistrict.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboDistrict.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cboDistrict.FormattingEnabled = true;
            this.cboDistrict.Location = new System.Drawing.Point(-1, -1);
            this.cboDistrict.Name = "cboDistrict";
            this.cboDistrict.Size = new System.Drawing.Size(324, 23);
            this.cboDistrict.TabIndex = 0;
            this.cboDistrict.SelectedValueChanged += new System.EventHandler(this.cboDistrict_SelectedValueChanged);
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
            this.label4.Size = new System.Drawing.Size(49, 15);
            this.label4.TabIndex = 3;
            this.label4.Text = "District*";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnLastCode
            // 
            this.btnLastCode.BackColor = System.Drawing.Color.Silver;
            this.btnLastCode.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLastCode.FlatAppearance.BorderSize = 0;
            this.btnLastCode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLastCode.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnLastCode.ForeColor = System.Drawing.Color.Black;
            this.btnLastCode.Image = global::ABC.CarTraders.Properties.Resources.search_database_dark_15px;
            this.btnLastCode.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLastCode.Location = new System.Drawing.Point(147, 60);
            this.btnLastCode.Name = "btnLastCode";
            this.btnLastCode.Size = new System.Drawing.Size(25, 25);
            this.btnLastCode.TabIndex = 4;
            this.btnLastCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTip1.SetToolTip(this.btnLastCode, "Get last saved VS Range (by code) saved in the Database");
            this.btnLastCode.UseVisualStyleBackColor = false;
            this.btnLastCode.Click += new System.EventHandler(this.btnLastCode_Click);
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
            this.btnSave.Location = new System.Drawing.Point(340, 145);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(60, 25);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "SAVE";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTip1.SetToolTip(this.btnSave, "Save (Ctrl+S)");
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnToDatabase
            // 
            this.btnToDatabase.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnToDatabase.BackColor = System.Drawing.Color.Goldenrod;
            this.btnToDatabase.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnToDatabase.FlatAppearance.BorderSize = 0;
            this.btnToDatabase.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnToDatabase.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnToDatabase.ForeColor = System.Drawing.Color.Black;
            this.btnToDatabase.Image = global::ABC.CarTraders.Properties.Resources.database_restore_dark_15px;
            this.btnToDatabase.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnToDatabase.Location = new System.Drawing.Point(280, 145);
            this.btnToDatabase.Name = "btnToDatabase";
            this.btnToDatabase.Size = new System.Drawing.Size(25, 25);
            this.btnToDatabase.TabIndex = 7;
            this.btnToDatabase.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTip1.SetToolTip(this.btnToDatabase, "Upload to Database (Ctrl+Shift+S)");
            this.btnToDatabase.UseVisualStyleBackColor = false;
            this.btnToDatabase.Click += new System.EventHandler(this.btnToDatabase_Click);
            // 
            // btnNew
            // 
            this.btnNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNew.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnNew.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNew.FlatAppearance.BorderSize = 0;
            this.btnNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNew.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnNew.ForeColor = System.Drawing.Color.Black;
            this.btnNew.Image = global::ABC.CarTraders.Properties.Resources.add_dark_15px;
            this.btnNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNew.Location = new System.Drawing.Point(310, 145);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(25, 25);
            this.btnNew.TabIndex = 8;
            this.btnNew.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTip1.SetToolTip(this.btnNew, "New  (Ctrl+N)");
            this.btnNew.UseVisualStyleBackColor = false;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnFind
            // 
            this.btnFind.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFind.BackColor = System.Drawing.Color.Silver;
            this.btnFind.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFind.FlatAppearance.BorderSize = 0;
            this.btnFind.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFind.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnFind.ForeColor = System.Drawing.Color.Black;
            this.btnFind.Image = global::ABC.CarTraders.Properties.Resources.search_dark_15px;
            this.btnFind.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFind.Location = new System.Drawing.Point(122, 60);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(25, 25);
            this.btnFind.TabIndex = 14;
            this.btnFind.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTip1.SetToolTip(this.btnFind, "Find VS Range");
            this.btnFind.UseVisualStyleBackColor = false;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lblProgress
            // 
            this.lblProgress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblProgress.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblProgress.ForeColor = System.Drawing.Color.Black;
            this.lblProgress.Image = global::ABC.CarTraders.Properties.Resources.ok_dark_15px;
            this.lblProgress.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblProgress.Location = new System.Drawing.Point(3, 150);
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Size = new System.Drawing.Size(271, 15);
            this.lblProgress.TabIndex = 12;
            this.lblProgress.Text = "      Ready";
            this.lblProgress.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlNotes
            // 
            this.pnlNotes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlNotes.BackColor = System.Drawing.Color.DarkGray;
            this.pnlNotes.Controls.Add(this.pnlNotesHolder);
            this.pnlNotes.Controls.Add(this.label3);
            this.pnlNotes.Location = new System.Drawing.Point(0, 90);
            this.pnlNotes.Name = "pnlNotes";
            this.pnlNotes.Size = new System.Drawing.Size(400, 50);
            this.pnlNotes.TabIndex = 6;
            // 
            // pnlNotesHolder
            // 
            this.pnlNotesHolder.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlNotesHolder.BackColor = System.Drawing.Color.White;
            this.pnlNotesHolder.Controls.Add(this.txtNotes);
            this.pnlNotesHolder.Cursor = System.Windows.Forms.Cursors.Default;
            this.pnlNotesHolder.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlNotesHolder.Location = new System.Drawing.Point(73, 0);
            this.pnlNotesHolder.Name = "pnlNotesHolder";
            this.pnlNotesHolder.Size = new System.Drawing.Size(327, 49);
            this.pnlNotesHolder.TabIndex = 0;
            // 
            // txtNotes
            // 
            this.txtNotes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNotes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtNotes.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtNotes.ForeColor = System.Drawing.Color.Black;
            this.txtNotes.Location = new System.Drawing.Point(5, 5);
            this.txtNotes.MaxLength = 1023;
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtNotes.Size = new System.Drawing.Size(320, 41);
            this.txtNotes.TabIndex = 0;
            this.txtNotes.Text = "Line 1\r\nLine 2\r\nLine 3";
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
            this.label3.Size = new System.Drawing.Size(38, 15);
            this.label3.TabIndex = 3;
            this.label3.Text = "Notes";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlLoadingCircle
            // 
            this.pnlLoadingCircle.Location = new System.Drawing.Point(2, 148);
            this.pnlLoadingCircle.Name = "pnlLoadingCircle";
            this.pnlLoadingCircle.Size = new System.Drawing.Size(20, 20);
            this.pnlLoadingCircle.TabIndex = 13;
            this.pnlLoadingCircle.Visible = false;
            // 
            // pnlDataHolder
            // 
            this.pnlDataHolder.BackColor = System.Drawing.Color.Transparent;
            this.pnlDataHolder.Controls.Add(this.pnlProvince);
            this.pnlDataHolder.Controls.Add(this.btnFind);
            this.pnlDataHolder.Controls.Add(this.btnSave);
            this.pnlDataHolder.Controls.Add(this.btnToDatabase);
            this.pnlDataHolder.Controls.Add(this.btnNew);
            this.pnlDataHolder.Controls.Add(this.pnlName);
            this.pnlDataHolder.Controls.Add(this.pnlLoadingCircle);
            this.pnlDataHolder.Controls.Add(this.pnlNotes);
            this.pnlDataHolder.Controls.Add(this.pnlDistrict);
            this.pnlDataHolder.Controls.Add(this.lblProgress);
            this.pnlDataHolder.Controls.Add(this.pnlVsCode);
            this.pnlDataHolder.Controls.Add(this.btnLastCode);
            this.pnlDataHolder.Location = new System.Drawing.Point(5, 5);
            this.pnlDataHolder.Name = "pnlDataHolder";
            this.pnlDataHolder.Size = new System.Drawing.Size(400, 170);
            this.pnlDataHolder.TabIndex = 15;
            // 
            // pnlProvince
            // 
            this.pnlProvince.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlProvince.BackColor = System.Drawing.Color.DarkGray;
            this.pnlProvince.Controls.Add(this.pnlFilter1Holder);
            this.pnlProvince.Controls.Add(this.label6);
            this.pnlProvince.Location = new System.Drawing.Point(0, 0);
            this.pnlProvince.Name = "pnlProvince";
            this.pnlProvince.Size = new System.Drawing.Size(400, 25);
            this.pnlProvince.TabIndex = 15;
            // 
            // pnlFilter1Holder
            // 
            this.pnlFilter1Holder.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlFilter1Holder.BackColor = System.Drawing.Color.White;
            this.pnlFilter1Holder.Controls.Add(this.panel4);
            this.pnlFilter1Holder.Cursor = System.Windows.Forms.Cursors.Default;
            this.pnlFilter1Holder.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.pnlFilter1Holder.Location = new System.Drawing.Point(73, 0);
            this.pnlFilter1Holder.Name = "pnlFilter1Holder";
            this.pnlFilter1Holder.Size = new System.Drawing.Size(327, 24);
            this.pnlFilter1Holder.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.Controls.Add(this.cboProvince);
            this.panel4.Location = new System.Drawing.Point(3, 2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(322, 21);
            this.panel4.TabIndex = 0;
            // 
            // cboProvince
            // 
            this.cboProvince.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboProvince.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboProvince.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboProvince.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboProvince.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboProvince.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cboProvince.FormattingEnabled = true;
            this.cboProvince.Location = new System.Drawing.Point(-1, -1);
            this.cboProvince.Name = "cboProvince";
            this.cboProvince.Size = new System.Drawing.Size(324, 23);
            this.cboProvince.TabIndex = 0;
            this.cboProvince.SelectedValueChanged += new System.EventHandler(this.cboProvince_SelectedValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Cursor = System.Windows.Forms.Cursors.Default;
            this.label6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label6.Location = new System.Drawing.Point(3, 5);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 15);
            this.label6.TabIndex = 3;
            this.label6.Text = "Province*";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // VsRangeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(410, 180);
            this.Controls.Add(this.pnlDataHolder);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "VsRangeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add New VS Range";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.VsRangeForm_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.VsRangeForm_KeyDown);
            this.pnlVsCode.ResumeLayout(false);
            this.pnlVsCode.PerformLayout();
            this.pnlVsCodeHolder.ResumeLayout(false);
            this.pnlNudCodeHolder.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudCode)).EndInit();
            this.pnlName.ResumeLayout(false);
            this.pnlName.PerformLayout();
            this.pnlNameHolder.ResumeLayout(false);
            this.pnlNameHolder.PerformLayout();
            this.pnlDistrict.ResumeLayout(false);
            this.pnlDistrict.PerformLayout();
            this.pnlDistrictHolder.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.pnlNotes.ResumeLayout(false);
            this.pnlNotes.PerformLayout();
            this.pnlNotesHolder.ResumeLayout(false);
            this.pnlNotesHolder.PerformLayout();
            this.pnlDataHolder.ResumeLayout(false);
            this.pnlProvince.ResumeLayout(false);
            this.pnlProvince.PerformLayout();
            this.pnlFilter1Holder.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlVsCode;
        private System.Windows.Forms.Panel pnlVsCodeHolder;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnlName;
        private System.Windows.Forms.Panel pnlNameHolder;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel pnlDistrict;
        private System.Windows.Forms.Panel pnlDistrictHolder;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ComboBox cboDistrict;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel pnlNudCodeHolder;
        private System.Windows.Forms.NumericUpDown nudCode;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btnLastCode;
        private System.Windows.Forms.Label lblProgress;
        private System.Windows.Forms.Panel pnlNotes;
        private System.Windows.Forms.Panel pnlNotesHolder;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel pnlLoadingCircle;
        private System.Windows.Forms.Panel pnlDataHolder;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnToDatabase;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.Panel pnlProvince;
        private System.Windows.Forms.Panel pnlFilter1Holder;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.ComboBox cboProvince;
        private System.Windows.Forms.Label label6;
    }
}