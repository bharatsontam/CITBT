namespace CITBT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterEventCancellation01 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.UserEventCancellationRequests", "ProcessedUserId", c => c.Guid(nullable: true));
            CreateIndex("dbo.UserEventCancellationRequests", "ProcessedUserId");
            AddForeignKey("dbo.UserEventCancellationRequests", "ProcessedUserId", "dbo.Admins", "AdminId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserEventCancellationRequests", "ProcessedUserId", "dbo.Admins");
            DropIndex("dbo.UserEventCancellationRequests", new[] { "ProcessedUserId" });
            AlterColumn("dbo.UserEventCancellationRequests", "ProcessedUserId", c => c.Guid());
        }
    }
}
