namespace GarbagePickup.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedApplicationUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "ScheduleId", c => c.Int(nullable: false));
            AddColumn("dbo.AspNetUsers", "scheduleList_Id", c => c.Int());
            CreateIndex("dbo.AspNetUsers", "scheduleList_Id");
            AddForeignKey("dbo.AspNetUsers", "scheduleList_Id", "dbo.ScheduleLists", "Id");
            DropColumn("dbo.AspNetUsers", "Schedule");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "Schedule", c => c.String());
            DropForeignKey("dbo.AspNetUsers", "scheduleList_Id", "dbo.ScheduleLists");
            DropIndex("dbo.AspNetUsers", new[] { "scheduleList_Id" });
            DropColumn("dbo.AspNetUsers", "scheduleList_Id");
            DropColumn("dbo.AspNetUsers", "ScheduleId");
        }
    }
}
