using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABC.CarTraders.Core.Domain
{
    public class VsRange
    {
        //nav props
        public District District { get; set; }

        //domain props
        public byte No { get; set; } //pk (partial)
        public string Name { get; set; } //req
        public string Notes { get; set; } //opt

        //extra domain props
        public DateTime? CreatedOn { get; set; } //gen
        public User CreatedBy { get; set; } //gen
        public DateTime? ModifiedOn { get; set; } //gen
        public User ModifiedBy { get; set; } //gen

        //child props
        public ICollection<Technician> Technicians { get; set; }
        public ICollection<CalvingSheet> CalvingSheets { get; set; }

        //fk props
        public byte ProvinceNo { get; set; } //pk (partial)
        public byte DistrictNo { get; set; } //pk (partial)
        public string CreatedByUsername { get; set; } //fk User
        public string ModifiedByUsername { get; set; } //fk User

        public VsRange()
        {
            Technicians = new HashSet<Technician>();
            CalvingSheets = new HashSet<CalvingSheet>();
        }

        //extra props
        [NotMapped]
        public int Code { get { return (((ProvinceNo * 10) + DistrictNo) * 100) + No; } }

        [NotMapped]
        public Province Province { get { return District?.Province; } }
        //methods
        public override string ToString()
        {
            return $"{Name} (#{Code})";
        }
    }
}
