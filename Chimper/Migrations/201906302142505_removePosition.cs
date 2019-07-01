namespace Chimper.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removePosition : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TeamPositions", "Team_id", "dbo.Teams");
            DropForeignKey("dbo.TeamPositions", "Position_id", "dbo.Positions");
            DropIndex("dbo.TeamPositions", new[] { "Team_id" });
            DropIndex("dbo.TeamPositions", new[] { "Position_id" });
            DropTable("dbo.Positions");
            DropTable("dbo.TeamPositions");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.TeamPositions",
                c => new
                    {
                        Team_id = c.Int(nullable: false),
                        Position_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Team_id, t.Position_id });
            
            CreateTable(
                "dbo.Positions",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateIndex("dbo.TeamPositions", "Position_id");
            CreateIndex("dbo.TeamPositions", "Team_id");
            AddForeignKey("dbo.TeamPositions", "Position_id", "dbo.Positions", "id", cascadeDelete: true);
            AddForeignKey("dbo.TeamPositions", "Team_id", "dbo.Teams", "id", cascadeDelete: true);
        }
    }
}
