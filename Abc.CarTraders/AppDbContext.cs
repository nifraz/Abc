using ABC.CarTraders.Entities;
using System.Data.Entity;

namespace ABC.CarTraders
{
    public class AppDbContext : DbContext
    {
        public DbSet<Log> Logs { get; set; }
        public DbSet<User> Users { get; set; }
        //public DbSet<Customer> Customers { get; set; }
        //public DbSet<Car> Cars { get; set; }
        //public DbSet<CarPart> CarParts { get; set; }
        //public DbSet<Order> Orders { get; set; }
        //public DbSet<Payment> Payments { get; set; }

        public AppDbContext() : base("name=AppDbContext")
        {

        }

        public AppDbContext(string connectionString) : base(connectionString)
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // User -> Customer (One-to-One)
            //modelBuilder.Entity<User>()
            //    .HasOptional(u => u.CustomerProfile)
            //    .WithRequired(c => c.User)
            //    .Map(m => m.MapKey("UserId"));

            //modelBuilder.Entity<Customer>()
            //    .HasRequired(x => x.User)
            //    .WithOptional(x => x.CustomerProfile);

            //// Customer -> Orders (One-to-Many)
            //modelBuilder.Entity<Customer>()
            //    .HasMany(u => u.Orders)
            //    .WithRequired(o => o.Customer)
            //    .HasForeignKey(o => o.CustomerId);

            //// Car -> CarParts (One-to-Many)
            //modelBuilder.Entity<Car>()
            //    .HasMany(c => c.CarParts)
            //    .WithRequired(cp => cp.Car)
            //    .HasForeignKey(cp => cp.CarId);

            //// Order -> Cars (Many-to-Many)
            //modelBuilder.Entity<Order>()
            //    .HasMany(o => o.Cars)
            //    .WithMany(c => c.Orders)
            //    .Map(m =>
            //    {
            //        m.ToTable("OrderCars");
            //        m.MapLeftKey("OrderId");
            //        m.MapRightKey("CarId");
            //    });

            // Order -> CarParts (Many-to-Many)
            //modelBuilder.Entity<Order>()
            //    .HasMany(o => o.CarParts)
            //    .WithMany(cp => cp.Orders)
            //    .Map(m =>
            //    {
            //        m.ToTable("OrderCarParts");
            //        m.MapLeftKey("OrderId");
            //        m.MapRightKey("CarPartId");
            //    });

            //// One-to-Many Order -> Payment
            //modelBuilder.Entity<Order>()
            //    .HasMany(o => o.Payments)
            //    .WithRequired(p => p.Order)
            //    .HasForeignKey(p => p.OrderId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
