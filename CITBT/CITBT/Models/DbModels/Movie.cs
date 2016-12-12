using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CITBT.Models.DbModels
{
    public class Movie : TrackedEntity
    {
        [Key]
        public override Guid Id { get; set; }
        
        [Display(Name="Movie Name")]
        [Required]
        public string MovieName { get; set; }
        
        [Display(Name="Duration")]
        [Required]
        public string Duration { get; set; }
        
        [Display(Name="Movie Language")]
        [Required]
        public string MovieLanguage { get; set; }
        
        [Display(Name="Movie Genre")]
        [Required]
        public string MovieGenre { get; set; }
        
        [Display(Name="Release Date")]
        [Required]
        public DateTime? ReleaseDate { get; set; }
        
        [Display(Name="Movie Cast")]
        [Required]
        public string MovieCast { get; set; }

        [Display(Name="Ticket Price")]
        public string TicketPrice { get; set; }

        public string FileName { get; set; }
        public string ContentType { get; set; }

        public byte[] Image { get; set; }

        public virtual ICollection<MovieShowTimes> MovieShowTimes { get; set; }

        public virtual ICollection<UserPurchasedMovies> UserPurchasedMovies { get; set; }

        public virtual ICollection<UserMovieCancellationRequests> UserMovieCancellationRequests { get; set; }

        public virtual ICollection<BookingOpenMovie> BookingOpenMovies { get; set; }

        public virtual ICollection<PreBookingMovie> PreBookingMovies { get; set; }
    }
}