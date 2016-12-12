namespace CITBT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeColumnNames : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.EventRequests");
            AddColumn("dbo.EventRequests", "Id", c => c.Guid(nullable: false, identity: true));
            AddPrimaryKey("dbo.EventRequests", "Id");
            DropColumn("dbo.EventRequests", "RequestId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.EventRequests", "RequestId", c => c.Guid(nullable: false, identity: true));
            DropPrimaryKey("dbo.EventRequests");
            DropColumn("dbo.EventRequests", "Id");
            AddPrimaryKey("dbo.EventRequests", "RequestId");
        }
    }
}
