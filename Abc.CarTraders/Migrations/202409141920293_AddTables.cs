namespace ABC.CarTraders.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CarParts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PartName = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Image = c.Binary(),
                        Stock = c.Int(nullable: false),
                        CarId = c.Int(nullable: false),
                        CreatedUserId = c.Int(),
                        CreatedDate = c.DateTime(nullable: false),
                        LastModifiedUserId = c.Int(),
                        LastModifiedDate = c.DateTime(),
                        DeletedUserId = c.Int(),
                        DeletedDate = c.DateTime(),
                        Notes = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cars", t => t.CarId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.CreatedUserId)
                .ForeignKey("dbo.Users", t => t.DeletedUserId)
                .ForeignKey("dbo.Users", t => t.LastModifiedUserId)
                .Index(t => t.CarId)
                .Index(t => t.CreatedUserId)
                .Index(t => t.LastModifiedUserId)
                .Index(t => t.DeletedUserId);
            
            CreateTable(
                "dbo.Cars",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ModelName = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Year = c.Int(nullable: false),
                        Type = c.Byte(nullable: false),
                        EngineDetails = c.String(),
                        Color = c.String(),
                        Image = c.Binary(),
                        Stock = c.Int(nullable: false),
                        CreatedUserId = c.Int(),
                        CreatedDate = c.DateTime(nullable: false),
                        LastModifiedUserId = c.Int(),
                        LastModifiedDate = c.DateTime(),
                        DeletedUserId = c.Int(),
                        DeletedDate = c.DateTime(),
                        Notes = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.CreatedUserId)
                .ForeignKey("dbo.Users", t => t.DeletedUserId)
                .ForeignKey("dbo.Users", t => t.LastModifiedUserId)
                .Index(t => t.CreatedUserId)
                .Index(t => t.LastModifiedUserId)
                .Index(t => t.DeletedUserId);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Status = c.Byte(nullable: false),
                        TotalPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CreatedUserId = c.Int(),
                        CreatedDate = c.DateTime(nullable: false),
                        LastModifiedUserId = c.Int(),
                        LastModifiedDate = c.DateTime(),
                        DeletedUserId = c.Int(),
                        DeletedDate = c.DateTime(),
                        Notes = c.String(),
                        Car_Id = c.Int(),
                        CarPart_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.CreatedUserId)
                .ForeignKey("dbo.Users", t => t.DeletedUserId)
                .ForeignKey("dbo.Users", t => t.LastModifiedUserId)
                .ForeignKey("dbo.Cars", t => t.Car_Id)
                .ForeignKey("dbo.CarParts", t => t.CarPart_Id)
                .Index(t => t.CreatedUserId)
                .Index(t => t.LastModifiedUserId)
                .Index(t => t.DeletedUserId)
                .Index(t => t.Car_Id)
                .Index(t => t.CarPart_Id);
            
            CreateTable(
                "dbo.OrderItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrderId = c.Int(nullable: false),
                        CarId = c.Int(),
                        CarPartId = c.Int(),
                        Quantity = c.Int(nullable: false),
                        UnitPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TotalPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CreatedUserId = c.Int(),
                        CreatedDate = c.DateTime(nullable: false),
                        LastModifiedUserId = c.Int(),
                        LastModifiedDate = c.DateTime(),
                        DeletedUserId = c.Int(),
                        DeletedDate = c.DateTime(),
                        Notes = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cars", t => t.CarId)
                .ForeignKey("dbo.CarParts", t => t.CarPartId)
                .ForeignKey("dbo.Users", t => t.CreatedUserId)
                .ForeignKey("dbo.Users", t => t.DeletedUserId)
                .ForeignKey("dbo.Users", t => t.LastModifiedUserId)
                .ForeignKey("dbo.Orders", t => t.OrderId, cascadeDelete: true)
                .Index(t => t.OrderId)
                .Index(t => t.CarId)
                .Index(t => t.CarPartId)
                .Index(t => t.CreatedUserId)
                .Index(t => t.LastModifiedUserId)
                .Index(t => t.DeletedUserId);
            
            CreateTable(
                "dbo.Payments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PaymentMethod = c.Int(nullable: false),
                        OrderId = c.Int(nullable: false),
                        CreatedUserId = c.Int(),
                        CreatedDate = c.DateTime(nullable: false),
                        LastModifiedUserId = c.Int(),
                        LastModifiedDate = c.DateTime(),
                        DeletedUserId = c.Int(),
                        DeletedDate = c.DateTime(),
                        Notes = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.CreatedUserId)
                .ForeignKey("dbo.Users", t => t.DeletedUserId)
                .ForeignKey("dbo.Users", t => t.LastModifiedUserId)
                .ForeignKey("dbo.Orders", t => t.OrderId, cascadeDelete: true)
                .Index(t => t.OrderId)
                .Index(t => t.CreatedUserId)
                .Index(t => t.LastModifiedUserId)
                .Index(t => t.DeletedUserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "CarPart_Id", "dbo.CarParts");
            DropForeignKey("dbo.CarParts", "LastModifiedUserId", "dbo.Users");
            DropForeignKey("dbo.CarParts", "DeletedUserId", "dbo.Users");
            DropForeignKey("dbo.CarParts", "CreatedUserId", "dbo.Users");
            DropForeignKey("dbo.Orders", "Car_Id", "dbo.Cars");
            DropForeignKey("dbo.Payments", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.Payments", "LastModifiedUserId", "dbo.Users");
            DropForeignKey("dbo.Payments", "DeletedUserId", "dbo.Users");
            DropForeignKey("dbo.Payments", "CreatedUserId", "dbo.Users");
            DropForeignKey("dbo.OrderItems", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.OrderItems", "LastModifiedUserId", "dbo.Users");
            DropForeignKey("dbo.OrderItems", "DeletedUserId", "dbo.Users");
            DropForeignKey("dbo.OrderItems", "CreatedUserId", "dbo.Users");
            DropForeignKey("dbo.OrderItems", "CarPartId", "dbo.CarParts");
            DropForeignKey("dbo.OrderItems", "CarId", "dbo.Cars");
            DropForeignKey("dbo.Orders", "LastModifiedUserId", "dbo.Users");
            DropForeignKey("dbo.Orders", "DeletedUserId", "dbo.Users");
            DropForeignKey("dbo.Orders", "CreatedUserId", "dbo.Users");
            DropForeignKey("dbo.Cars", "LastModifiedUserId", "dbo.Users");
            DropForeignKey("dbo.Cars", "DeletedUserId", "dbo.Users");
            DropForeignKey("dbo.Cars", "CreatedUserId", "dbo.Users");
            DropForeignKey("dbo.CarParts", "CarId", "dbo.Cars");
            DropIndex("dbo.Payments", new[] { "DeletedUserId" });
            DropIndex("dbo.Payments", new[] { "LastModifiedUserId" });
            DropIndex("dbo.Payments", new[] { "CreatedUserId" });
            DropIndex("dbo.Payments", new[] { "OrderId" });
            DropIndex("dbo.OrderItems", new[] { "DeletedUserId" });
            DropIndex("dbo.OrderItems", new[] { "LastModifiedUserId" });
            DropIndex("dbo.OrderItems", new[] { "CreatedUserId" });
            DropIndex("dbo.OrderItems", new[] { "CarPartId" });
            DropIndex("dbo.OrderItems", new[] { "CarId" });
            DropIndex("dbo.OrderItems", new[] { "OrderId" });
            DropIndex("dbo.Orders", new[] { "CarPart_Id" });
            DropIndex("dbo.Orders", new[] { "Car_Id" });
            DropIndex("dbo.Orders", new[] { "DeletedUserId" });
            DropIndex("dbo.Orders", new[] { "LastModifiedUserId" });
            DropIndex("dbo.Orders", new[] { "CreatedUserId" });
            DropIndex("dbo.Cars", new[] { "DeletedUserId" });
            DropIndex("dbo.Cars", new[] { "LastModifiedUserId" });
            DropIndex("dbo.Cars", new[] { "CreatedUserId" });
            DropIndex("dbo.CarParts", new[] { "DeletedUserId" });
            DropIndex("dbo.CarParts", new[] { "LastModifiedUserId" });
            DropIndex("dbo.CarParts", new[] { "CreatedUserId" });
            DropIndex("dbo.CarParts", new[] { "CarId" });
            DropTable("dbo.Payments");
            DropTable("dbo.OrderItems");
            DropTable("dbo.Orders");
            DropTable("dbo.Cars");
            DropTable("dbo.CarParts");
        }
    }
}
