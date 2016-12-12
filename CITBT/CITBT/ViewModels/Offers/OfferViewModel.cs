using CITBT.Models.DbModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CITBT.ViewModels.Offers
{
    public class OfferViewModel
    {
        public Guid Id { get; set; }

        [Display(Name = "Offer Name")]
        public string OfferName { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        [Display(Name = "Offer Price")]
        public string OfferPrice { get; set; }

        [Display(Name = "Offer Percentage")]
        public string OfferPercentage { get; set; }
    }

    public class CreateOfferViewModel : OfferViewModel
    {

    }

    public class EditOfferViewModel : CreateOfferViewModel
    {

    }

    public class OfferDetailViewModel : OfferViewModel
    {
        public OfferDetailViewModel()
        {
            this.UserApplicableToOffers = Enumerable.Empty<UserApplicableOffersDetailViewModel>();
        }
        public IEnumerable<UserApplicableOffersDetailViewModel> UserApplicableToOffers { get; set; }
    }
}