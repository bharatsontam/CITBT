using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CITBT.Models.DbModels
{
    public class Event : TrackedEntity
    {
        [Key]
        public override Guid Id { get; set; }
        
        [Display(Name="Name")]
        [Required]
        public string Name { get; set; }
        
        [Display(Name = "Address1")]
        [Required]
        public string Address1 { get; set; }
        
        [Display(Name = "Address2")]
        public string Address2 { get; set; }
        
        [Display(Name = "City")]
        [Required]
        public string City { get; set; }
        
        [Display(Name = "State")]
        [Required]
        public string State { get; set; }
        
        [Display(Name = "Zip code")]
        [Required]
        public string ZipCode { get; set; }
        
        [Display(Name = "Country")]
        [Required]
        public string Country { get; set; }
        
        [Display(Name = "Organizer")]
        [Required]
        public string OrganizerName { get; set; }
        
        [ForeignKey("User")]
        [Display(Name = "User Id")]
        [Required]
        public string UserId { get; set; }
        
        [Display(Name = "Event Date")]
        [Required]
        public DateTime? EventDateTime { get; set; }
        
        [Display(Name = "Entry Fee")]
        [Required]
        public string EntryFee { get; set; }

        public string FileName { get; set; }
        public string ContentType { get; set; }

        public byte[] Image { get; set; }
        
        public virtual ApplicationUser User { get; set; }

        public virtual ICollection<UserEventCancellationRequests> UserEventCancellationRequests { get; set; }

        public virtual ICollection<BookingOpenEvent> BookingOpenEvents { get; set; }

        public virtual ICollection<PreBookingEvent> PreBookingEvents { get; set; }

        public virtual ICollection<EventRequests> EventRequests { get; set; }

        public virtual ICollection<UserRegisteredEvents> UserRegisteredEvents { get; set; }
    }
}