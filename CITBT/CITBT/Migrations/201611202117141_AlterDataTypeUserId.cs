namespace CITBT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterDataTypeUserId : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.EventRequests", "ProcessedUserId", "dbo.Admins");
            DropForeignKey("dbo.EventRequests", "OrganizerId", "dbo.EventOrganizers");
            DropForeignKey("dbo.UserEventCancellationRequests", "ProcessedUserId", "dbo.Admins");
            DropForeignKey("dbo.UserMovieCancellationRequests", "ProcessedUserId", "dbo.Admins");
            DropForeignKey("dbo.UserApplicableToOffers", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserPurchasedMovies", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserMovieCancellationRequests", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserRegisteredEvents", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserEventCancellationRequests", "UserId", "dbo.Users");
            DropIndex("dbo.EventRequests", new[] { "ProcessedUserId" });
            DropIndex("dbo.UserEventCancellationRequests", new[] { "UserId" });
            DropIndex("dbo.UserEventCancellationRequests", new[] { "ProcessedUserId" });
            DropIndex("dbo.UserApplicableToOffers", new[] { "UserId" });
            DropIndex("dbo.UserMovieCancellationRequests", new[] { "UserId" });
            DropIndex("dbo.UserMovieCancellationRequests", new[] { "ProcessedUserId" });
            DropIndex("dbo.UserPurchasedMovies", new[] { "UserId" });
            DropIndex("dbo.UserRegisteredEvents", new[] { "UserId" });
            DropPrimaryKey("dbo.Admins");
            DropPrimaryKey("dbo.Users");
            DropPrimaryKey("dbo.EventOrganizers");
            AddColumn("dbo.EventRequests", "EventOrganizer_OrganizerId", c => c.Guid());
            AlterColumn("dbo.Admins", "AdminId", c => c.Guid(nullable: false));
            AlterColumn("dbo.EventRequests", "ProcessedUserId", c => c.Guid(nullable: false));
            AlterColumn("dbo.UserEventCancellationRequests", "UserId", c => c.Guid(nullable: false));
            AlterColumn("dbo.UserEventCancellationRequests", "ProcessedUserId", c => c.Guid(nullable: false));
            AlterColumn("dbo.Users", "UserId", c => c.Guid(nullable: false));
            AlterColumn("dbo.UserApplicableToOffers", "UserId", c => c.Guid(nullable: false));
            AlterColumn("dbo.UserMovieCancellationRequests", "UserId", c => c.Guid(nullable: false));
            AlterColumn("dbo.UserMovieCancellationRequests", "ProcessedUserId", c => c.Guid(nullable: false));
            AlterColumn("dbo.UserPurchasedMovies", "UserId", c => c.Guid(nullable: false));
            AlterColumn("dbo.UserRegisteredEvents", "UserId", c => c.Guid(nullable: false));
            AlterColumn("dbo.EventOrganizers", "OrganizerId", c => c.Guid(nullable: false));
            AddPrimaryKey("dbo.Admins", "AdminId");
            AddPrimaryKey("dbo.Users", "UserId");
            AddPrimaryKey("dbo.EventOrganizers", "OrganizerId");
            CreateIndex("dbo.EventRequests", "ProcessedUserId");
            CreateIndex("dbo.EventRequests", "EventOrganizer_OrganizerId");
            CreateIndex("dbo.UserEventCancellationRequests", "UserId");
            CreateIndex("dbo.UserEventCancellationRequests", "ProcessedUserId");
            CreateIndex("dbo.UserApplicableToOffers", "UserId");
            CreateIndex("dbo.UserMovieCancellationRequests", "UserId");
            CreateIndex("dbo.UserMovieCancellationRequests", "ProcessedUserId");
            CreateIndex("dbo.UserPurchasedMovies", "UserId");
            CreateIndex("dbo.UserRegisteredEvents", "UserId");
            AddForeignKey("dbo.EventRequests", "ProcessedUserId", "dbo.Admins", "AdminId", cascadeDelete: true);
            AddForeignKey("dbo.EventRequests", "EventOrganizer_OrganizerId", "dbo.EventOrganizers", "OrganizerId");
            AddForeignKey("dbo.UserEventCancellationRequests", "ProcessedUserId", "dbo.Admins", "AdminId", cascadeDelete: true);
            AddForeignKey("dbo.UserMovieCancellationRequests", "ProcessedUserId", "dbo.Admins", "AdminId");
            AddForeignKey("dbo.UserApplicableToOffers", "UserId", "dbo.Users", "UserId", cascadeDelete: true);
            AddForeignKey("dbo.UserPurchasedMovies", "UserId", "dbo.Users", "UserId");
            AddForeignKey("dbo.UserMovieCancellationRequests", "UserId", "dbo.Users", "UserId", cascadeDelete: true);
            AddForeignKey("dbo.UserRegisteredEvents", "UserId", "dbo.Users", "UserId");
            AddForeignKey("dbo.UserEventCancellationRequests", "UserId", "dbo.Users", "UserId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserEventCancellationRequests", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserRegisteredEvents", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserMovieCancellationRequests", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserPurchasedMovies", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserApplicableToOffers", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserMovieCancellationRequests", "ProcessedUserId", "dbo.Admins");
            DropForeignKey("dbo.UserEventCancellationRequests", "ProcessedUserId", "dbo.Admins");
            DropForeignKey("dbo.EventRequests", "EventOrganizer_OrganizerId", "dbo.EventOrganizers");
            DropForeignKey("dbo.EventRequests", "ProcessedUserId", "dbo.Admins");
            DropIndex("dbo.UserRegisteredEvents", new[] { "UserId" });
            DropIndex("dbo.UserPurchasedMovies", new[] { "UserId" });
            DropIndex("dbo.UserMovieCancellationRequests", new[] { "ProcessedUserId" });
            DropIndex("dbo.UserMovieCancellationRequests", new[] { "UserId" });
            DropIndex("dbo.UserApplicableToOffers", new[] { "UserId" });
            DropIndex("dbo.UserEventCancellationRequests", new[] { "ProcessedUserId" });
            DropIndex("dbo.UserEventCancellationRequests", new[] { "UserId" });
            DropIndex("dbo.EventRequests", new[] { "EventOrganizer_OrganizerId" });
            DropIndex("dbo.EventRequests", new[] { "ProcessedUserId" });
            DropPrimaryKey("dbo.EventOrganizers");
            DropPrimaryKey("dbo.Users");
            DropPrimaryKey("dbo.Admins");
            AlterColumn("dbo.EventOrganizers", "OrganizerId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.UserRegisteredEvents", "UserId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.UserPurchasedMovies", "UserId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.UserMovieCancellationRequests", "ProcessedUserId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.UserMovieCancellationRequests", "UserId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.UserApplicableToOffers", "UserId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Users", "UserId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.UserEventCancellationRequests", "ProcessedUserId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.UserEventCancellationRequests", "UserId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.EventRequests", "ProcessedUserId", c => c.String(maxLength: 128));
            AlterColumn("dbo.Admins", "AdminId", c => c.String(nullable: false, maxLength: 128));
            DropColumn("dbo.EventRequests", "EventOrganizer_OrganizerId");
            AddPrimaryKey("dbo.EventOrganizers", "OrganizerId");
            AddPrimaryKey("dbo.Users", "UserId");
            AddPrimaryKey("dbo.Admins", "AdminId");
            CreateIndex("dbo.UserRegisteredEvents", "UserId");
            CreateIndex("dbo.UserPurchasedMovies", "UserId");
            CreateIndex("dbo.UserMovieCancellationRequests", "ProcessedUserId");
            CreateIndex("dbo.UserMovieCancellationRequests", "UserId");
            CreateIndex("dbo.UserApplicableToOffers", "UserId");
            CreateIndex("dbo.UserEventCancellationRequests", "ProcessedUserId");
            CreateIndex("dbo.UserEventCancellationRequests", "UserId");
            CreateIndex("dbo.EventRequests", "ProcessedUserId");
            AddForeignKey("dbo.UserEventCancellationRequests", "UserId", "dbo.Users", "UserId", cascadeDelete: true);
            AddForeignKey("dbo.UserRegisteredEvents", "UserId", "dbo.Users", "UserId");
            AddForeignKey("dbo.UserMovieCancellationRequests", "UserId", "dbo.Users", "UserId", cascadeDelete: true);
            AddForeignKey("dbo.UserPurchasedMovies", "UserId", "dbo.Users", "UserId");
            AddForeignKey("dbo.UserApplicableToOffers", "UserId", "dbo.Users", "UserId", cascadeDelete: true);
            AddForeignKey("dbo.UserMovieCancellationRequests", "ProcessedUserId", "dbo.Admins", "AdminId");
            AddForeignKey("dbo.UserEventCancellationRequests", "ProcessedUserId", "dbo.Admins", "AdminId", cascadeDelete: true);
            AddForeignKey("dbo.EventRequests", "OrganizerId", "dbo.EventOrganizers", "OrganizerId", cascadeDelete: true);
            AddForeignKey("dbo.EventRequests", "ProcessedUserId", "dbo.Admins", "AdminId");
        }
    }
}
