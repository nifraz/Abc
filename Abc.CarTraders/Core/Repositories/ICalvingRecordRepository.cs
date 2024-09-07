using ABC.CarTraders.Core.Domain;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABC.CarTraders.Core.Repositories
{
    public interface ICalvingRecordRepository : IRepository<CalvingRecord>
    {
        Task<IPagedList<CalvingRecord>> GetPagedListAsync(string rangeField, DateTime? rangeStart, DateTime? rangeEnd, Province calvingRecordProvince, District calvingRecordDistrict, VsRange calvingRecordVsRange, Institute calvingRecordInstitute, int? calvingRecordTechnicianCode, int? calvingRecordSemenCode, string sortField, string sortDirection, int pageNumber, int pageSize);
        Task<string> ExportToExcelAsync(string rangeField, DateTime? rangeStart, DateTime? rangeEnd, Province calvingRecordProvince, District calvingRecordDistrict, VsRange calvingRecordVsRange, Institute calvingRecordInstitute, int? calvingRecordTechnicianCode, int? calvingRecordSemenCode, string sortField, string sortDirection);
        Task<List<Tuple<string, int, int, int>>> GetYearlyPerformanceAsync(DateTime? rangeStart, DateTime? rangeEnd, Province province, District district, VsRange vsRange, Institute institute, int? technicianCode, int? semenCode);
        Task<List<Tuple<string, int, int, int>>> GetMonthlyPerformanceAsync(DateTime? rangeStart, DateTime? rangeEnd, Province province, District district, VsRange vsRange, Institute institute, int? technicianCode, int? semenCode);
        Task<Tuple<int, int, int>> GetTotalsAsync(Province province, District district, VsRange vsRange, Institute institute, int? technicianCode, int? semenCode, DateTime? rangeStart, DateTime? rangeEnd);
    }
}
