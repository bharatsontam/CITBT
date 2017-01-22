using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CITBT.Models.DbModels
{
    public class UserRegisteredEvents : Payment
    {
        [Key]
        public override Guid Id { get; set; }
        
        [Display(Name="User Id")]
        [Required]
        [ForeignKey("User")]
        public Guid UserId { get; set; }
        
        [Display(Name="Event Id")]
        [Required]
        [ForeignKey("Event")]
        public Guid EventId { get; set; }
        
        [Display(Name="Registered Date")]
        public DateTime RegisteredDate { get; set; }
        
        [Display(Name="Purchase Price")]
        [Required]
        public string PurchasePrice { get; set; }

        public int TicketsCount { get; set; }

        [Display(Name="Is Cancelled")]
        public bool IsCancelled { get; set; }
        
        [Display(Name="IsRefunded")]
        public bool IsRefunded { get; set; }

        public virtual Event Event { get; set; }

        public virtual ICollection<UserEventCancellationRequests> UserEventCancellationRequests { get; set; }

        public virtual User User { get; set; }
    }
}