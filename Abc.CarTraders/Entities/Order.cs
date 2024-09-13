using ABC.CarTraders.Enums;
using System.Collections.Generic;

namespace ABC.CarTraders.Entities
{
    public class Order : Record
    {
        public OrderStatus Status { get; set; }
        public decimal TotalPrice { get; set; }

        public long CustomerId { get; set; }
        public Customer Customer { get; set; }  // Relationship: Each Order is placed by one Customer
        public long PaymentId { get; set; }

        // Navigation Properties
        public List<Car> Cars { get; set; } = new List<Car>();  // Relationship: Each Order can contain multiple Cars
        public List<CarPart> CarParts { get; set; } = new List<CarPart>();  // Relationship: Each Order can contain multiple Car Parts
        public List<Payment> Payments { get; set; }  // Relationship: Each Order has multiple Payments
    }

}
