namespace CITBT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterEvenRequesttColumn : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.EventRequests", "ProcessedUserId", "dbo.Admins");
            DropIndex("dbo.EventRequests", new[] { "ProcessedUserId" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.EventRequests", "ProcessedUserId");
            AddForeignKey("dbo.EventRequests", "ProcessedUserId", "dbo.Admins", "AdminId", cascadeDelete: true);
        }
    }
}
