namespace GarbagePickup.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Customercannowchoosedaysandeditprofile : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "TempZip", c => c.String());
            AddColumn("dbo.AspNetUsers", "applicationUsers_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.AspNetUsers", "applicationUsers_Id");
            AddForeignKey("dbo.AspNetUsers", "applicationUsers_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "applicationUsers_Id", "dbo.AspNetUsers");
            DropIndex("dbo.AspNetUsers", new[] { "applicationUsers_Id" });
            DropColumn("dbo.AspNetUsers", "applicationUsers_Id");
            DropColumn("dbo.AspNetUsers", "TempZip");
        }
    }
}
