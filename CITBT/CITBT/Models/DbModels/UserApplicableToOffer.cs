using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CITBT.Models.DbModels
{
    public class UserApplicableToOffer : Entity
    {
        [Key]
        public override Guid Id { get; set; }

        [Display(Name = "User Id")]
        [ForeignKey("User")]
        public Guid UserId { get; set; }

        [Display(Name = "Offer Id")]
        [ForeignKey("Offer")]
        public Guid OfferId { get; set; }

        [Display(Name = "Offer Valid Days")]
        public int OfferValidDays { get; set; }

        [Display(Name = "Offer Valid Start Date")]
        public DateTime OfferValidStartDate { get; set; }

        [Display(Name = "Offer Valid End Date")]
        public DateTime OfferValidEndDate { get; set; }

        public virtual User User { get; set; }
        public virtual Offer Offer { get; set; }
    }
}