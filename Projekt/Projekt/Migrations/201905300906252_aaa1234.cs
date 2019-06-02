namespace Projekt.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class aaa1234 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Items", "productScore");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Items", "productScore", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
