using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CITBT.Models.DbModels
{
    public class UserMovieCancellationRequests : Entity
    {
        [Key]
        public override Guid Id { get; set; }

        [Display(Name="User Movie Purchase Id")]
        [Required]
        [ForeignKey("UserPurchasedMovie")]
        public Guid UserMoviePurchaseId { get; set; }
        
        [Display(Name="Movie Id")]
        [Required]
        [ForeignKey("Movie")]
        public Guid MovieId { get; set; }
        
        [Display(Name="User Id")]
        [Required]
        [ForeignKey("User")]
        public Guid UserId { get; set; }
        
        [Display(Name="Request Date")]
        public DateTime? RequestDate { get; set; }
        
        [Display(Name="Processed Date")]
        public DateTime? ProcessedDate { get; set; }
        
        [Display(Name="Processed User Id")]
        [ForeignKey("Admin")]
        public Guid? ProcessedUserId { get; set; }
        
        [Display(Name="Is Approved")]
        public bool IsApproved { get; set; }
        
        [Display(Name="Is Refunded")]
        public bool IsRefunded { get; set; }

        public virtual UserPurchasedMovies UserPurchasedMovie { get; set; }
        public virtual Movie Movie { get; set; }
        public virtual User User { get; set; }
        public virtual Admin Admin {get;set;}
    }
}