namespace BMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Catagories",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                        Code = c.String(),
                        CreatedById = c.Long(),
                        CreatedOn = c.DateTime(nullable: false),
                        LastModifideById = c.Long(),
                        LastModifiedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                        Code = c.String(),
                        ReorderLevel = c.Double(nullable: false),
                        Description = c.String(),
                        Photo = c.Binary(),
                        UnitPrice = c.Double(nullable: false),
                        CostPrice = c.Double(nullable: false),
                        CatagoryId = c.Long(nullable: false),
                        CreatedById = c.Long(),
                        CreatedOn = c.DateTime(nullable: false),
                        LastModifideById = c.Long(),
                        LastModifiedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Catagories", t => t.CatagoryId, cascadeDelete: true)
                .Index(t => t.CatagoryId);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                        ContactNo = c.String(),
                        Email = c.String(),
                        Address = c.String(),
                        LoyaltyPoint = c.Double(nullable: false),
                        Code = c.String(),
                        Photo = c.Binary(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PurchaseDetails",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        ProductId = c.Long(nullable: false),
                        ManufectureDate = c.DateTime(nullable: false),
                        ExpireDate = c.DateTime(nullable: false),
                        PurchaseQuantity = c.Double(nullable: false),
                        UnitPrice = c.Double(nullable: false),
                        TotalPrice = c.Double(nullable: false),
                        PreviousCostPrice = c.Double(nullable: false),
                        PreviousMRP = c.Double(nullable: false),
                        NewCostPrice = c.Double(nullable: false),
                        NewMRP = c.Double(nullable: false),
                        Purchase_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.Purchases", t => t.Purchase_Id)
                .Index(t => t.ProductId)
                .Index(t => t.Purchase_Id);
            
            CreateTable(
                "dbo.Purchases",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        PurchaseDate = c.DateTime(nullable: false),
                        SuplierId = c.Long(nullable: false),
                        ProductId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Supliers", t => t.SuplierId, cascadeDelete: true)
                .Index(t => t.SuplierId);
            
            CreateTable(
                "dbo.Supliers",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                        ContactNo = c.String(),
                        Email = c.String(),
                        Address = c.String(),
                        Code = c.String(),
                        ContactPerson = c.String(),
                        Photo = c.Binary(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Sales",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        PurchaseDate = c.DateTime(nullable: false),
                        CustomerId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .Index(t => t.CustomerId);
            
            CreateTable(
                "dbo.SaleDetails",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        ProductId = c.Long(nullable: false),
                        Name = c.String(),
                        Quantiy = c.Double(nullable: false),
                        UnitPrice = c.Double(nullable: false),
                        LineTotal = c.Double(nullable: false),
                        Sale_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.Sales", t => t.Sale_Id)
                .Index(t => t.ProductId)
                .Index(t => t.Sale_Id);
            
            CreateTable(
                "dbo.Stocks",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        ProductName = c.Long(nullable: false),
                        ExpiredDate = c.DateTime(nullable: false),
                        OpeningBalance = c.Double(nullable: false),
                        InStock = c.Double(nullable: false),
                        OutStock = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SaleDetails", "Sale_Id", "dbo.Sales");
            DropForeignKey("dbo.SaleDetails", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Sales", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.Purchases", "SuplierId", "dbo.Supliers");
            DropForeignKey("dbo.PurchaseDetails", "Purchase_Id", "dbo.Purchases");
            DropForeignKey("dbo.PurchaseDetails", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Products", "CatagoryId", "dbo.Catagories");
            DropIndex("dbo.SaleDetails", new[] { "Sale_Id" });
            DropIndex("dbo.SaleDetails", new[] { "ProductId" });
            DropIndex("dbo.Sales", new[] { "CustomerId" });
            DropIndex("dbo.Purchases", new[] { "SuplierId" });
            DropIndex("dbo.PurchaseDetails", new[] { "Purchase_Id" });
            DropIndex("dbo.PurchaseDetails", new[] { "ProductId" });
            DropIndex("dbo.Products", new[] { "CatagoryId" });
            DropTable("dbo.Stocks");
            DropTable("dbo.SaleDetails");
            DropTable("dbo.Sales");
            DropTable("dbo.Supliers");
            DropTable("dbo.Purchases");
            DropTable("dbo.PurchaseDetails");
            DropTable("dbo.Customers");
            DropTable("dbo.Products");
            DropTable("dbo.Catagories");
        }
    }
}
