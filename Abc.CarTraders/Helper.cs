using ABC.CarTraders.Entities;
using ABC.CarTraders.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Mail;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

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
    }
}
