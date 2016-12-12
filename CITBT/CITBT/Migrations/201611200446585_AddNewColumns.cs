namespace CITBT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNewColumns : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Events", "FileName", c => c.String());
            AddColumn("dbo.Events", "ContentType", c => c.String());
            AddColumn("dbo.Events", "Image", c => c.Binary());
            AddColumn("dbo.UserPurchasedMovies", "TicketsCount", c => c.Int(nullable: false));
            AddColumn("dbo.UserRegisteredEvents", "TicketsCount", c => c.Int(nullable: false));
            DropColumn("dbo.BookingOpenEvents", "BookingStartDate");
            DropColumn("dbo.BookingOpenEvents", "BookingEndDate");
            DropColumn("dbo.PreBookingEvents", "PreBookingStartDate");
            DropColumn("dbo.PreBookingEvents", "PreBookingEndDate");
            DropColumn("dbo.BookingOpenMovies", "MovieBookingStartDate");
            DropColumn("dbo.BookingOpenMovies", "MovieBookingEndDate");
            DropColumn("dbo.PreBookingMovies", "PreBookingStartDate");
            DropColumn("dbo.PreBookingMovies", "PreBookingEndDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PreBookingMovies", "PreBookingEndDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.PreBookingMovies", "PreBookingStartDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.BookingOpenMovies", "MovieBookingEndDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.BookingOpenMovies", "MovieBookingStartDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.PreBookingEvents", "PreBookingEndDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.PreBookingEvents", "PreBookingStartDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.BookingOpenEvents", "BookingEndDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.BookingOpenEvents", "BookingStartDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.UserRegisteredEvents", "TicketsCount");
            DropColumn("dbo.UserPurchasedMovies", "TicketsCount");
            DropColumn("dbo.Events", "Image");
            DropColumn("dbo.Events", "ContentType");
            DropColumn("dbo.Events", "FileName");
        }
    }
}
