namespace CITBT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterMovieCancellation01 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.UserMovieCancellationRequests", "ProcessedUserId", c => c.Guid(nullable: true));
            CreateIndex("dbo.UserMovieCancellationRequests", "ProcessedUserId");
            AddForeignKey("dbo.UserMovieCancellationRequests", "ProcessedUserId", "dbo.Admins", "AdminId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserMovieCancellationRequests", "ProcessedUserId", "dbo.Admins");
            DropIndex("dbo.UserMovieCancellationRequests", new[] { "ProcessedUserId" });
            AlterColumn("dbo.UserMovieCancellationRequests", "ProcessedUserId", c => c.Guid());
        }
    }
}
