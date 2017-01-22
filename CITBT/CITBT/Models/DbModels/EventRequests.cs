using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CITBT.Models.DbModels
{
    public class EventRequests : Entity
    {
        [Key]
        [Display(Name="Request Id")]
        public override Guid Id { get; set; }
        
        [Display(Name="Event Id")]
        [ForeignKey("Event")]
        [Required]
        public Guid EventId { get; set; }
        
        [Display(Name="Organizer Id")]
        [ForeignKey("Organizer")]
        [Required]
        public string OrganizerId { get; set; }
        
        [Display(Name="Request Date")]
        public DateTime? RequestDate { get; set; }
        
        [Display(Name = "Processed Admin Id")]
        [ForeignKey("ProcessedUser")]
        public Guid? ProcessedUserId { get; set; }
        
        [Display(Name = "Processed Date")]
        public DateTime? ProcessedDate { get; set; }
        
        [Display(Name = "Is Approved")]
        public bool IsApproved { get; set; }
        
        [Display(Name = "Is Updated")]
        public bool IsUpdated { get; set; }
        
        [Display(Name = "Name")]
        [Required]
        public string RequestName { get; set; }
        
        [Display(Name = "Address1")]
        [Required]
        public string RequestAddress1 { get; set; }
        
        [Display(Name = "Address2")]
        public string RequestAddress2 { get; set; }
        
        [Display(Name = "City")]
        [Required]
        public string RequestCity { get; set; }
        
        [Display(Name = "State")]
        [Required]
        public string RequestState { get; set; }
        
        [Display(Name = "Zip code")]
        [Required]
        public string RequestZipCode { get; set; }
        
        [Display(Name = "Country")]
        [Required]
        public string RequestCountry { get; set; }
        
        [Display(Name = "Organizer")]
        [Required]
        public string RequestOrganizer { get; set; }
        
        [Display(Name = "Event Date")]
        [Required]
        public DateTime? RequestEventDateTime { get; set; }
        
        [Display(Name = "Entry Fee")]
        [Required]
        public string RequestEntryFee { get; set; }


        public virtual Event Event { get; set; }
        public virtual ApplicationUser Organizer { get; set; }
        public virtual Admin ProcessedUser { get; set; }
    }
}