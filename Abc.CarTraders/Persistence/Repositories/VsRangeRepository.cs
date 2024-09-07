using ABC.CarTraders.Core.Domain;
using ABC.CarTraders.Core.Repositories;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Data.Entity;
using PagedList;
using PagedList.EntityFramework;
using ClosedXML.Excel;

namespace ABC.CarTraders.Persistence.Repositories
{
    public class VsRangeRepository : Repository<VsRange>, IVsRangeRepository
    {
        public VsRangeRepository(AbcCarTradersContext context) : base(context)
        {

        }

        public Task<int> GetMaxNoAsync(District district)
        {
            return GetQueryable().Where(vsr => vsr.ProvinceNo == district.ProvinceNo && vsr.DistrictNo == district.No).Select(vsr => (int)vsr.No).DefaultIfEmpty(0).MaxAsync();
        }

        public Task<VsRange> GetLastKeyRecordAsync(District district)
        {
            return GetQueryable().Where(vsr => vsr.ProvinceNo == district.ProvinceNo && vsr.DistrictNo == district.No).OrderByDescending(d => d.Code).FirstOrDefaultAsync();
        }

        private IQueryable<VsRange> GetQueryable(string rangeField, DateTime? rangeStart, DateTime? rangeEnd, Province vsRangeProvince, District vsRangeDistrict, string findField, string findText, string sortField, string sortDirection)
        {
            var qry = GetQueryable();

            if (rangeStart != null)
            {
                switch (rangeField)
                {
                    case "Created On":
                        qry = qry.Where(vsr => vsr.CreatedOn >= rangeStart);
                        break;
                    case "Modified On":
                        qry = qry.Where(vsr => vsr.ModifiedOn >= rangeStart);
                        break;
                }
            }

            if (rangeEnd != null)
            {
                switch (rangeField)
                {
                    case "Created On":
                        qry = qry.Where(vsr => vsr.CreatedOn <= rangeEnd);
                        break;
                    case "Modified On":
                        qry = qry.Where(vsr => vsr.ModifiedOn <= rangeEnd);
                        break;
                }
            }

            if (vsRangeProvince != null)
            {
                qry = qry.Where(vsr => vsr.ProvinceNo == vsRangeProvince.No);
            }

            if (vsRangeDistrict != null)
            {
                qry = qry.Where(vsr => vsr.ProvinceNo == vsRangeDistrict.ProvinceNo && vsr.DistrictNo == vsRangeDistrict.No);
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
                    case "Code":
                        qry = qry.OrderByDescending(t => t.ProvinceNo).ThenByDescending(t => t.DistrictNo).ThenByDescending(t => t.No);
                        break;
                    case "Name":
                        qry = qry.OrderByDescending(t => t.Name);
                        break;
                    default:
                        qry = qry.OrderByDescending(t => t.ProvinceNo).ThenByDescending(t => t.DistrictNo).ThenByDescending(t => t.No);
                        break;
                }
            }
            else
            {
                switch (sortField)
                {
                    case "Code":
                        qry = qry.OrderBy(t => t.ProvinceNo).ThenBy(t => t.DistrictNo).ThenBy(t => t.No);
                        break;
                    case "Name":
                        qry = qry.OrderBy(t => t.Name);
                        break;
                    default:
                        qry = qry.OrderBy(t => t.ProvinceNo).ThenBy(t => t.DistrictNo).ThenBy(t => t.No);
                        break;
                }
            }
            return qry;
        }

        public Task<IPagedList<VsRange>> GetPagedListAsync(string rangeField, DateTime? rangeStart, DateTime? rangeEnd, Province vsRangeProvince, District vsRangeDistrict, string findField, string findText, string sortField, string sortDirection, int pageNumber, int pageSize)
        {
            var qry = GetQueryable(rangeField, rangeStart, rangeEnd, vsRangeProvince, vsRangeDistrict, findField, findText, sortField, sortDirection);
            return qry.ToPagedListAsync(pageNumber, pageSize);
        }

        public static readonly string[] DATA_COLUMN_HEADERS = { "Code", "Name", "District", "Province", "Created On", "Created By", "Modified On", "Modified By", "Notes" };

        public async Task<string> ExportToExcelAsync(string rangeField, DateTime? rangeStart, DateTime? rangeEnd, Province vsRangeProvince, District vsRangeDistrict, string findField, string findText, string sortField, string sortDirection)
        {
            var qry = GetQueryable(rangeField, rangeStart, rangeEnd, vsRangeProvince, vsRangeDistrict, findField, findText, sortField, sortDirection);
            var vsRanges = await qry.ToListAsync();
            var vsRangeCount = vsRanges.Count;
            var path = System.IO.Path.Combine(AppSettings.ABCFolderPath, $"VSRanges_{DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss")}.xlsx");
            await Task.Run(() =>
            {
                var workbook = new XLWorkbook();
                var worksheet = workbook.Worksheets.Add("VS Ranges");

                for (int i = 0; i < DATA_COLUMN_HEADERS.Length; i++)
                {
                    worksheet.Cell(1, i + 1).Value = DATA_COLUMN_HEADERS[i];
                }
                for (int i = 0; i < vsRangeCount; i++)
                {
                    worksheet.Cell(i + 2, 1).Value = vsRanges[i].Code;
                    worksheet.Cell(i + 2, 2).Value = vsRanges[i].Name;
                    worksheet.Cell(i + 2, 3).Value = vsRanges[i].District?.ToString();
                    worksheet.Cell(i + 2, 4).Value = vsRanges[i].Province?.ToString();
                    worksheet.Cell(i + 2, 5).Value = vsRanges[i].CreatedOn?.ToString();
                    worksheet.Cell(i + 2, 6).Value = vsRanges[i].CreatedBy?.ToString();
                    worksheet.Cell(i + 2, 7).Value = vsRanges[i].ModifiedOn?.ToString();
                    worksheet.Cell(i + 2, 8).Value = vsRanges[i].ModifiedBy?.ToString();
                    worksheet.Cell(i + 2, 9).Value = vsRanges[i].Notes;
                }
                workbook.SaveAs(path);
            });
            return path;
        }
    }
}
