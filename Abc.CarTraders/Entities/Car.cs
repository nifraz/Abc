using ABC.CarTraders.Enums;
using System.Collections.Generic;

namespace ABC.CarTraders.Entities
{
    public class Car : Record
    {
        public string ModelName { get; set; }
        public decimal Price { get; set; }
        public int Year { get; set; }
        public CarType Type { get; set; }
        public string EngineDetails { get; set; }
        public string Color { get; set; }
        public byte[] CarPicture { get; set; }

        // Navigation Properties
        //public List<CarPart> CarParts { get; set; } = new List<CarPart>(); // Relationship: One Car can have multiple parts
        //public List<Order> Orders { get; set; } = new List<Order>(); // Relationship: One Car can be part of multiple Orders
    }
}
