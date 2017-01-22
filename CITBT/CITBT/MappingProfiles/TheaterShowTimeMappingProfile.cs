using AutoMapper;
using CITBT.Models.DbModels;
using CITBT.ViewModels.Theaters.TheaterShowTimings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CITBT.MappingProfiles
{
    public class TheaterShowTimeMappingProfile : Profile
    {
        protected override void Configure()
        {
            base.Configure();

            CreateMap<TheatreShowTimings, TheatreShowTimingsViewModel>();
            CreateMap<CreateTheaterShowTimeViewModel, TheatreShowTimings>();
            CreateMap<TheatreShowTimings, EditTheaterShowTImeViewModel>();
            CreateMap<EditTheaterShowTImeViewModel, TheatreShowTimings>();
            CreateMap<TheatreShowTimings, TheaterShowTimeDetailViewModel>();
        }
    }
}