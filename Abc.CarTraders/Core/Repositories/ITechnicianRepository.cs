using ABC.CarTraders.Core.Domain;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABC.CarTraders.Core.Repositories
{
    public interface ITechnicianRepository : IRepository<Technician>
    {
        Task<int> GetMaxCodeAsync(TechnicianType? technicianType);
        Task<Technician> GetLastKeyRecordAsync(TechnicianType? technicianType);
        Task<IPagedList<Technician>> GetPagedListAsync(string rangeField, DateTime? rangeStart, DateTime? rangeEnd, Province technicianProvince, District technicianDistrict, VsRange technicianVsRange, Institute technicianInstitute, TechnicianType? technicianType, TechnicianStatus? technicianStatus, string findField, string findText, string sortField, string sortDirection, int pageNumber, int pageSize);
        Task<string> ExportToExcelAsync(string rangeField, DateTime? rangeStart, DateTime? rangeEnd, Province technicianProvince, District technicianDistrict, VsRange technicianVsRange, Institute technicianInstitute, TechnicianType? technicianType, TechnicianStatus? technicianStatus, string findField, string findText, string sortField, string sortDirection);

        //Task<int> UpdateAllToNullAsync(User user);
        //Task<int> UpdateAllToNullAsync(VsRange vsRange);
        //Task<int> UpdateAllToNullAsync(Institute institute);

        //Task<int> DeleteAllAsync(User user);
        //Task<int> DeleteAllAsync(VsRange vsRange);
        //Task<int> DeleteAllAsync(Institute institute);
    }
}
