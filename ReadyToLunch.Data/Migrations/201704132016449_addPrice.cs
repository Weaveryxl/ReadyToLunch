namespace ReadyToLunch.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addPrice : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CartItems", "TotalPrice", c => c.Double(nullable: false));
            AddColumn("dbo.Dishes", "Price", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Dishes", "Price");
            DropColumn("dbo.CartItems", "TotalPrice");
        }
    }
}
