namespace CITBT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddImageColumns : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Events", "EventImage", c => c.Binary(storeType: "image"));
            AddColumn("dbo.Movies", "MovieImage", c => c.Binary(storeType: "image"));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "MovieImage");
            DropColumn("dbo.Events", "EventImage");
        }
    }
}
