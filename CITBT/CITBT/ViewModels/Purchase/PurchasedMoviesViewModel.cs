using CITBT.Models.DbModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CITBT.ViewModels.Purchase
{
    public class PurchasedMoviesViewModel : Payment
    {
        public Guid Id { get; set; }
        [Display(Name = "User Id")]
        [Required]
        public string UserId { get; set; }

        [Display(Name = "Movie Id")]
        [Required]
        public Guid MovieId { get; set; }

        [Display(Name = "Movie Show Time Id")]
        [Required]
        public Guid MovieShowTimeId { get; set; }

        public int TicketsCount { get; set; }

        [Display(Name = "Purchase Price")]
        public string PurchasePrice { get; set; }

        [Display(Name = "Is Cancelled")]
        public bool IsCancelled { get; set; }

        [Display(Name = "Is Refunded")]
        public bool IsRefunded { get; set; }

        [DisplayName("Movie Name")]
        public string MovieName { get; set; }
        [DisplayName("Ticket Price")]
        public string MovieTicketPrice { get; set; }

    }

    public class CreatePurchasedMovieViewModel : PurchasedMoviesViewModel
    {
        public CreatePurchasedMovieViewModel()
        {
            this.MovieShowTimeList = Enumerable.Empty<SelectListItem>();
        }

        public IEnumerable<SelectListItem> MovieShowTimeList { get; set; }
    }

    
}