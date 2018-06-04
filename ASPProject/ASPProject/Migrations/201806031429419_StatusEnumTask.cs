namespace ASPProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StatusEnumTask : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Tasks", "Status", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Tasks", "Status", c => c.String());
        }
    }
}
