namespace ReadyToLunch.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newOrderArch2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CartItemBases", "Order_OrderID", "dbo.Orders");
            DropIndex("dbo.CartItemBases", new[] { "Order_OrderID" });
            RenameColumn(table: "dbo.CartItemBases", name: "Order_OrderID", newName: "OrderID");
            AlterColumn("dbo.CartItemBases", "OrderID", c => c.Int(nullable: false));
            CreateIndex("dbo.CartItemBases", "OrderID");
            AddForeignKey("dbo.CartItemBases", "OrderID", "dbo.Orders", "OrderID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CartItemBases", "OrderID", "dbo.Orders");
            DropIndex("dbo.CartItemBases", new[] { "OrderID" });
            AlterColumn("dbo.CartItemBases", "OrderID", c => c.Int());
            RenameColumn(table: "dbo.CartItemBases", name: "OrderID", newName: "Order_OrderID");
            CreateIndex("dbo.CartItemBases", "Order_OrderID");
            AddForeignKey("dbo.CartItemBases", "Order_OrderID", "dbo.Orders", "OrderID");
        }
    }
}
