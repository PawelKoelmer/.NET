namespace Projekt.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ItemCategories",
                c => new
                    {
                        ItemCategoryId = c.Int(nullable: false, identity: true),
                        ItemCategoryName = c.String(),
                        ItemCategoryDescription = c.String(),
                    })
                .PrimaryKey(t => t.ItemCategoryId);
            
            CreateTable(
                "dbo.Items",
                c => new
                    {
                        ItemId = c.Int(nullable: false, identity: true),
                        productName = c.String(),
                        productPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        inStock = c.Int(nullable: false),
                        productDescription = c.String(),
                        productScore = c.Decimal(nullable: false, precision: 18, scale: 2),
                        avaiablity = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ItemId);
            
            CreateTable(
                "dbo.OrderPostitions",
                c => new
                    {
                        OrderPostitionId = c.Int(nullable: false, identity: true),
                        OrderId = c.Int(nullable: false),
                        ItemId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        orderPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.OrderPostitionId)
                .ForeignKey("dbo.Items", t => t.ItemId, cascadeDelete: true)
                .ForeignKey("dbo.Orders", t => t.OrderId, cascadeDelete: true)
                .Index(t => t.OrderId)
                .Index(t => t.ItemId);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderId = c.Int(nullable: false, identity: true),
                        buyerName = c.String(),
                        buyerLastName = c.String(),
                        buyerEmail = c.String(),
                        city = c.String(),
                        street = c.String(),
                        homeFlatNumber = c.String(),
                        zipCode = c.String(),
                        telNumber = c.String(),
                        addTime = c.DateTime(nullable: false),
                        shipmentStatus = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OrderId);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        RoleId = c.Int(nullable: false, identity: true),
                        roleName = c.String(),
                    })
                .PrimaryKey(t => t.RoleId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderPostitions", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.OrderPostitions", "ItemId", "dbo.Items");
            DropIndex("dbo.OrderPostitions", new[] { "ItemId" });
            DropIndex("dbo.OrderPostitions", new[] { "OrderId" });
            DropTable("dbo.Roles");
            DropTable("dbo.Orders");
            DropTable("dbo.OrderPostitions");
            DropTable("dbo.Items");
            DropTable("dbo.ItemCategories");
        }
    }
}
