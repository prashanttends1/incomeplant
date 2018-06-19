namespace mlmStudio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class second : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.User", "ProductId", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.User", "ProductId");
        }
    }
}
