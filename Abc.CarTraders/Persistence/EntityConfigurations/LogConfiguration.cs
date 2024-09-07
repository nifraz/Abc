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
    public class LogConfiguration : EntityTypeConfiguration<Log>
    {
        public LogConfiguration()
        {
            HasKey(l => l.Id);

            Property(l => l.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(l => l.Title)
                .IsRequired()
                .HasMaxLength(255);

            Property(l => l.Text)
                .IsRequired()
                .HasMaxLength(255);

            HasOptional(l => l.User)
                .WithMany(u => u.Logs)
                .HasForeignKey(l => l.Username)
                .WillCascadeOnDelete(false);
        }
    }
}
