namespace ABC.CarTraders.GUI.Forms
{
    partial class CarPartForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CarPartForm));
            this.pnlNotes = new System.Windows.Forms.Panel();
            this.pnlNotesHolder = new System.Windows.Forms.Panel();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.pnlName = new System.Windows.Forms.Panel();
            this.pnlNameHolder = new System.Windows.Forms.Panel();
            this.txtPartName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnSave = new System.Windows.Forms.Button();
            this.pnlRoleHolder = new System.Windows.Forms.Panel();
            this.pnlCboHolder = new System.Windows.Forms.Panel();
            this.cboCar = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.pnlRole = new System.Windows.Forms.Panel();
            this.pnlLoadingCircle = new System.Windows.Forms.Panel();
            this.lblProgress = new System.Windows.Forms.Label();
            this.pnlDataHolder = new System.Windows.Forms.Panel();
            this.panel17 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.panel18 = new System.Windows.Forms.Panel();
            this.panel19 = new System.Windows.Forms.Panel();
            this.nudStock = new System.Windows.Forms.NumericUpDown();
            this.pnlPort = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlPortHolder = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.nudPrice = new System.Windows.Forms.NumericUpDown();
            this.panel9 = new System.Windows.Forms.Panel();
            this.panel11 = new System.Windows.Forms.Panel();
            this.txtImagePath = new System.Windows.Forms.TextBox();
            this.btnBrowseImage = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.panel8 = new System.Windows.Forms.Panel();
            this.panel10 = new System.Windows.Forms.Panel();
            this.picImage = new System.Windows.Forms.PictureBox();
            this.label10 = new System.Windows.Forms.Label();
            this.pnlNotes.SuspendLayout();
            this.pnlNotesHolder.SuspendLayout();
            this.pnlName.SuspendLayout();
            this.pnlNameHolder.SuspendLayout();
            this.pnlRoleHolder.SuspendLayout();
            this.pnlCboHolder.SuspendLayout();
            this.pnlRole.SuspendLayout();
            this.pnlDataHolder.SuspendLayout();
            this.panel17.SuspendLayout();
            this.panel18.SuspendLayout();
            this.panel19.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudStock)).BeginInit();
            this.pnlPort.SuspendLayout();
            this.pnlPortHolder.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPrice)).BeginInit();
            this.panel9.SuspendLayout();
            this.panel11.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlNotes
            // 
            this.pnlNotes.BackColor = System.Drawing.Color.DarkGray;
            this.pnlNotes.Controls.Add(this.pnlNotesHolder);
            this.pnlNotes.Controls.Add(this.label3);
            this.pnlNotes.Location = new System.Drawing.Point(0, 120);
            this.pnlNotes.Name = "pnlNotes";
            this.pnlNotes.Size = new System.Drawing.Size(360, 50);
            this.pnlNotes.TabIndex = 4;
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
            this.pnlNotesHolder.Size = new System.Drawing.Size(287, 49);
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
            this.txtNotes.Size = new System.Drawing.Size(280, 41);
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
            // pnlName
            // 
            this.pnlName.BackColor = System.Drawing.Color.DarkGray;
            this.pnlName.Controls.Add(this.pnlNameHolder);
            this.pnlName.Controls.Add(this.label2);
            this.pnlName.Location = new System.Drawing.Point(0, 0);
            this.pnlName.Name = "pnlName";
            this.pnlName.Size = new System.Drawing.Size(360, 25);
            this.pnlName.TabIndex = 0;
            // 
            // pnlNameHolder
            // 
            this.pnlNameHolder.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlNameHolder.BackColor = System.Drawing.Color.White;
            this.pnlNameHolder.Controls.Add(this.txtPartName);
            this.pnlNameHolder.Cursor = System.Windows.Forms.Cursors.Default;
            this.pnlNameHolder.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlNameHolder.Location = new System.Drawing.Point(90, 0);
            this.pnlNameHolder.Name = "pnlNameHolder";
            this.pnlNameHolder.Size = new System.Drawing.Size(270, 24);
            this.pnlNameHolder.TabIndex = 0;
            // 
            // txtPartName
            // 
            this.txtPartName.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPartName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPartName.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtPartName.ForeColor = System.Drawing.Color.Black;
            this.txtPartName.Location = new System.Drawing.Point(5, 5);
            this.txtPartName.MaxLength = 255;
            this.txtPartName.Name = "txtPartName";
            this.txtPartName.Size = new System.Drawing.Size(263, 16);
            this.txtPartName.TabIndex = 0;
            this.txtPartName.Text = "A. B. C. Dumbledore";
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
            this.label2.Size = new System.Drawing.Size(68, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Part Name*";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnSave.ForeColor = System.Drawing.Color.Black;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(295, 383);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(65, 25);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "SAVE";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTip1.SetToolTip(this.btnSave, "Save (Ctrl+S)");
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // pnlRoleHolder
            // 
            this.pnlRoleHolder.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlRoleHolder.BackColor = System.Drawing.Color.White;
            this.pnlRoleHolder.Controls.Add(this.pnlCboHolder);
            this.pnlRoleHolder.Cursor = System.Windows.Forms.Cursors.Default;
            this.pnlRoleHolder.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlRoleHolder.Location = new System.Drawing.Point(73, 0);
            this.pnlRoleHolder.Name = "pnlRoleHolder";
            this.pnlRoleHolder.Size = new System.Drawing.Size(287, 24);
            this.pnlRoleHolder.TabIndex = 0;
            // 
            // pnlCboHolder
            // 
            this.pnlCboHolder.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlCboHolder.Controls.Add(this.cboCar);
            this.pnlCboHolder.Location = new System.Drawing.Point(3, 2);
            this.pnlCboHolder.Name = "pnlCboHolder";
            this.pnlCboHolder.Size = new System.Drawing.Size(282, 21);
            this.pnlCboHolder.TabIndex = 1;
            // 
            // cboCar
            // 
            this.cboCar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboCar.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboCar.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboCar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboCar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cboCar.FormattingEnabled = true;
            this.cboCar.Location = new System.Drawing.Point(-1, -1);
            this.cboCar.Name = "cboCar";
            this.cboCar.Size = new System.Drawing.Size(284, 23);
            this.cboCar.TabIndex = 0;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Cursor = System.Windows.Forms.Cursors.Default;
            this.label9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label9.Location = new System.Drawing.Point(3, 5);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(25, 15);
            this.label9.TabIndex = 3;
            this.label9.Text = "Car";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlRole
            // 
            this.pnlRole.BackColor = System.Drawing.Color.DarkGray;
            this.pnlRole.Controls.Add(this.pnlRoleHolder);
            this.pnlRole.Controls.Add(this.label9);
            this.pnlRole.Location = new System.Drawing.Point(0, 60);
            this.pnlRole.Name = "pnlRole";
            this.pnlRole.Size = new System.Drawing.Size(360, 25);
            this.pnlRole.TabIndex = 2;
            // 
            // pnlLoadingCircle
            // 
            this.pnlLoadingCircle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pnlLoadingCircle.Location = new System.Drawing.Point(2, 386);
            this.pnlLoadingCircle.Name = "pnlLoadingCircle";
            this.pnlLoadingCircle.Size = new System.Drawing.Size(20, 20);
            this.pnlLoadingCircle.TabIndex = 31;
            this.pnlLoadingCircle.Visible = false;
            // 
            // lblProgress
            // 
            this.lblProgress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblProgress.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblProgress.ForeColor = System.Drawing.Color.Black;
            this.lblProgress.Image = global::ABC.CarTraders.Properties.Resources.ok_dark_15px;
            this.lblProgress.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblProgress.Location = new System.Drawing.Point(3, 388);
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Size = new System.Drawing.Size(231, 15);
            this.lblProgress.TabIndex = 30;
            this.lblProgress.Text = "      Ready";
            this.lblProgress.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlDataHolder
            // 
            this.pnlDataHolder.BackColor = System.Drawing.Color.Transparent;
            this.pnlDataHolder.Controls.Add(this.panel17);
            this.pnlDataHolder.Controls.Add(this.pnlPort);
            this.pnlDataHolder.Controls.Add(this.btnSave);
            this.pnlDataHolder.Controls.Add(this.pnlLoadingCircle);
            this.pnlDataHolder.Controls.Add(this.pnlRole);
            this.pnlDataHolder.Controls.Add(this.lblProgress);
            this.pnlDataHolder.Controls.Add(this.pnlName);
            this.pnlDataHolder.Controls.Add(this.pnlNotes);
            this.pnlDataHolder.Location = new System.Drawing.Point(5, 5);
            this.pnlDataHolder.Name = "pnlDataHolder";
            this.pnlDataHolder.Size = new System.Drawing.Size(360, 408);
            this.pnlDataHolder.TabIndex = 32;
            // 
            // panel17
            // 
            this.panel17.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel17.BackColor = System.Drawing.Color.DarkGray;
            this.panel17.Controls.Add(this.label8);
            this.panel17.Controls.Add(this.panel18);
            this.panel17.Location = new System.Drawing.Point(0, 90);
            this.panel17.Name = "panel17";
            this.panel17.Size = new System.Drawing.Size(359, 25);
            this.panel17.TabIndex = 3;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Cursor = System.Windows.Forms.Cursors.Default;
            this.label8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label8.Location = new System.Drawing.Point(3, 5);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 15);
            this.label8.TabIndex = 3;
            this.label8.Text = "Stock*";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel18
            // 
            this.panel18.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel18.BackColor = System.Drawing.Color.White;
            this.panel18.Controls.Add(this.panel19);
            this.panel18.Cursor = System.Windows.Forms.Cursors.Default;
            this.panel18.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel18.Location = new System.Drawing.Point(73, 0);
            this.panel18.Name = "panel18";
            this.panel18.Size = new System.Drawing.Size(286, 24);
            this.panel18.TabIndex = 0;
            // 
            // panel19
            // 
            this.panel19.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel19.Controls.Add(this.nudStock);
            this.panel19.Location = new System.Drawing.Point(5, 5);
            this.panel19.Name = "panel19";
            this.panel19.Size = new System.Drawing.Size(278, 19);
            this.panel19.TabIndex = 0;
            // 
            // nudStock
            // 
            this.nudStock.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nudStock.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.nudStock.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.nudStock.Location = new System.Drawing.Point(0, 0);
            this.nudStock.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.nudStock.Name = "nudStock";
            this.nudStock.Size = new System.Drawing.Size(280, 19);
            this.nudStock.TabIndex = 0;
            this.nudStock.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // pnlPort
            // 
            this.pnlPort.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlPort.BackColor = System.Drawing.Color.DarkGray;
            this.pnlPort.Controls.Add(this.label1);
            this.pnlPort.Controls.Add(this.pnlPortHolder);
            this.pnlPort.Location = new System.Drawing.Point(0, 30);
            this.pnlPort.Name = "pnlPort";
            this.pnlPort.Size = new System.Drawing.Size(359, 25);
            this.pnlPort.TabIndex = 1;
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
            this.label1.Size = new System.Drawing.Size(38, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "Price*";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlPortHolder
            // 
            this.pnlPortHolder.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlPortHolder.BackColor = System.Drawing.Color.White;
            this.pnlPortHolder.Controls.Add(this.panel1);
            this.pnlPortHolder.Cursor = System.Windows.Forms.Cursors.Default;
            this.pnlPortHolder.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlPortHolder.Location = new System.Drawing.Point(73, 0);
            this.pnlPortHolder.Name = "pnlPortHolder";
            this.pnlPortHolder.Size = new System.Drawing.Size(286, 24);
            this.pnlPortHolder.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.nudPrice);
            this.panel1.Location = new System.Drawing.Point(5, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(278, 19);
            this.panel1.TabIndex = 0;
            // 
            // nudPrice
            // 
            this.nudPrice.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nudPrice.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.nudPrice.DecimalPlaces = 2;
            this.nudPrice.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.nudPrice.Location = new System.Drawing.Point(0, 0);
            this.nudPrice.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.nudPrice.Name = "nudPrice";
            this.nudPrice.Size = new System.Drawing.Size(280, 19);
            this.nudPrice.TabIndex = 0;
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.Color.Transparent;
            this.panel9.Controls.Add(this.panel11);
            this.panel9.Controls.Add(this.btnBrowseImage);
            this.panel9.Controls.Add(this.btnClear);
            this.panel9.Controls.Add(this.panel8);
            this.panel9.Location = new System.Drawing.Point(370, 5);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(400, 408);
            this.panel9.TabIndex = 33;
            // 
            // panel11
            // 
            this.panel11.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel11.BackColor = System.Drawing.Color.White;
            this.panel11.Controls.Add(this.txtImagePath);
            this.panel11.Cursor = System.Windows.Forms.Cursors.Default;
            this.panel11.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel11.Location = new System.Drawing.Point(1, 383);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(275, 24);
            this.panel11.TabIndex = 0;
            // 
            // txtImagePath
            // 
            this.txtImagePath.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtImagePath.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtImagePath.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtImagePath.ForeColor = System.Drawing.Color.Black;
            this.txtImagePath.Location = new System.Drawing.Point(5, 5);
            this.txtImagePath.MaxLength = 255;
            this.txtImagePath.Name = "txtImagePath";
            this.txtImagePath.Size = new System.Drawing.Size(268, 16);
            this.txtImagePath.TabIndex = 0;
            // 
            // btnBrowseImage
            // 
            this.btnBrowseImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowseImage.BackColor = System.Drawing.Color.NavajoWhite;
            this.btnBrowseImage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBrowseImage.FlatAppearance.BorderSize = 0;
            this.btnBrowseImage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBrowseImage.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnBrowseImage.ForeColor = System.Drawing.Color.Black;
            this.btnBrowseImage.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBrowseImage.Location = new System.Drawing.Point(282, 383);
            this.btnBrowseImage.Name = "btnBrowseImage";
            this.btnBrowseImage.Size = new System.Drawing.Size(62, 25);
            this.btnBrowseImage.TabIndex = 10;
            this.btnBrowseImage.Text = "BROWSE";
            this.btnBrowseImage.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBrowseImage.UseVisualStyleBackColor = false;
            this.btnBrowseImage.Click += new System.EventHandler(this.btnBrowseImage_Click);
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.BackColor = System.Drawing.Color.DarkGray;
            this.btnClear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClear.FlatAppearance.BorderSize = 0;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnClear.ForeColor = System.Drawing.Color.Black;
            this.btnClear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClear.Location = new System.Drawing.Point(349, 383);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(51, 25);
            this.btnClear.TabIndex = 11;
            this.btnClear.Text = "CLEAR";
            this.btnClear.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // panel8
            // 
            this.panel8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel8.BackColor = System.Drawing.Color.DarkGray;
            this.panel8.Controls.Add(this.panel10);
            this.panel8.Controls.Add(this.label10);
            this.panel8.Location = new System.Drawing.Point(0, 0);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(400, 377);
            this.panel8.TabIndex = 8;
            // 
            // panel10
            // 
            this.panel10.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel10.BackColor = System.Drawing.Color.White;
            this.panel10.Controls.Add(this.picImage);
            this.panel10.Cursor = System.Windows.Forms.Cursors.Default;
            this.panel10.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel10.Location = new System.Drawing.Point(0, 25);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(400, 352);
            this.panel10.TabIndex = 0;
            // 
            // picImage
            // 
            this.picImage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picImage.BackColor = System.Drawing.Color.White;
            this.picImage.Location = new System.Drawing.Point(5, 5);
            this.picImage.Name = "picImage";
            this.picImage.Size = new System.Drawing.Size(395, 347);
            this.picImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picImage.TabIndex = 16;
            this.picImage.TabStop = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Cursor = System.Windows.Forms.Cursors.Default;
            this.label10.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label10.Location = new System.Drawing.Point(3, 5);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(40, 15);
            this.label10.TabIndex = 3;
            this.label10.Text = "Image";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CarPartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(774, 419);
            this.Controls.Add(this.panel9);
            this.Controls.Add(this.pnlDataHolder);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CarPartForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add New Car Part";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.UserForm_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.UserForm_KeyDown);
            this.pnlNotes.ResumeLayout(false);
            this.pnlNotes.PerformLayout();
            this.pnlNotesHolder.ResumeLayout(false);
            this.pnlNotesHolder.PerformLayout();
            this.pnlName.ResumeLayout(false);
            this.pnlName.PerformLayout();
            this.pnlNameHolder.ResumeLayout(false);
            this.pnlNameHolder.PerformLayout();
            this.pnlRoleHolder.ResumeLayout(false);
            this.pnlCboHolder.ResumeLayout(false);
            this.pnlRole.ResumeLayout(false);
            this.pnlRole.PerformLayout();
            this.pnlDataHolder.ResumeLayout(false);
            this.panel17.ResumeLayout(false);
            this.panel17.PerformLayout();
            this.panel18.ResumeLayout(false);
            this.panel19.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudStock)).EndInit();
            this.pnlPort.ResumeLayout(false);
            this.pnlPort.PerformLayout();
            this.pnlPortHolder.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudPrice)).EndInit();
            this.panel9.ResumeLayout(false);
            this.panel11.ResumeLayout(false);
            this.panel11.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.panel10.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Panel pnlNotes;
        private System.Windows.Forms.Panel pnlNotesHolder;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel pnlName;
        private System.Windows.Forms.Panel pnlNameHolder;
        private System.Windows.Forms.TextBox txtPartName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel pnlRoleHolder;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel pnlRole;
        private System.Windows.Forms.Panel pnlCboHolder;
        private System.Windows.Forms.ComboBox cboCar;
        private System.Windows.Forms.Panel pnlLoadingCircle;
        private System.Windows.Forms.Label lblProgress;
        private System.Windows.Forms.Panel pnlDataHolder;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.PictureBox picImage;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnBrowseImage;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.TextBox txtImagePath;
        private System.Windows.Forms.Panel pnlPort;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnlPortHolder;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.NumericUpDown nudPrice;
        private System.Windows.Forms.Panel panel17;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel18;
        private System.Windows.Forms.Panel panel19;
        private System.Windows.Forms.NumericUpDown nudStock;
    }
}