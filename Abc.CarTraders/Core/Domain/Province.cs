using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABC.CarTraders.Core.Domain
{
    public class Province
    {
        //domain props
        public byte No { get; set; } //pk
        public string Name { get; set; } //req
        public string SinhalaName { get; set; } //req
        public string TamilName { get; set; } //req

        //child props
        public ICollection<District> Districts { get; set; }

        //ctor
        public Province()
        {
            Districts = new HashSet<District>();
        }

        //extra props
        [NotMapped]
        public int Code { get { return No; } }

        //methods
        public override string ToString()
        {
            return $"{Name} / {SinhalaName} / {TamilName}";
        }
    }
}
