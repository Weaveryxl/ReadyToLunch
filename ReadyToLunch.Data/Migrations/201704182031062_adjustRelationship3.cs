namespace ReadyToLunch.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adjustRelationship3 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Orders", "CartID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "CartID", c => c.Int(nullable: false));
        }
    }
}
