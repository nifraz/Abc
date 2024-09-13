using ABC.CarTraders.Enums;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace ABC.CarTraders.Entities
{
    public class User : Record
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public string PhoneNo { get; set; }
        public UserRole Role { get; set; }

        public Customer CustomerProfile { get; set; }  // Relationship: A User can be a Customer

        public static string GetHashSha1(string text)
        {
            var sha1 = SHA1.Create();
            var inputBytes = Encoding.ASCII.GetBytes(text);
            var hash = sha1.ComputeHash(inputBytes);

            var sb = new StringBuilder();
            for (var i = 0; i < hash.Length; i++) sb.Append(hash[i].ToString("X2"));
            return sb.ToString();
        }
    }

}
