namespace Chimper.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveArticleAddSectionClm : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Services", "Type", c => c.String());
            DropTable("dbo.Articles");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Articles",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Header = c.String(nullable: false, maxLength: 60),
                        Text = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            DropColumn("dbo.Services", "Type");
        }
    }
}
