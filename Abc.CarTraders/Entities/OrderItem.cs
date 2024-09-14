using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABC.CarTraders.Entities
{
    public class OrderItem : Record
    {
        public int OrderId { get; set; }
        public Order Order { get; set; }

        public int? CarId { get; set; }
        public Car Car { get; set; }

        public int? CarPartId { get; set; }
        public CarPart CarPart { get; set; }

        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }  // Quantity * UnitPrice

        // Helper method to calculate the total price for this item
        public void CalculateTotal()
        {
            TotalPrice = Quantity * UnitPrice;
        }
    }
}
