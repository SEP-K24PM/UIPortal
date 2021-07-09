namespace UI_portal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addblock : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "block", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "block");
        }
    }
}
