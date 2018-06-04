namespace ASPProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class oneToOneUserUserDetails : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Users", new[] { "UserDetails_Id" });
            RenameColumn(table: "dbo.Users", name: "UserDetails_Id", newName: "UserDetailsId");
            DropPrimaryKey("dbo.Users");
            AlterColumn("dbo.Users", "Email", c => c.String());
            AlterColumn("dbo.Users", "UserDetailsId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Users", "UserDetailsId");
            CreateIndex("dbo.Users", "UserDetailsId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Users", new[] { "UserDetailsId" });
            DropPrimaryKey("dbo.Users");
            AlterColumn("dbo.Users", "UserDetailsId", c => c.Int());
            AlterColumn("dbo.Users", "Email", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Users", "Email");
            RenameColumn(table: "dbo.Users", name: "UserDetailsId", newName: "UserDetails_Id");
            CreateIndex("dbo.Users", "UserDetails_Id");
        }
    }
}
