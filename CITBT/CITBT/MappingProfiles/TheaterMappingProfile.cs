using AutoMapper;
using CITBT.Models.DbModels;
using CITBT.ViewModels.Theaters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CITBT.MappingProfiles
{
    public class TheaterMappingProfile : Profile
    {
        protected override void Configure()
        {
            base.Configure();

            CreateMap<Theater, TheaterViewModel>();
            CreateMap<CreateTheaterViewModel, Theater>();
            CreateMap<EditTheaterViewModel, Theater>();
            CreateMap<Theater, EditTheaterViewModel>();
            CreateMap<Theater, TheatreDetailViewModel>();
        }
    }
}