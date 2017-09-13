namespace GarbagePickup.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deletenulldata : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AspNetUsers", "LeavingDate", c => c.String());
            AlterColumn("dbo.AspNetUsers", "ReturningDate", c => c.String());
            AlterColumn("dbo.SpecialDates", "LeaveDate", c => c.String());
            AlterColumn("dbo.SpecialDates", "ReturnDate", c => c.String());        
        }
        
        public override void Down()
        {
            AlterColumn("dbo.SpecialDates", "ReturnDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.SpecialDates", "LeaveDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.AspNetUsers", "ReturningDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.AspNetUsers", "LeavingDate", c => c.DateTime(nullable: false));
        }
    }
}
