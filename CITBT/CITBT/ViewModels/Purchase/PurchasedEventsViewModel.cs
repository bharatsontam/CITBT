using CITBT.Models.DbModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CITBT.ViewModels.Purchase
{
    public class PurchasedEventsViewModel : Payment
    {
        public Guid Id { get; set; }
        [Display(Name = "User Id")]
        [Required]
        public string UserId { get; set; }

        [Display(Name = "Event Id")]
        [Required]
        public Guid EventId { get; set; }

        [Display(Name = "Registered Date")]
        public DateTime RegisteredDate { get; set; }

        [Display(Name = "Purchase Price")]
        public string PurchasePrice { get; set; }

        public int TicketsCount { get; set; }

        [Display(Name = "Is Cancelled")]
        public bool IsCancelled { get; set; }

        [Display(Name = "IsRefunded")]
        public bool IsRefunded { get; set; }

        public string EventName { get; set; }
        public string EntryFee { get; set; }
        public string UserName { get; set; }
    }

    public class CreatePurchasedEventsViewModel : PurchasedEventsViewModel
    {

    }

    
}