using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.IO;

namespace ABC.CarTraders.Entities
{
    public class CarPart : Record
    {
        public string PartName { get; set; }
        public decimal Price { get; set; }
        public byte[] Image { get; set; }
        public int Stock { get; set; }

        // Foreign Key to Car
        public int CarId { get; set; }
        public Car Car { get; set; }  // Relationship: Each CarPart belongs to one Car

        public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>(); // Relationship: One CarPart can be part of multiple Orders

        [NotMapped]
        public Image Thumbnail
        {
            get
            {
                if (Image == null || Image.Length == 0)
                {
                    // Return the default image
                    return Helper.ResizeImageToFitBox(Helper.GetDefaultCarPartImage(), 100, 100);
                }

                // Convert byte[] to Image and resize it to 100px width
                using (var ms = new MemoryStream(Image))
                {
                    Image originalImage = System.Drawing.Image.FromStream(ms);
                    return Helper.ResizeImageToFitBox(originalImage, 100, 100);  // Resize to 100px width
                }
            }
        }

        public override string ToString()
        {
            return PartName;
        }
    }

}
