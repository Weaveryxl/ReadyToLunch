namespace ReadyToLunch.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adjustedRelationship : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.RestaurantDishes", newName: "DishRestaurants");
            DropForeignKey("dbo.OrderDishes", "Order_OrderID", "dbo.Orders");
            DropForeignKey("dbo.OrderDishes", "Dish_DishID", "dbo.Dishes");
            DropIndex("dbo.OrderDishes", new[] { "Order_OrderID" });
            DropIndex("dbo.OrderDishes", new[] { "Dish_DishID" });
            DropPrimaryKey("dbo.DishRestaurants");
            AddPrimaryKey("dbo.DishRestaurants", new[] { "Dish_DishID", "Restaurant_ID" });
            DropColumn("dbo.Orders", "DishID");
            //DropTable("dbo.OrderDishes");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.OrderDishes",
                c => new
                    {
                        Order_OrderID = c.Int(nullable: false),
                        Dish_DishID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Order_OrderID, t.Dish_DishID });
            
            AddColumn("dbo.Orders", "DishID", c => c.Int(nullable: false));
            DropPrimaryKey("dbo.DishRestaurants");
            AddPrimaryKey("dbo.DishRestaurants", new[] { "Restaurant_ID", "Dish_DishID" });
            CreateIndex("dbo.OrderDishes", "Dish_DishID");
            CreateIndex("dbo.OrderDishes", "Order_OrderID");
            AddForeignKey("dbo.OrderDishes", "Dish_DishID", "dbo.Dishes", "DishID", cascadeDelete: true);
            AddForeignKey("dbo.OrderDishes", "Order_OrderID", "dbo.Orders", "OrderID", cascadeDelete: true);
            RenameTable(name: "dbo.DishRestaurants", newName: "RestaurantDishes");
        }
    }
}
