using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABC.CarTraders.Core.Domain
{
    public class Technician
    {
        //nav props
        public VsRange VsRange { get; set; }
        public Institute Institute { get; set; }

        //domain props
        public int Code { get; set; } //pk
        public string Name { get; set; } //req
        public string NicNo { get; set; } //opt
        public string PhoneNo { get; set; } //opt
        public DateTime? IssuedDate { get; set; } //opt
        public TechnicianType Type { get; set; } //req
        public TechnicianStatus Status { get; set; } //req
        public string Notes { get; set; } //opt

        //extra domain props
        //extra domain props
        public DateTime? CreatedOn { get; set; } //gen
        public User CreatedBy { get; set; } //gen
        public DateTime? ModifiedOn { get; set; } //gen
        public User ModifiedBy { get; set; } //gen

        //child props
        public ICollection<CalvingSheet> CalvingSheets { get; set; }

        //fk props
        public byte? ProvinceNo { get; set; } //fk VsRange opt
        public byte? DistrictNo { get; set; } //fk VsRange opt
        public byte? VsRangeNo { get; set; } //fk VsRange opt
        public string InstituteName { get; set; } //fk institute opt
        public string CreatedByUsername { get; set; } //fk User opt
        public string ModifiedByUsername { get; set; } //fk User opt

        public Technician()
        {
            CalvingSheets = new HashSet<CalvingSheet>();
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

        //methods
        public override string ToString()
        {
            return $"{Name} - {Code}";
        }

    }

    public enum TechnicianType : byte
    {
        Government = 1,
        Private = 2
    }

    public enum TechnicianStatus : byte
    {
        Active = 1,
        Retired = 2,
        Cancelled = 3
    }
}
