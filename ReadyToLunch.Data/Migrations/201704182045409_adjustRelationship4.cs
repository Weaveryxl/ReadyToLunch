namespace ReadyToLunch.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adjustRelationship4 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.DishRestaurants", newName: "RestaurantDishes");
            DropForeignKey("dbo.Orders", "CustomerID", "dbo.Customers");
            DropIndex("dbo.Orders", new[] { "CustomerID" });
            RenameColumn(table: "dbo.Orders", name: "CustomerID", newName: "Customer_ID");
            DropPrimaryKey("dbo.RestaurantDishes");
            AlterColumn("dbo.Orders", "Customer_ID", c => c.Int());
            AddPrimaryKey("dbo.RestaurantDishes", new[] { "Restaurant_ID", "Dish_DishID" });
            CreateIndex("dbo.Orders", "Customer_ID");
            AddForeignKey("dbo.Orders", "Customer_ID", "dbo.Customers", "ID");
            DropColumn("dbo.Orders", "number");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "number", c => c.Int(nullable: false));
            DropForeignKey("dbo.Orders", "Customer_ID", "dbo.Customers");
            DropIndex("dbo.Orders", new[] { "Customer_ID" });
            DropPrimaryKey("dbo.RestaurantDishes");
            AlterColumn("dbo.Orders", "Customer_ID", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.RestaurantDishes", new[] { "Dish_DishID", "Restaurant_ID" });
            RenameColumn(table: "dbo.Orders", name: "Customer_ID", newName: "CustomerID");
            CreateIndex("dbo.Orders", "CustomerID");
            AddForeignKey("dbo.Orders", "CustomerID", "dbo.Customers", "ID", cascadeDelete: true);
            RenameTable(name: "dbo.RestaurantDishes", newName: "DishRestaurants");
        }
    }
}
