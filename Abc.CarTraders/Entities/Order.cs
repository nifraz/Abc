using ABC.CarTraders.Enums;
using System.Collections.Generic;

namespace ABC.CarTraders.Entities
{
    public class Order : Record
    {
        public OrderStatus Status { get; set; }
        public decimal TotalPrice { get; set; }

        // Navigation Properties
        public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
        public List<Payment> Payments { get; set; } = new List<Payment>();  // Relationship: Each Order has multiple Payments
    }

}
