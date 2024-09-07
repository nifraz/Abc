using ClosedXML.Excel;
using ABC.CarTraders.Core.Domain;
using ABC.CarTraders.Core.Repositories;
using PagedList;
using PagedList.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABC.CarTraders.Persistence.Repositories
{
    public class InstituteRepository : Repository<Institute>, IInstituteRepository
    {
        public InstituteRepository(AbcCarTradersContext context) : base(context)
        {

        }

        private IQueryable<Institute> GetQueryable(string rangeField, DateTime? rangeStart, DateTime? rangeEnd, string findField, string findText, string sortField, string sortDirection)
        {
            var qry = GetQueryable();

            if (rangeStart != null)
            {
                switch (rangeField)
                {
                    case "Created On":
                        qry = qry.Where(i => i.CreatedOn >= rangeStart);
                        break;
                    case "Modified On":
                        qry = qry.Where(i => i.ModifiedOn >= rangeStart);
                        break;
                }
            }

            if (rangeEnd != null)
            {
                switch (rangeField)
                {
                    case "Created On":
                        qry = qry.Where(i => i.CreatedOn <= rangeEnd);
                        break;
                    case "Modified On":
                        qry = qry.Where(i => i.ModifiedOn <= rangeEnd);
                        break;
                }
            }

            if (findText != null)
            {
                switch (findField)
                {
                    case "Name":
                        qry = qry.Where(vsr => vsr.Name.Contains(findText));
                        break;
                }
            }

            if (sortDirection.Equals("Descending"))
            {
                switch (sortField)
                {
                    case "Name":
                        qry = qry.OrderByDescending(t => t.Name);
                        break;
                    default:
                        qry = qry.OrderByDescending(t => t.Name);
                        break;
                }
            }
            else
            {
                switch (sortField)
                {
                    case "Name":
                        qry = qry.OrderBy(t => t.Name);
                        break;
                    default:
                        qry = qry.OrderBy(t => t.Name);
                        break;
                }
            }
            return qry;
        }

        public Task<IPagedList<Institute>> GetPagedListAsync(string rangeField, DateTime? rangeStart, DateTime? rangeEnd, string findField, string findText, string sortField, string sortDirection, int pageNumber, int pageSize)
        {
            var qry = GetQueryable(rangeField, rangeStart, rangeEnd, findField, findText, sortField, sortDirection);
            return qry.ToPagedListAsync(pageNumber, pageSize);
        }

        public static readonly string[] DATA_COLUMN_HEADERS = { "Name", "Created On", "Created By", "Modified On", "Modified By", "Notes" };

        public async Task<string> ExportToExcelAsync(string rangeField, DateTime? rangeStart, DateTime? rangeEnd, string findField, string findText, string sortField, string sortDirection)
        {
            var qry = GetQueryable(rangeField, rangeStart, rangeEnd, findField, findText, sortField, sortDirection);
            var Institutes = await qry.ToListAsync();
            var InstituteCount = Institutes.Count;
            var path = System.IO.Path.Combine(AppSettings.ABCFolderPath, $"Institutes_{DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss")}.xlsx");
            await Task.Run(() =>
            {
                var workbook = new XLWorkbook();
                var worksheet = workbook.Worksheets.Add("VS Ranges");

                for (int i = 0; i < DATA_COLUMN_HEADERS.Length; i++)
                {
                    worksheet.Cell(1, i + 1).Value = DATA_COLUMN_HEADERS[i];
                }
                for (int i = 0; i < InstituteCount; i++)
                {
                    worksheet.Cell(i + 2, 1).Value = Institutes[i].Name;
                    worksheet.Cell(i + 2, 2).Value = Institutes[i].CreatedOn?.ToString();
                    worksheet.Cell(i + 2, 3).Value = Institutes[i].CreatedBy?.ToString();
                    worksheet.Cell(i + 2, 4).Value = Institutes[i].ModifiedOn?.ToString();
                    worksheet.Cell(i + 2, 5).Value = Institutes[i].ModifiedBy?.ToString();
                    worksheet.Cell(i + 2, 6).Value = Institutes[i].Notes;
                }
                workbook.SaveAs(path);
            });
            return path;
        }
    }
}
