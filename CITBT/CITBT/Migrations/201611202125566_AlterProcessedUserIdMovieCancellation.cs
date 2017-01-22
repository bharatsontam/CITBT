namespace CITBT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterProcessedUserIdMovieCancellation : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UserEventCancellationRequests", "ProcessedUserId", "dbo.Admins");
            DropForeignKey("dbo.UserMovieCancellationRequests", "ProcessedUserId", "dbo.Admins");
            DropIndex("dbo.UserEventCancellationRequests", new[] { "ProcessedUserId" });
            DropIndex("dbo.UserMovieCancellationRequests", new[] { "ProcessedUserId" });
            AlterColumn("dbo.UserEventCancellationRequests", "ProcessedUserId", c => c.Guid());
            AlterColumn("dbo.UserMovieCancellationRequests", "ProcessedUserId", c => c.Guid());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.UserMovieCancellationRequests", "ProcessedUserId", c => c.Guid(nullable: false));
            AlterColumn("dbo.UserEventCancellationRequests", "ProcessedUserId", c => c.Guid(nullable: false));
            CreateIndex("dbo.UserMovieCancellationRequests", "ProcessedUserId");
            CreateIndex("dbo.UserEventCancellationRequests", "ProcessedUserId");
            AddForeignKey("dbo.UserMovieCancellationRequests", "ProcessedUserId", "dbo.Admins", "AdminId");
            AddForeignKey("dbo.UserEventCancellationRequests", "ProcessedUserId", "dbo.Admins", "AdminId", cascadeDelete: true);
        }
    }
}
