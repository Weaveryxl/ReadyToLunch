namespace ReadyToLunch.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newOrderArch : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.OrderCartItems", "Order_OrderID", "dbo.Orders");
            DropForeignKey("dbo.OrderCartItems", "CartItem_ID", "dbo.CartItems");
            DropIndex("dbo.OrderCartItems", new[] { "Order_OrderID" });
            DropIndex("dbo.OrderCartItems", new[] { "CartItem_ID" });
            CreateTable(
                "dbo.CartItemBases",
                c => new
                    {
                        CartItemBaseID = c.Int(nullable: false, identity: true),
                        CustomerID = c.Int(nullable: false),
                        RestaurantID = c.Int(nullable: false),
                        DishID = c.Int(nullable: false),
                        CartItemID = c.Int(nullable: false),
                        DishAmount = c.Int(nullable: false),
                        TotalPrice = c.Double(nullable: false),
                        Order_OrderID = c.Int(),
                    })
                .PrimaryKey(t => t.CartItemBaseID)
                .ForeignKey("dbo.CartItems", t => t.CartItemID, cascadeDelete: false)
                .ForeignKey("dbo.Customers", t => t.CustomerID, cascadeDelete: false)
                .ForeignKey("dbo.Dishes", t => t.DishID, cascadeDelete: false   )
                .ForeignKey("dbo.Orders", t => t.Order_OrderID)
                .ForeignKey("dbo.Restaurants", t => t.RestaurantID, cascadeDelete: false)
                .Index(t => t.CustomerID)
                .Index(t => t.RestaurantID)
                .Index(t => t.DishID)
                .Index(t => t.CartItemID)
                .Index(t => t.Order_OrderID);
            
            DropTable("dbo.OrderCartItems");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.OrderCartItems",
                c => new
                    {
                        Order_OrderID = c.Int(nullable: false),
                        CartItem_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Order_OrderID, t.CartItem_ID });
            
            DropForeignKey("dbo.CartItemBases", "RestaurantID", "dbo.Restaurants");
            DropForeignKey("dbo.CartItemBases", "Order_OrderID", "dbo.Orders");
            DropForeignKey("dbo.CartItemBases", "DishID", "dbo.Dishes");
            DropForeignKey("dbo.CartItemBases", "CustomerID", "dbo.Customers");
            DropForeignKey("dbo.CartItemBases", "CartItemID", "dbo.CartItems");
            DropIndex("dbo.CartItemBases", new[] { "Order_OrderID" });
            DropIndex("dbo.CartItemBases", new[] { "CartItemID" });
            DropIndex("dbo.CartItemBases", new[] { "DishID" });
            DropIndex("dbo.CartItemBases", new[] { "RestaurantID" });
            DropIndex("dbo.CartItemBases", new[] { "CustomerID" });
            DropTable("dbo.CartItemBases");
            CreateIndex("dbo.OrderCartItems", "CartItem_ID");
            CreateIndex("dbo.OrderCartItems", "Order_OrderID");
            AddForeignKey("dbo.OrderCartItems", "CartItem_ID", "dbo.CartItems", "ID", cascadeDelete: true);
            AddForeignKey("dbo.OrderCartItems", "Order_OrderID", "dbo.Orders", "OrderID", cascadeDelete: true);
        }
    }
}
