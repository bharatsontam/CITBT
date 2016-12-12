using AutoMapper;
using CITBT.Models.DbModels;
using CITBT.ViewModels.Events;
using CITBT.ViewModels.Events.EventRequests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CITBT.MappingProfiles
{
    public class EventRequestMappingProfile : Profile
    {
        protected override void Configure()
        {
            base.Configure();

            CreateMap<EditEventViewModel, CreateEventRequestViewModel>()
               .MapFrom(d => d.RequestAddress1, s => s.Address1)
               .MapFrom(d => d.RequestAddress2, s => s.Address2)
               .MapFrom(d => d.RequestCity, s => s.City)
               .MapFrom(d => d.RequestCountry, s => s.Country)
               .MapFrom(d => d.RequestEntryFee, s => s.EntryFee)
               .MapFrom(d => d.RequestEventDateTime, s => s.EventDateTime)
               .MapFrom(d => d.RequestName, s => s.Name)
               .MapFrom(d => d.RequestOrganizer, s => s.OrganizerName)
               .MapFrom(d => d.RequestState, s => s.State)
               .MapFrom(d => d.RequestZipCode, s => s.ZipCode)
               .MapFrom(d => d.RequestDate, s => DateTime.Now)
               .MapFrom(d => d.IsApproved, s => false)
               .MapFrom(d => d.IsUpdated, s => false)
               .MapFrom(d => d.EventId, s => s.Id)
               .Ignore(x => x.Id);

            CreateMap<CreateEventRequestViewModel, EventRequests>();

            CreateMap<EventRequests, EventRequestViewModel>();
                

            CreateMap<EventRequests, EventRequestDetailViewModel>();

        }
    }
}