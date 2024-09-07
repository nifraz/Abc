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
    public class DistrictConfiguration : EntityTypeConfiguration<District>
    {
        public DistrictConfiguration()
        {
            HasKey(d => new { d.ProvinceNo, d.No });

            Property(p => p.No)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            Property(d => d.Name)
                .IsRequired()
                .HasMaxLength(255);

            Property(d => d.SinhalaName)
                .IsRequired()
                .HasMaxLength(255);

            Property(d => d.TamilName)
                .IsRequired()
                .HasMaxLength(255);

            HasRequired(d => d.Province)
                .WithMany(p => p.Districts)
                .HasForeignKey(d => d.ProvinceNo)
                .WillCascadeOnDelete(true);

        }
    }
}
