using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABC.CarTraders.Core.Domain
{
    public class CalvingSheet
    {
        //nav props
        public VsRange VsRange { get; set; }
        public Institute Institute { get; set; }
        public Technician Technician { get; set; }

        //domain props
        public int Id { get; set; } //pk
        public int Year { get; set; } //req
        public byte Month { get; set; } //req
        public string Notes { get; set; } //opt

        //extra domain props
        public DateTime? CreatedOn { get; set; } //gen
        public User CreatedBy { get; set; } //gen
        public DateTime? ModifiedOn { get; set; } //gen
        public User ModifiedBy { get; set; } //gen

        //child props
        public ICollection<CalvingRecord> CalvingRecords { get; set; }

        //fk props
        public int? TechnicianCode { get; set; } //fk technician opt
        public byte? ProvinceNo { get; set; } //fk vsrange opt
        public byte? DistrictNo { get; set; } //fk vsrange opt
        public byte? VsRangeNo { get; set; } //fk vsrange opt
        public string InstituteName { get; set; } //fk institute opt
        public string CreatedByUsername { get; set; } //fk User opt
        public string ModifiedByUsername { get; set; } //fk User opt

        public CalvingSheet()
        {
            CalvingRecords = new HashSet<CalvingRecord>();
        }

        //extra props
        [NotMapped]
        public string ProvinceName { get { return VsRange?.District?.Province?.Name; } }
        [NotMapped]
        public string DistrictName { get { return VsRange?.District?.Name; } }
        [NotMapped]
        public string VsRangeName { get { return VsRange?.Name; } }
        //[NotMapped]
        //public string InstituteName { get { return Institute?.Name; } }

        [NotMapped]
        public int Calvings { get { return CalvingRecords.Count(); } }

        [NotMapped]
        public int Males { get { return CalvingRecords.Count(cr => cr.Sex == 1); } }

        [NotMapped]
        public int Females { get { return CalvingRecords.Count(cr => cr.Sex == 0); } }

        //methods
        public override string ToString()
        {
            return $"{Id}";
        }
    }
}
