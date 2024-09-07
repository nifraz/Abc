using ABC.CarTraders.Core.Domain;
using ABC.CarTraders.Core.Repositories;
using PagedList;
using PagedList.EntityFramework;
using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using ClosedXML.Excel;

namespace ABC.CarTraders.Persistence.Repositories
{
    class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(AbcCarTradersContext context) : base(context)
        {

        }

        private IQueryable<User> GetQueryable(string rangeField, DateTime? rangeStart, DateTime? rangeEnd, UserRole? userRole, UserSex? userSex, string findField, string findText, string sortField, string sortDirection)
        {
            var qry = GetQueryable();

            if (rangeStart != null)
            {
                switch (rangeField)
                {
                    case "Created On":
                        qry = qry.Where(u => u.CreatedOn >= rangeStart);
                        break;
                    case "Modified On":
                        qry = qry.Where(u => u.ModifiedOn >= rangeStart);
                        break;
                }
            }

            if (rangeEnd != null)
            {
                switch (rangeField)
                {
                    case "Created On":
                        qry = qry.Where(u => u.CreatedOn <= rangeEnd);
                        break;
                    case "Modified On":
                        qry = qry.Where(u => u.ModifiedOn <= rangeEnd);
                        break;
                }
            }

            if (userRole != null)
            {
                qry = qry.Where(u => u.Role == userRole);
            }

            if (userSex != null)
            {
                qry = qry.Where(u => u.Sex == userSex);
            }

            if (findText != null)
            {
                switch (findField)
                {
                    case "Username":
                        qry = qry.Where(t => t.Username.Contains(findText));
                        break;
                    case "Name":
                        qry = qry.Where(t => t.Name.Contains(findText));
                        break;
                    case "E-Mail":
                        qry = qry.Where(t => t.EMail.Contains(findText));
                        break;
                    case "Phone No":
                        qry = qry.Where(t => t.PhoneNo.Contains(findText));
                        break;
                }
            }

            if (sortDirection.Equals("Descending"))
            {
                switch (sortField)
                {
                    case "Username":
                        qry = qry.OrderByDescending(t => t.Username);
                        break;
                    case "Name":
                        qry = qry.OrderByDescending(t => t.Name);
                        break;
                    case "E-Mail":
                        qry = qry.OrderByDescending(t => t.EMail);
                        break;
                    case "Phone No":
                        qry = qry.OrderByDescending(t => t.PhoneNo);
                        break;
                    default:
                        qry = qry.OrderByDescending(t => t.Username);
                        break;
                }
            }
            else
            {
                switch (sortField)
                {
                    case "Username":
                        qry = qry.OrderBy(t => t.Username);
                        break;
                    case "Name":
                        qry = qry.OrderBy(t => t.Name);
                        break;
                    case "E-Mail":
                        qry = qry.OrderBy(t => t.EMail);
                        break;
                    case "Phone No":
                        qry = qry.OrderBy(t => t.PhoneNo);
                        break;
                    default:
                        qry = qry.OrderBy(t => t.Username);
                        break;
                }
            }
            return qry;
        }

        public Task<IPagedList<User>> GetPagedListAsync(string rangeField, DateTime? rangeStart, DateTime? rangeEnd, UserRole? userRole, UserSex? userSex, string findField, string findText, string sortField, string sortDirection, int pageNumber, int pageSize)
        {
            var qry = GetQueryable(rangeField, rangeStart, rangeEnd, userRole, userSex, findField, findText, sortField, sortDirection);
            return qry.ToPagedListAsync(pageNumber, pageSize);
        }

        public static readonly string[] DATA_COLUMN_HEADERS = { "Username", "Name", "Sex", "E-Mail", "Phone No", "Role", "Created On", "Created By", "Modified On", "Modified By", "Notes" };
        public async Task<string> ExportToExcelAsync(string rangeField, DateTime? rangeStart, DateTime? rangeEnd, UserRole? userRole, UserSex? userSex, string findField, string findText, string sortField, string sortDirection)
        {
            var qry = GetQueryable(rangeField, rangeStart, rangeEnd, userRole, userSex, findField, findText, sortField, sortDirection);
            var users = await qry.ToListAsync();
            var userCount = users.Count;
            var path = System.IO.Path.Combine(AppSettings.ABCFolderPath, $"Users_{DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss")}.xlsx");
            await Task.Run(() =>
            {
                var workbook = new XLWorkbook();
                var worksheet = workbook.Worksheets.Add("Users");

                for (int i = 0; i < DATA_COLUMN_HEADERS.Length; i++)
                {
                    worksheet.Cell(1, i + 1).Value = DATA_COLUMN_HEADERS[i];
                }
                for (int i = 0; i < userCount; i++)
                {
                    worksheet.Cell(i + 2, 1).Value = users[i].Username;
                    worksheet.Cell(i + 2, 2).Value = users[i].Name;
                    worksheet.Cell(i + 2, 3).Value = users[i].Sex.ToString();
                    worksheet.Cell(i + 2, 4).Value = users[i].EMail;
                    worksheet.Cell(i + 2, 5).Value = users[i].PhoneNo;
                    worksheet.Cell(i + 2, 6).Value = users[i].Role.ToString();
                    worksheet.Cell(i + 2, 7).Value = users[i].CreatedOn?.ToString();
                    worksheet.Cell(i + 2, 8).Value = users[i].CreatedBy?.ToString();
                    worksheet.Cell(i + 2, 9).Value = users[i].ModifiedOn?.ToString();
                    worksheet.Cell(i + 2, 10).Value = users[i].ModifiedBy?.ToString();
                    worksheet.Cell(i + 2, 11).Value = users[i].Notes;
                }
                workbook.SaveAs(path);
            });
            return path;
        }
    }
}
