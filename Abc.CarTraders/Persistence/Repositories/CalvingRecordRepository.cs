using ClosedXML.Excel;
using ABC.CarTraders.Core.Domain;
using ABC.CarTraders.Core.Repositories;
using PagedList;
using PagedList.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace ABC.CarTraders.Persistence.Repositories
{
    class CalvingRecordRepository : Repository<CalvingRecord>, ICalvingRecordRepository
    {
        public CalvingRecordRepository(AbcCarTradersContext context) : base(context)
        {

        }

        private IQueryable<CalvingRecord> GetQueryable(string rangeField, DateTime? rangeStart, DateTime? rangeEnd, Province calvingRecordProvince, District calvingRecordDistrict, VsRange calvingRecordVsRange, Institute calvingRecordInstitute, int? calvingRecordTechnicianCode, int? calvingRecordSemenCode, string sortField, string sortDirection)
        {
            var qry = GetQueryable().Include(cr => cr.CalvingSheet.CalvingRecords);

            if (rangeStart != null)
            {
                switch (rangeField)
                {
                    case "AI Date":
                        qry = qry.Where(cr => cr.AiDate >= rangeStart);
                        break;
                    case "Calving Date":
                        qry = qry.Where(cr => cr.CalvingDate >= rangeStart);
                        break;
                }
            }

            if (rangeEnd != null)
            {
                switch (rangeField)
                {
                    case "AI Date":
                        qry = qry.Where(cr => cr.AiDate <= rangeEnd);
                        break;
                    case "Calving Date":
                        qry = qry.Where(cr => cr.CalvingDate <= rangeEnd);
                        break;
                }
            }

            if (calvingRecordProvince != null)
            {
                qry = qry.Where(cr => cr.CalvingSheet.ProvinceNo == calvingRecordProvince.No);
            }

            if (calvingRecordDistrict != null)
            {
                qry = qry.Where(cr => cr.CalvingSheet.ProvinceNo == calvingRecordDistrict.ProvinceNo && cr.CalvingSheet.DistrictNo == calvingRecordDistrict.No);
            }

            if (calvingRecordVsRange != null)
            {
                qry = qry.Where(cr => cr.CalvingSheet.ProvinceNo == calvingRecordVsRange.ProvinceNo && cr.CalvingSheet.DistrictNo == calvingRecordVsRange.DistrictNo && cr.CalvingSheet.VsRangeNo == calvingRecordVsRange.No);
            }

            if (calvingRecordInstitute != null)
            {
                qry = qry.Where(cr => cr.CalvingSheet.InstituteName == calvingRecordInstitute.Name);
            }

            if (calvingRecordTechnicianCode != null)
            {
                if (calvingRecordTechnicianCode == 0)
                {
                    qry = qry.Where(cr => cr.CalvingSheet.TechnicianCode == null);
                }
                else
                {
                    qry = qry.Where(cr => cr.CalvingSheet.TechnicianCode == calvingRecordTechnicianCode);
                }
            }

            if (calvingRecordSemenCode != null)
            {
                if (calvingRecordSemenCode == 0)
                {
                    qry = qry.Where(cr => cr.SemenCode == null);
                }
                else
                {
                    qry = qry.Where(cr => cr.SemenCode == calvingRecordSemenCode);
                }
            }

            if (sortDirection.Equals("Descending"))
            {
                switch (sortField)
                {
                    case "Sheet ID / No":
                        qry = qry.OrderByDescending(cr => cr.CalvingSheetId).ThenByDescending(cr => cr.No);
                        break;
                    case "Province":
                        qry = qry.OrderByDescending(cr => cr.CalvingSheet.VsRange.District.Province.Name);
                        break;
                    case "District":
                        qry = qry.OrderByDescending(cr => cr.CalvingSheet.VsRange.District.Name);
                        break;
                    case "VS Range":
                        qry = qry.OrderByDescending(cr => cr.CalvingSheet.VsRange.Name);
                        break;
                    default:
                        qry = qry.OrderByDescending(cr => cr.CalvingSheetId).ThenByDescending(cr => cr.No);
                        break;
                }
            }
            else
            {
                switch (sortField)
                {
                    case "Sheet ID / No":
                        qry = qry.OrderBy(cr => cr.CalvingSheetId).ThenBy(cr => cr.No);
                        break;
                    case "Province":
                        qry = qry.OrderBy(cr => cr.CalvingSheet.VsRange.District.Province.Name);
                        break;
                    case "District":
                        qry = qry.OrderBy(cr => cr.CalvingSheet.VsRange.District.Name);
                        break;
                    case "VS Range":
                        qry = qry.OrderBy(cr => cr.CalvingSheet.VsRange.Name);
                        break;
                    default:
                        qry = qry.OrderBy(cr => cr.CalvingSheetId).ThenBy(cr => cr.No);
                        break;
                }
            }
            return qry;
        }

        public Task<IPagedList<CalvingRecord>> GetPagedListAsync(string rangeField, DateTime? rangeStart, DateTime? rangeEnd, Province calvingRecordProvince, District calvingRecordDistrict, VsRange calvingRecordVsRange, Institute calvingRecordInstitute, int? calvingRecordTechnicianCode, int? calvingRecordSemenCode, string sortField, string sortDirection, int pageNumber, int pageSize)
        {
            var qry = GetQueryable(rangeField, rangeStart, rangeEnd, calvingRecordProvince, calvingRecordDistrict, calvingRecordVsRange, calvingRecordInstitute, calvingRecordTechnicianCode, calvingRecordSemenCode, sortField, sortDirection);
            return qry.ToPagedListAsync(pageNumber, pageSize);
        }

        public static readonly string[] DATA_HEADERS = { "Sheet ID", "No", "Province", "District", "VS Range", "Institute", "Tech.", "Semen", "AI Date", "Calving Date", "Cow ID", "Calf ID", "Sex" };
        public async Task<string> ExportToExcelAsync(string rangeField, DateTime? rangeStart, DateTime? rangeEnd, Province calvingRecordProvince, District calvingRecordDistrict, VsRange calvingRecordVsRange, Institute calvingRecordInstitute, int? calvingRecordTechnicianCode, int? calvingRecordSemenCode, string sortField, string sortDirection)
        {
            var qry = GetQueryable(rangeField, rangeStart, rangeEnd, calvingRecordProvince, calvingRecordDistrict, calvingRecordVsRange, calvingRecordInstitute, calvingRecordTechnicianCode, calvingRecordSemenCode, sortField, sortDirection);

            var calvingRecords = await qry.Select(cr => new
            {
                SheetId = cr.CalvingSheetId,
                No = cr.No,
                Province = cr.CalvingSheet.VsRange.District.Province.Name,
                District = cr.CalvingSheet.VsRange.District.Name,
                VsRange = cr.CalvingSheet.VsRange.Name,
                Institute = cr.CalvingSheet.Institute.Name,
                TechnicianCode = cr.CalvingSheet.TechnicianCode,
                SemenCode = cr.SemenCode,
                AiDate = cr.AiDate,
                CalvingDate = cr.CalvingDate,
                cr.CowVsCode,
                cr.CowFarmNo,
                cr.CowAnimalNo,
                cr.CalfVsCode,
                cr.CalfFarmNo,
                cr.CalfAnimalNo,
                Sex = cr.Sex == 0 ? "Female" : "Male"
            }).ToListAsync();

            var calvingRecordCount = calvingRecords.Count;
            var path = System.IO.Path.Combine(AppSettings.ABCFolderPath, $"CalvingRecords_{DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss")}.xlsx");
            await Task.Run(() =>
            {
                var workbook = new XLWorkbook();
                var worksheet = workbook.Worksheets.Add("Calving Records");

                for (int i = 0; i < DATA_HEADERS.Length; i++)
                {
                    worksheet.Cell(1, i + 1).Value = DATA_HEADERS[i];
                }

                for (int i = 0; i < calvingRecordCount; i++)
                {
                    worksheet.Cell(i + 2, 1).Value = calvingRecords[i].SheetId;
                    worksheet.Cell(i + 2, 2).Value = calvingRecords[i].No;
                    worksheet.Cell(i + 2, 3).Value = calvingRecords[i].Province;
                    worksheet.Cell(i + 2, 4).Value = calvingRecords[i].District;
                    worksheet.Cell(i + 2, 5).Value = calvingRecords[i].VsRange;
                    worksheet.Cell(i + 2, 6).Value = calvingRecords[i].Institute;
                    worksheet.Cell(i + 2, 7).Value = calvingRecords[i].TechnicianCode;
                    worksheet.Cell(i + 2, 8).Value = calvingRecords[i].SemenCode;
                    worksheet.Cell(i + 2, 9).Value = calvingRecords[i].AiDate;
                    worksheet.Cell(i + 2, 10).Value = calvingRecords[i].CalvingDate;
                    worksheet.Cell(i + 2, 11).Value = $"{calvingRecords[i].CowVsCode ?? 0:D4}{calvingRecords[i].CowFarmNo ?? 0:D4}{calvingRecords[i].CowAnimalNo ?? 0:D4}";
                    worksheet.Cell(i + 2, 12).Value = $"{calvingRecords[i].CalfVsCode ?? 0:D4}{calvingRecords[i].CalfFarmNo ?? 0:D4}{calvingRecords[i].CalfAnimalNo ?? 0:D4}";
                    worksheet.Cell(i + 2, 13).Value = calvingRecords[i].Sex;
                }
                workbook.SaveAs(path);
            });
            return path;
        }

        public async Task<List<Tuple<string, int, int, int>>> GetYearlyPerformanceAsync(DateTime? rangeStart, DateTime? rangeEnd, Province province, District district, VsRange vsRange, Institute institute, int? technicianCode, int? semenCode)
        {
            var qry = GetQueryable("Calving Date", rangeStart, rangeEnd, province, district, vsRange, institute, technicianCode, semenCode, null, "Ascending").Where(cr => cr.CalvingDate != null);

            var result = await qry
                .GroupBy(cr => cr.CalvingDate.Value.Year)
                .OrderBy(g => g.Key)
                .Select(g => new
                {
                    Year = g.Key,
                    Male = g.Count(cr => cr.Sex == 1),
                    Female = g.Count(cr => cr.Sex == 0),
                    Total = g.Count()
                }).ToListAsync();

            var list = new List<Tuple<int, int, int, int>>();
            foreach (var r in result)
            {
                list.Add(Tuple.Create(r.Year, r.Male, r.Female, r.Total));
            }

            var rangeStartYear = rangeStart != null ? rangeStart.Value.Year : 2014;
            var rangeEndYear = rangeEnd != null ? rangeEnd.Value.Year : DateTime.Today.Year;

            for (int i = rangeStartYear; i <= rangeEndYear; i++)
            {
                if (!list.Any(y => y.Item1 == i))
                {
                    list.Add(Tuple.Create(i, 0, 0, 0));
                }
            }

            return list.OrderBy(e => e.Item1).Select(e => Tuple.Create(e.Item1.ToString(), e.Item2, e.Item3, e.Item4)).ToList();
        }
        public async Task<List<Tuple<string, int, int, int>>> GetMonthlyPerformanceAsync(DateTime? rangeStart, DateTime? rangeEnd, Province province, District district, VsRange vsRange, Institute institute, int? technicianCode, int? semenCode)
        {
            var qry = GetQueryable("Calving Date", rangeStart, rangeEnd, province, district, vsRange, institute, technicianCode, semenCode, null, "Ascending").Where(cr => cr.CalvingDate != null);

            var result = await qry
                .GroupBy(cr => new { Year = cr.CalvingDate.Value.Year, Month = cr.CalvingDate.Value.Month })
                .OrderBy(g => g.Key)
                .Select(g => new
                {
                    YearMonth = g.Key,
                    Male = g.Count(cr => cr.Sex == 1),
                    Female = g.Count(cr => cr.Sex == 0),
                    Total = g.Count()
                }).ToListAsync();

            var list = new List<Tuple<int, int, int, int, int>>();
            foreach (var r in result)
            {
                list.Add(Tuple.Create(r.YearMonth.Year, r.YearMonth.Month, r.Male, r.Female, r.Total));
            }

            var rangeStartYear = rangeStart != null ? rangeStart.Value.Year : 2014;
            var rangeEndYear = rangeEnd != null ? rangeEnd.Value.Year : DateTime.Today.Year;

            for (int i = rangeStartYear; i <= rangeEndYear; i++)
            {
                for (int j = 1; j <= 12; j++)
                {
                    if (!list.Any(y => y.Item1 == i && y.Item2 == j))
                    {
                        list.Add(Tuple.Create(i, j, 0, 0, 0));
                    }
                }
            }

            return list.OrderBy(e => e.Item1).ThenBy(e => e.Item2).Select(e => Tuple.Create($"{e.Item1}/{e.Item2}", e.Item3, e.Item4, e.Item5)).ToList();
        }

        public async Task<Tuple<int, int, int>> GetTotalsAsync(Province province, District district, VsRange vsRange, Institute institute, int? technicianCode, int? semenCode, DateTime? rangeStart, DateTime? rangeEnd)
        {
            var qry = GetQueryable("Calving Date", rangeStart, rangeEnd, province, district, vsRange, institute, technicianCode, semenCode, null, "Ascending");

            var males = await qry.CountAsync(cr => cr.Sex == 1);
            var females = await qry.CountAsync(cr => cr.Sex == 0);
            var total = await qry.CountAsync();

            return Tuple.Create(males, females, total);
        }
    }
}
