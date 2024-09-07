using ABC.CarTraders.Core.Domain;
using ABC.CarTraders.Persistence.EntityConfigurations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABC.CarTraders.Persistence
{
    public class AbcCarTradersContext : DbContext
    {
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Log> Logs { get; set; }
        public virtual DbSet<Province> Provinces { get; set; }
        public virtual DbSet<District> Districts { get; set; }
        public virtual DbSet<VsRange> VsRanges { get; set; }
        public virtual DbSet<Institute> Institutes { get; set; }
        public virtual DbSet<Technician> Technicians { get; set; }
        public virtual DbSet<CalvingSheet> CalvingSheets { get; set; }
        public virtual DbSet<CalvingRecord> CalvingRecords { get; set; }

        public AbcCarTradersContext() : base("name=AbcCarTradersContext")
        {

        }

        public AbcCarTradersContext(string connectionString) : base(connectionString)
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UserConfiguration());
            modelBuilder.Configurations.Add(new LogConfiguration());
            modelBuilder.Configurations.Add(new ProvinceConfiguration());
            modelBuilder.Configurations.Add(new DistrictConfiguration());
            modelBuilder.Configurations.Add(new VsRangeConfiguration());
            modelBuilder.Configurations.Add(new InstituteConfiguration());
            modelBuilder.Configurations.Add(new TechnicianConfiguration());
            modelBuilder.Configurations.Add(new CalvingSheetConfiguration());
            modelBuilder.Configurations.Add(new CalvingRecordConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
