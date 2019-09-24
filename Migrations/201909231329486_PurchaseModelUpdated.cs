namespace BMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PurchaseModelUpdated : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Supliers", newName: "Suppliers");
            DropForeignKey("dbo.PurchaseDetails", "Purchase_Id", "dbo.Purchases");
            DropIndex("dbo.PurchaseDetails", new[] { "Purchase_Id" });
            RenameColumn(table: "dbo.PurchaseDetails", name: "Purchase_Id", newName: "PurchaseId");
            RenameColumn(table: "dbo.Purchases", name: "SuplierId", newName: "SupplierId");
            RenameIndex(table: "dbo.Purchases", name: "IX_SuplierId", newName: "IX_SupplierId");
            AddColumn("dbo.PurchaseDetails", "Qty", c => c.Double(nullable: false));
            AddColumn("dbo.PurchaseDetails", "MrP", c => c.Double(nullable: false));
            AddColumn("dbo.Purchases", "PurchaseDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Stocks", "ProductId", c => c.Long(nullable: false));
            AddColumn("dbo.Stocks", "Qty", c => c.Double(nullable: false));
            AlterColumn("dbo.PurchaseDetails", "PurchaseId", c => c.Long(nullable: false));
            CreateIndex("dbo.PurchaseDetails", "PurchaseId");
            CreateIndex("dbo.Stocks", "ProductId");
            AddForeignKey("dbo.Stocks", "ProductId", "dbo.Products", "Id", cascadeDelete: true);
            AddForeignKey("dbo.PurchaseDetails", "PurchaseId", "dbo.Purchases", "Id", cascadeDelete: true);
            DropColumn("dbo.PurchaseDetails", "PurchaseQuantity");
            DropColumn("dbo.PurchaseDetails", "TotalPrice");
            DropColumn("dbo.PurchaseDetails", "PreviousCostPrice");
            DropColumn("dbo.PurchaseDetails", "PreviousMRP");
            DropColumn("dbo.PurchaseDetails", "NewCostPrice");
            DropColumn("dbo.PurchaseDetails", "NewMRP");
            DropColumn("dbo.Stocks", "ProductName");
            DropColumn("dbo.Stocks", "OpeningBalance");
            DropColumn("dbo.Stocks", "InStock");
            DropColumn("dbo.Stocks", "OutStock");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Stocks", "OutStock", c => c.Double(nullable: false));
            AddColumn("dbo.Stocks", "InStock", c => c.Double(nullable: false));
            AddColumn("dbo.Stocks", "OpeningBalance", c => c.Double(nullable: false));
            AddColumn("dbo.Stocks", "ProductName", c => c.Long(nullable: false));
            AddColumn("dbo.PurchaseDetails", "NewMRP", c => c.Double(nullable: false));
            AddColumn("dbo.PurchaseDetails", "NewCostPrice", c => c.Double(nullable: false));
            AddColumn("dbo.PurchaseDetails", "PreviousMRP", c => c.Double(nullable: false));
            AddColumn("dbo.PurchaseDetails", "PreviousCostPrice", c => c.Double(nullable: false));
            AddColumn("dbo.PurchaseDetails", "TotalPrice", c => c.Double(nullable: false));
            AddColumn("dbo.PurchaseDetails", "PurchaseQuantity", c => c.Double(nullable: false));
            DropForeignKey("dbo.PurchaseDetails", "PurchaseId", "dbo.Purchases");
            DropForeignKey("dbo.Stocks", "ProductId", "dbo.Products");
            DropIndex("dbo.Stocks", new[] { "ProductId" });
            DropIndex("dbo.PurchaseDetails", new[] { "PurchaseId" });
            AlterColumn("dbo.PurchaseDetails", "PurchaseId", c => c.Long());
            DropColumn("dbo.Stocks", "Qty");
            DropColumn("dbo.Stocks", "ProductId");
            DropColumn("dbo.Purchases", "PurchaseDate");
            DropColumn("dbo.PurchaseDetails", "MrP");
            DropColumn("dbo.PurchaseDetails", "Qty");
            RenameIndex(table: "dbo.Purchases", name: "IX_SupplierId", newName: "IX_SuplierId");
            RenameColumn(table: "dbo.Purchases", name: "SupplierId", newName: "SuplierId");
            RenameColumn(table: "dbo.PurchaseDetails", name: "PurchaseId", newName: "Purchase_Id");
            CreateIndex("dbo.PurchaseDetails", "Purchase_Id");
            AddForeignKey("dbo.PurchaseDetails", "Purchase_Id", "dbo.Purchases", "Id");
            RenameTable(name: "dbo.Suppliers", newName: "Supliers");
        }
    }
}
