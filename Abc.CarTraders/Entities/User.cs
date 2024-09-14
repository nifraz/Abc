using ABC.CarTraders.Enums;
using System;
using System.Drawing;
using System.IO;
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

        public Image Thumbnail
        {
            get
            {
                if (Image == null || Image.Length == 0)
                {
                    // Return the default image
                    return Helper.ResizeImageToFitBox(Helper.GetDefaultUserImage(), 100, 100);
                }

                // Convert byte[] to Image and resize it to 100px width
                using (var ms = new MemoryStream(Image))
                {
                    Image originalImage = System.Drawing.Image.FromStream(ms);
                    return Helper.ResizeImageToFitBox(originalImage, 100, 100);  // Resize to 100px width
                }
            }
        }

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
