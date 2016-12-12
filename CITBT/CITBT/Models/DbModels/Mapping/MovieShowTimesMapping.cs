using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace CITBT.Models.DbModels.Mapping
{
    public class MovieShowTimesMapping : EntityTypeConfiguration<MovieShowTimes>
    {
        public MovieShowTimesMapping()
        {
            HasKey(x => x.Id);

            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            HasRequired(x => x.Movie).WithMany(x => x.MovieShowTimes).HasForeignKey(x => x.MovieId);
            Property(x => x.ShowTime);
            HasRequired(x => x.Theatre).WithMany(x => x.MovieShowTimes).HasForeignKey(x => x.TheatreId);

            ToTable("MovieShowTimes");
        }
    }
}