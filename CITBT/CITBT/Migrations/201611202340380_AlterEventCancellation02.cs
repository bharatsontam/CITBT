namespace CITBT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterEventCancellation02 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.UserEventCancellationRequests", "RequestedDate", c => c.DateTime());
            AlterColumn("dbo.UserEventCancellationRequests", "ProcessedDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.UserEventCancellationRequests", "ProcessedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.UserEventCancellationRequests", "RequestedDate", c => c.DateTime(nullable: false));
        }
    }
}
