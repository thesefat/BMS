namespace BMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DateExcluded : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.PurchaseDetails", "ManufectureDate");
            DropColumn("dbo.PurchaseDetails", "ExpireDate");
            DropColumn("dbo.Purchases", "PurchaseDate");
            DropColumn("dbo.Stocks", "ExpiredDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Stocks", "ExpiredDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Purchases", "PurchaseDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.PurchaseDetails", "ExpireDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.PurchaseDetails", "ManufectureDate", c => c.DateTime(nullable: false));
        }
    }
}
