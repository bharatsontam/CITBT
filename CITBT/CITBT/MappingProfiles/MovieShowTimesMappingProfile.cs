using AutoMapper;
using CITBT.Models.DbModels;
using CITBT.ViewModels.Movies.MovieShowTimes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CITBT.MappingProfiles
{
    public class MovieShowTimesMappingProfile : Profile
    {
        protected override void Configure()
        {
            base.Configure();

            CreateMap<MovieShowTimes, MovieShowTimesViewModel>()
                .MapFrom(d=>d.TheatreId,s=>s.TheatreId.ToString());

            CreateMap<MovieShowTimes, CreateMovieShowTimesViewModel>()
                .MapFrom(d => d.TheatreId, s => s.TheatreId.ToString());

            CreateMap<CreateMovieShowTimesViewModel, MovieShowTimes>()
                .MapFrom(d => d.TheatreId, s => new Guid(s.TheatreId));

            CreateMap<MovieShowTimes, EditMovieShowTimesViewModel>()
                .MapFrom(d => d.TheatreId, s => s.TheatreId.ToString());

            CreateMap<EditMovieShowTimesViewModel, MovieShowTimes>()
                .MapFrom(d => d.TheatreId, s => new Guid(s.TheatreId));

            CreateMap<MovieShowTimes, MovieShowTimesDetailViewModel>()
                .MapFrom(d => d.TheatreId, s => s.TheatreId.ToString());
        }
    }
}