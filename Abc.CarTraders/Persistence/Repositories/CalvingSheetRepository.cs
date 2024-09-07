using ABC.CarTraders.Core.Domain;
using ABC.CarTraders.Core.Repositories;
using PagedList;
using PagedList.EntityFramework;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Data.Entity;
using ClosedXML.Excel;
//using Z.EntityFramework.Plus;
using System.Collections.Generic;

namespace ABC.CarTraders.Persistence.Repositories
{
    class CalvingSheetRepository : Repository<CalvingSheet>, ICalvingSheetRepository
    {
        public CalvingSheetRepository(AbcCarTradersContext context) : base(context)
        {

        }

        private IQueryable<CalvingSheet> GetQueryable(string rangeField, DateTime? rangeStart, DateTime? rangeEnd, Province calvingSheetProvince, District calvingSheetDistrict, VsRange calvingSheetVsRange, Institute calvingSheetInstitute, int? calvingSheetTechnicianCode, string sortField, string sortDirection)
        {
            var qry = GetQueryable().Include(cs => cs.CalvingRecords);

            if (rangeStart != null)
            {
                switch (rangeField)
                {
                    case "Year / Month":
                        qry = qry.Where(cs => cs.Year >= rangeStart.Value.Year && cs.Month >= rangeStart.Value.Month);
                        break;
                    case "Created On":
                        qry = qry.Where(cs => cs.CreatedOn >= rangeStart);
                        break;
                    case "Modified On":
                        qry = qry.Where(cs => cs.ModifiedOn >= rangeStart);
                        break;
                }
            }

            if (rangeEnd != null)
            {
                switch (rangeField)
                {
                    case "Year / Month":
                        qry = qry.Where(cs => cs.Year <= rangeEnd.Value.Year && cs.Month <= rangeEnd.Value.Month);
                        break;
                    case "Created On":
                        qry = qry.Where(cs => cs.CreatedOn <= rangeEnd);
                        break;
                    case "Modified On":
                        qry = qry.Where(cs => cs.ModifiedOn <= rangeEnd);
                        break;
                }
            }

            if (calvingSheetProvince != null)
            {
                qry = qry.Where(cs => cs.ProvinceNo == calvingSheetProvince.No);
            }

            if (calvingSheetDistrict != null)
            {
                qry = qry.Where(cs => cs.ProvinceNo == calvingSheetDistrict.ProvinceNo && cs.DistrictNo == calvingSheetDistrict.No);
            }

            if (calvingSheetVsRange != null)
            {
                qry = qry.Where(cs => cs.ProvinceNo == calvingSheetVsRange.ProvinceNo && cs.DistrictNo == calvingSheetVsRange.DistrictNo && cs.VsRangeNo == calvingSheetVsRange.No);
            }

            if (calvingSheetInstitute != null)
            {
                qry = qry.Where(cs => cs.InstituteName == calvingSheetInstitute.Name);
            }

            if (calvingSheetTechnicianCode != null)
            {
                if (calvingSheetTechnicianCode == 0)
                {
                    qry = qry.Where(cs => cs.TechnicianCode == null);
                }
                else
                {
                    qry = qry.Where(cs => cs.TechnicianCode == calvingSheetTechnicianCode);
                }
            }

            if (sortDirection.Equals("Descending"))
            {
                switch (sortField)
                {
                    case "ID":
                        qry = qry.OrderByDescending(cs => cs.Id);
                        break;
                    case "Year / Month":
                        qry = qry.OrderByDescending(cs => cs.Year).ThenByDescending(cs => cs.Month);
                        break;
                    case "VS Range":
                        qry = qry.OrderByDescending(cs => cs.VsRange.Name);
                        break;
                    case "Tech. Code":
                        qry = qry.OrderByDescending(cs => cs.TechnicianCode);
                        break;
                    default:
                        qry = qry.OrderByDescending(cs => cs.Id);
                        break;
                }
            }
            else
            {
                switch (sortField)
                {
                    case "Id":
                        qry = qry.OrderBy(cs => cs.Id);
                        break;
                    case "Year / Month":
                        qry = qry.OrderBy(cs => cs.Year).ThenBy(cs => cs.Month);
                        break;
                    case "VS Range":
                        qry = qry.OrderBy(cs => cs.VsRange.Name);
                        break;
                    case "Tech. Code":
                        qry = qry.OrderBy(cs => cs.TechnicianCode);
                        break;
                    default:
                        qry = qry.OrderBy(cs => cs.Id);
                        break;
                }
            }
            return qry;
        }

        public Task<IPagedList<CalvingSheet>> GetPagedListAsync(string rangeField, DateTime? rangeStart, DateTime? rangeEnd, Province calvingSheetProvince, District calvingSheetDistrict, VsRange calvingSheetVsRange, Institute calvingSheetInstitute, int? calvingSheetTechnicianCode, string sortField, string sortDirection, int pageNumber, int pageSize)
        {
            var qry = GetQueryable(rangeField, rangeStart, rangeEnd, calvingSheetProvince, calvingSheetDistrict, calvingSheetVsRange, calvingSheetInstitute, calvingSheetTechnicianCode, sortField, sortDirection);
            return qry.ToPagedListAsync(pageNumber, pageSize);
        }

        public static readonly string[] DATA_COLUMN_HEADERS = new string[] { "ID", "Year", "Month", "Province", "District", "VS Range", "Institute", "Tech. Code", "Calvings", "Males", "Females", "Created On", "Created By", "Modified On", "Modified By", "Notes" };

        public async Task<string> ExportToExcelAsync(string rangeField, DateTime? rangeStart, DateTime? rangeEnd, Province calvingSheetProvince, District calvingSheetDistrict, VsRange calvingSheetVsRange, Institute calvingSheetInstitute, int? calvingSheetTechnicianCode, string sortField, string sortDirection)
        {
            var qry = GetQueryable(rangeField, rangeStart, rangeEnd, calvingSheetProvince, calvingSheetDistrict, calvingSheetVsRange, calvingSheetInstitute, calvingSheetTechnicianCode, sortField, sortDirection);

            var calvingSheets = await qry.ToListAsync();
            var calvingSheetCount = calvingSheets.Count();
            var calvingRecords = calvingSheets.SelectMany(cs => cs.CalvingRecords.OrderBy(cr => cr.No)).ToList();
            var calvingRecordsCount = calvingRecords.Count();
            var path = System.IO.Path.Combine(AppSettings.ABCFolderPath, $"CalvingSheets_{DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss")}.xlsx");
            await Task.Run(() =>
            {
                var workbook = new XLWorkbook();

                var worksheet1 = workbook.Worksheets.Add("Calving Sheets");

                for (int i = 0; i < DATA_COLUMN_HEADERS.Length; i++)
                {
                    worksheet1.Cell(1, i + 1).Value = DATA_COLUMN_HEADERS[i];
                }
                for (int i = 0; i < calvingSheetCount; i++)
                {
                    worksheet1.Cell(i + 2, 1).Value = calvingSheets[i].Id;
                    worksheet1.Cell(i + 2, 2).Value = calvingSheets[i].Year;
                    worksheet1.Cell(i + 2, 3).Value = calvingSheets[i].Month;
                    worksheet1.Cell(i + 2, 4).Value = calvingSheets[i].ProvinceName;
                    worksheet1.Cell(i + 2, 5).Value = calvingSheets[i].DistrictName;
                    worksheet1.Cell(i + 2, 6).Value = calvingSheets[i].VsRangeName;
                    worksheet1.Cell(i + 2, 7).Value = calvingSheets[i].InstituteName;
                    worksheet1.Cell(i + 2, 8).Value = calvingSheets[i].TechnicianCode;
                    worksheet1.Cell(i + 2, 9).Value = calvingSheets[i].Calvings;
                    worksheet1.Cell(i + 2, 10).Value = calvingSheets[i].Males;
                    worksheet1.Cell(i + 2, 11).Value = calvingSheets[i].Females;
                    worksheet1.Cell(i + 2, 12).Value = calvingSheets[i].CreatedOn?.ToString();
                    worksheet1.Cell(i + 2, 13).Value = calvingSheets[i].CreatedBy?.ToString();
                    worksheet1.Cell(i + 2, 14).Value = calvingSheets[i].ModifiedOn?.ToString();
                    worksheet1.Cell(i + 2, 15).Value = calvingSheets[i].ModifiedBy?.ToString();
                    worksheet1.Cell(i + 2, 16).Value = calvingSheets[i].Notes;
                }
                workbook.SaveAs(path);
            });
            return path;
        }

        ////Update
        //public Task<int> UpdateAllToNullAsync(User user)
        //{
        //    return GetQueryable().Where(cs => cs.CreatedByUsername == user.Username).UpdateAsync(cs => new CalvingSheet() { CreatedByUsername = null });
        //}
        //public Task<int> UpdateAllToNullAsync(VsRange vsRange)
        //{
        //    return GetQueryable().Where(cs => cs.ProvinceNo == vsRange.ProvinceNo && cs.DistrictNo == vsRange.DistrictNo && cs.VsRangeNo == vsRange.No).UpdateAsync(cs => new CalvingSheet() { ProvinceNo = null, DistrictNo = null, VsRangeNo = null });
        //}
        //public Task<int> UpdateAllToNullAsync(Institute institute)
        //{
        //    return GetQueryable().Where(cs => cs.InstituteName == institute.Name).UpdateAsync(cs => new CalvingSheet() { InstituteName = null });
        //}
        //public Task<int> UpdateAllToNullAsync(Technician technician)
        //{
        //    return GetQueryable().Where(cs => cs.TechnicianCode == technician.Code).UpdateAsync(cs => new CalvingSheet() { TechnicianCode = null });
        //}
        //public Task<int> UpdateAllToNullAsync(IEnumerable<int?> technicianCodes)
        //{
        //    return GetQueryable().Where(cs => technicianCodes.Contains(cs.TechnicianCode)).UpdateAsync(cs => new CalvingSheet() { TechnicianCode = null });
        //}

        ////Delete
        //public Task<int> DeleteAllAsync(User user)
        //{
        //    return GetQueryable().Where(cs => cs.CreatedByUsername == user.Username).DeleteAsync();
        //}
        //public Task<int> DeleteAllAsync(VsRange vsRange)
        //{
        //    return GetQueryable().Where(cs => cs.ProvinceNo == vsRange.ProvinceNo && cs.DistrictNo == vsRange.DistrictNo && cs.VsRangeNo == vsRange.No).DeleteAsync();
        //}
        //public Task<int> DeleteAllAsync(Institute institute)
        //{
        //    return GetQueryable().Where(cs => cs.InstituteName == institute.Name).DeleteAsync();
        //}
        //public Task<int> DeleteAllAsync(Technician technician)
        //{
        //    return GetQueryable().Where(cs => cs.TechnicianCode == technician.Code).DeleteAsync();
        //}
        //public Task<int> DeleteAllAsync(IEnumerable<int?> technicianCodes)
        //{
        //    return GetQueryable().Where(cs => technicianCodes.Contains(cs.TechnicianCode)).DeleteAsync();
        //}
    }
}
