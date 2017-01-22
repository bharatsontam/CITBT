using CITBT.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CITBT.ViewModels.Events
{
    public class EventViewModel
    {
        public Guid Id { get; set; }
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

        [Display(Name = "User Id")]
        public string UserId { get; set; }

        [Display(Name = "Event Date")]
        [Required]
        public DateTime? EventDateTime { get; set; }

        [Display(Name = "Entry Fee")]
        [Required]
        public string EntryFee { get; set; }

        public string Image { get; set; }
    }

    public class CreateEventViewModel : EventViewModel
    {
    }

    public class EditEventViewModel : CreateEventViewModel
    {

    }

    public class EventDetailViewModel : EventViewModel
    {

    }

    public class EditEventRequestViewModel : EditEventViewModel
    {

    }
}