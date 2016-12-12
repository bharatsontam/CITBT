using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace CITBT.Models.DbModels.Mapping
{
    public class UserEventCancellationRequestsMapping : EntityTypeConfiguration<UserEventCancellationRequests>
    {
        public UserEventCancellationRequestsMapping()
        {
            HasKey(x => x.Id);

            HasRequired(x => x.Admin).WithMany(x => x.UserEventCancellationRequests).HasForeignKey(x => x.ProcessedUserId);
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.IsApproved);
            Property(x => x.IsRefunded);
            HasRequired(x => x.Event).WithMany(x => x.UserEventCancellationRequests).HasForeignKey(x => x.EventId);
            Property(x => x.ProcessedDate);
            Property(x => x.RequestedDate);
            HasRequired(x => x.User).WithMany(x => x.UserEventCancellationRequests).HasForeignKey(x => x.UserId);
            HasRequired(x => x.UserRegisteredEvent).WithMany(x => x.UserEventCancellationRequests).HasForeignKey(x => x.UserEventRegisteredId);

            ToTable("UserEventCancellationRequests");
        }
    }
}