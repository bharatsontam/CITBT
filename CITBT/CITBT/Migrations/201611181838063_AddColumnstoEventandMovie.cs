namespace CITBT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddColumnstoEventandMovie : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Events", "EventImageFileName", c => c.String());
            AddColumn("dbo.Movies", "MovieImageFileName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "MovieImageFileName");
            DropColumn("dbo.Events", "EventImageFileName");
        }
    }
}
