using ABC.CarTraders.Core.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABC.CarTraders.Persistence.EntityConfigurations
{
    public class UserConfiguration : EntityTypeConfiguration<User>
    {
        public UserConfiguration()
        {
            HasKey(u => u.Username);

            Property(u => u.Username)
                .HasMaxLength(255);

            Property(u => u.Password)
                .HasMaxLength(255)
                .IsRequired();

            Property(u => u.Name)
                .HasMaxLength(255)
                .IsRequired();

            Property(u => u.EMail)
                .HasMaxLength(255);

            Property(u => u.PhoneNo)
                .HasMaxLength(15);

            Property(u => u.Notes)
                .HasMaxLength(1023);

            HasOptional(u => u.CreatedBy)
                .WithMany(u => u.CreatedUsers)
                .HasForeignKey(u => u.CreatedByUsername)
                .WillCascadeOnDelete(false);

            HasOptional(u => u.ModifiedBy)
                .WithMany(u => u.ModifiedUsers)
                .HasForeignKey(u => u.ModifiedByUsername)
                .WillCascadeOnDelete(false);
        }
    }
}
