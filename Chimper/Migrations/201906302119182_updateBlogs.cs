namespace Chimper.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateBlogs : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Blogs", "ShareDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Blogs", "ShareDate");
        }
    }
}
