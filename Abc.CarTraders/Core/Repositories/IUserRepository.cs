using ABC.CarTraders.Core.Domain;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABC.CarTraders.Core.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        Task<IPagedList<User>> GetPagedListAsync(string rangeField, DateTime? rangeStart, DateTime? rangeEnd, UserRole? userRole, UserSex? userSex, string findField, string findText, string sortField, string sortDirection, int pageNumber, int pageSize);
        Task<string> ExportToExcelAsync(string rangeField, DateTime? rangeStart, DateTime? rangeEnd, UserRole? userRole, UserSex? userSex, string findField, string findText, string sortField, string sortDirection);
    }
}
