namespace ReadyToLunch.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddShipedAndDelivered : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "Shiped", c => c.Boolean(nullable: false));
            AddColumn("dbo.Orders", "Delivered", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "Delivered");
            DropColumn("dbo.Orders", "Shiped");
        }
    }
}
