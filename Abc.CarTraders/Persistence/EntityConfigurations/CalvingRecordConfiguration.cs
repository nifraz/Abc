using ABC.CarTraders.Core.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABC.CarTraders.Persistence.EntityConfigurations
{
    class CalvingRecordConfiguration : EntityTypeConfiguration<CalvingRecord>
    {
        public CalvingRecordConfiguration()
        {
            HasKey(cr => new { cr.CalvingSheetId, cr.No });

            HasRequired(cr => cr.CalvingSheet)
                .WithMany(cs => cs.CalvingRecords)
                .HasForeignKey(cr => cr.CalvingSheetId)
                .WillCascadeOnDelete(true);
        }
    }
}
