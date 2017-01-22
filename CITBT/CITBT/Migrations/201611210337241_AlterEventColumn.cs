namespace CITBT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterEventColumn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Events", "OrganizerName", c => c.String(nullable: false));
            DropColumn("dbo.Events", "Organizer");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Events", "Organizer", c => c.String(nullable: false));
            DropColumn("dbo.Events", "OrganizerName");
        }
    }
}
