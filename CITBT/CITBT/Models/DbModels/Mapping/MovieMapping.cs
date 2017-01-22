using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace CITBT.Models.DbModels.Mapping
{
    public class MovieMapping : EntityTypeConfiguration<Movie>
    {
        public MovieMapping()
        {
            HasKey(x => x.Id);

            Property(x => x.CreatedBy);
            Property(x => x.CreatedTimeStamp);
            Property(x => x.Duration);
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.ModifiedBy);
            Property(x => x.MovieCast);
            Property(x => x.MovieGenre);
            Property(x => x.MovieLanguage);
            Property(x => x.MovieName);
            Property(x => x.ReleaseDate).IsRequired();
            Property(x => x.UpdatedTimeStamp);
            Property(x => x.TicketPrice);
            Property(x => x.Image);
            Property(x => x.ContentType);
            Property(x => x.FileName);

            ToTable("Movies");
        }
    }
}