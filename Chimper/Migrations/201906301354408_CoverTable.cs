namespace Chimper.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CoverTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Covers",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Photo = c.String(),
                        Page = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Covers");
        }
    }
}
