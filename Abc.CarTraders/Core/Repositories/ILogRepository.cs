using ABC.CarTraders.Core.Domain;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABC.CarTraders.Core.Repositories
{
    public interface ILogRepository : IRepository<Log>
    {
        Task<IPagedList<Log>> GetPagedListAsync(string rangeField, DateTime? rangeStart, DateTime? rangeEnd, LogAction? logAction, User logUser, string findField, string findText, string sortField, string sortDirection, int pageNumber, int pageSize);
        Task<string> ExportToExcelAsync(string rangeField, DateTime? rangeStart, DateTime? rangeEnd, LogAction? logAction, User logUser, string findField, string findText, string sortField, string sortDirection);
    }
}
