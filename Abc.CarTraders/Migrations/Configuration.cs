namespace ABC.CarTraders.Migrations
{
    using ABC.CarTraders.Entities;
    using ABC.CarTraders.Enums;
    using System;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<AppDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(AppDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

            context.Users.AddOrUpdate(x => x.Id,
                new User
                {
                    Id = 1,
                    Email = "admin@system.com",
                    Password = User.GetHashSha1("0000"),
                    FullName = "System Admin",
                    PhoneNo = "0712000000",
                    Role = UserRole.Admin,
                    Notes = "Admin",
                    CreatedDate = DateTime.Now,
                    Sex = Sex.Male,
                },
                new User
                {
                    Id = 2,
                    Email = "nifraz@live.com",
                    Password = User.GetHashSha1("1234"),
                    FullName = "Nifraz Navahz",
                    PhoneNo = "0712319319",
                    Role = UserRole.Admin,
                    Notes = "Developer",
                    CreatedDate = DateTime.Now,
                    Sex = Sex.Male,
                },
                new User
                {
                    Id = 3,
                    Email = "customer@abc.com",
                    Password = User.GetHashSha1("1111"),
                    FullName = "ABC Customer",
                    PhoneNo = "0812123123",
                    Role = UserRole.Customer,
                    Notes = "Developer",
                    CreatedDate = DateTime.Now,
                    Address = "123, New Road, Kandy",
                    DateOfBirth = DateTime.Now.AddYears(-20),
                    PaymentMethod = PaymentMethod.Cash,
                    Sex = Sex.Male,
                }
            );

        }
    }
}
