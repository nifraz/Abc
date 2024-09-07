namespace ABC.CarTraders.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CalvingRecords",
                c => new
                    {
                        CalvingSheetId = c.Int(nullable: false),
                        No = c.Byte(nullable: false),
                        AiDate = c.DateTime(),
                        SemenCode = c.Int(),
                        CowVsCode = c.Int(),
                        CowFarmNo = c.Int(),
                        CowAnimalNo = c.Int(),
                        CalfVsCode = c.Int(),
                        CalfFarmNo = c.Int(),
                        CalfAnimalNo = c.Int(),
                        CalvingDate = c.DateTime(),
                        Sex = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => new { t.CalvingSheetId, t.No })
                .ForeignKey("dbo.CalvingSheets", t => t.CalvingSheetId, cascadeDelete: true)
                .Index(t => t.CalvingSheetId);
            
            CreateTable(
                "dbo.CalvingSheets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Year = c.Int(nullable: false),
                        Month = c.Byte(nullable: false),
                        Notes = c.String(maxLength: 1023),
                        CreatedOn = c.DateTime(),
                        ModifiedOn = c.DateTime(),
                        TechnicianCode = c.Int(),
                        ProvinceNo = c.Byte(),
                        DistrictNo = c.Byte(),
                        VsRangeNo = c.Byte(),
                        InstituteName = c.String(maxLength: 255),
                        CreatedByUsername = c.String(maxLength: 255),
                        ModifiedByUsername = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.CreatedByUsername)
                .ForeignKey("dbo.Institutes", t => t.InstituteName)
                .ForeignKey("dbo.Users", t => t.ModifiedByUsername)
                .ForeignKey("dbo.Technicians", t => t.TechnicianCode)
                .ForeignKey("dbo.VsRanges", t => new { t.ProvinceNo, t.DistrictNo, t.VsRangeNo })
                .Index(t => t.TechnicianCode)
                .Index(t => new { t.ProvinceNo, t.DistrictNo, t.VsRangeNo })
                .Index(t => t.InstituteName)
                .Index(t => t.CreatedByUsername)
                .Index(t => t.ModifiedByUsername);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Username = c.String(nullable: false, maxLength: 255),
                        Password = c.String(nullable: false, maxLength: 255),
                        Name = c.String(nullable: false, maxLength: 255),
                        Sex = c.Byte(nullable: false),
                        EMail = c.String(maxLength: 255),
                        PhoneNo = c.String(maxLength: 15),
                        Role = c.Byte(nullable: false),
                        Notes = c.String(maxLength: 1023),
                        CreatedOn = c.DateTime(),
                        ModifiedOn = c.DateTime(),
                        CreatedByUsername = c.String(maxLength: 255),
                        ModifiedByUsername = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.Username)
                .ForeignKey("dbo.Users", t => t.CreatedByUsername)
                .ForeignKey("dbo.Users", t => t.ModifiedByUsername)
                .Index(t => t.CreatedByUsername)
                .Index(t => t.ModifiedByUsername);
            
            CreateTable(
                "dbo.Institutes",
                c => new
                    {
                        Name = c.String(nullable: false, maxLength: 255),
                        Notes = c.String(maxLength: 1023),
                        CreatedOn = c.DateTime(),
                        ModifiedOn = c.DateTime(),
                        CreatedByUsername = c.String(maxLength: 255),
                        ModifiedByUsername = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.Name)
                .ForeignKey("dbo.Users", t => t.CreatedByUsername)
                .ForeignKey("dbo.Users", t => t.ModifiedByUsername)
                .Index(t => t.CreatedByUsername)
                .Index(t => t.ModifiedByUsername);
            
            CreateTable(
                "dbo.Technicians",
                c => new
                    {
                        Code = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 255),
                        NicNo = c.String(maxLength: 12),
                        PhoneNo = c.String(maxLength: 15),
                        IssuedDate = c.DateTime(),
                        Type = c.Byte(nullable: false),
                        Status = c.Byte(nullable: false),
                        Notes = c.String(maxLength: 1023),
                        CreatedOn = c.DateTime(),
                        ModifiedOn = c.DateTime(),
                        ProvinceNo = c.Byte(),
                        DistrictNo = c.Byte(),
                        VsRangeNo = c.Byte(),
                        InstituteName = c.String(maxLength: 255),
                        CreatedByUsername = c.String(maxLength: 255),
                        ModifiedByUsername = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.Code)
                .ForeignKey("dbo.Users", t => t.CreatedByUsername)
                .ForeignKey("dbo.Institutes", t => t.InstituteName)
                .ForeignKey("dbo.Users", t => t.ModifiedByUsername)
                .ForeignKey("dbo.VsRanges", t => new { t.ProvinceNo, t.DistrictNo, t.VsRangeNo })
                .Index(t => new { t.ProvinceNo, t.DistrictNo, t.VsRangeNo })
                .Index(t => t.InstituteName)
                .Index(t => t.CreatedByUsername)
                .Index(t => t.ModifiedByUsername);
            
            CreateTable(
                "dbo.VsRanges",
                c => new
                    {
                        ProvinceNo = c.Byte(nullable: false),
                        DistrictNo = c.Byte(nullable: false),
                        No = c.Byte(nullable: false),
                        Name = c.String(nullable: false, maxLength: 255),
                        Notes = c.String(maxLength: 1023),
                        CreatedOn = c.DateTime(),
                        ModifiedOn = c.DateTime(),
                        CreatedByUsername = c.String(maxLength: 255),
                        ModifiedByUsername = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => new { t.ProvinceNo, t.DistrictNo, t.No })
                .ForeignKey("dbo.Users", t => t.CreatedByUsername)
                .ForeignKey("dbo.Districts", t => new { t.ProvinceNo, t.DistrictNo }, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.ModifiedByUsername)
                .Index(t => new { t.ProvinceNo, t.DistrictNo })
                .Index(t => t.Name, unique: true, name: "Index")
                .Index(t => t.CreatedByUsername)
                .Index(t => t.ModifiedByUsername);
            
            CreateTable(
                "dbo.Districts",
                c => new
                    {
                        ProvinceNo = c.Byte(nullable: false),
                        No = c.Byte(nullable: false),
                        Name = c.String(nullable: false, maxLength: 255),
                        SinhalaName = c.String(nullable: false, maxLength: 255),
                        TamilName = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => new { t.ProvinceNo, t.No })
                .ForeignKey("dbo.Provinces", t => t.ProvinceNo, cascadeDelete: true)
                .Index(t => t.ProvinceNo);
            
            CreateTable(
                "dbo.Provinces",
                c => new
                    {
                        No = c.Byte(nullable: false),
                        Name = c.String(nullable: false, maxLength: 255),
                        SinhalaName = c.String(nullable: false, maxLength: 255),
                        TamilName = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.No);
            
            CreateTable(
                "dbo.Logs",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Time = c.DateTime(nullable: false),
                        Title = c.String(nullable: false, maxLength: 255),
                        Action = c.Byte(nullable: false),
                        Text = c.String(nullable: false, maxLength: 255),
                        Username = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.Username)
                .Index(t => t.Username);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CalvingRecords", "CalvingSheetId", "dbo.CalvingSheets");
            DropForeignKey("dbo.CalvingSheets", new[] { "ProvinceNo", "DistrictNo", "VsRangeNo" }, "dbo.VsRanges");
            DropForeignKey("dbo.CalvingSheets", "TechnicianCode", "dbo.Technicians");
            DropForeignKey("dbo.CalvingSheets", "ModifiedByUsername", "dbo.Users");
            DropForeignKey("dbo.CalvingSheets", "InstituteName", "dbo.Institutes");
            DropForeignKey("dbo.CalvingSheets", "CreatedByUsername", "dbo.Users");
            DropForeignKey("dbo.Users", "ModifiedByUsername", "dbo.Users");
            DropForeignKey("dbo.Logs", "Username", "dbo.Users");
            DropForeignKey("dbo.Technicians", new[] { "ProvinceNo", "DistrictNo", "VsRangeNo" }, "dbo.VsRanges");
            DropForeignKey("dbo.VsRanges", "ModifiedByUsername", "dbo.Users");
            DropForeignKey("dbo.VsRanges", new[] { "ProvinceNo", "DistrictNo" }, "dbo.Districts");
            DropForeignKey("dbo.Districts", "ProvinceNo", "dbo.Provinces");
            DropForeignKey("dbo.VsRanges", "CreatedByUsername", "dbo.Users");
            DropForeignKey("dbo.Technicians", "ModifiedByUsername", "dbo.Users");
            DropForeignKey("dbo.Technicians", "InstituteName", "dbo.Institutes");
            DropForeignKey("dbo.Technicians", "CreatedByUsername", "dbo.Users");
            DropForeignKey("dbo.Institutes", "ModifiedByUsername", "dbo.Users");
            DropForeignKey("dbo.Institutes", "CreatedByUsername", "dbo.Users");
            DropForeignKey("dbo.Users", "CreatedByUsername", "dbo.Users");
            DropIndex("dbo.Logs", new[] { "Username" });
            DropIndex("dbo.Districts", new[] { "ProvinceNo" });
            DropIndex("dbo.VsRanges", new[] { "ModifiedByUsername" });
            DropIndex("dbo.VsRanges", new[] { "CreatedByUsername" });
            DropIndex("dbo.VsRanges", "Index");
            DropIndex("dbo.VsRanges", new[] { "ProvinceNo", "DistrictNo" });
            DropIndex("dbo.Technicians", new[] { "ModifiedByUsername" });
            DropIndex("dbo.Technicians", new[] { "CreatedByUsername" });
            DropIndex("dbo.Technicians", new[] { "InstituteName" });
            DropIndex("dbo.Technicians", new[] { "ProvinceNo", "DistrictNo", "VsRangeNo" });
            DropIndex("dbo.Institutes", new[] { "ModifiedByUsername" });
            DropIndex("dbo.Institutes", new[] { "CreatedByUsername" });
            DropIndex("dbo.Users", new[] { "ModifiedByUsername" });
            DropIndex("dbo.Users", new[] { "CreatedByUsername" });
            DropIndex("dbo.CalvingSheets", new[] { "ModifiedByUsername" });
            DropIndex("dbo.CalvingSheets", new[] { "CreatedByUsername" });
            DropIndex("dbo.CalvingSheets", new[] { "InstituteName" });
            DropIndex("dbo.CalvingSheets", new[] { "ProvinceNo", "DistrictNo", "VsRangeNo" });
            DropIndex("dbo.CalvingSheets", new[] { "TechnicianCode" });
            DropIndex("dbo.CalvingRecords", new[] { "CalvingSheetId" });
            DropTable("dbo.Logs");
            DropTable("dbo.Provinces");
            DropTable("dbo.Districts");
            DropTable("dbo.VsRanges");
            DropTable("dbo.Technicians");
            DropTable("dbo.Institutes");
            DropTable("dbo.Users");
            DropTable("dbo.CalvingSheets");
            DropTable("dbo.CalvingRecords");
        }
    }
}
