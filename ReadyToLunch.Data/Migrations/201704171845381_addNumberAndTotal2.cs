namespace ReadyToLunch.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addNumberAndTotal2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Orders", "TotalPrice", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Orders", "TotalPrice", c => c.Int(nullable: false));
        }
    }
}
