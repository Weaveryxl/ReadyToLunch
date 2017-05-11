namespace ReadyToLunch.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addCustomerToOrder : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Orders", "Customer_ID", "dbo.Customers");
            DropIndex("dbo.Orders", new[] { "Customer_ID" });
            RenameColumn(table: "dbo.Orders", name: "Customer_ID", newName: "CustomerID");
            AlterColumn("dbo.Orders", "CustomerID", c => c.Int(nullable: false));
            CreateIndex("dbo.Orders", "CustomerID");
            AddForeignKey("dbo.Orders", "CustomerID", "dbo.Customers", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "CustomerID", "dbo.Customers");
            DropIndex("dbo.Orders", new[] { "CustomerID" });
            AlterColumn("dbo.Orders", "CustomerID", c => c.Int());
            RenameColumn(table: "dbo.Orders", name: "CustomerID", newName: "Customer_ID");
            CreateIndex("dbo.Orders", "Customer_ID");
            AddForeignKey("dbo.Orders", "Customer_ID", "dbo.Customers", "ID");
        }
    }
}
