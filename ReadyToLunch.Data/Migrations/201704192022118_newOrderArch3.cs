namespace ReadyToLunch.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newOrderArch3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CartItemBases", "CartItemID", "dbo.CartItems");
            DropIndex("dbo.CartItemBases", new[] { "CartItemID" });
            DropColumn("dbo.CartItemBases", "CartItemID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CartItemBases", "CartItemID", c => c.Int(nullable: false));
            CreateIndex("dbo.CartItemBases", "CartItemID");
            AddForeignKey("dbo.CartItemBases", "CartItemID", "dbo.CartItems", "ID", cascadeDelete: true);
        }
    }
}
