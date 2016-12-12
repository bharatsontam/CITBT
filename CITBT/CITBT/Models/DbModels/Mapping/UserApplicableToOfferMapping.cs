using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace CITBT.Models.DbModels.Mapping
{
    public class UserApplicableToOfferMapping : EntityTypeConfiguration<UserApplicableToOffer>
    {
        public UserApplicableToOfferMapping()
        {
            HasKey(x => x.Id);

            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.OfferValidDays);
            Property(x => x.OfferValidEndDate);
            Property(x => x.OfferValidStartDate);

            HasRequired(x => x.Offer).WithMany(x => x.UserApplicableToOffers).HasForeignKey(x => x.OfferId);
            HasRequired(x => x.User).WithMany(x => x.UserApplicableToOffers).HasForeignKey(x => x.UserId);

            ToTable("UserApplicableToOffers");
        }
    }
}