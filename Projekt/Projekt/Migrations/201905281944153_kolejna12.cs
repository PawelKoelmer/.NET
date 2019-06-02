namespace Projekt.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class kolejna12 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Items", "addTime", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Items", "addTime");
        }
    }
}
