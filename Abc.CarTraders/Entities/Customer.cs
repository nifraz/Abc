using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABC.CarTraders.Entities
{
    public class Customer : Record
    {
        public int UserId { get; set; }  // Primary Key and Foreign Key to User

        // Customer-specific properties
        public string Address { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string PreferredPaymentMethod { get; set; }
        public string LoyaltyCardNumber { get; set; }
        public List<Order> Orders { get; set; } = new List<Order>();  // Relationship: One Customer can place multiple Orders

        // Navigation property
        public virtual User User { get; set; }  // Back-reference to User

        public Customer()
        {
            RegistrationDate = DateTime.Now;
        }
    }

}
