namespace Projekt.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1341242 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Items", "inStock");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Items", "inStock", c => c.Int(nullable: false));
        }
    }
}
