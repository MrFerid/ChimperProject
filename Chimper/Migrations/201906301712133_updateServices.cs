namespace Chimper.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateServices : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Services", "Type", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Services", "Type", c => c.String());
        }
    }
}
