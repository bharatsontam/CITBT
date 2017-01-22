using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace CITBT.Models.DbModels.Mapping
{
    public class EventRequestsMapping : EntityTypeConfiguration<EventRequests>
    {
        public EventRequestsMapping()
        {
            HasKey(x => x.Id);

            Property(x => x.IsApproved);
            Property(x => x.IsUpdated);
            Property(x => x.ProcessedDate);
            Property(x => x.RequestAddress1);
            Property(x => x.RequestAddress2);
            Property(x => x.RequestCity);
            Property(x => x.RequestCountry);
            Property(x => x.RequestDate);
            Property(x => x.RequestEntryFee);
            Property(x => x.RequestEventDateTime);
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.RequestName);
            Property(x => x.RequestOrganizer);
            Property(x => x.RequestState);
            Property(x => x.RequestZipCode);

            HasRequired(x => x.Event).WithMany(x => x.EventRequests).HasForeignKey(x => x.EventId);
            HasRequired(x => x.ProcessedUser).WithMany(x => x.ProcessedEventRequests).HasForeignKey(x => x.ProcessedUserId).WillCascadeOnDelete(false);

            ToTable("EventRequests");
        }
    }
}