using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace CITBT.Models.DbModels.Mapping
{
    public class UserRegisteredEventsMapping : EntityTypeConfiguration<UserRegisteredEvents>
    {
        public UserRegisteredEventsMapping()
        {
            HasKey(x => x.Id);

            Property(x => x.BAddress1);
            Property(x => x.BAddress2);
            Property(x => x.BCity);
            Property(x => x.BState);
            Property(x => x.BzipCode);
            Property(x => x.CardNumber);
            Property(x => x.CardType);
            Property(x => x.CVV);
            Property(x => x.ExpirationDate);
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.IsCancelled);
            Property(x => x.IsRefunded);
            Property(x => x.PurchasePrice);
            Property(x => x.RegisteredDate);
            Property(x => x.TicketsCount);

            HasRequired(x => x.Event).WithMany(x => x.UserRegisteredEvents).HasForeignKey(x => x.EventId).WillCascadeOnDelete(false);
            HasRequired(x => x.User).WithMany(x => x.UserRegisteredEvents).HasForeignKey(x => x.UserId).WillCascadeOnDelete(false);

            ToTable("UserRegisteredEvents");
        }
    }
}