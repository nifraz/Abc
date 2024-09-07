using ABC.CarTraders.Core.Domain;
using ABC.CarTraders.Core.Repositories;
using PagedList;
using PagedList.EntityFramework;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Data.Entity;
using ClosedXML.Excel;

namespace ABC.CarTraders.Persistence.Repositories
{
    public class LogRepository : Repository<Log>, ILogRepository
    {
        public LogRepository(AbcCarTradersContext context) : base(context)
        {

        }

        private IQueryable<Log> GetQueryable(string rangeField, DateTime? rangeStart, DateTime? rangeEnd, LogAction? logAction, User logUser, string findField, string findText, string sortField, string sortDirection)
        {
            var qry = GetQueryable();

            if (rangeStart != null)
            {
                switch (rangeField)
                {
                    case "Time":
                        qry = qry.Where(l => l.Time >= rangeStart);
                        break;
                }
            }

            if (rangeEnd != null)
            {
                switch (rangeField)
                {
                    case "Time":
                        qry = qry.Where(l => l.Time <= rangeEnd);
                        break;
                }
            }

            if (logAction != null)
            {
                qry = qry.Where(l => l.Action == logAction);
            }

            if (logUser != null)
            {
                qry = qry.Where(l => l.Username == logUser.Username);
            }

            if (findText != null)
            {
                switch (findField)
                {
                    case "Username":
                        qry = qry.Where(l => l.Username.Contains(findText));
                        break;
                    case "Title":
                        qry = qry.Where(l => l.Title.Contains(findText));
                        break;
                    case "Text":
                        qry = qry.Where(l => l.Text.Contains(findText));
                        break;
                }
            }

            if (sortDirection.Equals("Descending"))
            {
                switch (sortField)
                {
                    case "ID":
                        qry = qry.OrderByDescending(l => l.Id);
                        break;
                    case "Username":
                        qry = qry.OrderByDescending(l => l.Username);
                        break;
                    case "Time":
                        qry = qry.OrderByDescending(l => l.Time);
                        break;
                    case "Title":
                        qry = qry.OrderByDescending(l => l.Title);
                        break;
                    default:
                        qry = qry.OrderByDescending(l => l.Id);
                        break;
                }
            }
            else
            {
                switch (sortField)
                {
                    case "ID":
                        qry = qry.OrderBy(l => l.Id);
                        break;
                    case "Username":
                        qry = qry.OrderBy(l => l.Username);
                        break;
                    case "Time":
                        qry = qry.OrderBy(l => l.Time);
                        break;
                    case "Title":
                        qry = qry.OrderBy(l => l.Title);
                        break;
                    default:
                        qry = qry.OrderBy(l => l.Id);
                        break;
                }
            }
            return qry;
        }

        public Task<IPagedList<Log>> GetPagedListAsync(string rangeField, DateTime? rangeStart, DateTime? rangeEnd, LogAction? logAction, User logUser, string findField, string findText, string sortField, string sortDirection, int pageNumber, int pageSize)
        {
            var qry = GetQueryable(rangeField, rangeStart, rangeEnd, logAction, logUser, findField, findText, sortField, sortDirection);
            return qry.ToPagedListAsync(pageNumber, pageSize);
        }

        public static readonly string[] DATA_COLUMN_HEADERS = new string[] { "ID", "User", "Time", "Title", "Action", "Text"};
        public async Task<string> ExportToExcelAsync(string rangeField, DateTime? rangeStart, DateTime? rangeEnd, LogAction? logAction, User logUser, string findField, string findText, string sortField, string sortDirection)
        {
            var qry = GetQueryable(rangeField, rangeStart, rangeEnd, logAction, logUser, findField, findText, sortField, sortDirection);
            var logs = await qry.ToListAsync();
            var logCount = logs.Count;
            var path = System.IO.Path.Combine(AppSettings.ABCFolderPath, $"Logs_{DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss")}.xlsx");
            await Task.Run(() =>
            {
                var workbook = new XLWorkbook();
                var worksheet = workbook.Worksheets.Add("Logs");

                for (int i = 0; i < DATA_COLUMN_HEADERS.Length; i++)
                {
                    worksheet.Cell(1, i + 1).Value = DATA_COLUMN_HEADERS[i];
                }
                for (int i = 0; i < logCount; i++)
                {
                    worksheet.Cell(i + 2, 1).Value = logs[i].Id;
                    worksheet.Cell(i + 2, 2).Value = logs[i].User?.ToString();
                    worksheet.Cell(i + 2, 3).Value = logs[i].Time.ToString();
                    worksheet.Cell(i + 2, 4).Value = logs[i].Title;
                    worksheet.Cell(i + 2, 5).Value = logs[i].Action.ToString();
                    worksheet.Cell(i + 2, 6).Value = logs[i].Text;
                }
                workbook.SaveAs(path);
            });
            return path;
        }
    }
}
