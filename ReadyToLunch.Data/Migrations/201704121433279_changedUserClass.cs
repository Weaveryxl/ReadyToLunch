namespace ReadyToLunch.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedUserClass : DbMigration
    {
        public override void Up()
        {
            ////CreateTable(
            ////    "dbo.CartItems",
            ////    c => new
            ////        {
            ////            ID = c.Int(nullable: false, identity: true),
            ////            CustomerID = c.Int(nullable: false),
            ////            RestaurantID = c.Int(nullable: false),
            ////            DishID = c.Int(nullable: false),
            ////            DishAmount = c.Int(nullable: false),
            ////        })
            ////    .PrimaryKey(t => t.ID)
            ////    .ForeignKey("dbo.Customers", t => t.CustomerID, cascadeDelete: true)
            ////    .ForeignKey("dbo.Dishes", t => t.DishID, cascadeDelete: true)
            ////    .ForeignKey("dbo.Restaurants", t => t.RestaurantID, cascadeDelete: true)
            ////    .Index(t => t.CustomerID)
            ////    .Index(t => t.RestaurantID)
            ////    .Index(t => t.DishID);
            
            //CreateTable(
            //    "dbo.Customers",
            //    c => new
            //        {
            //            ID = c.Int(nullable: false, identity: true),
            //            Email = c.String(nullable: false, maxLength: 100),
            //            FirstName = c.String(nullable: false, maxLength: 50),
            //            LastName = c.String(nullable: false, maxLength: 50),
            //            UserName = c.String(nullable: false, maxLength: 50),
            //            Password = c.String(nullable: false, maxLength: 50),
            //            Address1 = c.String(nullable: false),
            //            Address2 = c.String(),
            //            Address3 = c.String(),
            //            State = c.String(nullable: false),
            //            RegisterDate = c.DateTime(nullable: false),
            //            Roles = c.String(nullable: false),
            //            isActived = c.Boolean(nullable: false),
            //            VIP = c.Int(nullable: false),
            //            FullAddress = c.String(),
            //            FullName = c.String(),
            //            Telephone = c.String(),
            //        })
            //    .PrimaryKey(t => t.ID);
            
            //CreateTable(
            //    "dbo.Orders",
            //    c => new
            //        {
            //            OrderID = c.Int(nullable: false, identity: true),
            //            CustomerID = c.Int(nullable: false),
            //            DishID = c.Int(nullable: false),
            //            OrderDate = c.DateTime(nullable: false),
            //            Restaurant_ID = c.Int(),
            //        })
            //    .PrimaryKey(t => t.OrderID)
            //    .ForeignKey("dbo.Customers", t => t.CustomerID, cascadeDelete: true)
            //    .ForeignKey("dbo.Restaurants", t => t.Restaurant_ID)
            //    .Index(t => t.CustomerID)
            //    .Index(t => t.Restaurant_ID);
            
            //CreateTable(
            //    "dbo.Dishes",
            //    c => new
            //        {
            //            DishID = c.Int(nullable: false, identity: true),
            //            DishName = c.String(),
            //            DishDisc = c.String(),
            //            Spicy = c.Int(nullable: false),
            //            isMuslim = c.Boolean(nullable: false),
            //            isGlutenFree = c.Boolean(nullable: false),
            //            CategoryID = c.Int(nullable: false),
            //            CartID = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => t.DishID)
            //    .ForeignKey("dbo.Categories", t => t.CategoryID, cascadeDelete: true)
            //    .Index(t => t.CategoryID);
            
            //CreateTable(
            //    "dbo.Categories",
            //    c => new
            //        {
            //            CategoryID = c.Int(nullable: false, identity: true),
            //            CategoryName = c.String(),
            //        })
            //    .PrimaryKey(t => t.CategoryID);
            
            //CreateTable(
            //    "dbo.Restaurants",
            //    c => new
            //        {
            //            ID = c.Int(nullable: false, identity: true),
            //            UserName = c.String(nullable: false, maxLength: 50),
            //            RestaurantDescrip = c.String(),
            //            CategoryID = c.Int(nullable: false),
            //            Stars = c.Double(nullable: false),
            //            Website = c.String(),
            //            Email = c.String(nullable: false, maxLength: 100),
            //            FirstName = c.String(nullable: false, maxLength: 50),
            //            LastName = c.String(nullable: false, maxLength: 50),
            //            Password = c.String(nullable: false, maxLength: 50),
            //            Address1 = c.String(nullable: false),
            //            Address2 = c.String(),
            //            Address3 = c.String(),
            //            State = c.String(nullable: false),
            //            RegisterDate = c.DateTime(nullable: false),
            //            Roles = c.String(nullable: false),
            //            isActived = c.Boolean(nullable: false),
            //            VIP = c.Int(nullable: false),
            //            FullAddress = c.String(),
            //            FullName = c.String(),
            //            Telephone = c.String(),
            //        })
            //    .PrimaryKey(t => t.ID)
            //    .ForeignKey("dbo.Categories", t => t.CategoryID, cascadeDelete: true)
            //    .Index(t => t.CategoryID);
            
            //CreateTable(
            //    "dbo.RestaurantDishes",
            //    c => new
            //        {
            //            Restaurant_ID = c.Int(nullable: false),
            //            Dish_DishID = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => new { t.Restaurant_ID, t.Dish_DishID })
            //    .ForeignKey("dbo.Restaurants", t => t.Restaurant_ID, cascadeDelete: true)
            //    .ForeignKey("dbo.Dishes", t => t.Dish_DishID, cascadeDelete: true)
            //    .Index(t => t.Restaurant_ID)
            //    .Index(t => t.Dish_DishID);
            
            //CreateTable(
            //    "dbo.OrderDishes",
            //    c => new
            //        {
            //            Order_OrderID = c.Int(nullable: false),
            //            Dish_DishID = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => new { t.Order_OrderID, t.Dish_DishID })
            //    .ForeignKey("dbo.Orders", t => t.Order_OrderID, cascadeDelete: true)
            //    .ForeignKey("dbo.Dishes", t => t.Dish_DishID, cascadeDelete: true)
            //    .Index(t => t.Order_OrderID)
            //    .Index(t => t.Dish_DishID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CartItems", "RestaurantID", "dbo.Restaurants");
            DropForeignKey("dbo.CartItems", "DishID", "dbo.Dishes");
            DropForeignKey("dbo.CartItems", "CustomerID", "dbo.Customers");
            DropForeignKey("dbo.OrderDishes", "Dish_DishID", "dbo.Dishes");
            DropForeignKey("dbo.OrderDishes", "Order_OrderID", "dbo.Orders");
            DropForeignKey("dbo.Dishes", "CategoryID", "dbo.Categories");
            DropForeignKey("dbo.Orders", "Restaurant_ID", "dbo.Restaurants");
            DropForeignKey("dbo.RestaurantDishes", "Dish_DishID", "dbo.Dishes");
            DropForeignKey("dbo.RestaurantDishes", "Restaurant_ID", "dbo.Restaurants");
            DropForeignKey("dbo.Restaurants", "CategoryID", "dbo.Categories");
            DropForeignKey("dbo.Orders", "CustomerID", "dbo.Customers");
            DropIndex("dbo.OrderDishes", new[] { "Dish_DishID" });
            DropIndex("dbo.OrderDishes", new[] { "Order_OrderID" });
            DropIndex("dbo.RestaurantDishes", new[] { "Dish_DishID" });
            DropIndex("dbo.RestaurantDishes", new[] { "Restaurant_ID" });
            DropIndex("dbo.Restaurants", new[] { "CategoryID" });
            DropIndex("dbo.Dishes", new[] { "CategoryID" });
            DropIndex("dbo.Orders", new[] { "Restaurant_ID" });
            DropIndex("dbo.Orders", new[] { "CustomerID" });
            DropIndex("dbo.CartItems", new[] { "DishID" });
            DropIndex("dbo.CartItems", new[] { "RestaurantID" });
            DropIndex("dbo.CartItems", new[] { "CustomerID" });
            DropTable("dbo.OrderDishes");
            DropTable("dbo.RestaurantDishes");
            DropTable("dbo.Restaurants");
            DropTable("dbo.Categories");
            DropTable("dbo.Dishes");
            DropTable("dbo.Orders");
            DropTable("dbo.Customers");
            DropTable("dbo.CartItems");
        }
    }
}
