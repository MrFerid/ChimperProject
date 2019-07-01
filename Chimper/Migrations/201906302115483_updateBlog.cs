namespace Chimper.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateBlog : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Blogs", "ShareDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Blogs", "ShareDate", c => c.DateTime(nullable: false));
        }
    }
}
