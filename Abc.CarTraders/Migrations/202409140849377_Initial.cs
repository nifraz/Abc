namespace ABC.CarTraders.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Logs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Action = c.Byte(nullable: false),
                        Text = c.String(),
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
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                        Password = c.String(),
                        FullName = c.String(),
                        Sex = c.Byte(nullable: false),
                        PhoneNo = c.String(),
                        Role = c.Byte(nullable: false),
                        Address = c.String(),
                        DateOfBirth = c.DateTime(),
                        PaymentMethod = c.Int(),
                        Image = c.Binary(),
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Logs", "LastModifiedUserId", "dbo.Users");
            DropForeignKey("dbo.Logs", "DeletedUserId", "dbo.Users");
            DropForeignKey("dbo.Logs", "CreatedUserId", "dbo.Users");
            DropForeignKey("dbo.Users", "LastModifiedUserId", "dbo.Users");
            DropForeignKey("dbo.Users", "DeletedUserId", "dbo.Users");
            DropForeignKey("dbo.Users", "CreatedUserId", "dbo.Users");
            DropIndex("dbo.Users", new[] { "DeletedUserId" });
            DropIndex("dbo.Users", new[] { "LastModifiedUserId" });
            DropIndex("dbo.Users", new[] { "CreatedUserId" });
            DropIndex("dbo.Logs", new[] { "DeletedUserId" });
            DropIndex("dbo.Logs", new[] { "LastModifiedUserId" });
            DropIndex("dbo.Logs", new[] { "CreatedUserId" });
            DropTable("dbo.Users");
            DropTable("dbo.Logs");
        }
    }
}
