namespace CITBT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddImageColumnToMovies : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "FileName", c => c.String());
            AddColumn("dbo.Movies", "ContentType", c => c.String());
            AddColumn("dbo.Movies", "Image", c => c.Binary());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "Image");
            DropColumn("dbo.Movies", "ContentType");
            DropColumn("dbo.Movies", "FileName");
        }
    }
}
