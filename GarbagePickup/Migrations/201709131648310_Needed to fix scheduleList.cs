namespace GarbagePickup.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NeededtofixscheduleList : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE dbo.ScheduleLists SEt Day='Monday' WHERE Id='3'");
            Sql("UPDATE dbo.ScheduleLists SEt Day='Tuesday' WHERE Id='4'");
            Sql("UPDATE dbo.ScheduleLists SEt Day='Wednesday' WHERE Id='5'");
            Sql("UPDATE dbo.ScheduleLists SEt Day='Thursday' WHERE Id='6'");
            Sql("UPDATE dbo.ScheduleLists SEt Day='Friday' WHERE Id='7'");
        }
        
        public override void Down()
        {
        }
    }
}
