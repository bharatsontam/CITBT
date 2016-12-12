using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CITBT.Models.DbModels
{
    public class UserPurchasedMovies : Payment
    {
        [Key]
        public override Guid Id { get; set; }
        
        [Display(Name="User Id")]
        [ForeignKey("User")]
        [Required]
        public Guid UserId { get; set; }
        
        [Display(Name="Movie Id")]
        [ForeignKey("Movie")]
        [Required]
        public Guid MovieId { get; set; }
        
        [Display(Name="Movie Show Time Id")]
        [ForeignKey("MovieShowTime")]
        [Required]
        public Guid MovieShowTimeId { get; set; }

        public int TicketsCount { get; set; }
        
        [Display(Name="Purchase Price")]
        [Required]
        public string PurchasePrice { get; set; }
        
        [Display(Name="Is Cancelled")]
        public bool IsCancelled { get; set; }
        
        [Display(Name="Is Refunded")]
        public bool IsRefunded { get; set; }

        public virtual User User { get; set; }

        public virtual Movie Movie { get; set; }

        public virtual MovieShowTimes MovieShowTime { get; set; }

        public virtual ICollection<UserMovieCancellationRequests> UserMovieCancellationRequests { get; set; }
    }
}