namespace CITBT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterMovieCancellation : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UserMovieCancellationRequests", "ProcessedUserId", "dbo.Admins");
            DropIndex("dbo.UserMovieCancellationRequests", new[] { "ProcessedUserId" });
            AlterColumn("dbo.UserMovieCancellationRequests", "ProcessedUserId", c => c.Guid());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.UserMovieCancellationRequests", "ProcessedUserId", c => c.Guid(nullable: false));
            CreateIndex("dbo.UserMovieCancellationRequests", "ProcessedUserId");
            AddForeignKey("dbo.UserMovieCancellationRequests", "ProcessedUserId", "dbo.Admins", "AdminId");
        }
    }
}
