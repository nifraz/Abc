using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABC.CarTraders.Core.Domain
{
    public class CalvingRecord
    {
        //nav props
        public CalvingSheet CalvingSheet { get; set; }

        //domain props
        public byte No { get; set; } //pk (partial)
        public DateTime? AiDate { get; set; } //req
        public int? SemenCode { get; set; } //req
        public int? CowVsCode { get; set; } //opt
        public int? CowFarmNo { get; set; } //opt
        public int? CowAnimalNo { get; set; } //opt
        public int? CalfVsCode { get; set; } //opt
        public int? CalfFarmNo { get; set; } //opt
        public int? CalfAnimalNo { get; set; } //opt
        public DateTime? CalvingDate { get; set; } //req
        public byte Sex { get; set; } //req

        //fk props
        public int CalvingSheetId { get; set; } //pk (partial)

        public CalvingRecord()
        {

        }

        //extra props
        [NotMapped]
        public string Uid { get { return $"{CalvingSheetId}#{No:D2}"; } }
        [NotMapped]
        public int? AiDD { get { return AiDate?.Day; } }
        [NotMapped]
        public int? AiMM { get { return AiDate?.Month; } }
        [NotMapped]
        public int? AiYY { get { return AiDate?.Year % 100; } }

        [NotMapped]
        public string CowId { get { return $"{CowVsCode ?? 0:D4}{CowFarmNo ?? 0:D4}{CowAnimalNo ?? 0:D4}"; } }
        [NotMapped]
        public string CalfId { get { return $"{CalfVsCode ?? 0:D4}{CalfFarmNo ?? 0:D4}{CalfAnimalNo ?? 0:D4}"; } }

        [NotMapped]
        public int? CalvingDD { get { return CalvingDate?.Day; } }
        [NotMapped]
        public int? CalvingMM { get { return CalvingDate?.Month; } }
        [NotMapped]
        public int? CalvingYY { get { return CalvingDate?.Year % 100; } }

        [NotMapped]
        public string ProvinceName { get { return CalvingSheet?.VsRange?.District?.Province?.Name; } }
        [NotMapped]
        public string DistrictName { get { return CalvingSheet?.VsRange?.District?.Name; } }
        [NotMapped]
        public string VsRangeName { get { return CalvingSheet?.VsRange?.Name; } }
        [NotMapped]
        public string InstituteName { get { return CalvingSheet?.Institute?.Name; } }
        [NotMapped]
        public int? TechnicianCode { get { return CalvingSheet?.TechnicianCode; } }
        [NotMapped]
        public string SexName { get { return Sex == 0 ? "Female" : "Male"; } }
    }
}
