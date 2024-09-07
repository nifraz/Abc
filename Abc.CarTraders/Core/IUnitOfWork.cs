using ABC.CarTraders.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABC.CarTraders.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository Users { get; }
        ILogRepository Logs { get; }
        IProvinceRepository Provinces { get; }
        IDistrictRepository Districts { get; }
        IVsRangeRepository VsRanges { get; }
        IInstituteRepository Institutes { get; }
        ITechnicianRepository Technicians { get; }
        ICalvingSheetRepository CalvingSheets { get; }
        ICalvingRecordRepository CalvingRecords { get; }

        Task CacheLocalAsync();
        Task<int> CompleteAsync();
    }
}
