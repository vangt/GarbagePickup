namespace GarbagePickup.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addschedulelist : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ScheduleLists",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ScheduleLists");
        }
    }
}
