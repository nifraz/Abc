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
    public class CalvingSheetConfiguration : EntityTypeConfiguration<CalvingSheet>
    {
        public CalvingSheetConfiguration()
        {
            HasKey(cs => cs.Id);

            Property(cs => cs.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(cs => cs.Notes)
                .HasMaxLength(1023);

            HasOptional(cs => cs.CreatedBy)
                .WithMany(u => u.CreatedCalvingSheets)
                .HasForeignKey(cs => cs.CreatedByUsername)
                .WillCascadeOnDelete(false);

            HasOptional(cs => cs.ModifiedBy)
                .WithMany(u => u.ModifiedCalvingSheets)
                .HasForeignKey(cs => cs.ModifiedByUsername)
                .WillCascadeOnDelete(false);

            HasOptional(cs => cs.VsRange)
                .WithMany(vsr => vsr.CalvingSheets)
                .HasForeignKey(cs => new { cs.ProvinceNo, cs.DistrictNo, cs.VsRangeNo })
                .WillCascadeOnDelete(false);

            HasOptional(cs => cs.Institute)
                .WithMany(i => i.CalvingSheets)
                .HasForeignKey(cs => cs.InstituteName)
                .WillCascadeOnDelete(false);

            HasOptional(cs => cs.Technician)
                .WithMany(t => t.CalvingSheets)
                .HasForeignKey(cs => cs.TechnicianCode)
                .WillCascadeOnDelete(false); 
        }
    }
}
