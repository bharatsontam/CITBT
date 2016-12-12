using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace CITBT.Models.DbModels.Mapping
{
    public class BookingOpenMovieMapping : EntityTypeConfiguration<BookingOpenMovie>
    {
        public BookingOpenMovieMapping()
        {
            HasKey(x => x.Id);

            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            HasRequired(x => x.Movie).WithMany(x => x.BookingOpenMovies).HasForeignKey(x => x.MovieId);


            ToTable("BookingOpenMovies");
        }
    }
}