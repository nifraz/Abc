using ABC.CarTraders.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Threading.Tasks;
using ABC.CarTraders.Core.Repositories;
using ABC.CarTraders.Persistence.Repositories;
using ABC.CarTraders.Core.Domain;
using System.Net.NetworkInformation;

namespace ABC.CarTraders.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AbcCarTradersContext _context;

        public IUserRepository Users { get; private set; }
        public ILogRepository Logs { get; private set; }
        public IProvinceRepository Provinces { get; private set; }
        public IDistrictRepository Districts { get; private set; }
        public IVsRangeRepository VsRanges { get; private set; }
        public IInstituteRepository Institutes { get; private set; }
        public ITechnicianRepository Technicians { get; private set; }
        public ICalvingSheetRepository CalvingSheets { get; private set; }
        public ICalvingRecordRepository CalvingRecords { get; private set; }

        public UnitOfWork(AbcCarTradersContext context)
        {
            _context = context;
            Users = new UserRepository(_context);
            Logs = new LogRepository(_context);
            Provinces = new ProvinceRepository(_context);
            Districts = new DistrictRepository(_context);
            VsRanges = new VsRangeRepository(_context);
            Institutes = new InstituteRepository(_context);
            Technicians = new TechnicianRepository(_context);
            CalvingSheets = new CalvingSheetRepository(_context);
            CalvingRecords = new CalvingRecordRepository(_context);
        }

        public async Task CacheLocalAsync()
        {
            await _context.Users.LoadAsync();
            await _context.Provinces.LoadAsync();
            await _context.Districts.LoadAsync();
            await _context.VsRanges.LoadAsync();
            await _context.Institutes.LoadAsync();
        }

        public Task<int> CompleteAsync()
        {
            return _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
