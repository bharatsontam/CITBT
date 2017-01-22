namespace CITBT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterProcessedUserId : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UserMovieCancellationRequests", "ProcessedUserId", "dbo.Admins");
            AddForeignKey("dbo.UserMovieCancellationRequests", "ProcessedUserId", "dbo.Admins", "AdminId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserMovieCancellationRequests", "ProcessedUserId", "dbo.Admins");
            AddForeignKey("dbo.UserMovieCancellationRequests", "ProcessedUserId", "dbo.Admins", "AdminId", cascadeDelete: true);
        }
    }
}
