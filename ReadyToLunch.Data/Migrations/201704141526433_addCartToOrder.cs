namespace ReadyToLunch.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addCartToOrder : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CartItems", "Order_OrderID", c => c.Int());
            AddColumn("dbo.Orders", "CartID", c => c.Int(nullable: false));
            CreateIndex("dbo.CartItems", "Order_OrderID");
            AddForeignKey("dbo.CartItems", "Order_OrderID", "dbo.Orders", "OrderID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CartItems", "Order_OrderID", "dbo.Orders");
            DropIndex("dbo.CartItems", new[] { "Order_OrderID" });
            DropColumn("dbo.Orders", "CartID");
            DropColumn("dbo.CartItems", "Order_OrderID");
        }
    }
}
