using ABC.CarTraders.Core.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABC.CarTraders.Persistence.EntityConfigurations
{
    class TechnicianConfiguration : EntityTypeConfiguration<Technician>
    {
        public TechnicianConfiguration()
        {
            HasKey(t => t.Code);

            Property(t => t.Code)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            Property(t => t.Name)
                .HasMaxLength(255)
                .IsRequired();

            Property(t => t.NicNo)
                .HasMaxLength(12);

            Property(t => t.PhoneNo)
                .HasMaxLength(15);

            Property(t => t.Notes)
                .HasMaxLength(1023);

            HasOptional(t => t.CreatedBy)
                .WithMany(u => u.CreatedTechnicians)
                .HasForeignKey(t => t.CreatedByUsername)
                .WillCascadeOnDelete(false);

            HasOptional(t => t.ModifiedBy)
                .WithMany(u => u.ModifiedTechnicians)
                .HasForeignKey(t => t.ModifiedByUsername)
                .WillCascadeOnDelete(false);

            HasOptional(t => t.VsRange)
                .WithMany(vsr => vsr.Technicians)
                .HasForeignKey(t => new { t.ProvinceNo, t.DistrictNo, t.VsRangeNo })
                .WillCascadeOnDelete(false);

            HasOptional(t => t.Institute)
                .WithMany(i => i.Technicians)
                .HasForeignKey(t => t.InstituteName)
                .WillCascadeOnDelete(false);
        }
    }
}
