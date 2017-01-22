using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace CITBT.Models.DbModels.Mapping
{
    public class UserPurchasedMoviesMapping : EntityTypeConfiguration<UserPurchasedMovies>
    {
        public UserPurchasedMoviesMapping()
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
            Property(x => x.TicketsCount);

            HasRequired(x => x.Movie).WithMany(x => x.UserPurchasedMovies).HasForeignKey(x => x.MovieId).WillCascadeOnDelete(false);
            HasRequired(x => x.MovieShowTime).WithMany(x => x.UserPurchasedMovies).HasForeignKey(x => x.MovieShowTimeId).WillCascadeOnDelete(false);
            HasRequired(x => x.User).WithMany(x => x.UserPurchasedMovies).HasForeignKey(x => x.UserId).WillCascadeOnDelete(false);

            ToTable("UserPurchasedMovies");
        }
    }
}