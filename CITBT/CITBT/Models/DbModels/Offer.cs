using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CITBT.Models.DbModels
{
    public class Offer : Entity
    {
        [Key]
        public override Guid Id { get; set; }
        
        [Display(Name="Offer Name")]
        public string OfferName { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        [Display(Name = "Offer Price")]
        public string OfferPrice { get; set; }

        [Display(Name = "Offer Percentage")]
        public string OfferPercentage { get; set; }

        public virtual ICollection<UserApplicableToOffer> UserApplicableToOffers { get; set; }
    }
}