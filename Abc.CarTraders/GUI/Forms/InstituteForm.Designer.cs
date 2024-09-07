namespace ABC.CarTraders.GUI.Forms
{
    partial class InstituteForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InstituteForm));
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnSave = new System.Windows.Forms.Button();
            this.btnToDatabase = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnConvert = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pnlDataHolder = new System.Windows.Forms.Panel();
            this.pnlName = new System.Windows.Forms.Panel();
            this.pnlNameHolder = new System.Windows.Forms.Panel();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pnlLoadingCircle = new System.Windows.Forms.Panel();
            this.pnlNotes = new System.Windows.Forms.Panel();
            this.pnlNotesHolder = new System.Windows.Forms.Panel();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblProgress = new System.Windows.Forms.Label();
            this.pnlVsRange = new System.Windows.Forms.Panel();
            this.pnlVsRangeHolder = new System.Windows.Forms.Panel();
            this.chkVsRange = new System.Windows.Forms.CheckBox();
            this.pnlCboVsRangeHolder = new System.Windows.Forms.Panel();
            this.cboVsRange = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.pnlDataHolder.SuspendLayout();
            this.pnlName.SuspendLayout();
            this.pnlNameHolder.SuspendLayout();
            this.pnlNotes.SuspendLayout();
            this.pnlNotesHolder.SuspendLayout();
            this.pnlVsRange.SuspendLayout();
            this.pnlVsRangeHolder.SuspendLayout();
            this.pnlCboVsRangeHolder.SuspendLayout();
            this.SuspendLayout();
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
            this.btnSave.Location = new System.Drawing.Point(340, 85);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(60, 25);
            this.btnSave.TabIndex = 6;
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
            this.btnToDatabase.Location = new System.Drawing.Point(280, 85);
            this.btnToDatabase.Name = "btnToDatabase";
            this.btnToDatabase.Size = new System.Drawing.Size(25, 25);
            this.btnToDatabase.TabIndex = 4;
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
            this.btnNew.Location = new System.Drawing.Point(310, 85);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(25, 25);
            this.btnNew.TabIndex = 5;
            this.btnNew.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTip1.SetToolTip(this.btnNew, "New  (Ctrl+N)");
            this.btnNew.UseVisualStyleBackColor = false;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnConvert
            // 
            this.btnConvert.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConvert.BackColor = System.Drawing.Color.Silver;
            this.btnConvert.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConvert.Enabled = false;
            this.btnConvert.FlatAppearance.BorderSize = 0;
            this.btnConvert.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConvert.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnConvert.ForeColor = System.Drawing.Color.Black;
            this.btnConvert.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConvert.Location = new System.Drawing.Point(335, 120);
            this.btnConvert.Name = "btnConvert";
            this.btnConvert.Size = new System.Drawing.Size(70, 25);
            this.btnConvert.TabIndex = 2;
            this.btnConvert.Text = "CONVERT";
            this.toolTip1.SetToolTip(this.btnConvert, "Convert to VS Range");
            this.btnConvert.UseVisualStyleBackColor = false;
            this.btnConvert.Click += new System.EventHandler(this.btnConvert_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // pnlDataHolder
            // 
            this.pnlDataHolder.BackColor = System.Drawing.Color.Transparent;
            this.pnlDataHolder.Controls.Add(this.btnSave);
            this.pnlDataHolder.Controls.Add(this.pnlName);
            this.pnlDataHolder.Controls.Add(this.pnlLoadingCircle);
            this.pnlDataHolder.Controls.Add(this.btnToDatabase);
            this.pnlDataHolder.Controls.Add(this.pnlNotes);
            this.pnlDataHolder.Controls.Add(this.lblProgress);
            this.pnlDataHolder.Controls.Add(this.btnNew);
            this.pnlDataHolder.Location = new System.Drawing.Point(5, 5);
            this.pnlDataHolder.Name = "pnlDataHolder";
            this.pnlDataHolder.Size = new System.Drawing.Size(400, 110);
            this.pnlDataHolder.TabIndex = 16;
            // 
            // pnlName
            // 
            this.pnlName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlName.BackColor = System.Drawing.Color.DarkGray;
            this.pnlName.Controls.Add(this.pnlNameHolder);
            this.pnlName.Controls.Add(this.label2);
            this.pnlName.Location = new System.Drawing.Point(0, 0);
            this.pnlName.Name = "pnlName";
            this.pnlName.Size = new System.Drawing.Size(400, 25);
            this.pnlName.TabIndex = 1;
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
            this.pnlNameHolder.Size = new System.Drawing.Size(327, 24);
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
            this.txtName.Size = new System.Drawing.Size(320, 16);
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
            // pnlLoadingCircle
            // 
            this.pnlLoadingCircle.Location = new System.Drawing.Point(2, 88);
            this.pnlLoadingCircle.Name = "pnlLoadingCircle";
            this.pnlLoadingCircle.Size = new System.Drawing.Size(20, 20);
            this.pnlLoadingCircle.TabIndex = 13;
            this.pnlLoadingCircle.Visible = false;
            // 
            // pnlNotes
            // 
            this.pnlNotes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlNotes.BackColor = System.Drawing.Color.DarkGray;
            this.pnlNotes.Controls.Add(this.pnlNotesHolder);
            this.pnlNotes.Controls.Add(this.label3);
            this.pnlNotes.Location = new System.Drawing.Point(0, 30);
            this.pnlNotes.Name = "pnlNotes";
            this.pnlNotes.Size = new System.Drawing.Size(400, 50);
            this.pnlNotes.TabIndex = 3;
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
            // lblProgress
            // 
            this.lblProgress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblProgress.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblProgress.ForeColor = System.Drawing.Color.Black;
            this.lblProgress.Image = global::ABC.CarTraders.Properties.Resources.ok_dark_15px;
            this.lblProgress.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblProgress.Location = new System.Drawing.Point(3, 90);
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Size = new System.Drawing.Size(271, 15);
            this.lblProgress.TabIndex = 12;
            this.lblProgress.Text = "      Ready";
            this.lblProgress.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlVsRange
            // 
            this.pnlVsRange.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlVsRange.BackColor = System.Drawing.Color.DarkGray;
            this.pnlVsRange.Controls.Add(this.pnlVsRangeHolder);
            this.pnlVsRange.Controls.Add(this.label10);
            this.pnlVsRange.Location = new System.Drawing.Point(5, 120);
            this.pnlVsRange.Name = "pnlVsRange";
            this.pnlVsRange.Size = new System.Drawing.Size(330, 25);
            this.pnlVsRange.TabIndex = 17;
            // 
            // pnlVsRangeHolder
            // 
            this.pnlVsRangeHolder.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlVsRangeHolder.BackColor = System.Drawing.Color.White;
            this.pnlVsRangeHolder.Controls.Add(this.chkVsRange);
            this.pnlVsRangeHolder.Controls.Add(this.pnlCboVsRangeHolder);
            this.pnlVsRangeHolder.Cursor = System.Windows.Forms.Cursors.Default;
            this.pnlVsRangeHolder.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.pnlVsRangeHolder.Location = new System.Drawing.Point(73, 0);
            this.pnlVsRangeHolder.Name = "pnlVsRangeHolder";
            this.pnlVsRangeHolder.Size = new System.Drawing.Size(257, 24);
            this.pnlVsRangeHolder.TabIndex = 0;
            // 
            // chkVsRange
            // 
            this.chkVsRange.AutoSize = true;
            this.chkVsRange.Checked = true;
            this.chkVsRange.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkVsRange.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkVsRange.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.chkVsRange.Location = new System.Drawing.Point(6, 7);
            this.chkVsRange.Name = "chkVsRange";
            this.chkVsRange.Size = new System.Drawing.Size(12, 11);
            this.chkVsRange.TabIndex = 0;
            this.chkVsRange.UseVisualStyleBackColor = true;
            // 
            // pnlCboVsRangeHolder
            // 
            this.pnlCboVsRangeHolder.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlCboVsRangeHolder.Controls.Add(this.cboVsRange);
            this.pnlCboVsRangeHolder.Location = new System.Drawing.Point(20, 2);
            this.pnlCboVsRangeHolder.Name = "pnlCboVsRangeHolder";
            this.pnlCboVsRangeHolder.Size = new System.Drawing.Size(235, 21);
            this.pnlCboVsRangeHolder.TabIndex = 1;
            // 
            // cboVsRange
            // 
            this.cboVsRange.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboVsRange.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboVsRange.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboVsRange.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboVsRange.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboVsRange.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cboVsRange.FormattingEnabled = true;
            this.cboVsRange.Location = new System.Drawing.Point(-1, -1);
            this.cboVsRange.Name = "cboVsRange";
            this.cboVsRange.Size = new System.Drawing.Size(237, 23);
            this.cboVsRange.TabIndex = 0;
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
            this.label10.Size = new System.Drawing.Size(35, 15);
            this.label10.TabIndex = 3;
            this.label10.Text = "To VS";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // InstituteForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(410, 150);
            this.Controls.Add(this.btnConvert);
            this.Controls.Add(this.pnlVsRange);
            this.Controls.Add(this.pnlDataHolder);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "InstituteForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add New Institute";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.InstituteForm_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.InstituteForm_KeyDown);
            this.pnlDataHolder.ResumeLayout(false);
            this.pnlName.ResumeLayout(false);
            this.pnlName.PerformLayout();
            this.pnlNameHolder.ResumeLayout(false);
            this.pnlNameHolder.PerformLayout();
            this.pnlNotes.ResumeLayout(false);
            this.pnlNotes.PerformLayout();
            this.pnlNotesHolder.ResumeLayout(false);
            this.pnlNotesHolder.PerformLayout();
            this.pnlVsRange.ResumeLayout(false);
            this.pnlVsRange.PerformLayout();
            this.pnlVsRangeHolder.ResumeLayout(false);
            this.pnlVsRangeHolder.PerformLayout();
            this.pnlCboVsRangeHolder.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel pnlDataHolder;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnToDatabase;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Panel pnlName;
        private System.Windows.Forms.Panel pnlNameHolder;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel pnlLoadingCircle;
        private System.Windows.Forms.Panel pnlNotes;
        private System.Windows.Forms.Panel pnlNotesHolder;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblProgress;
        private System.Windows.Forms.Button btnConvert;
        private System.Windows.Forms.Panel pnlVsRange;
        private System.Windows.Forms.Panel pnlVsRangeHolder;
        private System.Windows.Forms.CheckBox chkVsRange;
        private System.Windows.Forms.Panel pnlCboVsRangeHolder;
        private System.Windows.Forms.ComboBox cboVsRange;
        private System.Windows.Forms.Label label10;
    }
}