using ABC.CarTraders.Core.Domain;
using ABC.CarTraders.Core.Repositories;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Data.Entity;
using PagedList;
using PagedList.EntityFramework;
using ClosedXML.Excel;
//using Z.EntityFramework.Plus;

namespace ABC.CarTraders.Persistence.Repositories
{
    class TechnicianRepository : Repository<Technician>, ITechnicianRepository
    {
        public TechnicianRepository(AbcCarTradersContext context) : base(context)
        {

        }

        public Task<int> GetMaxCodeAsync(TechnicianType? technicianType)
        {
            var qry = GetQueryable();
            if (technicianType != null)
            {
                qry = qry.Where(t => t.Type == technicianType);
            }
            return qry.Select(t => t.Code).DefaultIfEmpty(0).MaxAsync();
        }

        public Task<Technician> GetLastKeyRecordAsync(TechnicianType? technicianType)
        {
            var qry = GetQueryable();
            if (technicianType != null)
            {
                qry = qry.Where(t => t.Type == technicianType);
            }
            return qry.OrderByDescending(t => t.Code).FirstOrDefaultAsync();
        }

        private IQueryable<Technician> GetQueryable(string rangeField, DateTime? rangeStart, DateTime? rangeEnd, Province technicianProvince, District technicianDistrict, VsRange technicianVsRange, Institute technicianInstitute, TechnicianType? technicianType, TechnicianStatus? technicianStatus, string findField, string findText, string sortField, string sortDirection)
        {
            var qry = GetQueryable().Include(t => t.CalvingSheets);

            if (rangeStart != null)
            {
                switch (rangeField)
                {
                    case "Issued Date":
                        qry = qry.Where(t => t.IssuedDate >= rangeStart);
                        break;
                    case "Created On":
                        qry = qry.Where(t => t.CreatedOn >= rangeStart);
                        break;
                    case "Modified On":
                        qry = qry.Where(t => t.ModifiedOn >= rangeStart);
                        break;
                }
            }

            if (rangeEnd != null)
            {
                switch (rangeField)
                {
                    case "Issued Date":
                        qry = qry.Where(t => t.IssuedDate <= rangeEnd);
                        break;
                    case "Created On":
                        qry = qry.Where(t => t.CreatedOn <= rangeEnd);
                        break;
                    case "Modified On":
                        qry = qry.Where(t => t.ModifiedOn <= rangeEnd);
                        break;
                }
            }

            if (technicianProvince != null)
            {
                qry = qry.Where(t => t.ProvinceNo == technicianProvince.No);
            }

            if (technicianDistrict != null)
            {
                qry = qry.Where(t => t.ProvinceNo == technicianDistrict.ProvinceNo && t.DistrictNo == technicianDistrict.No);
            }

            if (technicianVsRange != null)
            {
                qry = qry.Where(t => t.ProvinceNo == technicianVsRange.ProvinceNo && t.DistrictNo == technicianVsRange.DistrictNo && t.VsRangeNo == technicianVsRange.No);
            }

            if (technicianInstitute != null)
            {
                qry = qry.Where(t => t.InstituteName == technicianInstitute.Name);
            }

            if (technicianType != null)
            {
                qry = qry.Where(t => t.Type == technicianType);
            }

            if (technicianStatus != null)
            {
                qry = qry.Where(t => t.Status == technicianStatus);
            }

            if (findText != null)
            {
                switch (findField)
                {
                    case "Name":
                        qry = qry.Where(t => t.Name.Contains(findText));
                        break;
                    case "NIC No":
                        qry = qry.Where(t => t.NicNo.Contains(findText));
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
                    case "Code":
                        qry = qry.OrderByDescending(t => t.Code);
                        break;
                    case "Name":
                        qry = qry.OrderByDescending(t => t.Name);
                        break;
                    case "NIC No":
                        qry = qry.OrderByDescending(t => t.NicNo);
                        break;
                    case "Phone No":
                        qry = qry.OrderByDescending(t => t.PhoneNo);
                        break;
                    default:
                        qry = qry.OrderByDescending(t => t.Code);
                        break;
                }
            }
            else
            {
                switch (sortField)
                {
                    case "Code":
                        qry = qry.OrderBy(t => t.Code);
                        break;
                    case "Name":
                        qry = qry.OrderBy(t => t.Name);
                        break;
                    case "NIC No":
                        qry = qry.OrderBy(t => t.NicNo);
                        break;
                    case "Phone No":
                        qry = qry.OrderBy(t => t.PhoneNo);
                        break;
                    default:
                        qry = qry.OrderBy(t => t.Code);
                        break;
                }
            }
            return qry;
        }

        public async Task<IPagedList<Technician>> GetPagedListAsync(string rangeField, DateTime? rangeStart, DateTime? rangeEnd, Province technicianProvince, District technicianDistrict, VsRange technicianVsRange, Institute technicianInstitute, TechnicianType? technicianType, TechnicianStatus? technicianStatus, string findField, string findText, string sortField, string sortDirection, int pageNumber, int pageSize)
        {
            var qry = GetQueryable(rangeField, rangeStart, rangeEnd, technicianProvince, technicianDistrict, technicianVsRange, technicianInstitute, technicianType, technicianStatus, findField, findText, sortField, sortDirection);
            return await qry.ToPagedListAsync(pageNumber, pageSize);
        }

        public static readonly string[] DATA_COLUMN_HEADERS = { "Code", "Name", "NIC No", "Phone No", "Province", "District", "VS Range", "Institute", "Issued Date", "Type", "Status", "Created On", "Created By", "Modified On", "Modified By", "Notes" };
        public async Task<string> ExportToExcelAsync(string rangeField, DateTime? rangeStart, DateTime? rangeEnd, Province technicianProvince, District technicianDistrict, VsRange technicianVsRange, Institute technicianInstitute, TechnicianType? technicianType, TechnicianStatus? technicianStatus, string findField, string findText, string sortField, string sortDirection)
        {
            var qry = GetQueryable(rangeField, rangeStart, rangeEnd, technicianProvince, technicianDistrict, technicianVsRange, technicianInstitute, technicianType, technicianStatus, findField, findText, sortField, sortDirection);
            var technicians = await qry.ToListAsync();
            var technicianCount = technicians.Count;
            var path = System.IO.Path.Combine(AppSettings.ABCFolderPath, $"Technicians_{DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss")}.xlsx");
            await Task.Run(() =>
            {
                var workbook = new XLWorkbook();
                var worksheet = workbook.Worksheets.Add("Technicians");

                for (int i = 0; i < DATA_COLUMN_HEADERS.Length; i++)
                {
                    worksheet.Cell(1, i + 1).Value = DATA_COLUMN_HEADERS[i];
                }
                for (int i = 0; i < technicianCount; i++)
                {
                    worksheet.Cell(i + 2, 1).Value = technicians[i].Code;
                    worksheet.Cell(i + 2, 2).Value = technicians[i].Name;
                    worksheet.Cell(i + 2, 3).Value = technicians[i].NicNo;
                    worksheet.Cell(i + 2, 4).Value = technicians[i].PhoneNo;
                    worksheet.Cell(i + 2, 5).Value = technicians[i].ProvinceName;
                    worksheet.Cell(i + 2, 6).Value = technicians[i].DistrictName;
                    worksheet.Cell(i + 2, 7).Value = technicians[i].VsRangeName;
                    worksheet.Cell(i + 2, 8).Value = technicians[i].InstituteName;
                    worksheet.Cell(i + 2, 9).Value = technicians[i].IssuedDate?.ToShortDateString();
                    worksheet.Cell(i + 2, 10).Value = technicians[i].Type.ToString();
                    worksheet.Cell(i + 2, 11).Value = technicians[i].Status.ToString();
                    worksheet.Cell(i + 2, 12).Value = technicians[i].CreatedOn?.ToString();
                    worksheet.Cell(i + 2, 13).Value = technicians[i].CreatedBy?.ToString();
                    worksheet.Cell(i + 2, 14).Value = technicians[i].ModifiedOn?.ToString();
                    worksheet.Cell(i + 2, 15).Value = technicians[i].ModifiedBy?.ToString();
                    worksheet.Cell(i + 2, 16).Value = technicians[i].Notes;
                }
                workbook.SaveAs(path);
            });
            return path;
        }

        ////Update
        //public Task<int> UpdateAllToNullAsync(User user)
        //{
        //    return GetQueryable().Where(t => t.CreatedByUsername == user.Username).UpdateAsync(t => new Technician() { CreatedByUsername = null });
        //}
        //public Task<int> UpdateAllToNullAsync(VsRange vsRange)
        //{
        //    return GetQueryable().Where(t => t.ProvinceNo == vsRange.ProvinceNo && t.DistrictNo == vsRange.DistrictNo && t.VsRangeNo == vsRange.No).UpdateAsync(t => new Technician() { ProvinceNo = null, DistrictNo = null, VsRangeNo = null });
        //}
        //public Task<int> UpdateAllToNullAsync(Institute institute)
        //{
        //    return GetQueryable().Where(t => t.InstituteName == institute.Name).UpdateAsync(t => new Technician() { InstituteName = null });
        //}

        ////Delete
        //public Task<int> DeleteAllAsync(User user)
        //{
        //    return GetQueryable().Where(t => t.CreatedByUsername == user.Username).DeleteAsync();
        //}
        //public Task<int> DeleteAllAsync(VsRange vsRange)
        //{
        //    return GetQueryable().Where(t => t.ProvinceNo == vsRange.ProvinceNo && t.DistrictNo == vsRange.DistrictNo && t.VsRangeNo == vsRange.No).DeleteAsync();
        //}
        //public Task<int> DeleteAllAsync(Institute institute)
        //{
        //    return GetQueryable().Where(t => t.InstituteName == institute.Name).DeleteAsync();
        //}
    }
}
