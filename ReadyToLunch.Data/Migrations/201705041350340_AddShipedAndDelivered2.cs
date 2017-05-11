namespace ReadyToLunch.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddShipedAndDelivered2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "Shipped", c => c.Boolean(nullable: false));
            DropColumn("dbo.Orders", "Shiped");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "Shiped", c => c.Boolean(nullable: false));
            DropColumn("dbo.Orders", "Shipped");
        }
    }
}
