using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Calendar;

namespace Daph.Breeding.GUI.Forms
{
    public partial class LogsForm : Form
    {
        public LogsForm()
        {
            InitializeComponent();

            DrawCalendarView();
            DrawMonthView();
        }

        #region Draw
        private MonthView monthView1;
        private void DrawMonthView()
        {
            monthView1 = new MonthView();

            this.monthView1.Anchor = AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Left;
            this.monthView1.ArrowsColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(191)))), ((int)(((byte)(225)))));
            this.monthView1.ArrowsSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(140)))), ((int)(((byte)(201)))));
            this.monthView1.DayBackgroundColor = System.Drawing.Color.Empty;
            this.monthView1.DayGrayedText = System.Drawing.SystemColors.GrayText;
            this.monthView1.DaySelectedBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(140)))), ((int)(((byte)(201)))));
            this.monthView1.DaySelectedColor = System.Drawing.SystemColors.WindowText;
            this.monthView1.DaySelectedTextColor = System.Drawing.SystemColors.HighlightText;
            this.monthView1.FirstDayOfWeek = System.DayOfWeek.Monday;
            this.monthView1.ItemPadding = new System.Windows.Forms.Padding(2);
            this.monthView1.Location = new System.Drawing.Point(0, -1);
            this.monthView1.MaxSelectionCount = 35;
            this.monthView1.MonthTitleColor = System.Drawing.SystemColors.ActiveCaption;
            this.monthView1.MonthTitleColorInactive = System.Drawing.SystemColors.InactiveCaption;
            this.monthView1.MonthTitleTextColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.monthView1.MonthTitleTextColorInactive = System.Drawing.SystemColors.InactiveCaptionText;
            this.monthView1.Name = "monthView1";
            this.monthView1.Size = new Size(pnlMonthViewHolder.Width, 828);
            this.monthView1.TabIndex = 0;
            this.monthView1.Text = "monthView1";
            this.monthView1.TodayBorderColor = System.Drawing.Color.Maroon;
            this.monthView1.SelectionChanged += new System.EventHandler(this.monthView1_SelectionChanged);
            //this.monthView1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.monthView1_MouseDoubleClick);

            pnlMonthViewHolder.Controls.Add(monthView1);
        }

        private Calendar calendar1;
        private void DrawCalendarView()
        {
            calendar1 = new Calendar();
            this.calendar1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            //this.calendar1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            //this.calendar1.ContextMenuStrip = this.contextMenuStrip;
            this.calendar1.FirstDayOfWeek = System.DayOfWeek.Monday;
            this.calendar1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.calendar1.Location = new System.Drawing.Point(5, 5);
            this.calendar1.Name = "calendar1";
            this.calendar1.Size = new System.Drawing.Size(pnlCalendarHolder.Width + 5, pnlCalendarHolder.Height - 10);
            this.calendar1.TabIndex = 2;
            this.calendar1.Text = "calendar1";
            this.calendar1.LoadItems += new System.Windows.Forms.Calendar.Calendar.CalendarLoadEventHandler(this.calendar1_LoadItems);
            this.calendar1.DayHeaderClick += new System.Windows.Forms.Calendar.Calendar.CalendarDayEventHandler(this.calendar1_DayHeaderClick);
            this.calendar1.ItemCreated += new System.Windows.Forms.Calendar.Calendar.CalendarItemCancelEventHandler(this.calendar1_ItemCreated);
            this.calendar1.ItemDeleted += new System.Windows.Forms.Calendar.Calendar.CalendarItemEventHandler(this.calendar1_ItemDeleted);
            this.calendar1.ItemClick += new System.Windows.Forms.Calendar.Calendar.CalendarItemEventHandler(this.calendar1_ItemClick);
            this.calendar1.ItemDoubleClick += new System.Windows.Forms.Calendar.Calendar.CalendarItemEventHandler(this.calendar1_ItemDoubleClick);
            this.calendar1.ItemMouseHover += new System.Windows.Forms.Calendar.Calendar.CalendarItemEventHandler(this.calendar1_ItemMouseHover);

            calendar1.ViewStart = DateTime.Today.AddDays(-1);
            calendar1.ViewEnd = DateTime.Today.AddDays(1);
            calendar1.TimeUnitsOffset = -14;

            pnlCalendarHolder.Controls.Add(calendar1);
        }
        #endregion


        //private void LoadCalendarItems()
        //{
        //    if (ItemsFile.Exists)
        //    {
        //        List<Event> lst = new List<Event>();

        //        XmlSerializer xml = new XmlSerializer(lst.GetType());

        //        using (Stream s = ItemsFile.OpenRead())
        //        {
        //            lst = xml.Deserialize(s) as List<Event>;
        //        }

        //        foreach (Event item in lst)
        //        {
        //            //cal.ApplyColor(item.BackColor);

        //            _items.Add(new CalendarItem(calendar1, item.StartTime, item.EndTime, item.Title)
        //            {
        //                BackgroundColor = item.BackColor,
        //                Image = Properties.Resources.add_dark_15px
        //            });
        //        }

        //        PlaceItems();
        //    }
        //}

        private void calendar1_LoadItems(object sender, CalendarLoadEventArgs e)
        {
            PlaceItems();
        }

        private void PlaceItems()
        {
            //foreach (CalendarItem item in _items)
            //{
            //    if (calendar1.ViewIntersects(item))
            //    {
            //        calendar1.Items.Add(item);
            //    }
            //}
        }

        private void calendar1_ItemCreated(object sender, CalendarItemCancelEventArgs e)
        {
            //_items.Add(e.Item);
        }

        private void calendar1_ItemMouseHover(object sender, CalendarItemEventArgs e)
        {
            //Text = e.Item.Text;
        }

        private void calendar1_ItemClick(object sender, CalendarItemEventArgs e)
        {

        }

        private void hourToolStripMenuItem_Click(object sender, EventArgs e)
        {
            calendar1.TimeScale = CalendarTimeScale.SixtyMinutes;
        }

        private void minutesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            calendar1.TimeScale = CalendarTimeScale.ThirtyMinutes;
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            calendar1.TimeScale = CalendarTimeScale.FifteenMinutes;
        }

        private void minutesToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            calendar1.TimeScale = CalendarTimeScale.SixMinutes;
        }

        private void minutesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            calendar1.TimeScale = CalendarTimeScale.TenMinutes;
        }

        private void minutesToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            calendar1.TimeScale = CalendarTimeScale.FiveMinutes;
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void redTagToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void yellowTagToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void greenTagToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void blueTagToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void editItemToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        //public void SaveCalendarData()
        //{
        //    CalendarItem ci = new CalendarItem(calendar1, DateTime.Today, DateTime.Now, "Calendar Title")
        //    {

        //    };
        //    List<Event> lst = new List<Event>();

        //    foreach (CalendarItem item in _items)
        //    {
        //        lst.Add(new Event()
        //        {
        //            StartTime = item.StartDate,
        //            EndTime = item.EndDate,
        //            Text = item.Text,
        //            BackColor = item.BackgroundColor,

        //        });
        //    }

        //    XmlSerializer xmls = new XmlSerializer(lst.GetType());

        //    if (ItemsFile.Exists)
        //    {
        //        ItemsFile.Delete();
        //    }

        //    using (Stream s = ItemsFile.OpenWrite())
        //    {
        //        xmls.Serialize(s, lst);
        //        s.Close();
        //    }
        //}

        private void otherColorTagToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void calendar1_ItemDoubleClick(object sender, CalendarItemEventArgs e)
        {
            calendar1.ActivateEditMode();
            //MessageBox.Show("Double click: " + e.Item.Text);
        }

        private void calendar1_ItemDeleted(object sender, CalendarItemEventArgs e)
        {
            //_items.Remove(e.Item);
        }

        private void calendar1_DayHeaderClick(object sender, CalendarDayEventArgs e)
        {
            if (e.CalendarDay.Date < monthView1.SelectionStart)
            {
                monthView1.SelectionStart = e.CalendarDay.Date;
            }

            if (e.CalendarDay.Date > monthView1.SelectionEnd)
            {
                monthView1.SelectionEnd = e.CalendarDay.Date;
            }
            monthView1.SelectionStart = e.CalendarDay.Date;
            monthView1.SelectionEnd = e.CalendarDay.Date;
        }

        private void diagonalToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void verticalToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void horizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void hatchToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void noneToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void monthView1_SelectionChanged(object sender, EventArgs e)
        {
            calendar1.SetViewRange(monthView1.SelectionStart, monthView1.SelectionEnd);
            //lblTimeRange.Text = (monthView1.SelectionEnd - monthView1.SelectionStart).Days > 0 ? $"      Time: {monthView1.SelectionStart.ToShortDateString()} - {monthView1.SelectionEnd.ToShortDateString()}" : $"      Time: {monthView1.SelectionStart.ToShortDateString()}";
            //lblInfo.Text = $"Showing data from {monthView1.SelectionStart.ToShortDateString()} to {monthView1.SelectionEnd.ToShortDateString()}";
        }

        private void northToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void eastToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void southToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void westToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void selectImageToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }



        private void btnDelete_Click(object sender, EventArgs e)
        {
            //
        }
        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            
        }

        //private void addToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    EventForm.Add();
        //}

        //private void editToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    EventForm.Add();
        //}

        //private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        //{

        //}

        //private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        //{

        //}

        //private void eventsToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    if (eventsToolStripMenuItem.Checked)
        //    {
        //        eventsToolStripMenuItem.Checked = false;
        //    }
        //    else
        //    {
        //        eventsToolStripMenuItem.Checked = true;
        //    }
        //}

        //private void logsToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    logsToolStripMenuItem.Checked = !logsToolStripMenuItem.Checked;
        //}

        //private void UnCheckTimeScaleMenuItems()
        //{
        //    oneHourToolStripMenuItem.Checked = false;
        //    thirtyMinToolStripMenuItem.Checked = false;
        //    fifteenMinToolStripMenuItem.Checked = false;
        //    fiveMinToolStripMenuItem.Checked = false;
        //}
        //private void oneHourToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    UnCheckTimeScaleMenuItems();
        //    calendar1.TimeScale = CalendarTimeScale.SixtyMinutes;
        //    oneHourToolStripMenuItem.Checked = true;
        //}

        //private void thirtyMinToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    UnCheckTimeScaleMenuItems();
        //    calendar1.TimeScale = CalendarTimeScale.ThirtyMinutes;
        //    thirtyMinToolStripMenuItem.Checked = true;
        //}

        //private void fifteenMinToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    UnCheckTimeScaleMenuItems();
        //    calendar1.TimeScale = CalendarTimeScale.FifteenMinutes;
        //    fifteenMinToolStripMenuItem.Checked = true;
        //}

        //private void fiveMinToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    UnCheckTimeScaleMenuItems();
        //    calendar1.TimeScale = CalendarTimeScale.FiveMinutes;
        //    fiveMinToolStripMenuItem.Checked = true;
        //}

        private void monthView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            MessageBox.Show("D");
        }

        private void contextMenuStrip_Opening(object sender, CancelEventArgs e)
        {
            //contextItem = calendar1.ItemAt(contextMenuStrip1.Bounds.Location);
            //editItemToolStripMenuItem.Enabled = calendar1.GetSelectedItems().Count() == 1;
            //Console.WriteLine(calendar1.GetSelectedItems().Count());
        }
    }
}
