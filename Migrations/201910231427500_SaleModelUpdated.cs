namespace BMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SaleModelUpdated : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SaleDetails", "Sale_Id", "dbo.Sales");
            DropIndex("dbo.SaleDetails", new[] { "Sale_Id" });
            RenameColumn(table: "dbo.SaleDetails", name: "Sale_Id", newName: "SaleId");
            AddColumn("dbo.Sales", "ProductId", c => c.Long(nullable: false));
            AddColumn("dbo.SaleDetails", "Qty", c => c.Double(nullable: false));
            AlterColumn("dbo.SaleDetails", "SaleId", c => c.Long(nullable: false));
            CreateIndex("dbo.SaleDetails", "SaleId");
            AddForeignKey("dbo.SaleDetails", "SaleId", "dbo.Sales", "Id", cascadeDelete: true);
            DropColumn("dbo.SaleDetails", "Name");
            DropColumn("dbo.SaleDetails", "Quantiy");
            DropColumn("dbo.SaleDetails", "LineTotal");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SaleDetails", "LineTotal", c => c.Double(nullable: false));
            AddColumn("dbo.SaleDetails", "Quantiy", c => c.Double(nullable: false));
            AddColumn("dbo.SaleDetails", "Name", c => c.String());
            DropForeignKey("dbo.SaleDetails", "SaleId", "dbo.Sales");
            DropIndex("dbo.SaleDetails", new[] { "SaleId" });
            AlterColumn("dbo.SaleDetails", "SaleId", c => c.Long());
            DropColumn("dbo.SaleDetails", "Qty");
            DropColumn("dbo.Sales", "ProductId");
            RenameColumn(table: "dbo.SaleDetails", name: "SaleId", newName: "Sale_Id");
            CreateIndex("dbo.SaleDetails", "Sale_Id");
            AddForeignKey("dbo.SaleDetails", "Sale_Id", "dbo.Sales", "Id");
        }
    }
}
