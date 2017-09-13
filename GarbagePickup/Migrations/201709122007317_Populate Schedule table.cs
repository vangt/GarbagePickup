namespace GarbagePickup.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateScheduletable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO ScheduleLists (Date) VALUES ('Weekly')");
            Sql("INSERT INTO ScheduleLists (Date) VALUES ('Bi-Weekly')");
            Sql("INSERT INTO ScheduleLists (Date) VALUES ('None')");
        }
        
        public override void Down()
        {
        }
    }
}
