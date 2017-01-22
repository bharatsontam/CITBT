namespace CITBT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterEvenRequestColumn01 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.EventRequests", "ProcessedUserId", c => c.Guid(nullable: true));
            CreateIndex("dbo.EventRequests", "ProcessedUserId");
            AddForeignKey("dbo.EventRequests", "ProcessedUserId", "dbo.Admins", "AdminId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EventRequests", "ProcessedUserId", "dbo.Admins");
            DropIndex("dbo.EventRequests", new[] { "ProcessedUserId" });
            AlterColumn("dbo.EventRequests", "ProcessedUserId", c => c.Guid());
        }
    }
}
