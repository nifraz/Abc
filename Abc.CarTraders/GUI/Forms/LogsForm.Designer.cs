namespace Daph.Breeding.GUI.Forms
{
    partial class LogsForm
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
            this.pnlSeperator = new System.Windows.Forms.Panel();
            this.pnlLoadingCircle = new System.Windows.Forms.Panel();
            this.lblProgress = new System.Windows.Forms.Label();
            this.pnlRadioButton = new System.Windows.Forms.Panel();
            this.pnlRadioButtonHolder = new System.Windows.Forms.Panel();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.btnWeek = new System.Windows.Forms.Button();
            this.btnMonth = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.pnlCalendar = new System.Windows.Forms.Panel();
            this.pnlCalendarHolder = new System.Windows.Forms.Panel();
            this.pnlMonthView = new System.Windows.Forms.Panel();
            this.pnlMonthViewHolder = new System.Windows.Forms.Panel();
            this.pnlRadioButton.SuspendLayout();
            this.pnlRadioButtonHolder.SuspendLayout();
            this.pnlCalendar.SuspendLayout();
            this.pnlMonthView.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlSeperator
            // 
            this.pnlSeperator.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlSeperator.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.pnlSeperator.Location = new System.Drawing.Point(532, 5);
            this.pnlSeperator.Margin = new System.Windows.Forms.Padding(2);
            this.pnlSeperator.Name = "pnlSeperator";
            this.pnlSeperator.Size = new System.Drawing.Size(5, 411);
            this.pnlSeperator.TabIndex = 46;
            // 
            // pnlLoadingCircle
            // 
            this.pnlLoadingCircle.Location = new System.Drawing.Point(7, 395);
            this.pnlLoadingCircle.Name = "pnlLoadingCircle";
            this.pnlLoadingCircle.Size = new System.Drawing.Size(20, 20);
            this.pnlLoadingCircle.TabIndex = 50;
            this.pnlLoadingCircle.Visible = false;
            // 
            // lblProgress
            // 
            this.lblProgress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblProgress.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblProgress.ForeColor = System.Drawing.Color.Black;
            this.lblProgress.Image = global::Daph.Breeding.Properties.Resources.ok_dark_15px;
            this.lblProgress.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblProgress.Location = new System.Drawing.Point(8, 397);
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Size = new System.Drawing.Size(489, 15);
            this.lblProgress.TabIndex = 49;
            this.lblProgress.Text = "      Ready";
            this.lblProgress.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlRadioButton
            // 
            this.pnlRadioButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlRadioButton.BackColor = System.Drawing.Color.Gainsboro;
            this.pnlRadioButton.Controls.Add(this.pnlRadioButtonHolder);
            this.pnlRadioButton.Location = new System.Drawing.Point(542, 391);
            this.pnlRadioButton.Name = "pnlRadioButton";
            this.pnlRadioButton.Size = new System.Drawing.Size(110, 25);
            this.pnlRadioButton.TabIndex = 62;
            // 
            // pnlRadioButtonHolder
            // 
            this.pnlRadioButtonHolder.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlRadioButtonHolder.BackColor = System.Drawing.Color.Transparent;
            this.pnlRadioButtonHolder.Controls.Add(this.radioButton2);
            this.pnlRadioButtonHolder.Controls.Add(this.radioButton1);
            this.pnlRadioButtonHolder.Cursor = System.Windows.Forms.Cursors.Default;
            this.pnlRadioButtonHolder.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlRadioButtonHolder.Location = new System.Drawing.Point(0, 0);
            this.pnlRadioButtonHolder.Name = "pnlRadioButtonHolder";
            this.pnlRadioButtonHolder.Size = new System.Drawing.Size(110, 24);
            this.pnlRadioButtonHolder.TabIndex = 20;
            // 
            // radioButton2
            // 
            this.radioButton2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.radioButton2.AutoSize = true;
            this.radioButton2.Checked = true;
            this.radioButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radioButton2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.radioButton2.Location = new System.Drawing.Point(57, 3);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(45, 19);
            this.radioButton2.TabIndex = 63;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "This";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.radioButton1.AutoSize = true;
            this.radioButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radioButton1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.radioButton1.Location = new System.Drawing.Point(6, 3);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(45, 19);
            this.radioButton1.TabIndex = 63;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Last";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // btnWeek
            // 
            this.btnWeek.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnWeek.BackColor = System.Drawing.Color.Silver;
            this.btnWeek.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnWeek.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnWeek.FlatAppearance.BorderSize = 0;
            this.btnWeek.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnWeek.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnWeek.ForeColor = System.Drawing.Color.Black;
            this.btnWeek.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnWeek.Location = new System.Drawing.Point(707, 391);
            this.btnWeek.Name = "btnWeek";
            this.btnWeek.Size = new System.Drawing.Size(45, 25);
            this.btnWeek.TabIndex = 63;
            this.btnWeek.Text = "Week";
            this.btnWeek.UseVisualStyleBackColor = false;
            // 
            // btnMonth
            // 
            this.btnMonth.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMonth.BackColor = System.Drawing.Color.Silver;
            this.btnMonth.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMonth.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnMonth.FlatAppearance.BorderSize = 0;
            this.btnMonth.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMonth.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMonth.ForeColor = System.Drawing.Color.Black;
            this.btnMonth.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMonth.Location = new System.Drawing.Point(652, 391);
            this.btnMonth.Name = "btnMonth";
            this.btnMonth.Size = new System.Drawing.Size(55, 25);
            this.btnMonth.TabIndex = 64;
            this.btnMonth.Text = "Month";
            this.btnMonth.UseVisualStyleBackColor = false;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.BackColor = System.Drawing.Color.Silver;
            this.btnRefresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefresh.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnRefresh.FlatAppearance.BorderSize = 0;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnRefresh.ForeColor = System.Drawing.Color.Black;
            this.btnRefresh.Image = global::Daph.Breeding.Properties.Resources.refresh_dark_15px;
            this.btnRefresh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRefresh.Location = new System.Drawing.Point(502, 391);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(25, 25);
            this.btnRefresh.TabIndex = 23;
            this.btnRefresh.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRefresh.UseVisualStyleBackColor = false;
            // 
            // pnlCalendar
            // 
            this.pnlCalendar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlCalendar.BackColor = System.Drawing.Color.DarkGray;
            this.pnlCalendar.Controls.Add(this.pnlCalendarHolder);
            this.pnlCalendar.Location = new System.Drawing.Point(5, 5);
            this.pnlCalendar.Name = "pnlCalendar";
            this.pnlCalendar.Size = new System.Drawing.Size(522, 381);
            this.pnlCalendar.TabIndex = 66;
            // 
            // pnlCalendarHolder
            // 
            this.pnlCalendarHolder.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlCalendarHolder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.pnlCalendarHolder.Location = new System.Drawing.Point(0, 0);
            this.pnlCalendarHolder.Name = "pnlCalendarHolder";
            this.pnlCalendarHolder.Size = new System.Drawing.Size(522, 380);
            this.pnlCalendarHolder.TabIndex = 21;
            // 
            // pnlMonthView
            // 
            this.pnlMonthView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlMonthView.BackColor = System.Drawing.Color.DarkGray;
            this.pnlMonthView.Controls.Add(this.pnlMonthViewHolder);
            this.pnlMonthView.Location = new System.Drawing.Point(542, 5);
            this.pnlMonthView.Name = "pnlMonthView";
            this.pnlMonthView.Size = new System.Drawing.Size(210, 381);
            this.pnlMonthView.TabIndex = 44;
            // 
            // pnlMonthViewHolder
            // 
            this.pnlMonthViewHolder.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlMonthViewHolder.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pnlMonthViewHolder.Location = new System.Drawing.Point(0, 0);
            this.pnlMonthViewHolder.Name = "pnlMonthViewHolder";
            this.pnlMonthViewHolder.Size = new System.Drawing.Size(210, 380);
            this.pnlMonthViewHolder.TabIndex = 44;
            // 
            // LogsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(757, 421);
            this.Controls.Add(this.pnlMonthView);
            this.Controls.Add(this.pnlCalendar);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.pnlRadioButton);
            this.Controls.Add(this.btnWeek);
            this.Controls.Add(this.btnMonth);
            this.Controls.Add(this.pnlLoadingCircle);
            this.Controls.Add(this.lblProgress);
            this.Controls.Add(this.pnlSeperator);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(600, 400);
            this.Name = "LogsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Logs";
            this.pnlRadioButton.ResumeLayout(false);
            this.pnlRadioButtonHolder.ResumeLayout(false);
            this.pnlRadioButtonHolder.PerformLayout();
            this.pnlCalendar.ResumeLayout(false);
            this.pnlMonthView.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pnlSeperator;
        private System.Windows.Forms.Panel pnlLoadingCircle;
        private System.Windows.Forms.Label lblProgress;
        private System.Windows.Forms.Panel pnlRadioButton;
        private System.Windows.Forms.Panel pnlRadioButtonHolder;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Button btnWeek;
        private System.Windows.Forms.Button btnMonth;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Panel pnlCalendar;
        private System.Windows.Forms.Panel pnlCalendarHolder;
        private System.Windows.Forms.Panel pnlMonthView;
        private System.Windows.Forms.Panel pnlMonthViewHolder;
    }
}