namespace GarbagePickup.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addedaschedulechangepage : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Schedule", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Schedule");
        }
    }
}
