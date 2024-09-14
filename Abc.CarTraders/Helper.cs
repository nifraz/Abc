using ABC.CarTraders.Entities;
using ABC.CarTraders.Enums;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Mail;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ABC.CarTraders
{
    public static class Helper
    {
        public static Expression<Func<T, object>> BuildOrderByExpression<T>(string propertyName)
        {
            // Parameter expression: represents the entity (e.g., "User user => ...")
            var parameter = Expression.Parameter(typeof(T), "x");

            // Property expression: represents accessing a property by name (e.g., "user.Property")
            var property = Expression.Property(parameter, propertyName);

            // If the property is a value type (like long, int, etc.), do not cast to object
            Type propertyType = property.Type;
            Expression conversion = property;

            // Only box value types (e.g., long, int) to object for OrderBy if required
            if (propertyType.IsValueType && propertyType != typeof(long))
            {
                conversion = Expression.Convert(property, typeof(object));  // Only for non-long value types
            }

            // Build and return the lambda expression: "user => user.Property"
            return Expression.Lambda<Func<T, object>>(conversion, parameter);
        }

        public static IQueryable<User> ApplyOrderBy(IQueryable<User> query, string orderByProperty, string sortDirection)
        {
            // Build the expression dynamically
            var orderByExpression = BuildOrderByExpression<User>(orderByProperty);

            // Apply OrderBy or OrderByDescending based on the ascending flag
            if (sortDirection == SortDirection.Descending.ToString())
            {
                return query.OrderByDescending(orderByExpression);
            }
            return query.OrderBy(orderByExpression);
        }

        public static List<string> GetAllPropertyNames<T>()
        {
            // Get the type of the class
            var type = typeof(T);

            // Use reflection to get all properties
            return type.GetProperties(BindingFlags.Instance | BindingFlags.Public)
                       .Select(prop => prop.Name)
                       .ToList();
        }

        public static bool IsValidEmail(string email)
        {
            try
            {
                var addr = new MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        public static Image ResizeImage(Image image, int width)
        {
            if (image == null)
                return null;

            // Calculate the height to maintain aspect ratio
            int originalWidth = image.Width;
            int originalHeight = image.Height;
            int height = (int)(originalHeight * (100.0 / originalWidth));

            // Create a new image with the specified dimensions
            var resizedImage = new Bitmap(width, height);
            using (var graphics = Graphics.FromImage(resizedImage))
            {
                graphics.DrawImage(image, 0, 0, width, height);
            }
            return resizedImage;
        }

        public static Image GetDefaultUserImage()
        {
            // Assuming you have a default image in the project resources
            return Properties.Resources.user_100px;  // Replace with the actual default image resource
        }

        public static Image GetDefaultCarImage()
        {
            // Assuming you have a default image in the project resources
            return Properties.Resources.car_100px;  // Replace with the actual default image resource
        }

        public static Image GetDefaultCarPartImage()
        {
            // Assuming you have a default image in the project resources
            return Properties.Resources.carpart_100px;  // Replace with the actual default image resource
        }

        public static Image ResizeImageToFitBox(Image image, int boxWidth, int boxHeight)
        {
            if (image == null)
                return null;

            // Get the original width and height of the image
            int originalWidth = image.Width;
            int originalHeight = image.Height;

            // Calculate the ratio to maintain aspect ratio
            float widthRatio = (float)boxWidth / originalWidth;
            float heightRatio = (float)boxHeight / originalHeight;

            // Use the smaller ratio to ensure the image fits within the box
            float scaleRatio = Math.Min(widthRatio, heightRatio);

            // Calculate the new width and height while maintaining the aspect ratio
            int newWidth = (int)(originalWidth * scaleRatio);
            int newHeight = (int)(originalHeight * scaleRatio);

            // Create a new bitmap with the desired size
            var resizedImage = new Bitmap(newWidth, newHeight);

            // Draw the original image, resized, onto the new bitmap
            using (var graphics = Graphics.FromImage(resizedImage))
            {
                graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                graphics.DrawImage(image, 0, 0, newWidth, newHeight);
            }

            return resizedImage;
        }

        public static Image LoadImageFromDatabase(byte[] imageData)
        {
            // Use the MemoryStream to load the image
            using (var ms = new MemoryStream(imageData))
            {
                // Load the image from the stream
                Image originalImage = Image.FromStream(ms);

                // Create a new Bitmap, making a full copy of the image
                return new Bitmap(originalImage);  // This ensures the image is independent of the stream
            }
        }

        public static byte[] GetImageBytesFromPictureBox(PictureBox pictureBox)
        {
            if (pictureBox.Image != null)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    // Clone the image from PictureBox to avoid GDI+ locking issues
                    using (Image cloneImage = new Bitmap(pictureBox.Image))  // Make a full copy with Bitmap
                    {
                        // Save the cloned image into the MemoryStream
                        cloneImage.Save(ms, System.Drawing.Imaging.ImageFormat.Png);  // Specify the format (PNG, JPEG, etc.)

                        // Return the byte array
                        return ms.ToArray();
                    }
                }
            }

            return null;
        }

    }
}
