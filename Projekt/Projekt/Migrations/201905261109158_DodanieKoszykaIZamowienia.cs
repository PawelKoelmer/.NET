namespace Projekt.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DodanieKoszykaIZamowienia : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "orderValue", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "orderValue");
        }
    }
}
