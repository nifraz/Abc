using ABC.CarTraders.Entities;
using ABC.CarTraders.Enums;
using ABC.CarTraders.GUI.Forms;
using Material.Styles;
using MRG.Controls.UI;
using PagedList;
using PagedList.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ABC.CarTraders.GUI.Sections
{
    public partial class UserSection : UserControl, IColoredControl
    {
        #region Common
        private AppDbContext DbContext { get { return DashboardForm.DbContext; } }
        private Action<Log> WriteLog { get { return DashboardForm.WriteLog; } }
        private User User { get { return DashboardForm.User; } }
        #endregion

        #region Control
        public UserSection()
        {
            InitializeComponent();
            pnlLoadingCircle.Controls.Add(LoadingCircle);
            dataGridView1.AutoGenerateColumns = false;

            cboRangeField.DataSource = new List<string>() { "Created On", "Modified On" };
            cboRole.DataSource = new List<string>() 
            { 
                "All",
                Enums.UserRole.Guest.ToString(),
                Enums.UserRole.Customer.ToString(),
                Enums.UserRole.Staff.ToString(),
                Enums.UserRole.Admin.ToString(),
            };
            cboSex.DataSource = new List<string>() 
            { 
                "Both",
                Enums.Sex.Male.ToString(),
                Enums.Sex.Female.ToString(),
            };
            cboFindField.DataSource = new List<string>() { "Email", "FullName", "PhoneNo", "Address" };
            cboSortField.DataSource = new List<string>() { "Email", "FullName" };
            cboSortDirection.DataSource = Enum.GetNames(typeof(SortDirection)).ToList();

            RangeStart = DateTime.Today;
            RangeEnd = DateTime.Today.AddDays(1).AddSeconds(-1);

            RangeStart = null;
            RangeEnd = null;

            SortField = "Id";
            SortDirection = Enums.SortDirection.Ascending.ToString();

            nudPageNumber.MouseWheel += nudPageNumber_MouseWheel;
            ColorSchemeChanged += UserSection_ColorSchemeChanged;
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
        private void UserSection_ColorSchemeChanged(object sender, ColorScheme e)
        {
            if (e == null) return;

            BackColor = e.Color4;

            pnlMain.BackColor = e.Color9;
            btnExport.BackColor = e.Color9;
            pnlMainHolder.BackColor = e.Color0;

            pnlDgv.BackColor = e.Color3;
            dataGridView1.BackgroundColor = e.Color0;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = e.Color3;
            dataGridView1.ColumnHeadersDefaultCellStyle.SelectionBackColor = e.Color3;
            dataGridView1.DefaultCellStyle.SelectionBackColor = e.Color1;
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.Black;

            btnAdd.BackColor = e.Color2;
            btnEdit.BackColor = e.Color2;
            btnDelete.BackColor = e.Color2;

            btnFirstPage.BackColor = e.Color2;
            btnPreviousPage.BackColor = e.Color2;
            pnlPageIndicator.BackColor = e.Color3;
            btnNextPage.BackColor = e.Color2;
            btnLastPage.BackColor = e.Color2;
            btnRefresh.BackColor = e.Color2;

            pnlRange.BackColor = e.Color9;
            btnLastYear.BackColor = e.Color9;
            btnThisYear.BackColor = e.Color9;
            btnRangeClear.BackColor = e.Color9;
            pnlRangeHolder.BackColor = e.Color0;
            pnlRangeField.BackColor = e.Color3;
            pnlRangeStart.BackColor = e.Color3;
            pnlRangeEnd.BackColor = e.Color3;

            pnlFilter.BackColor = e.Color9;
            btnFilterClear.BackColor = e.Color9;
            pnlFilterHolder.BackColor = e.Color0;
            pnlFilter1.BackColor = e.Color3;
            pnlFilter2.BackColor = e.Color3;

            pnlFind.BackColor = e.Color9;
            btnFindClear.BackColor = e.Color9;
            pnlFindHolder.BackColor = e.Color0;
            pnlFindField.BackColor = e.Color3;
            pnlFindText.BackColor = e.Color3;

            pnlSort.BackColor = e.Color9;
            pnlSortHolder.BackColor = e.Color0;
            pnlSortField.BackColor = e.Color3;
            pnlSortDirection.BackColor = e.Color3;
        }

        public void LoadInitialData()
        {

        }

        private Expression<Func<User, bool>> GetExpression()
        {
            // Parameter Expression - represents the "User" entity in the expression
            var parameter = Expression.Parameter(typeof(User), "user");

            // Initialize an empty expression to combine conditions later
            Expression combinedExpression = Expression.Constant(true);

            //// Condition 1: Email equals
            //if (!string.IsNullOrEmpty(email))
            //{
            //    var emailProperty = Expression.Property(parameter, "EMail");
            //    var emailValue = Expression.Constant(email);
            //    var emailEquals = Expression.Equal(emailProperty, emailValue);

            //    combinedExpression = Expression.AndAlso(combinedExpression, emailEquals);
            //}

            // Condition 2: Role equals
            if (Role != null)
            {
                var property = Expression.Property(parameter, "Role");
                var value = Expression.Constant(Role);
                var expression = Expression.Equal(property, value);

                combinedExpression = Expression.AndAlso(combinedExpression, expression);
            }

            if (Sex != null)
            {
                var property = Expression.Property(parameter, "Sex");
                var value = Expression.Constant(Sex);
                var expression = Expression.Equal(property, value);

                combinedExpression = Expression.AndAlso(combinedExpression, expression);
            }

            if (!string.IsNullOrWhiteSpace(FindText))
            {
                var constant = Expression.Constant(FindText, typeof(string));
                var property = Expression.Property(parameter, FindField);
                var containsMethod = typeof(string).GetMethod("Contains", new[] { typeof(string) });
                var containsExpression = Expression.Call(property, containsMethod, constant);
                combinedExpression = Expression.AndAlso(combinedExpression, containsExpression);
            }

            // Final lambda expression: user => combined conditions
            return Expression.Lambda<Func<User, bool>>(combinedExpression, parameter);
        }
        #endregion

        #region Data & Actions
        private string MainTitleText { set { lblMainTitle.Text = $"      {value}"; } }
        private void lblMainTitle_DoubleClick(object sender, EventArgs e)
        {
            dataGridView1.SelectAll();
        }

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
            //        var path = await DbContext.Users.ExportToExcelAsync(RangeField, RangeStart, RangeEnd, UserRole, Sex, FindField, FindText, SortField, SortDirection);
            //        StopProgress();
            //        StatusText = "Data Exported";
            //        var option = MessageBox.Show($"User data successfully exported to \"{path}\".\nDo you want to open the exported file now?", "EXPORT", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            //        if (option == DialogResult.Yes)
            //        {
            //            MessageBox.Show("Please close any opened Excel files before proceeding.\nClick OK to continue opening the file.", "EXCEL", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //            Process.Start(path);
            //        }
            //        else
            //        {
            //            Process.Start(AppSettings.ABCFolderPath);
            //        }
            //        dataGridView1_SelectionChanged(null, null);
            //        break;
            //    }
            //    catch (Exception ex)
            //    {
            //        StopProgress();
            //        StatusText = "Error Occurred";
            //        result = MessageBox.Show($"An error occurred while exporting data from the Database to the Excel file.\n{ex.Message}\nPlease try again.", "ERROR", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            //    }
            //}
            dataGridView1_SelectionChanged(null, null);
        }

        private IList<User> SelectedRecords
        {
            get
            {
                return dataGridView1.SelectedRows.Cast<DataGridViewRow>().Select(dgvr => dgvr.DataBoundItem as User).ToList();
            }
        }

        private User SelectedRecord
        {
            get
            {
                return dataGridView1.CurrentRow.DataBoundItem as User;
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            btnEdit.Enabled = dataGridView1.SelectedRows.Count == 1;
            btnDelete.Enabled = dataGridView1.SelectedRows.Count > 0 && ValidateDeletePermission();
            StatusText = $"{dataGridView1.SelectedRows.Count} record(s) selected";
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F2:
                    btnEdit.PerformClick();
                    break;
                case Keys.Delete:
                    btnDelete.PerformClick();
                    break;
            }
            e.Handled = true;
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (btnEdit.Enabled) btnEdit.PerformClick();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (var form = new UserForm())
            {
                form.LoadInitialData();
                form.NewRecord();
                form.ShowDialog();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count != 1) return;

            using (var form = new UserForm())
            {
                form.LoadInitialData();
                form.ViewRecord(SelectedRecord);
                form.ShowDialog();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0) return;
            if (!ValidateDeletePermission()) return;
            var option = MessageBox.Show($"Do you want to delete the selected {dataGridView1.SelectedRows.Count} User record(s)?", "DELETE", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (option == DialogResult.Yes)
            {
                DeleteRecords();
            }
        }
        private bool ValidateDeletePermission()
        {
            return (User.Role == Enums.UserRole.Admin) && false;
        }

        private void DeleteRecords()
        {
            if (DbContext == null) return;

            var users = SelectedRecords.OrderBy(u => u.Email);
            var userCount = users.Count();
            var userNames = string.Join(",", users.Select(u => u.Email));
            DbContext.Users.RemoveRange(users);

            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                dataGridView1.Rows.Remove(row);
            }

            WriteLog.Invoke(new Log()
            {
                CreatedDate = DateTime.Now,
                CreatedUser = User,
                Title = "User",
                Action = LogAction.Delete,
                Text = $"Deleted {userCount} user(s) (#{userNames})"
            });
        }

        private int TotalRecords { get; set; } = 0;
        private int OldPageNumber { get; set; } = 1;
        private int PageSize { get { return 100; } }

        private void btnFirstPage_Click(object sender, EventArgs e)
        {
            PageNumber = 1;
        }

        private void btnPreviousPage_Click(object sender, EventArgs e)
        {
            if (PagedList.HasPreviousPage)
            {
                PageNumber--;
            }
        }
        private int PageNumber
        {
            get { return (int)nudPageNumber.Value; }
            set { nudPageNumber.Value = value; }
        }
        private async void nudPageNumber_ValueChanged(object sender, EventArgs e)
        {
            await RefreshAsync();
            nudPageNumber.Focus();
        }

        private void nudPageNumber_MouseWheel(object sender, MouseEventArgs e)
        {
            ((HandledMouseEventArgs)e).Handled = true;
        }

        private void btnNextPage_Click(object sender, EventArgs e)
        {
            if (PagedList.HasNextPage)
            {
                PageNumber++;
            }
        }

        private void btnLastPage_Click(object sender, EventArgs e)
        {
            PageNumber = PagedList.PageCount;
        }

        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            await RefreshAsync();
        }

        private IPagedList<User> PagedList { get; set; }

        public async Task RefreshAsync()
        {
            if (DbContext == null) return;
            var result = DialogResult.Retry;
            while (result == DialogResult.Retry)
            {
                try
                {
                    StartProgress("Refreshing...");
                    var queryable = DbContext.Users
                        .Where(GetExpression());
                    queryable = Helper.ApplyOrderBy(queryable, SortField, SortDirection);

                    PagedList = await queryable
                        .ToPagedListAsync(PageNumber, PageSize);
                    StopProgress();

                    dataGridView1.DataSource = new BindingList<User>(PagedList.ToList());
                    btnFirstPage.Enabled = PagedList.PageNumber > 1;
                    btnPreviousPage.Enabled = PagedList.HasPreviousPage;
                    btnNextPage.Enabled = PagedList.HasNextPage;
                    btnLastPage.Enabled = PagedList.PageNumber < PagedList.PageCount;
                    nudPageNumber.Maximum = PagedList.PageCount < 1 ? 1 : PagedList.PageCount;
                    lblPages.Text = $"/ {PagedList.PageCount}";
                    MainTitleText = $"Users [{PagedList.FirstItemOnPage} - {PagedList.LastItemOnPage} / {PagedList.TotalItemCount}]";

                    OldPageNumber = PageNumber;
                    break;
                }
                catch (Exception ex)
                {
                    StopProgress();
                    StatusText = "Error Occurred";
                    result = MessageBox.Show($"An error occurred while retrieving data from the Database.\n{ex.Message}\nPlease try again.", "ERROR", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                    if (result == DialogResult.Cancel)
                    {
                        PageNumber = OldPageNumber;
                    }
                }
            }
            dataGridView1_SelectionChanged(null, null);
        }
        #endregion

        #region Range
        private string RangeField
        {
            get { return cboRangeField.SelectedItem as string; }
            set { cboRangeField.SelectedItem = value; }
        }

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

        private async void cboRangeField_SelectedValueChanged(object sender, EventArgs e)
        {
            if (RangeStart == null && RangeEnd == null) return;

            await RefreshAsync();
            cboRangeField.Focus();
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
        private UserRole? Role
        {
            get
            {
                if (cboRole.Text != "All")
                {
                    UserRole v;
                    if (Enum.TryParse(cboRole.Text, out v))
                    {
                        return v;
                    }
                }
                return null;
            }
            set
            {
                cboRole.SelectedValueChanged -= cboRole_SelectedValueChanged;
                cboRole.SelectedItem = value == null ? "All" : value.ToString();
                cboRole.SelectedValueChanged += cboRole_SelectedValueChanged;
            }
        }

        private Sex? Sex
        {
            get
            {
                if (cboSex.Text != "Both" && Enum.TryParse(cboSex.Text, out Sex v))
                {
                    return v;
                }
                return null;
            }
            set
            {
                cboSex.SelectedValueChanged -= cboSex_SelectedValueChanged;
                cboSex.SelectedItem = value == null ? "Both" : value.ToString();
                cboSex.SelectedValueChanged += cboSex_SelectedValueChanged;
            }
        }

        private async void btnFilterClear_Click(object sender, EventArgs e)
        {
            if (Role == null && Sex == null) return;

            Role = null;
            Sex = null;

            await RefreshAsync();
            btnFilterClear.Focus();
        }

        private async void cboRole_SelectedValueChanged(object sender, EventArgs e)
        {
            await RefreshAsync();
            cboRole.Focus();
        }

        private async void cboSex_SelectedValueChanged(object sender, EventArgs e)
        {
            await RefreshAsync();
            cboSex.Focus();
        }
        #endregion

        #region Find
        private string FindField
        {
            get { return cboFindField.SelectedItem as string; }
            set { cboFindField.SelectedItem = value; }
        }
        private string FindText
        {
            get
            {
                var str = txtFindText.Text.Trim();
                return str == string.Empty ? null : str;
            }
            set { txtFindText.Text = value; }
        }
        private async void btnFindClear_Click(object sender, EventArgs e)
        {
            if (FindText == null) return;

            FindText = null;

            await RefreshAsync();
            btnFindClear.Focus();
        }

        private async void cboFindField_SelectedValueChanged(object sender, EventArgs e)
        {
            if (FindText == null) return;

            await RefreshAsync();
            cboFindField.Focus();
        }

        private async void txtFindText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                await RefreshAsync();
            }
            txtFindText.Focus();
        }
        #endregion

        #region Sort
        private string SortField
        {
            get { return cboSortField.SelectedItem as string; }
            set { cboSortField.SelectedItem = value; }
        }

        private string SortDirection
        {
            get { return cboSortDirection.SelectedItem as string; }
            set { cboSortDirection.SelectedItem = value; }
        }

        private async void cboSortField_SelectedValueChanged(object sender, EventArgs e)
        {
            await RefreshAsync();
            cboSortField.Focus();
        }

        private async void cboSortDirection_SelectedValueChanged(object sender, EventArgs e)
        {
            await RefreshAsync();
            cboSortDirection.Focus();
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

            dataGridView1_SelectionChanged(null, null);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            var elapsed = Stopwatch.Elapsed;
            StatusText = $"{ProgressText} ({elapsed.Minutes:00}:{elapsed.Seconds:00})";
        }
        #endregion
    }
}
