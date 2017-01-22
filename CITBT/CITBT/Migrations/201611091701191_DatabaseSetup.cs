namespace CITBT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DatabaseSetup : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        AdminId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.AdminId);
            
            CreateTable(
                "dbo.EventRequests",
                c => new
                    {
                        RequestId = c.Guid(nullable: false, identity: true),
                        EventId = c.Guid(nullable: false),
                        OrganizerId = c.String(nullable: false, maxLength: 128),
                        RequestDate = c.DateTime(),
                        ProcessedUserId = c.String(maxLength: 128),
                        ProcessedDate = c.DateTime(),
                        IsApproved = c.Boolean(nullable: false),
                        IsUpdated = c.Boolean(nullable: false),
                        RequestName = c.String(nullable: false),
                        RequestAddress1 = c.String(nullable: false),
                        RequestAddress2 = c.String(),
                        RequestCity = c.String(nullable: false),
                        RequestState = c.String(nullable: false),
                        RequestZipCode = c.String(nullable: false),
                        RequestCountry = c.String(nullable: false),
                        RequestOrganizer = c.String(nullable: false),
                        RequestEventDateTime = c.DateTime(nullable: false),
                        RequestEntryFee = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.RequestId)
                .ForeignKey("dbo.Events", t => t.EventId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.OrganizerId, cascadeDelete: true)
                .ForeignKey("dbo.Admins", t => t.ProcessedUserId)
                .ForeignKey("dbo.EventOrganizers", t => t.OrganizerId, cascadeDelete: true)
                .Index(t => t.EventId)
                .Index(t => t.OrganizerId)
                .Index(t => t.ProcessedUserId);
            
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Address1 = c.String(nullable: false),
                        Address2 = c.String(),
                        City = c.String(nullable: false),
                        State = c.String(nullable: false),
                        ZipCode = c.String(nullable: false),
                        Country = c.String(nullable: false),
                        Organizer = c.String(nullable: false),
                        UserId = c.String(nullable: false, maxLength: 128),
                        EventDateTime = c.DateTime(nullable: false),
                        EntryFee = c.String(nullable: false),
                        CreatedBy = c.String(),
                        CreatedTimeStamp = c.DateTimeOffset(nullable: false, precision: 7),
                        ModifiedBy = c.String(),
                        UpdatedTimeStamp = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.BookingOpenEvents",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        EventId = c.Guid(nullable: false),
                        BookingStartDate = c.DateTime(nullable: false),
                        BookingEndDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Events", t => t.EventId, cascadeDelete: true)
                .Index(t => t.EventId);
            
            CreateTable(
                "dbo.PreBookingEvents",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        EventId = c.Guid(nullable: false),
                        PreBookingStartDate = c.DateTime(nullable: false),
                        PreBookingEndDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Events", t => t.EventId, cascadeDelete: true)
                .Index(t => t.EventId);
            
            CreateTable(
                "dbo.UserEventCancellationRequests",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        UserEventRegisteredId = c.Guid(nullable: false),
                        EventId = c.Guid(nullable: false),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ProcessedUserId = c.String(nullable: false, maxLength: 128),
                        RequestedDate = c.DateTime(nullable: false),
                        ProcessedDate = c.DateTime(nullable: false),
                        IsApproved = c.Boolean(nullable: false),
                        IsRefunded = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Admins", t => t.ProcessedUserId, cascadeDelete: true)
                .ForeignKey("dbo.Events", t => t.EventId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.UserRegisteredEvents", t => t.UserEventRegisteredId, cascadeDelete: true)
                .Index(t => t.UserEventRegisteredId)
                .Index(t => t.EventId)
                .Index(t => t.UserId)
                .Index(t => t.ProcessedUserId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.UserApplicableToOffers",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        OfferId = c.Guid(nullable: false),
                        OfferValidDays = c.Int(nullable: false),
                        OfferValidStartDate = c.DateTime(nullable: false),
                        OfferValidEndDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Offers", t => t.OfferId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.OfferId);
            
            CreateTable(
                "dbo.Offers",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        OfferName = c.String(),
                        Description = c.String(),
                        OfferPrice = c.String(),
                        OfferPercentage = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserMovieCancellationRequests",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        UserMoviePurchaseId = c.Guid(nullable: false),
                        MovieId = c.Guid(nullable: false),
                        UserId = c.String(nullable: false, maxLength: 128),
                        RequestDate = c.DateTime(nullable: false),
                        ProcessedDate = c.DateTime(nullable: false),
                        ProcessedUserId = c.String(nullable: false, maxLength: 128),
                        IsApproved = c.Boolean(nullable: false),
                        IsRefunded = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Admins", t => t.ProcessedUserId, cascadeDelete: true)
                .ForeignKey("dbo.Movies", t => t.MovieId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.UserPurchasedMovies", t => t.UserMoviePurchaseId, cascadeDelete: true)
                .Index(t => t.UserMoviePurchaseId)
                .Index(t => t.MovieId)
                .Index(t => t.UserId)
                .Index(t => t.ProcessedUserId);
            
            CreateTable(
                "dbo.Movies",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        MovieName = c.String(nullable: false),
                        Duration = c.String(nullable: false),
                        MovieLanguage = c.String(nullable: false),
                        MovieGenre = c.String(nullable: false),
                        ReleaseDate = c.DateTime(nullable: false),
                        MovieCast = c.String(nullable: false),
                        CreatedBy = c.String(),
                        CreatedTimeStamp = c.DateTimeOffset(nullable: false, precision: 7),
                        ModifiedBy = c.String(),
                        UpdatedTimeStamp = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.BookingOpenMovies",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        MovieId = c.Guid(nullable: false),
                        MovieBookingStartDate = c.DateTime(nullable: false),
                        MovieBookingEndDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Movies", t => t.MovieId, cascadeDelete: true)
                .Index(t => t.MovieId);
            
            CreateTable(
                "dbo.MovieShowTimes",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        MovieId = c.Guid(nullable: false),
                        TheatreId = c.Guid(nullable: false),
                        ShowTime = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Movies", t => t.MovieId, cascadeDelete: true)
                .ForeignKey("dbo.Theatres", t => t.TheatreId, cascadeDelete: true)
                .Index(t => t.MovieId)
                .Index(t => t.TheatreId);
            
            CreateTable(
                "dbo.Theatres",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Address1 = c.String(nullable: false),
                        Address2 = c.String(),
                        City = c.String(nullable: false),
                        State = c.String(nullable: false),
                        ZipCode = c.String(nullable: false),
                        Country = c.String(nullable: false),
                        CreatedBy = c.String(),
                        CreatedTimeStamp = c.DateTimeOffset(nullable: false, precision: 7),
                        ModifiedBy = c.String(),
                        UpdatedTimeStamp = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TheatreShowTimings",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        TheatreId = c.Guid(nullable: false),
                        AvailableShowTime = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Theatres", t => t.TheatreId, cascadeDelete: true)
                .Index(t => t.TheatreId);
            
            CreateTable(
                "dbo.UserPurchasedMovies",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        MovieId = c.Guid(nullable: false),
                        MovieShowTimeId = c.Guid(nullable: false),
                        PurchasePrice = c.String(nullable: false),
                        IsCancelled = c.Boolean(nullable: false),
                        IsRefunded = c.Boolean(nullable: false),
                        CardNumber = c.String(),
                        CardType = c.String(),
                        CVV = c.String(),
                        ExpirationDate = c.String(),
                        BAddress1 = c.String(),
                        BAddress2 = c.String(),
                        BCity = c.String(),
                        BState = c.String(),
                        BzipCode = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Movies", t => t.MovieId)
                .ForeignKey("dbo.MovieShowTimes", t => t.MovieShowTimeId)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.MovieId)
                .Index(t => t.MovieShowTimeId);
            
            CreateTable(
                "dbo.PreBookingMovies",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        MovieId = c.Guid(nullable: false),
                        PreBookingStartDate = c.DateTime(nullable: false),
                        PreBookingEndDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Movies", t => t.MovieId, cascadeDelete: true)
                .Index(t => t.MovieId);
            
            CreateTable(
                "dbo.UserRegisteredEvents",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        EventId = c.Guid(nullable: false),
                        RegisteredDate = c.DateTime(nullable: false),
                        PurchasePrice = c.String(nullable: false),
                        IsCancelled = c.Boolean(nullable: false),
                        IsRefunded = c.Boolean(nullable: false),
                        CardNumber = c.String(),
                        CardType = c.String(),
                        CVV = c.String(),
                        ExpirationDate = c.String(),
                        BAddress1 = c.String(),
                        BAddress2 = c.String(),
                        BCity = c.String(),
                        BState = c.String(),
                        BzipCode = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Events", t => t.EventId)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.EventId);
            
            CreateTable(
                "dbo.EventOrganizers",
                c => new
                    {
                        OrganizerId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.OrganizerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EventRequests", "OrganizerId", "dbo.EventOrganizers");
            DropForeignKey("dbo.EventRequests", "ProcessedUserId", "dbo.Admins");
            DropForeignKey("dbo.EventRequests", "OrganizerId", "dbo.AspNetUsers");
            DropForeignKey("dbo.EventRequests", "EventId", "dbo.Events");
            DropForeignKey("dbo.UserEventCancellationRequests", "UserEventRegisteredId", "dbo.UserRegisteredEvents");
            DropForeignKey("dbo.UserEventCancellationRequests", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserRegisteredEvents", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserRegisteredEvents", "EventId", "dbo.Events");
            DropForeignKey("dbo.UserMovieCancellationRequests", "UserMoviePurchaseId", "dbo.UserPurchasedMovies");
            DropForeignKey("dbo.UserMovieCancellationRequests", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserMovieCancellationRequests", "MovieId", "dbo.Movies");
            DropForeignKey("dbo.PreBookingMovies", "MovieId", "dbo.Movies");
            DropForeignKey("dbo.UserPurchasedMovies", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserPurchasedMovies", "MovieShowTimeId", "dbo.MovieShowTimes");
            DropForeignKey("dbo.UserPurchasedMovies", "MovieId", "dbo.Movies");
            DropForeignKey("dbo.MovieShowTimes", "TheatreId", "dbo.Theatres");
            DropForeignKey("dbo.TheatreShowTimings", "TheatreId", "dbo.Theatres");
            DropForeignKey("dbo.MovieShowTimes", "MovieId", "dbo.Movies");
            DropForeignKey("dbo.BookingOpenMovies", "MovieId", "dbo.Movies");
            DropForeignKey("dbo.UserMovieCancellationRequests", "ProcessedUserId", "dbo.Admins");
            DropForeignKey("dbo.UserApplicableToOffers", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserApplicableToOffers", "OfferId", "dbo.Offers");
            DropForeignKey("dbo.UserEventCancellationRequests", "EventId", "dbo.Events");
            DropForeignKey("dbo.UserEventCancellationRequests", "ProcessedUserId", "dbo.Admins");
            DropForeignKey("dbo.Events", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.PreBookingEvents", "EventId", "dbo.Events");
            DropForeignKey("dbo.BookingOpenEvents", "EventId", "dbo.Events");
            DropIndex("dbo.UserRegisteredEvents", new[] { "EventId" });
            DropIndex("dbo.UserRegisteredEvents", new[] { "UserId" });
            DropIndex("dbo.PreBookingMovies", new[] { "MovieId" });
            DropIndex("dbo.UserPurchasedMovies", new[] { "MovieShowTimeId" });
            DropIndex("dbo.UserPurchasedMovies", new[] { "MovieId" });
            DropIndex("dbo.UserPurchasedMovies", new[] { "UserId" });
            DropIndex("dbo.TheatreShowTimings", new[] { "TheatreId" });
            DropIndex("dbo.MovieShowTimes", new[] { "TheatreId" });
            DropIndex("dbo.MovieShowTimes", new[] { "MovieId" });
            DropIndex("dbo.BookingOpenMovies", new[] { "MovieId" });
            DropIndex("dbo.UserMovieCancellationRequests", new[] { "ProcessedUserId" });
            DropIndex("dbo.UserMovieCancellationRequests", new[] { "UserId" });
            DropIndex("dbo.UserMovieCancellationRequests", new[] { "MovieId" });
            DropIndex("dbo.UserMovieCancellationRequests", new[] { "UserMoviePurchaseId" });
            DropIndex("dbo.UserApplicableToOffers", new[] { "OfferId" });
            DropIndex("dbo.UserApplicableToOffers", new[] { "UserId" });
            DropIndex("dbo.UserEventCancellationRequests", new[] { "ProcessedUserId" });
            DropIndex("dbo.UserEventCancellationRequests", new[] { "UserId" });
            DropIndex("dbo.UserEventCancellationRequests", new[] { "EventId" });
            DropIndex("dbo.UserEventCancellationRequests", new[] { "UserEventRegisteredId" });
            DropIndex("dbo.PreBookingEvents", new[] { "EventId" });
            DropIndex("dbo.BookingOpenEvents", new[] { "EventId" });
            DropIndex("dbo.Events", new[] { "UserId" });
            DropIndex("dbo.EventRequests", new[] { "ProcessedUserId" });
            DropIndex("dbo.EventRequests", new[] { "OrganizerId" });
            DropIndex("dbo.EventRequests", new[] { "EventId" });
            DropTable("dbo.EventOrganizers");
            DropTable("dbo.UserRegisteredEvents");
            DropTable("dbo.PreBookingMovies");
            DropTable("dbo.UserPurchasedMovies");
            DropTable("dbo.TheatreShowTimings");
            DropTable("dbo.Theatres");
            DropTable("dbo.MovieShowTimes");
            DropTable("dbo.BookingOpenMovies");
            DropTable("dbo.Movies");
            DropTable("dbo.UserMovieCancellationRequests");
            DropTable("dbo.Offers");
            DropTable("dbo.UserApplicableToOffers");
            DropTable("dbo.Users");
            DropTable("dbo.UserEventCancellationRequests");
            DropTable("dbo.PreBookingEvents");
            DropTable("dbo.BookingOpenEvents");
            DropTable("dbo.Events");
            DropTable("dbo.EventRequests");
            DropTable("dbo.Admins");
        }
    }
}
