namespace ASPProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class codefirst : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tasks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Time = c.Double(nullable: false),
                        Status = c.String(),
                        ExpectedTime = c.Double(nullable: false),
                        UserId = c.Int(nullable: false),
                        Team_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserDetails", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.Teams", t => t.Team_Id)
                .Index(t => t.UserId)
                .Index(t => t.Team_Id);
            
            CreateTable(
                "dbo.UserDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Team_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Teams", t => t.Team_Id)
                .Index(t => t.Team_Id);
            
            CreateTable(
                "dbo.Teams",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Director_Id = c.Int(),
                        TeamLeader_Id = c.Int(),
                        UserDetails_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserDetails", t => t.Director_Id)
                .ForeignKey("dbo.UserDetails", t => t.TeamLeader_Id)
                .ForeignKey("dbo.UserDetails", t => t.UserDetails_Id)
                .Index(t => t.Director_Id)
                .Index(t => t.TeamLeader_Id)
                .Index(t => t.UserDetails_Id);
            
            CreateTable(
                "dbo.Works",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        CurrentTime = c.Double(nullable: false),
                        Task_Id = c.Int(),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tasks", t => t.Task_Id)
                .ForeignKey("dbo.UserDetails", t => t.User_Id)
                .Index(t => t.Task_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Email = c.String(nullable: false, maxLength: 128),
                        Roles = c.String(),
                        Password = c.String(),
                        UserDetails_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Email)
                .ForeignKey("dbo.UserDetails", t => t.UserDetails_Id)
                .Index(t => t.UserDetails_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "UserDetails_Id", "dbo.UserDetails");
            DropForeignKey("dbo.Works", "User_Id", "dbo.UserDetails");
            DropForeignKey("dbo.Works", "Task_Id", "dbo.Tasks");
            DropForeignKey("dbo.Teams", "UserDetails_Id", "dbo.UserDetails");
            DropForeignKey("dbo.Teams", "TeamLeader_Id", "dbo.UserDetails");
            DropForeignKey("dbo.Tasks", "Team_Id", "dbo.Teams");
            DropForeignKey("dbo.UserDetails", "Team_Id", "dbo.Teams");
            DropForeignKey("dbo.Teams", "Director_Id", "dbo.UserDetails");
            DropForeignKey("dbo.Tasks", "UserId", "dbo.UserDetails");
            DropIndex("dbo.Users", new[] { "UserDetails_Id" });
            DropIndex("dbo.Works", new[] { "User_Id" });
            DropIndex("dbo.Works", new[] { "Task_Id" });
            DropIndex("dbo.Teams", new[] { "UserDetails_Id" });
            DropIndex("dbo.Teams", new[] { "TeamLeader_Id" });
            DropIndex("dbo.Teams", new[] { "Director_Id" });
            DropIndex("dbo.UserDetails", new[] { "Team_Id" });
            DropIndex("dbo.Tasks", new[] { "Team_Id" });
            DropIndex("dbo.Tasks", new[] { "UserId" });
            DropTable("dbo.Users");
            DropTable("dbo.Works");
            DropTable("dbo.Teams");
            DropTable("dbo.UserDetails");
            DropTable("dbo.Tasks");
        }
    }
}
