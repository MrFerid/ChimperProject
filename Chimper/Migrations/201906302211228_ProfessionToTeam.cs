namespace Chimper.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProfessionToTeam : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Teams", "Profession", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Teams", "Profession");
        }
    }
}
