using CITBT.ViewModels.Movies.MovieShowTimes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CITBT.ViewModels.Movies
{
    public class MovieViewModel
    {
        public Guid Id { get; set; }
        [Display(Name = "Movie Name")]
        [Required]
        public string MovieName { get; set; }

        [Display(Name = "Duration")]
        [Required]
        public string Duration { get; set; }

        [Display(Name = "Movie Language")]
        [Required]
        public string MovieLanguage { get; set; }

        [Display(Name = "Movie Genre")]
        [Required]
        public string MovieGenre { get; set; }

        [Display(Name = "Release Date")]
        [Required]
        public DateTime? ReleaseDate { get; set; }

        [Display(Name = "Movie Cast")]
        [Required]
        public string MovieCast { get; set; }

        [Display(Name="Ticket Price")]
        [Required]
        public string TicketPrice { get; set; }

        public string Image { get; set; }
    }

    public class CreateMovieViewModel : MovieViewModel
    {

    }
    public class EditMovieModel : CreateMovieViewModel
    {

    }
    public class MovieDetailViewModel : MovieViewModel
    {
        public MovieDetailViewModel()
        {
            this.MovieShowTimes = Enumerable.Empty<MovieShowTimesDetailViewModel>();
        }
        public IEnumerable<MovieShowTimesDetailViewModel> MovieShowTimes { get; set; }
    }
}