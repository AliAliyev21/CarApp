namespace WpfCarApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BanNovus",
                c => new
                    {
                        BanNovuID = c.Int(nullable: false, identity: true),
                        BanNovuName = c.String(),
                    })
                .PrimaryKey(t => t.BanNovuID);
            
            CreateTable(
                "dbo.Cars",
                c => new
                    {
                        CarID = c.Int(nullable: false, identity: true),
                        BrandID = c.Int(nullable: false),
                        NewOrOldID = c.Int(nullable: false),
                        BanNovuID = c.Int(nullable: false),
                        YurusID = c.Int(nullable: false),
                        BuraxilisIliID = c.Int(nullable: false),
                        ColorID = c.Int(nullable: false),
                        PriceID = c.Int(nullable: false),
                        PetrolTypeID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CarID)
                .ForeignKey("dbo.BanNovus", t => t.BanNovuID, cascadeDelete: true)
                .ForeignKey("dbo.Brands", t => t.BrandID, cascadeDelete: true)
                .ForeignKey("dbo.BuraxilisIlis", t => t.BuraxilisIliID, cascadeDelete: true)
                .ForeignKey("dbo.Colors", t => t.ColorID, cascadeDelete: true)
                .ForeignKey("dbo.NewOrOlds", t => t.NewOrOldID, cascadeDelete: true)
                .ForeignKey("dbo.PetrolTypes", t => t.PetrolTypeID, cascadeDelete: true)
                .ForeignKey("dbo.Prices", t => t.PriceID, cascadeDelete: true)
                .ForeignKey("dbo.Yurus", t => t.YurusID, cascadeDelete: true)
                .Index(t => t.BrandID)
                .Index(t => t.NewOrOldID)
                .Index(t => t.BanNovuID)
                .Index(t => t.YurusID)
                .Index(t => t.BuraxilisIliID)
                .Index(t => t.ColorID)
                .Index(t => t.PriceID)
                .Index(t => t.PetrolTypeID);
            
            CreateTable(
                "dbo.Brands",
                c => new
                    {
                        BrandID = c.Int(nullable: false, identity: true),
                        BrandName = c.String(),
                    })
                .PrimaryKey(t => t.BrandID);
            
            CreateTable(
                "dbo.BuraxilisIlis",
                c => new
                    {
                        BuraxilisIliID = c.Int(nullable: false, identity: true),
                        BuraxilisIliName = c.String(),
                    })
                .PrimaryKey(t => t.BuraxilisIliID);
            
            CreateTable(
                "dbo.Colors",
                c => new
                    {
                        ColorID = c.Int(nullable: false, identity: true),
                        ColorName = c.String(),
                    })
                .PrimaryKey(t => t.ColorID);
            
            CreateTable(
                "dbo.NewOrOlds",
                c => new
                    {
                        NewOrOldID = c.Int(nullable: false, identity: true),
                        Status = c.String(),
                    })
                .PrimaryKey(t => t.NewOrOldID);
            
            CreateTable(
                "dbo.PetrolTypes",
                c => new
                    {
                        PetrolTypeID = c.Int(nullable: false, identity: true),
                        PetrolTypeName = c.String(),
                    })
                .PrimaryKey(t => t.PetrolTypeID);
            
            CreateTable(
                "dbo.Prices",
                c => new
                    {
                        PriceID = c.Int(nullable: false, identity: true),
                        PriceAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.PriceID);
            
            CreateTable(
                "dbo.Yurus",
                c => new
                    {
                        YurusID = c.Int(nullable: false, identity: true),
                        MinYurus = c.Int(nullable: false),
                        MaxYurus = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.YurusID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cars", "YurusID", "dbo.Yurus");
            DropForeignKey("dbo.Cars", "PriceID", "dbo.Prices");
            DropForeignKey("dbo.Cars", "PetrolTypeID", "dbo.PetrolTypes");
            DropForeignKey("dbo.Cars", "NewOrOldID", "dbo.NewOrOlds");
            DropForeignKey("dbo.Cars", "ColorID", "dbo.Colors");
            DropForeignKey("dbo.Cars", "BuraxilisIliID", "dbo.BuraxilisIlis");
            DropForeignKey("dbo.Cars", "BrandID", "dbo.Brands");
            DropForeignKey("dbo.Cars", "BanNovuID", "dbo.BanNovus");
            DropIndex("dbo.Cars", new[] { "PetrolTypeID" });
            DropIndex("dbo.Cars", new[] { "PriceID" });
            DropIndex("dbo.Cars", new[] { "ColorID" });
            DropIndex("dbo.Cars", new[] { "BuraxilisIliID" });
            DropIndex("dbo.Cars", new[] { "YurusID" });
            DropIndex("dbo.Cars", new[] { "BanNovuID" });
            DropIndex("dbo.Cars", new[] { "NewOrOldID" });
            DropIndex("dbo.Cars", new[] { "BrandID" });
            DropTable("dbo.Yurus");
            DropTable("dbo.Prices");
            DropTable("dbo.PetrolTypes");
            DropTable("dbo.NewOrOlds");
            DropTable("dbo.Colors");
            DropTable("dbo.BuraxilisIlis");
            DropTable("dbo.Brands");
            DropTable("dbo.Cars");
            DropTable("dbo.BanNovus");
        }
    }
}
