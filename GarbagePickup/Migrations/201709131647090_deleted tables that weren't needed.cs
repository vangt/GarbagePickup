namespace GarbagePickup.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deletedtablesthatwerentneeded : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AspNetUsers", "SpecialDate_Id", "dbo.SpecialDates");
            DropForeignKey("dbo.AspNetUsers", "Week_Id", "dbo.Weeks");
            DropIndex("dbo.AspNetUsers", new[] { "SpecialDate_Id" });
            DropIndex("dbo.AspNetUsers", new[] { "Week_Id" });
            AddColumn("dbo.ScheduleLists", "Day", c => c.String());
            DropColumn("dbo.ScheduleLists", "Date");
            DropColumn("dbo.AspNetUsers", "SpecialDate_Id");
            DropColumn("dbo.AspNetUsers", "Week_Id");
            DropTable("dbo.SpecialDates");
            DropTable("dbo.Weeks");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Weeks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Weeks = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SpecialDates",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LeaveDate = c.String(),
                        ReturnDate = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.AspNetUsers", "Week_Id", c => c.Int());
            AddColumn("dbo.AspNetUsers", "SpecialDate_Id", c => c.Int());
            AddColumn("dbo.ScheduleLists", "Date", c => c.String());
            DropColumn("dbo.ScheduleLists", "Day");
            CreateIndex("dbo.AspNetUsers", "Week_Id");
            CreateIndex("dbo.AspNetUsers", "SpecialDate_Id");
            AddForeignKey("dbo.AspNetUsers", "Week_Id", "dbo.Weeks", "Id");
            AddForeignKey("dbo.AspNetUsers", "SpecialDate_Id", "dbo.SpecialDates", "Id");
        }
    }
}
