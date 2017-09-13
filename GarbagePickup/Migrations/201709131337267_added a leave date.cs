namespace GarbagePickup.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedaleavedate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ScheduleLists", "LeaveDate", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ScheduleLists", "LeaveDate");
        }
    }
}
