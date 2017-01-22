using CITBT.Models.DbModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CITBT.ViewModels.Offers
{
    public class UserApplicableOffersViewModel
    {
        public Guid Id { get; set; }

        [Display(Name="User")]
        public string UserId { get; set; }

        [Display(Name="Offer")]
        public Guid OfferId { get; set; }

        [Display(Name = "Offer Valid Days")]
        public int OfferValidDays { get; set; }

        [Display(Name = "Offer Valid Start Date")]
        public DateTime OfferValidStartDate { get; set; }

        [Display(Name = "Offer Valid End Date")]
        public DateTime OfferValidEndDate { get; set; }

        public User User { get; set; }
        public Offer Offer { get; set; }
    }

    public class CreateUserApplicableOffersViewModel : UserApplicableOffersViewModel
    {
        public CreateUserApplicableOffersViewModel()
        {
            this.UsersList = Enumerable.Empty<SelectListItem>();
        }

        public IEnumerable<SelectListItem> UsersList { get; set; }
    }

    public class EditUserApplicableOffersViewModel : CreateUserApplicableOffersViewModel
    {

    }

    public class UserApplicableOffersDetailViewModel : UserApplicableOffersViewModel
    {
        public string UserName { get; set; }
    }


}