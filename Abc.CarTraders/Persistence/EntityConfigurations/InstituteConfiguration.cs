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
    class InstituteConfiguration : EntityTypeConfiguration<Institute>
    {
        public InstituteConfiguration()
        {
            HasKey(i => i.Name);

            Property(i => i.Name)
                .HasMaxLength(255);

            Property(i => i.Notes)
                .HasMaxLength(1023);

            HasOptional(i => i.CreatedBy)
                .WithMany(u => u.CreatedInstitutes)
                .HasForeignKey(i => i.CreatedByUsername)
                .WillCascadeOnDelete(false);

            HasOptional(i => i.ModifiedBy)
                .WithMany(u => u.ModifiedInstitutes)
                .HasForeignKey(i => i.ModifiedByUsername)
                .WillCascadeOnDelete(false);
        }
    }
}
