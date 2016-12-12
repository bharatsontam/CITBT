namespace CITBT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeDatabase : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.UserMovieCancellationRequests", "RequestDate", c => c.DateTime());
            AlterColumn("dbo.UserMovieCancellationRequests", "ProcessedDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.UserMovieCancellationRequests", "ProcessedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.UserMovieCancellationRequests", "RequestDate", c => c.DateTime(nullable: false));
        }
    }
}
