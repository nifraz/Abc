namespace ABC.CarTraders.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateContext : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Orders", "Car_Id", "dbo.Cars");
            DropForeignKey("dbo.Orders", "CarPart_Id", "dbo.CarParts");
            DropIndex("dbo.Orders", new[] { "Car_Id" });
            DropIndex("dbo.Orders", new[] { "CarPart_Id" });
            DropColumn("dbo.Orders", "Car_Id");
            DropColumn("dbo.Orders", "CarPart_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "CarPart_Id", c => c.Int());
            AddColumn("dbo.Orders", "Car_Id", c => c.Int());
            CreateIndex("dbo.Orders", "CarPart_Id");
            CreateIndex("dbo.Orders", "Car_Id");
            AddForeignKey("dbo.Orders", "CarPart_Id", "dbo.CarParts", "Id");
            AddForeignKey("dbo.Orders", "Car_Id", "dbo.Cars", "Id");
        }
    }
}
