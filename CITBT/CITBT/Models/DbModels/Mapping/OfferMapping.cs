using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace CITBT.Models.DbModels.Mapping
{
    public class OfferMapping : EntityTypeConfiguration<Offer>
    {
        public OfferMapping()
        {
            HasKey(x => x.Id);

            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.Description);
            Property(x => x.OfferName);
            Property(x => x.OfferPercentage);
            Property(x => x.OfferPrice);
            

            ToTable("Offers");
        }
    }
}