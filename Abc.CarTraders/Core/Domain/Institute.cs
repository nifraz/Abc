using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABC.CarTraders.Core.Domain
{
    public class Institute
    {
        //domain props
        public string Name { get; set; } //pk
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
        public string CreatedByUsername { get; set; } //fk User
        public string ModifiedByUsername { get; set; } //fk User

        //ctor
        public Institute()
        {
            Technicians = new HashSet<Technician>();
            CalvingSheets = new HashSet<CalvingSheet>();
        }

        //methods
        public override string ToString()
        {
            return $"{Name}";
        }
    }
}
