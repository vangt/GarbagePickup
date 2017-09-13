namespace GarbagePickup.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deletedweekleaveandreturnMadethemseperatetables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SpecialDates",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LeaveDate = c.DateTime(nullable: false),
                        ReturnDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Weeks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Weeks = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.AspNetUsers", "Weeks", c => c.Int(nullable: false));
            AddColumn("dbo.AspNetUsers", "SpecialDate_Id", c => c.Int());
            AddColumn("dbo.AspNetUsers", "Week_Id", c => c.Int());
            AlterColumn("dbo.AspNetUsers", "LeavingDate", c => c.String());
            AlterColumn("dbo.AspNetUsers", "ReturningDate", c => c.String());
            CreateIndex("dbo.AspNetUsers", "SpecialDate_Id");
            CreateIndex("dbo.AspNetUsers", "Week_Id");
            AddForeignKey("dbo.AspNetUsers", "SpecialDate_Id", "dbo.SpecialDates", "Id");
            AddForeignKey("dbo.AspNetUsers", "Week_Id", "dbo.Weeks", "Id");
            DropColumn("dbo.ScheduleLists", "Week");
            DropColumn("dbo.ScheduleLists", "LeaveDate");
            DropColumn("dbo.ScheduleLists", "ReturnDate");
            DropColumn("dbo.AspNetUsers", "Week");
        }

        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "Week", c => c.String());
            AddColumn("dbo.ScheduleLists", "ReturnDate", c => c.String());
            AddColumn("dbo.ScheduleLists", "LeaveDate", c => c.String());
            AddColumn("dbo.ScheduleLists", "Week", c => c.String());
            DropForeignKey("dbo.AspNetUsers", "Week_Id", "dbo.Weeks");
            DropForeignKey("dbo.AspNetUsers", "SpecialDate_Id", "dbo.SpecialDates");
            DropIndex("dbo.AspNetUsers", new[] { "Week_Id" });
            DropIndex("dbo.AspNetUsers", new[] { "SpecialDate_Id" });
            AlterColumn("dbo.AspNetUsers", "ReturningDate", c => c.String());
            AlterColumn("dbo.AspNetUsers", "LeavingDate", c => c.String());
            DropColumn("dbo.AspNetUsers", "Week_Id");
            DropColumn("dbo.AspNetUsers", "SpecialDate_Id");
            DropColumn("dbo.AspNetUsers", "Weeks");
            DropTable("dbo.Weeks");
            DropTable("dbo.SpecialDates");
        }
    }
}
