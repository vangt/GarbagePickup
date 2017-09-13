namespace GarbagePickup.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addedweekdayleaveandreturntouser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Week", c => c.String());
            AddColumn("dbo.AspNetUsers", "Day", c => c.String());
            AddColumn("dbo.AspNetUsers", "LeavingDate", c => c.String());
            AddColumn("dbo.AspNetUsers", "ReturningDate", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "ReturningDate");
            DropColumn("dbo.AspNetUsers", "LeavingDate");
            DropColumn("dbo.AspNetUsers", "Day");
            DropColumn("dbo.AspNetUsers", "Week");
        }
    }
}
