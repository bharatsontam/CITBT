namespace CITBT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterEventCancellation : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UserEventCancellationRequests", "ProcessedUserId", "dbo.Admins");
            DropIndex("dbo.UserEventCancellationRequests", new[] { "ProcessedUserId" });
            AlterColumn("dbo.UserEventCancellationRequests", "ProcessedUserId", c => c.Guid());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.UserEventCancellationRequests", "ProcessedUserId", c => c.Guid(nullable: false));
            CreateIndex("dbo.UserEventCancellationRequests", "ProcessedUserId");
            AddForeignKey("dbo.UserEventCancellationRequests", "ProcessedUserId", "dbo.Admins", "AdminId", cascadeDelete: true);
        }
    }
}
