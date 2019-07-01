namespace Chimper.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateDatabase : DbMigration
    {
        public override void Up()
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
            
            CreateTable(
                "dbo.Blogs",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false, maxLength: 60),
                        UserSurname = c.String(nullable: false, maxLength: 60),
                        Header = c.String(nullable: false, maxLength: 60),
                        Text = c.String(nullable: false),
                        Photo = c.String(),
                        ShareDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Companies",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        Email = c.String(nullable: false, maxLength: 60),
                        Phone = c.String(),
                        Address = c.String(nullable: false),
                        About = c.String(nullable: false),
                        Photo = c.String(),
                        Facebook = c.String(),
                        Twitter = c.String(),
                        Instagram = c.String(),
                        Linkedin = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Messages",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 60),
                        LastName = c.String(nullable: false, maxLength: 60),
                        Email = c.String(nullable: false),
                        Subject = c.String(nullable: false, maxLength: 100),
                        Text = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Portfolios",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Header = c.String(nullable: false, maxLength: 60),
                        Description = c.String(nullable: false),
                        Photo = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Positions",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Teams",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 60),
                        Surname = c.String(nullable: false, maxLength: 60),
                        Photo = c.String(),
                        About = c.String(),
                        Facebook = c.String(),
                        Twitter = c.String(),
                        Linkedin = c.String(),
                        Instagram = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Services",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Header = c.String(nullable: false, maxLength: 60),
                        Text = c.String(nullable: false),
                        icon = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Specialties",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Header = c.String(nullable: false, maxLength: 60),
                        Text = c.String(nullable: false),
                        Icon = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Testimonials",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 60),
                        Surname = c.String(nullable: false, maxLength: 60),
                        Photo = c.String(),
                        Text = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.TeamPositions",
                c => new
                    {
                        Team_id = c.Int(nullable: false),
                        Position_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Team_id, t.Position_id })
                .ForeignKey("dbo.Teams", t => t.Team_id, cascadeDelete: true)
                .ForeignKey("dbo.Positions", t => t.Position_id, cascadeDelete: true)
                .Index(t => t.Team_id)
                .Index(t => t.Position_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TeamPositions", "Position_id", "dbo.Positions");
            DropForeignKey("dbo.TeamPositions", "Team_id", "dbo.Teams");
            DropIndex("dbo.TeamPositions", new[] { "Position_id" });
            DropIndex("dbo.TeamPositions", new[] { "Team_id" });
            DropTable("dbo.TeamPositions");
            DropTable("dbo.Testimonials");
            DropTable("dbo.Specialties");
            DropTable("dbo.Services");
            DropTable("dbo.Teams");
            DropTable("dbo.Positions");
            DropTable("dbo.Portfolios");
            DropTable("dbo.Messages");
            DropTable("dbo.Companies");
            DropTable("dbo.Blogs");
            DropTable("dbo.Articles");
        }
    }
}
