using ABC.CarTraders.Core.Domain;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABC.CarTraders.Core.Repositories
{
    public interface ICalvingSheetRepository : IRepository<CalvingSheet>
    {
        Task<IPagedList<CalvingSheet>> GetPagedListAsync(string rangeField, DateTime? rangeStart, DateTime? rangeEnd, Province calvingSheetProvince, District calvingSheetDistrict, VsRange calvingSheetVsRange, Institute calvingSheetInstitute, int? calvingSheetTechnicianCode, string sortField, string sortDirection, int pageNumber, int pageSize);
        Task<string> ExportToExcelAsync(string rangeField, DateTime? rangeStart, DateTime? rangeEnd, Province calvingSheetProvince, District calvingSheetDistrict, VsRange calvingSheetVsRange, Institute calvingSheetInstitute, int? calvingSheetTechnicianCode, string sortField, string sortDirection);

        //Task<int> UpdateAllToNullAsync(User user);
        //Task<int> UpdateAllToNullAsync(VsRange vsRange);
        //Task<int> UpdateAllToNullAsync(Institute institute);
        //Task<int> UpdateAllToNullAsync(Technician technician);
        //Task<int> UpdateAllToNullAsync(IEnumerable<int?> technicianCodes);

        //Task<int> DeleteAllAsync(User user);
        //Task<int> DeleteAllAsync(VsRange vsRange);
        //Task<int> DeleteAllAsync(Institute institute);
        //Task<int> DeleteAllAsync(Technician technician);
        //Task<int> DeleteAllAsync(IEnumerable<int?> technicianCodes);

        //Task<int> UpdateInstituteToVsRangeAsync(Institute institute, VsRange vsRange);
    }
}
