using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CITBT.Models.DbModels
{
    public class UserEventCancellationRequests : Entity
    {
        [Key]
        public override Guid Id { get; set; }

        [Display(Name="User Event Registered Id")]
        [Required]
        [ForeignKey("UserRegisteredEvent")]
        public Guid UserEventRegisteredId { get; set; }
        
        [Display(Name="Event Id")]
        [Required]
        [ForeignKey("Event")]
        public Guid EventId { get; set; }
        
        [Display(Name="User Id")]
        [Required]
        [ForeignKey("User")]
        public Guid UserId { get; set; }

        [Display(Name = "Processed User Id")]
        [ForeignKey("Admin")]
        public Guid? ProcessedUserId { get; set; }
        
        [Display(Name="Requested Date")]
        public DateTime? RequestedDate { get; set; }
        
        [Display(Name="Processed Date")]
        public DateTime? ProcessedDate { get; set; }
        
        [Display(Name="Is Approved")]
        public bool IsApproved { get; set; }
        
        [Display(Name="Is Refunded")]
        public bool IsRefunded { get; set; }

        public virtual UserRegisteredEvents UserRegisteredEvent { get; set; }
        public virtual Event Event { get; set; }
        public virtual User User { get; set; }
        public virtual Admin Admin { get; set; }
    }
}