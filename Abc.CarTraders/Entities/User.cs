using ABC.CarTraders.Enums;
using System;
using System.Security.Cryptography;
using System.Text;

namespace ABC.CarTraders.Entities
{
    public class User : Record
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public Sex Sex { get; set; }
        public string PhoneNo { get; set; }
        public UserRole Role { get; set; }

        // Customer-specific properties
        public string Address { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public PaymentMethod? PaymentMethod { get; set; }
        public byte[] Image { get; set; }
        //public bool IsActive { get; set; }
        //public List<Order> Orders { get; set; } = new List<Order>();  // Relationship: One Customer can place multiple Orders

        public static string GetHashSha1(string text)
        {
            var sha1 = SHA1.Create();
            var inputBytes = Encoding.ASCII.GetBytes(text);
            var hash = sha1.ComputeHash(inputBytes);

            var sb = new StringBuilder();
            for (var i = 0; i < hash.Length; i++) sb.Append(hash[i].ToString("X2"));
            return sb.ToString();
        }

        public override string ToString()
        {
            return Email;
        }
    }

}
