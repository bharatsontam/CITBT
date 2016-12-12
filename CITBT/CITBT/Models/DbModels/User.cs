using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CITBT.Models.DbModels
{
    public class User
    {
        public Guid UserId { get; set; }


        public virtual ICollection<UserRegisteredEvents> UserRegisteredEvents { get; set; } 

        public virtual ICollection<UserEventCancellationRequests> UserEventCancellationRequests { get; set; }

        public virtual ICollection<UserPurchasedMovies> UserPurchasedMovies { get; set; }

        public virtual ICollection<UserMovieCancellationRequests> UserMovieCancellationRequests { get; set; }

        public virtual ICollection<UserApplicableToOffer> UserApplicableToOffers { get; set; }
    }

    public class Admin
    {
        public Guid AdminId { get; set; }

        public virtual ICollection<EventRequests> ProcessedEventRequests { get; set; }
        public virtual ICollection<UserMovieCancellationRequests> UserMovieCancellationRequests { get; set; }
        public virtual ICollection<UserEventCancellationRequests> UserEventCancellationRequests { get; set; }

    }
    public class EventOrganizer
    {
        public Guid OrganizerId { get; set; }


        public virtual ICollection<EventRequests> EventRequests { get; set; }
    }

}