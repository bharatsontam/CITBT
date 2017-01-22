using AutoMapper;
using CITBT.Models.DbModels;
using CITBT.ViewModels.Movies;
using CITBT.ViewModels.Purchase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CITBT.MappingProfiles
{
    public class MovieMappingProfile : Profile
    {
        protected override void Configure()
        {
            base.Configure();

            CreateMap<Movie, MovieViewModel>()
                .MapFrom(d => d.Image, s => Convert.ToBase64String(s.Image));
            CreateMap<CreateMovieViewModel, Movie>();
            CreateMap<Movie, EditMovieModel>()
                .MapFrom(d => d.Image, s => Convert.ToBase64String(s.Image));
            CreateMap<EditMovieModel, Movie>();
            CreateMap<Movie, MovieDetailViewModel>()
                .MapFrom(d => d.Image, s => Convert.ToBase64String(s.Image))
                .Ignore(x => x.MovieShowTimes);

            CreateMap<CreatePurchasedMovieViewModel, UserPurchasedMovies>()
                .MapFrom(d => d.PurchasePrice, s => Convert.ToString(Convert.ToDecimal(s.MovieTicketPrice) * s.TicketsCount));
            CreateMap<UserPurchasedMovies, PurchasedMoviesViewModel>();

        }
    }
}