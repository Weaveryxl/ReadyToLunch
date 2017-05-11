namespace ReadyToLunch.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addNumberAndTotal : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "number", c => c.Int(nullable: false));
            AddColumn("dbo.Orders", "TotalPrice", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "TotalPrice");
            DropColumn("dbo.Orders", "number");
        }
    }
}
