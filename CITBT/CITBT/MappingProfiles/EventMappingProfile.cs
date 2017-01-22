using AutoMapper;
using CITBT.Models.DbModels;
using CITBT.ViewModels.Events;
using CITBT.ViewModels.Purchase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CITBT.MappingProfiles
{
    public class EventMappingProfile : Profile
    {
        protected override void Configure()
        {
            base.Configure();

            CreateMap<Event, EventViewModel>()
                .MapFrom(d => d.Image, s => Convert.ToBase64String(s.Image)); ;
            CreateMap<CreateEventViewModel, Event>();
            CreateMap<Event, EventDetailViewModel>()
                .MapFrom(d => d.Image, s => Convert.ToBase64String(s.Image));
            CreateMap<Event, EditEventViewModel>()
                .MapFrom(d => d.Image, s => Convert.ToBase64String(s.Image));
            CreateMap<EditEventViewModel, Event>();

            CreateMap<CreatePurchasedEventsViewModel, UserRegisteredEvents>()
                .MapFrom(d => d.PurchasePrice, s => Convert.ToString(Convert.ToDecimal(s.EntryFee) * s.TicketsCount))
                .MapFrom(d => d.RegisteredDate, s => DateTime.Now);
            CreateMap<UserRegisteredEvents, PurchasedEventsViewModel>();
        }
    }
}