using ABC.CarTraders.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.IO;

namespace ABC.CarTraders.Entities
{
    public class Car : Record
    {
        public string ModelName { get; set; }
        public decimal Price { get; set; }
        public int Year { get; set; }
        public CarType Type { get; set; }
        public string EngineDetails { get; set; }
        public string Color { get; set; }
        public byte[] Image { get; set; }
        public int Stock { get; set; }

        //Navigation Properties
        public List<CarPart> CarParts { get; set; } = new List<CarPart>(); // Relationship: One Car can have multiple parts
        public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>(); // Relationship: One Car can be part of multiple Orders

        [NotMapped]
        public Image Thumbnail
        {
            get
            {
                if (Image == null || Image.Length == 0)
                {
                    // Return the default image
                    return Helper.ResizeImageToFitBox(Helper.GetDefaultCarImage(), 100, 100);
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
            return ModelName;
        }

    }
}
