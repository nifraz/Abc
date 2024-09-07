using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABC.CarTraders.Core.Domain
{
    public class District
    {
        //nav props
        public Province Province { get; set; }

        //domain props
        public byte No { get; set; } //pk (partial)
        public string Name { get; set; } //req
        public string SinhalaName { get; set; } //req
        public string TamilName { get; set; } //req

        //child props
        public ICollection<VsRange> VsRanges { get; set; }

        //fk props
        public byte ProvinceNo { get; set; } //pk (partial)

        public District()
        {
            VsRanges = new HashSet<VsRange>();
        }

        //extra props
        [NotMapped]
        public int Code { get { return (ProvinceNo * 10) + No; } }

        //methods
        public override string ToString()
        {
            return $"{Name} / {SinhalaName} / {TamilName}";
        }
    }
}
