using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABC.CarTraders.Entities
{
    public class Payment : Record
    {
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public string PaymentMethod { get; set; }  // E.g., Credit Card, PayPal, etc.
        public bool IsSuccessful { get; set; }

        // Foreign Key to Order
        public long OrderId { get; set; }
        public Order Order { get; set; }  // Each Payment is associated with one Order
    }

}
