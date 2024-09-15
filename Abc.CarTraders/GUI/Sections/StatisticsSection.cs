using ABC.CarTraders.Entities;
using ABC.CarTraders.Enums;
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

            DrawPerformanceChartByColor();
            DrawTotalsChartByColor();

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
        private LiveCharts.WinForms.CartesianChart cartesianChart1;
        private LiveCharts.WinForms.PieChart pieChart1;

        // List of car colors
        private List<string> carColors = new List<string>()
        {
            "Black",
            "White",
            "Blue",
            "Green",
            "Yellow",
            "Red"
        };

        // List of car types (you'll need to populate this according to your data)
        private List<string> carTypes = Helper.GetEnumNamesToStringList<CarType>();
        private void DrawPerformanceChartByColor()
        {
            // Clear the existing chart before drawing
            pnlPerformanceChartHolder.Controls.Clear();

            cartesianChart1 = new LiveCharts.WinForms.CartesianChart()
            {
                Name = "Cartesian Chart",
                Location = new Point(0, 0),
                LegendLocation = LegendLocation.Right,
                Size = new Size(pnlPerformanceChartHolder.Width, pnlPerformanceChartHolder.Height - 1),
                Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right,
                Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0),
                AnimationsSpeed = TimeSpan.FromMilliseconds(100),
                Series = new SeriesCollection()
            };

            // Add a line series for each car color
            foreach (var color in carColors) // Skip "All"
            {
                var lineSeries = new LineSeries
                {
                    Title = color,
                    Foreground = System.Windows.Media.Brushes.Black,
                    Stroke = GetBrushForColor(color), // Custom method to get color brush
                    StrokeThickness = 2,
                    Fill = GetBrushForColor(color, 0.2), // Custom method to get transparent fill
                    DataLabels = true,
                    Values = new ChartValues<int>() // Add your data here
                };

                cartesianChart1.Series.Add(lineSeries);
            }

            cartesianChart1.AxisX.Add(new Axis
            {
                Title = rdoYearly.Checked ? "Year" : "Month", // Switch based on selected period
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

            pnlPerformanceChartHolder.Controls.Add(cartesianChart1); // Re-add the chart
        }

        private void DrawTotalsChartByColor()
        {
            // Clear the existing chart before drawing
            pnlTotalsChartHolder.Controls.Clear();

            pieChart1 = new LiveCharts.WinForms.PieChart()
            {
                Name = "Pie Chart",
                Location = new Point(0, 0),
                InnerRadius = 30,
                LegendLocation = LegendLocation.Right,
                Size = new Size(pnlTotalsChartHolder.Width, pnlTotalsChartHolder.Height - 1),
                Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right,
                Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0),
                AnimationsSpeed = TimeSpan.FromMilliseconds(100),
                Series = new SeriesCollection()
            };

            // Add a PieSeries for each car color
            foreach (var color in carColors) // Skip "All"
            {
                var pieSeries = new PieSeries
                {
                    Title = color,
                    DataLabels = true,
                    Fill = GetBrushForColor(color), // Custom method to get color brush
                    Foreground = System.Windows.Media.Brushes.Black,
                    FontSize = 9,
                    StrokeThickness = 0,
                    Values = new ChartValues<int> { GetSalesForColor(color) } // Add your data here
                };

                pieChart1.Series.Add(pieSeries);
            }

            pnlTotalsChartHolder.Controls.Add(pieChart1); // Re-add the chart
        }


        private void DrawPerformanceChartByType()
        {
            cartesianChart1.Series.Clear();

            // Add a line series for each car type
            foreach (var type in carTypes)
            {
                var lineSeries = new LineSeries
                {
                    Title = type,
                    Foreground = System.Windows.Media.Brushes.Black,
                    Stroke = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Colors.DarkGray),
                    StrokeThickness = 2,
                    Fill = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Colors.Gray)
                    {
                        Opacity = 0.2
                    },
                    DataLabels = true,
                    Values = new ChartValues<int>() // Add your data here
                };

                cartesianChart1.Series.Add(lineSeries);
            }

            cartesianChart1.AxisX[0].Title = rdoYearly.Checked ? "Year" : "Month"; // Update axis based on period
        }

        private void DrawTotalsChartByType()
        {
            pieChart1.Series.Clear();

            // Add a PieSeries for each car type
            foreach (var type in carTypes)
            {
                var pieSeries = new PieSeries
                {
                    Title = type,
                    DataLabels = true,
                    Fill = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Colors.Gray)
                    {
                        Opacity = 0.75
                    },
                    Foreground = System.Windows.Media.Brushes.Black,
                    FontSize = 9,
                    StrokeThickness = 0,
                    Values = new ChartValues<int> { GetSalesForType(type) } // Add your data here
                };

                pieChart1.Series.Add(pieSeries);
            }
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

            // Check whether Color or Type is selected
            if (rdoColor.Checked)
            {
                // Fetch data and update charts for car colors
                await RefreshPerformanceAsyncByColor();
                await RefreshTotalsAsyncByColor();
            }
            else if (rdoType.Checked)
            {
                // Fetch data and update charts for car types
                await RefreshPerformanceAsyncByType();
                await RefreshTotalsAsyncByType();
            }

            // Reapply the color scheme after refreshing the data
            HomeSection_ColorSchemeChanged(this, ColorScheme);
        }

        private async Task RefreshPerformanceAsyncByColor()
        {
            // Example: Fetch color-based performance data from the database (dummy data for now)
            var blackValues = new ChartValues<int> { 10, 20, 30 }; // Replace with actual data fetching
            var whiteValues = new ChartValues<int> { 15, 25, 35 };
            var blueValues = new ChartValues<int> { 5, 10, 15 };
            var greenValues = new ChartValues<int> { 8, 12, 18 };
            var yellowValues = new ChartValues<int> { 6, 14, 19 };
            var redValues = new ChartValues<int> { 13, 17, 21 };

            // Update chart values for each color
            cartesianChart1.Series[0].Values = blackValues;
            cartesianChart1.Series[1].Values = whiteValues;
            cartesianChart1.Series[2].Values = blueValues;
            cartesianChart1.Series[3].Values = greenValues;
            cartesianChart1.Series[4].Values = yellowValues;
            cartesianChart1.Series[5].Values = redValues;
        }

        private async Task RefreshPerformanceAsyncByType()
        {
            // Example: Fetch type-based performance data from the database (dummy data for now)
            var suvValues = new ChartValues<int> { 10, 30, 40 }; // Replace with actual data fetching
            var sedanValues = new ChartValues<int> { 20, 40, 60 };
            var truckValues = new ChartValues<int> { 15, 25, 35 };
            var convertibleValues = new ChartValues<int> { 18, 28, 38 };
            var coupeValues = new ChartValues<int> { 12, 22, 32 };

            // Update chart values for each type
            cartesianChart1.Series[0].Values = suvValues;
            cartesianChart1.Series[1].Values = sedanValues;
            cartesianChart1.Series[2].Values = truckValues;
            cartesianChart1.Series[3].Values = convertibleValues;
            cartesianChart1.Series[4].Values = coupeValues;
        }

        private async Task RefreshTotalsAsyncByColor()
        {
            // Simulate a delay to mimic data fetching
            await Task.Delay(500);

            // Dummy data for car colors' sales
            var blackSales = 50;
            var whiteSales = 70;
            var blueSales = 30;
            var greenSales = 40;
            var yellowSales = 20;
            var redSales = 60;

            // Update PieChart with color-based sales
            pieChart1.Series[0].Values = new ChartValues<int> { blackSales };  // Black
            pieChart1.Series[1].Values = new ChartValues<int> { whiteSales };  // White
            pieChart1.Series[2].Values = new ChartValues<int> { blueSales };   // Blue
            pieChart1.Series[3].Values = new ChartValues<int> { greenSales };  // Green
            pieChart1.Series[4].Values = new ChartValues<int> { yellowSales }; // Yellow
            pieChart1.Series[5].Values = new ChartValues<int> { redSales };    // Red
        }

        private async Task RefreshTotalsAsyncByType()
        {
            // Simulate a delay to mimic data fetching
            await Task.Delay(500);

            // Dummy data for car types' sales
            var suvSales = 100;
            var sedanSales = 80;
            var truckSales = 60;
            var convertibleSales = 40;
            var coupeSales = 90;

            // Update PieChart with type-based sales
            pieChart1.Series[0].Values = new ChartValues<int> { suvSales };        // SUV
            pieChart1.Series[1].Values = new ChartValues<int> { sedanSales };      // Sedan
            pieChart1.Series[2].Values = new ChartValues<int> { truckSales };      // Truck
            pieChart1.Series[3].Values = new ChartValues<int> { convertibleSales };// Convertible
            pieChart1.Series[4].Values = new ChartValues<int> { coupeSales };      // Coupe
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
        private async void rdoColor_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoColor.Checked)
            {
                DrawPerformanceChartByColor();
                DrawTotalsChartByColor();
                await RefreshAsync(); // Fetch and apply color-based statistics
            }
        }

        private async void rdoType_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoType.Checked)
            {
                DrawPerformanceChartByType();
                DrawTotalsChartByType();
                await RefreshAsync(); // Fetch and apply type-based statistics
            }
        }

        private async void rdoYearly_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoYearly.Checked)
            {
                if (rdoColor.Checked)
                {
                    DrawPerformanceChartByColor();  // Re-draw based on yearly data
                }
                else if (rdoType.Checked)
                {
                    DrawPerformanceChartByType();  // Re-draw based on yearly data
                }
                await RefreshAsync(); // Fetch and apply yearly data
            }
        }

        private async void rdoMonthly_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoMonthly.Checked)
            {
                if (rdoColor.Checked)
                {
                    DrawPerformanceChartByColor();  // Re-draw based on monthly data
                }
                else if (rdoType.Checked)
                {
                    DrawPerformanceChartByType();  // Re-draw based on monthly data
                }
                await RefreshAsync(); // Fetch and apply monthly data
            }
        }


        private System.Windows.Media.Brush GetBrushForColor(string color, double opacity = 1.0)
        {
            switch (color)
            {
                case "Black":
                    return new System.Windows.Media.SolidColorBrush(System.Windows.Media.Colors.Black) { Opacity = opacity };
                case "White":
                    return new System.Windows.Media.SolidColorBrush(System.Windows.Media.Colors.White) { Opacity = opacity };
                case "Blue":
                    return new System.Windows.Media.SolidColorBrush(System.Windows.Media.Colors.Blue) { Opacity = opacity };
                case "Green":
                    return new System.Windows.Media.SolidColorBrush(System.Windows.Media.Colors.Green) { Opacity = opacity };
                case "Yellow":
                    return new System.Windows.Media.SolidColorBrush(System.Windows.Media.Colors.Yellow) { Opacity = opacity };
                case "Red":
                    return new System.Windows.Media.SolidColorBrush(System.Windows.Media.Colors.Red) { Opacity = opacity };
                default:
                    return new System.Windows.Media.SolidColorBrush(System.Windows.Media.Colors.Gray) { Opacity = opacity };
            }
        }

        private void ClearCharts()
        {
            // Clear existing series from CartesianChart
            if (cartesianChart1 != null)
            {
                cartesianChart1.Series.Clear();  // Clears all the series in the Cartesian chart
            }

            // Clear existing series from PieChart
            if (pieChart1 != null)
            {
                pieChart1.Series.Clear();  // Clears all the series in the Pie chart
            }
        }


        private int GetSalesForColor(string color)
        {
            // Implement logic to fetch sales data for the specific color
            return new Random().Next(10, 100);  // Dummy data for now
        }

        private int GetSalesForType(string type)
        {
            // Implement logic to fetch sales data for the specific type
            return new Random().Next(10, 100);  // Dummy data for now
        }


    }
}
