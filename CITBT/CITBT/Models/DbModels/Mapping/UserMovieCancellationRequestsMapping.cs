using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace CITBT.Models.DbModels.Mapping
{
    public class UserMovieCancellationRequestsMapping : EntityTypeConfiguration<UserMovieCancellationRequests>
    {

        public UserMovieCancellationRequestsMapping()
        {
            HasKey(x => x.Id);

            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.IsApproved);
            Property(x => x.IsRefunded);
            Property(x => x.ProcessedDate);
            Property(x => x.RequestDate);
            Property(x => x.ProcessedUserId).IsOptional();

            HasRequired(x => x.Admin).WithMany(x => x.UserMovieCancellationRequests).HasForeignKey(x => x.ProcessedUserId).WillCascadeOnDelete(false);
            HasRequired(x => x.Movie).WithMany(x => x.UserMovieCancellationRequests).HasForeignKey(x => x.MovieId);
            HasRequired(x => x.User).WithMany(x => x.UserMovieCancellationRequests).HasForeignKey(x => x.UserId);
            HasRequired(x => x.UserPurchasedMovie).WithMany(x => x.UserMovieCancellationRequests).HasForeignKey(x => x.UserMoviePurchaseId);

            ToTable("UserMovieCancellationRequests");
        }
    }
}