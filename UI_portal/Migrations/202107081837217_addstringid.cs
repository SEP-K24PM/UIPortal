namespace UI_portal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addstringid : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "accountId", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "accountId");
        }
    }
}
