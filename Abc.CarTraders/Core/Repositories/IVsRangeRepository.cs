using ABC.CarTraders.Core.Domain;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABC.CarTraders.Core.Repositories
{
    public interface IVsRangeRepository : IRepository<VsRange>
    {
        Task<int> GetMaxNoAsync(District district);
        Task<VsRange> GetLastKeyRecordAsync(District district);

        Task<IPagedList<VsRange>> GetPagedListAsync(string rangeField, DateTime? rangeStart, DateTime? rangeEnd, Province vsRangeProvince, District vsRangeDistrict, string findField, string findText, string sortField, string sortDirection, int pageNumber, int pageSize);
        Task<string> ExportToExcelAsync(string rangeField, DateTime? rangeStart, DateTime? rangeEnd, Province vsRangeProvince, District vsRangeDistrict, string findField, string findText, string sortField, string sortDirection);
    }
}
