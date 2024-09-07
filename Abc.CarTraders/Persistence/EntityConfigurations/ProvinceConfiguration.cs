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
    public class ProvinceConfiguration : EntityTypeConfiguration<Province>
    {
        public ProvinceConfiguration()
        {
            HasKey(p => p.No);

            Property(p => p.No)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(255);

            Property(p => p.SinhalaName)
                .IsRequired()
                .HasMaxLength(255);

            Property(p => p.TamilName)
                .IsRequired()
                .HasMaxLength(255);

        }
    }
}
