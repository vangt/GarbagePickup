namespace GarbagePickup.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedtheschedulelistwithnewcolumns : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ScheduleLists", "Week", c => c.String());
            AddColumn("dbo.ScheduleLists", "ReturnDate", c => c.String());
            Sql("INSERT INTO dbo.ScheduleLists (Week) VALUES ('Only this week')");
            Sql("INSERT INTO dbo.ScheduleLists (Week) VALUES ('Every week')");
        }
        
        public override void Down()
        {
            DropColumn("dbo.ScheduleLists", "ReturnDate");
            DropColumn("dbo.ScheduleLists", "Week");
        }
    }
}
