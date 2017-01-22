namespace CITBT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveColumnstoEventandMovie : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Events", "EventImageFileName");
            DropColumn("dbo.Events", "EventImage");
            DropColumn("dbo.Movies", "MovieImageFileName");
            DropColumn("dbo.Movies", "MovieImage");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Movies", "MovieImage", c => c.Binary(storeType: "image"));
            AddColumn("dbo.Movies", "MovieImageFileName", c => c.String());
            AddColumn("dbo.Events", "EventImage", c => c.Binary(storeType: "image"));
            AddColumn("dbo.Events", "EventImageFileName", c => c.String());
        }
    }
}
