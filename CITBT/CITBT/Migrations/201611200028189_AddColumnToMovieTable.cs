namespace CITBT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddColumnToMovieTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "TicketPrice", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "TicketPrice");
        }
    }
}
