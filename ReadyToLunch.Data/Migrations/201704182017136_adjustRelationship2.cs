namespace ReadyToLunch.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adjustRelationship2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CartItems", "Order_OrderID", "dbo.Orders");
            DropIndex("dbo.CartItems", new[] { "Order_OrderID" });
            CreateTable(
                "dbo.OrderCartItems",
                c => new
                    {
                        Order_OrderID = c.Int(nullable: false),
                        CartItem_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Order_OrderID, t.CartItem_ID })
                .ForeignKey("dbo.Orders", t => t.Order_OrderID, cascadeDelete: false)
                .ForeignKey("dbo.CartItems", t => t.CartItem_ID, cascadeDelete: true)
                .Index(t => t.Order_OrderID)
                .Index(t => t.CartItem_ID);
            
            DropColumn("dbo.CartItems", "Order_OrderID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CartItems", "Order_OrderID", c => c.Int());
            DropForeignKey("dbo.OrderCartItems", "CartItem_ID", "dbo.CartItems");
            DropForeignKey("dbo.OrderCartItems", "Order_OrderID", "dbo.Orders");
            DropIndex("dbo.OrderCartItems", new[] { "CartItem_ID" });
            DropIndex("dbo.OrderCartItems", new[] { "Order_OrderID" });
            DropTable("dbo.OrderCartItems");
            CreateIndex("dbo.CartItems", "Order_OrderID");
            AddForeignKey("dbo.CartItems", "Order_OrderID", "dbo.Orders", "OrderID");
        }
    }
}
