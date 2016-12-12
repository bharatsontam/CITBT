using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using CITBT.Models.DbModels;
using CITBT.Models.DbModels.Mapping;

namespace CITBT.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        //public string PhoneNumber { get; set; }


        public virtual ICollection<Event> Events { get; set; }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("CITBTConnection", throwIfV1Schema: false)
        {
        }

        public DbSet<Theater> Theatres { get; set; }
        public DbSet<TheatreShowTimings> TheatreShowTimings { get; set; }

        public DbSet<Event> Events { get; set; }
        public DbSet<EventRequests> EventRequests { get; set; }
        public DbSet<UserRegisteredEvents> UserRegisteredEvents { get; set; }
        public DbSet<UserEventCancellationRequests> UserEventCancellationRequests { get; set; }
        public DbSet<BookingOpenEvent> BookingOpenEvents { get; set; }
        public DbSet<PreBookingEvent> PreBookingEvents { get; set; }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<MovieShowTimes> MovieShowTimes { get; set; }
        public DbSet<UserPurchasedMovies> UserPurchasedMovies { get; set; }
        public DbSet<UserMovieCancellationRequests> UserMovieCancellationRequests { get; set; }
        public DbSet<BookingOpenMovie> BookingOpenMovies { get; set; }
        public DbSet<PreBookingMovie> PreBookingMovies { get; set; }

        public DbSet<Offer> Offers { get; set; }
        public DbSet<UserApplicableToOffer> UserApplicableToOffers { get; set; }
         
        public DbSet<User> ApplicationUsers { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<EventOrganizer> EventOrganizers { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AdminMapping());
            modelBuilder.Configurations.Add(new BookingOpenEventMapping() );
            modelBuilder.Configurations.Add(new BookingOpenMovieMapping() );
            modelBuilder.Configurations.Add(new EventMapping() );
            modelBuilder.Configurations.Add(new EventOrganizerMapping());
            modelBuilder.Configurations.Add(new EventRequestsMapping());
            modelBuilder.Configurations.Add(new MovieMapping());
            modelBuilder.Configurations.Add(new MovieShowTimesMapping());
            modelBuilder.Configurations.Add(new OfferMapping());
            modelBuilder.Configurations.Add(new PreBookingEventMapping());
            modelBuilder.Configurations.Add(new PreBookingMovieMapping());
            modelBuilder.Configurations.Add(new TheatreMapping());
            modelBuilder.Configurations.Add(new TheatreShowTimingsMapping() );
            modelBuilder.Configurations.Add(new UserApplicableToOfferMapping());
            modelBuilder.Configurations.Add(new UserEventCancellationRequestsMapping());
            modelBuilder.Configurations.Add(new UserMapping());
            modelBuilder.Configurations.Add(new UserMovieCancellationRequestsMapping());
            modelBuilder.Configurations.Add(new UserPurchasedMoviesMapping());
            modelBuilder.Configurations.Add(new UserRegisteredEventsMapping());
            
            base.OnModelCreating(modelBuilder);
        }
    }
}