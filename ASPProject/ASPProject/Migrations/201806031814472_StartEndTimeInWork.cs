namespace ASPProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StartEndTimeInWork : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Works", "StartHour", c => c.Time(precision: 7));
            AddColumn("dbo.Works", "EndHour", c => c.Time(precision: 7));
            AlterColumn("dbo.Works", "Date", c => c.DateTime());
            DropColumn("dbo.Works", "CurrentTime");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Works", "CurrentTime", c => c.Double(nullable: false));
            AlterColumn("dbo.Works", "Date", c => c.DateTime(nullable: false));
            DropColumn("dbo.Works", "EndHour");
            DropColumn("dbo.Works", "StartHour");
        }
    }
}
