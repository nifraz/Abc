using ABC.CarTraders.Core.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABC.CarTraders.Persistence.EntityConfigurations
{
    public class VsRangeConfiguration : EntityTypeConfiguration<VsRange>
    {
        public VsRangeConfiguration()
        {
            HasKey(vsr => new { vsr.ProvinceNo, vsr.DistrictNo, vsr.No });

            Property(vsr => vsr.No)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            Property(vsr => vsr.Name)
                .IsRequired()
                .HasMaxLength(255);

            Property(vsr => vsr.Name)
                .HasColumnAnnotation("Index", new IndexAnnotation(new[] 
                { new IndexAttribute("Index") { IsUnique = true } }));

            Property(vsr => vsr.Notes)
                .HasMaxLength(1023);

            HasRequired(vsr => vsr.District)
                .WithMany(d => d.VsRanges)
                .HasForeignKey(vsr => new { vsr.ProvinceNo, vsr.DistrictNo })
                .WillCascadeOnDelete(true);

            HasOptional(vsr => vsr.CreatedBy)
                .WithMany(u => u.CreatedVsRanges)
                .HasForeignKey(vsr => vsr.CreatedByUsername)
                .WillCascadeOnDelete(false);

            HasOptional(vsr => vsr.ModifiedBy)
                .WithMany(u => u.ModifiedVsRanges)
                .HasForeignKey(vsr => vsr.ModifiedByUsername)
                .WillCascadeOnDelete(false);

        }
    }
}
