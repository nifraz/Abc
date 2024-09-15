using ABC.CarTraders.Entities;
using ABC.CarTraders.GUI.Forms;
using LiveCharts;
using LiveCharts.Wpf;
using Material.Styles;
using MRG.Controls.UI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ABC.CarTraders.GUI.Sections
{
    public partial class StatisticsSection : UserControl, IColoredControl
    {
        #region Common
        private AppDbContext DbContext { get { return DashboardForm.DbContext; } }
        private User User { get { return DashboardForm.User; } }
        #endregion

        #region Control
        public StatisticsSection()
        {
            InitializeComponent();
            pnlLoadingCircle.Controls.Add(LoadingCircle);

            DrawPerformanceChart();
            DrawTotalsChart();

            cboUser.DataSource = new List<string>() { "All" };

            RangeStart = new DateTime(2015, 1, 1, 0, 0, 0);
            RangeEnd = new DateTime(DateTime.Today.Year, 12, 31, 23, 59, 59);

            var paperSizes = (new PrinterSettings()).PaperSizes.Cast<PaperSize>();
            var sizeA4 = paperSizes.First(size => size.Kind == PaperKind.A4);
            printDocument1.DefaultPageSettings.PaperSize = sizeA4;
            printDocument1.DefaultPageSettings.Landscape = true;
            printDocument1.DefaultPageSettings.Margins = new Margins(100, 100, 100, 100);

            ColorSchemeChanged += HomeSection_ColorSchemeChanged;
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

        private void HomeSection_ColorSchemeChanged(object sender, ColorScheme e)
        {
            if (e == null) return;

            BackColor = e.Color4;

            pnlHeader.BackColor = e.Color9;

            pnlPerformance.BackColor = e.Color9;
            btnPrintPreview.BackColor = e.Color9;
            btnPrint.BackColor = e.Color9;
            pnlPerformanceHolder.BackColor = e.Color0;
            pnlShow.BackColor = e.Color3;

            pnlPerformanceChartHolder.BackColor = e.Color3;
            cartesianChart1.BackColor = e.Color0;

            btnRefresh.BackColor = e.Color2;

            pnlTotals.BackColor = e.Color9;
            btnExport.BackColor = e.Color9;
            pnlTotalsHolder.BackColor = e.Color0;
            pnlTotalsChartHolder.BackColor = e.Color3;
            pieChart1.BackColor = e.Color0;

            pnlRange.BackColor = e.Color9;
            btnLastYear.BackColor = e.Color9;
            btnThisYear.BackColor = e.Color9;
            btnRangeClear.BackColor = e.Color9;
            pnlRangeHolder.BackColor = e.Color0;
            pnlRangeStart.BackColor = e.Color3;
            pnlRangeEnd.BackColor = e.Color3;

            pnlFilter.BackColor = e.Color9;
            btnFilterClear.BackColor = e.Color9;
            pnlFilterHolder.BackColor = e.Color0;
            pnlFilter1.BackColor = e.Color3;
            pnlSex.BackColor = e.Color3;

            var maleFill = new System.Windows.Media.SolidColorBrush()
            {
                Color = new System.Windows.Media.Color()
                {
                    A = e.Color2.A,
                    R = e.Color2.R,
                    G = e.Color2.G,
                    B = e.Color2.B,
                }
            };

            var femaleFill = new System.Windows.Media.SolidColorBrush()
            {
                Color = new System.Windows.Media.Color()
                {
                    A = e.Color4.A,
                    R = e.Color4.R,
                    G = e.Color4.G,
                    B = e.Color4.B,
                }
            };

            (cartesianChart1.Series.ElementAt(0) as LineSeries).Fill = maleFill;
            (cartesianChart1.Series.ElementAt(1) as LineSeries).Fill = femaleFill;

            (pieChart1.Series.ElementAt(0) as PieSeries).Fill = maleFill;
            (pieChart1.Series.ElementAt(1) as PieSeries).Fill = femaleFill;

        }

        public async Task LoadInitialDataAsync()
        {
            //cboUser.SelectedValueChanged -= cboUser_SelectedValueChanged;

            //var users = new List<User>() { new User { Id = 0, Email = "All" } };
            //users.AddRange(await DbContext.Users
            //    .OrderBy(x => x.Email)
            //    .ToListAsync());

            //cboUser.DataSource = users;

            //cboUser.SelectedValueChanged += cboUser_SelectedValueChanged;
        }
        #endregion

        #region Drawing
        //cartesian chart
        private LiveCharts.WinForms.CartesianChart cartesianChart1;
        private void DrawPerformanceChart()
        {
            cartesianChart1 = new LiveCharts.WinForms.CartesianChart()
            {
                Name = "Cartesian Chart",
                Location = new Point(0, 0),
                LegendLocation = LegendLocation.Right,
                Size = new Size(pnlPerformanceChartHolder.Width, pnlPerformanceChartHolder.Height - 1),
                Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right,
                Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0),
                //BackColorTransparent = true,
                AnimationsSpeed = TimeSpan.FromMilliseconds(100),
                Series = new SeriesCollection
                {
                    new LineSeries
                    {
                        Title = "Black",
                        Foreground = System.Windows.Media.Brushes.Black,
                        Stroke = new System.Windows.Media.SolidColorBrush()
                        {
                            Color = System.Windows.Media.Colors.DarkGray
                        },
                        StrokeThickness = 2,
                        Fill = new System.Windows.Media.SolidColorBrush()
                        {
                            Color = System.Windows.Media.Colors.Gray,
                            Opacity = 0.20
                        },
                        DataLabels = true,
                        Values = new ChartValues<int>()
                    },
                    new LineSeries
                    {
                        Title = "White",
                        Foreground = System.Windows.Media.Brushes.Black,
                        Stroke = new System.Windows.Media.SolidColorBrush()
                        {
                            Color = System.Windows.Media.Colors.DarkGray
                        },
                        StrokeThickness = 2,
                        Fill = new System.Windows.Media.SolidColorBrush()
                        {
                            Color = System.Windows.Media.Colors.Gray,
                            Opacity = 0.20
                        },
                        DataLabels = true,
                        Values = new ChartValues<int>()
                    },
                }
            };

            cartesianChart1.AxisX.Add(new Axis
            {
                Title = "Year",
                Foreground = System.Windows.Media.Brushes.Black,
                FontSize = 12,
                Separator = new Separator
                {
                    StrokeThickness = 1,
                    Stroke = new System.Windows.Media.SolidColorBrush()
                    {
                        Color = System.Windows.Media.Colors.Gainsboro
                    }
                }
            });
            cartesianChart1.AxisY.Add(new Axis
            {
                Title = "Total Sales",
                MinValue = 0,
                Unit = 1,
                FontSize = 12,
                Foreground = System.Windows.Media.Brushes.Black,
                Separator = new Separator
                {
                    StrokeThickness = 1,
                    Stroke = System.Windows.Media.Brushes.Gainsboro
                }
            });

            pnlPerformanceChartHolder.Controls.Add(cartesianChart1);
        }

        //pie chart
        private LiveCharts.WinForms.PieChart pieChart1;
        private void DrawTotalsChart()
        {
            pieChart1 = new LiveCharts.WinForms.PieChart()
            {
                Name = "Pie Chart",
                Location = new Point(0, 0),
                InnerRadius = 30,
                LegendLocation = LegendLocation.Right,
                Size = new Size(pnlTotalsChartHolder.Width, pnlTotalsChartHolder.Height - 1),
                Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right,
                Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0),
                //BackColorTransparent = true,
                AnimationsSpeed = TimeSpan.FromMilliseconds(100),

                Series = new SeriesCollection
                {
                    new PieSeries
                    {
                        Title = "Black",
                        DataLabels = true,
                        Fill = new System.Windows.Media.SolidColorBrush()
                        {
                            Color = new System.Windows.Media.Color()
                            {
                                A = ColorScheme.Blue.Color3.A,
                                R = ColorScheme.Blue.Color3.R,
                                G = ColorScheme.Blue.Color3.G,
                                B = ColorScheme.Blue.Color3.B,
                            },
                            Opacity = 0.75
                        },
                        Foreground = System.Windows.Media.Brushes.Black,
                        FontSize = 9,
                        //Stroke = System.Windows.Media.Brushes.DarkGray,
                        StrokeThickness = 0,
                        Values = new ChartValues<int>()
                    },
                    new PieSeries
                    {
                        Title = "White",
                        DataLabels = true,
                        Fill = new System.Windows.Media.SolidColorBrush()
                        {
                            Color = new System.Windows.Media.Color()
                            {
                                A = ColorScheme.Green.Color3.A,
                                R = ColorScheme.Green.Color3.R,
                                G = ColorScheme.Green.Color3.G,
                                B = ColorScheme.Green.Color3.B,
                            },
                            Opacity = 0.75
                        },
                        Foreground = System.Windows.Media.Brushes.Black,
                        FontSize = 9,
                        //Stroke = System.Windows.Media.Brushes.DarkGray,
                        StrokeThickness = 0,
                        Values = new ChartValues<int>()
                    }
                }
            };

            pnlTotalsChartHolder.Controls.Add(pieChart1);
        }
        #endregion

        #region 
        private string MainTitleText { set { lblMainTitle.Text = $"      {value}"; } }
        #endregion

        #region Actions
        private void btnPrintPreview_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.ShowDialog();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (printDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }
        }

        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            await RefreshAsync();
        }
        #endregion

        #region Range
        private DateTime? RangeStart
        {
            get
            {
                if (chkRangeStart.Checked)
                {
                    return dtpRangeStart.Value;
                }
                return null;
            }
            set
            {
                dtpRangeStart.ValueChanged -= dtpRangeStart_ValueChanged;
                dtpRangeStart.Value = value ?? dtpRangeStart.Value;
                dtpRangeStart.ValueChanged += dtpRangeStart_ValueChanged;

                chkRangeStart.CheckedChanged -= chkRangeStart_CheckedChanged;
                chkRangeStart.Checked = value != null;
                chkRangeStart.CheckedChanged += chkRangeStart_CheckedChanged;

                pnlDtpRangeStartHolder.Visible = chkRangeStart.Checked;
            }
        }

        private DateTime? RangeEnd
        {
            get
            {
                if (chkRangeEnd.Checked)
                {
                    return dtpRangeEnd.Value;
                }
                return null;
            }
            set
            {
                dtpRangeEnd.ValueChanged -= dtpRangeEnd_ValueChanged;
                dtpRangeEnd.Value = value ?? dtpRangeEnd.Value;
                dtpRangeEnd.ValueChanged += dtpRangeEnd_ValueChanged;

                chkRangeEnd.CheckedChanged -= chkRangeEnd_CheckedChanged;
                chkRangeEnd.Checked = value != null;
                chkRangeEnd.CheckedChanged += chkRangeEnd_CheckedChanged;

                pnlDtpRangeEndHolder.Visible = chkRangeEnd.Checked;
            }
        }

        private async void btnLastYear_Click(object sender, EventArgs e)
        {
            RangeStart = new DateTime(DateTime.Today.Year - 1, 1, 1, 0, 0, 0);
            RangeEnd = new DateTime(DateTime.Today.Year - 1, 12, 31, 23, 59, 59);

            await RefreshAsync();
            btnLastYear.Focus();
        }

        private async void btnThisYear_Click(object sender, EventArgs e)
        {
            RangeStart = new DateTime(DateTime.Today.Year, 1, 1, 0, 0, 0);
            RangeEnd = new DateTime(DateTime.Today.Year, 12, 31, 23, 59, 59);

            await RefreshAsync();
            btnThisYear.Focus();
        }

        private async void btnRangeClear_Click(object sender, EventArgs e)
        {
            if (RangeStart == null && RangeEnd == null) return;

            RangeStart = null;
            RangeEnd = null;

            await RefreshAsync();
            btnRangeClear.Focus();
        }

        private async void chkRangeStart_CheckedChanged(object sender, EventArgs e)
        {
            pnlDtpRangeStartHolder.Visible = chkRangeStart.Checked;

            await RefreshAsync();
            chkRangeStart.Focus();
        }

        private async void dtpRangeStart_ValueChanged(object sender, EventArgs e)
        {
            await RefreshAsync();
            dtpRangeStart.Focus();
        }

        private async void chkRangeEnd_CheckedChanged(object sender, EventArgs e)
        {
            pnlDtpRangeEndHolder.Visible = chkRangeEnd.Checked;

            await RefreshAsync();
            chkRangeEnd.Focus();
        }

        private async void dtpRangeEnd_ValueChanged(object sender, EventArgs e)
        {
            await RefreshAsync();
            dtpRangeEnd.Focus();
        }
        #endregion

        #region Filter
        //private Province CalvingRecordProvince
        //{
        //    get
        //    {
        //        if (cboProvince.Text != "All")
        //        {
        //            return DbContext.Provinces.GetAllCached().SingleOrDefault(p => p.Name == cboProvince.Text);
        //        }
        //        return null;
        //    }
        //    set
        //    {
        //        cboProvince.SelectedValueChanged -= cboProvince_SelectedValueChanged;
        //        cboProvince.SelectedItem = value == null ? "All" : value.ToString();
        //        cboProvince.SelectedValueChanged += cboProvince_SelectedValueChanged;
        //    }
        //}

        //private District CalvingRecordDistrict
        //{
        //    get
        //    {
        //        if (cboDistrict.Text != "All")
        //        {
        //            return DbContext.Districts.GetAllCached().SingleOrDefault(d => d.Name == cboDistrict.Text);
        //        }
        //        return null;
        //    }
        //    set
        //    {
        //        cboDistrict.SelectedValueChanged -= cboDistrict_SelectedValueChanged;
        //        cboDistrict.SelectedItem = value == null ? "All" : value.ToString();
        //        cboDistrict.SelectedValueChanged += cboDistrict_SelectedValueChanged;
        //    }
        //}

        //private VsRange CalvingRecordVsRange
        //{
        //    get
        //    {
        //        if (cboVsRange.Text != "All")
        //        {
        //            return DbContext.VsRanges.GetAllCached().SingleOrDefault(d => d.Name == cboVsRange.Text);
        //        }
        //        return null;
        //    }
        //    set
        //    {
        //        cboVsRange.SelectedValueChanged -= cboVsRange_SelectedValueChanged;
        //        cboVsRange.SelectedItem = value == null ? "All" : value.ToString();
        //        cboVsRange.SelectedValueChanged += cboVsRange_SelectedValueChanged;
        //    }
        //}

        //private Institute CalvingRecordInstitute
        //{
        //    get
        //    {
        //        if (cboInstitute.Text != "All")
        //        {
        //            return DbContext.Institutes.GetAllCached().SingleOrDefault(d => d.Name == cboInstitute.Text);
        //        }
        //        return null;
        //    }
        //    set
        //    {
        //        cboInstitute.SelectedValueChanged -= cboInstitute_SelectedValueChanged;
        //        cboInstitute.SelectedItem = value == null ? "All" : value.ToString();
        //        cboInstitute.SelectedValueChanged += cboInstitute_SelectedValueChanged;
        //    }
        //}

        
        private async void btnFilterClear_Click(object sender, EventArgs e)
        {
            if (cboUser.SelectedIndex == 0) return;

            await RefreshAsync();
            btnFilterClear.Focus();
        }

        private void cboUser_SelectedValueChanged(object sender, EventArgs e)
        {
            //if (DbContext == null) return;
            //var districts = new List<string>() { "All" };
            //if (cboProvince.Text.Equals("All"))
            //{
            //    districts.AddRange(DbContext.Districts.GetAllCached().OrderBy(d => d.Name).Select(d => d.Name));
            //}
            //else
            //{
            //    districts.AddRange(DbContext.Districts.GetAllCached().Where(d => d.Province.Name.Equals(cboProvince.Text)).OrderBy(d => d.Name).Select(d => d.Name));
            //}

            //cboDistrict.DataSource = districts;
        }

        private void cboDistrict_SelectedValueChanged(object sender, EventArgs e)
        {
            //if (DbContext == null) return;
            //var vsRanges = new List<string>() { "All" };
            //if (cboDistrict.Text.Equals("All"))
            //{
            //    if (cboProvince.Text.Equals("All"))
            //    {
            //        vsRanges.AddRange(DbContext.VsRanges.GetAllCached().OrderBy(vsr => vsr.Name).Select(vsr => vsr.Name));
            //    }
            //    else
            //    {
            //        vsRanges.AddRange(DbContext.VsRanges.GetAllCached().Where(vsr => vsr.Province.Name.Equals(cboProvince.Text)).OrderBy(vsr => vsr.Name).Select(vsr => vsr.Name));
            //    }
            //}
            //else
            //{
            //    vsRanges.AddRange(DbContext.VsRanges.GetAllCached().Where(vsr => vsr.District.Name.Equals(cboDistrict.Text)).OrderBy(vsr => vsr.Name).Select(vsr => vsr.Name));
            //}

            //cboVsRange.DataSource = vsRanges;
        }

        private async void rdoCategory_CheckedChanged(object sender, EventArgs e)
        {
            await RefreshAsync();
        }

        #endregion

        #region Pie Chart
        private async void btnExport_Click(object sender, EventArgs e)
        {
            await ExportToExcelAsync();
        }

        public async Task ExportToExcelAsync()
        {
            //if (DbContext == null) return;
            //var result = DialogResult.Retry;
            //while (result == DialogResult.Retry)
            //{
            //    try
            //    {
            //        StartProgress("Exporting to Excel...");
            //        var path = await DbContext.CalvingRecords.ExportToExcelAsync("Calving Date", RangeStart, RangeEnd, CalvingRecordProvince, CalvingRecordDistrict, CalvingRecordVsRange, CalvingRecordInstitute, CalvingRecordTechnicianCode, CalvingRecordSemenCode, null, "Ascending");
            //        StopProgress();
            //        StatusText = "Data Exported";
            //        var option = MessageBox.Show($"Calving record data successfully exported to \"{path}\".\nDo you want to open the exported file now?", "EXPORT", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            //        if (option == DialogResult.Yes)
            //        {
            //            MessageBox.Show("Please close any opened Excel files before proceeding.\nClick OK to continue opening the file.", "EXCEL", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //            Process.Start(path);
            //        }
            //        else
            //        {
            //            Process.Start(AppSettings.ABCFolderPath);
            //        }
            //        StatusText = "Ready";
            //        break;
            //    }
            //    catch (Exception ex)
            //    {
            //        StopProgress();
            //        StatusText = "Error Occurred";
            //        result = MessageBox.Show($"An error occurred while exporting data from the Database to the Excel file.\n{ex.Message}\nPlease try again.", "ERROR", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            //    }
            //}
            //StatusText = "Ready";
        }
        #endregion

        #region Actions
        public async Task RefreshAsync()
        {
            if (DbContext == null) return;

            await RefreshPerformanceAsync();
            await RefreshTotalsAsync();
            //MainTitleText = $"Performance [{RangeStart == null?} - {PagedList.LastItemOnPage} / {PagedList.TotalItemCount}]";
            HomeSection_ColorSchemeChanged(this, ColorScheme);
        }

        private async Task RefreshPerformanceAsync()
        {
            if (DbContext == null) return;

            var result = DialogResult.Retry;
            while (result == DialogResult.Retry)
            {
                try
                {
                    StartProgress("Refreshing Performance...");

                    List<Tuple<string, int, int, int>> valuesList = new List<Tuple<string, int, int, int>>();

                    var rangeStart = RangeStart != null ? RangeStart : new DateTime(2015, 1, 1);
                    var rangeEnd = RangeEnd != null ? RangeEnd : DateTime.Today;

                    //if (rdoYearly.Checked)
                    //{

                    //}
                    //else
                    //{

                    //}

                    var labels = new ChartValues<string>();
                    var blackValues = new ChartValues<int>();
                    var whiteValues = new ChartValues<int>();
                    var totalValues = new ChartValues<int>();

                    foreach (var values in valuesList)
                    {
                        labels.Add(values.Item1.ToString());
                        blackValues.Add(values.Item2);
                        whiteValues.Add(values.Item3);
                        totalValues.Add(values.Item4);
                    }

                    cartesianChart1.Series[0].Values = blackValues;
                    cartesianChart1.Series[1].Values = whiteValues;
                    cartesianChart1.AxisX[0].Labels = labels;

                    StopProgress();
                    //StatusText = "Ready";
                    break;
                }
                catch (Exception ex)
                {
                    StopProgress();
                    StatusText = "Error Occurred";
                    result = MessageBox.Show($"An error occurred while retrieving data from the Database.\n{ex.Message}\nPlease try again.", "ERROR", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                }
            }
            StatusText = "Ready";
        }

        private async Task RefreshTotalsAsync()
        {
            if (DbContext == null) return;

            var result = DialogResult.Retry;
            while (result == DialogResult.Retry)
            {
                try
                {
                    StartProgress("Refreshing Totals...");

                    //var values = await DbContext.CalvingRecords.GetTotalsAsync(CalvingRecordProvince, CalvingRecordDistrict, CalvingRecordVsRange, CalvingRecordInstitute, CalvingRecordTechnicianCode, CalvingRecordSemenCode, RangeStart, RangeEnd);

                    //pieChart1.Series[0].Values = new ChartValues<int> { values.Item1 };
                    //pieChart1.Series[1].Values = new ChartValues<int> { values.Item2 };
                    //label7.Text = $"      Total [{values.Item3}]";

                    StopProgress();
                    //StatusText = "Ready";
                    break;
                }
                catch (Exception ex)
                {
                    StopProgress();
                    StatusText = "Error Occurred";
                    result = MessageBox.Show($"An error occurred while retrieving data from the Database.\n{ex.Message}\nPlease try again.", "ERROR", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                }
            }
            StatusText = "Ready";
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
            Enabled = false;
        }

        private void StopProgress()
        {
            Stopwatch.Stop();
            pnlLoadingCircle.Visible = false;
            LoadingCircle.Active = false;
            timer1.Enabled = false;
            Enabled = true;
            //StatusText = $"Ready";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            var elapsed = Stopwatch.Elapsed;
            StatusText = $"{ProgressText} ({elapsed.Minutes:00}:{elapsed.Seconds:00})";
        }
        #endregion

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            var grd = this;
            var bmp = new Bitmap(grd.Width, grd.Height, grd.CreateGraphics());
            grd.DrawToBitmap(bmp, new Rectangle(0, 0, grd.Width, grd.Height));
            var bounds = e.MarginBounds;
            //var bounds = e.PageSettings.PrintableArea;
            var factor = bmp.Height / (float)bmp.Width;
            e.Graphics.DrawImage(bmp, bounds.Left, bounds.Top, bounds.Width, factor * bounds.Width);
            
        }

        private async void rdoYearly_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoMonthly.Checked) return;
            await RefreshPerformanceAsync();
        }

        private async void rdoMonthly_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoYearly.Checked) return;
            await RefreshPerformanceAsync();
        }
    }
}
