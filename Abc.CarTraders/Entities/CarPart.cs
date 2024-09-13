using System.Collections.Generic;

namespace ABC.CarTraders.Entities
{
    public class CarPart : Record
    {
        public string PartName { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }

        // Foreign Key to Car
        public long CarId { get; set; }
        public Car Car { get; set; }  // Relationship: Each CarPart belongs to one Car

        public List<Order> Orders { get; set; } = new List<Order>(); // Relationship: One CarPart can be part of multiple Orders
    }

}
