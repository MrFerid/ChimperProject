namespace Chimper.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateService : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Services", "icon", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Services", "icon", c => c.String(nullable: false));
        }
    }
}
