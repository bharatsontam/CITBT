using AutoMapper;
using CITBT.Models.DbModels;
using CITBT.ViewModels.Offers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CITBT.MappingProfiles
{
    public class OfferMappingProfile : Profile
    {
        protected override void Configure()
        {
            base.Configure();

            CreateMap<Offer, OfferViewModel>();
            CreateMap<Offer, CreateOfferViewModel>();
            CreateMap<CreateOfferViewModel, Offer>();
            CreateMap<Offer, EditOfferViewModel>();
            CreateMap<EditOfferViewModel, Offer>();
            CreateMap<Offer, OfferDetailViewModel>();
        }
    }

    public class UserApplicableOffersMappingProfile : Profile
    {
        protected override void Configure()
        {
            base.Configure();

            CreateMap<UserApplicableToOffer, UserApplicableOffersViewModel>();
            CreateMap<UserApplicableToOffer, CreateUserApplicableOffersViewModel>();
            CreateMap<CreateUserApplicableOffersViewModel, UserApplicableToOffer>();
            CreateMap<UserApplicableToOffer, EditUserApplicableOffersViewModel>();
            CreateMap<EditUserApplicableOffersViewModel, UserApplicableToOffer>();
            CreateMap<UserApplicableToOffer, UserApplicableOffersDetailViewModel>();
        }
    }
}