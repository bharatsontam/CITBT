using CITBT.Models.DbModels;
using CITBT.ViewModels.Theaters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CITBT.ViewModels.Movies.MovieShowTimes
{
    public class MovieShowTimesViewModel
    {
        public Guid Id { get; set; }

        [Display(Name = "Movie Id")]
        [Required]
        public Guid MovieId { get; set; }

        [Display(Name = "Theatre")]
        [Required]
        public string TheatreId { get; set; }

        [Display(Name = "Show Time")]
        [Required]
        public string ShowTime { get; set; }
    }

    public class CreateMovieShowTimesViewModel : MovieShowTimesViewModel
    {
        public CreateMovieShowTimesViewModel()
        {
            this.Theaters = Enumerable.Empty<SelectListItem>();
        }

        public IEnumerable<SelectListItem> Theaters { get; set; }
    }

    public class EditMovieShowTimesViewModel : CreateMovieShowTimesViewModel
    {

    }

    public class MovieShowTimesDetailViewModel : MovieShowTimesViewModel
    {
        public Theater Theatre { get; set; }
        public Movie Movie { get; set; }
    }
}