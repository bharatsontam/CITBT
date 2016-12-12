using CITBT.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CITBT.ViewModels.Events.EventRequests
{
    public class EventRequestViewModel
    {
        public Guid Id { get; set; }
        [Display(Name = "Event Id")]
        [Required]
        public Guid EventId { get; set; }

        [Display(Name = "Organizer Id")]
        [Required]
        public string OrganizerId { get; set; }

        public ApplicationUser Organizer { get; set; }

        [Display(Name = "Request Date")]
        public DateTime? RequestDate { get; set; }

        [Display(Name = "Processed Admin Id")]
        public string ProcessedUserId { get; set; }

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
    }

    public class CreateEventRequestViewModel : EventRequestViewModel
    {

    }

    public class EditEventRequestViewModel : CreateEventRequestViewModel
    {

    }

    public class EventRequestDetailViewModel : EventRequestViewModel
    {

    }
}