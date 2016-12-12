using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FPS.Data;
using FPS.Service.Models;
using AutoMapper;

namespace FPS.Service.Infrastructure
{
    public static class AutomapperConfigurator
    {
        public static void Configure()
        {
            Mapper.Initialize(cfg => Init(cfg));
        }

        public static void Init(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<Resident, ResidentServiceModel>();
            cfg.CreateMap<Apartment, ApartmentServiceModel>()
            .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.Resident.FirstName))
            .ForMember(dest => dest.MiddleName, opt => opt.MapFrom(src => src.Resident.MiddleName))
            .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.Resident.LastName))
            .ForMember(dest => dest.ContactNumber1, opt => opt.MapFrom(src => src.Resident.ContactNumber1))
            .ForMember(dest => dest.ContactNumber2, opt => opt.MapFrom(src => src.Resident.ContactNumber2))
            .ForMember(dest => dest.ContactNumber3, opt => opt.MapFrom(src => src.Resident.ContactNumber3))
            .ForMember(dest => dest.MembersLiving, opt => opt.MapFrom(src => src.Resident.MembersLiving))
            .ForMember(dest => dest.LivingStart, opt => opt.MapFrom(src => src.Resident.LivingStart))
            .ForMember(dest => dest.LivingEnd, opt => opt.MapFrom(src => src.Resident.LivingEnd))
            .ForMember(dest => dest.OwnerFirstName, opt => opt.MapFrom(src => src.Owner.FirstName))
            .ForMember(dest => dest.OwnerMiddleName, opt => opt.MapFrom(src => src.Owner.MiddleName))
            .ForMember(dest => dest.OwnerLastName, opt => opt.MapFrom(src => src.Owner.LastName))
            .ForMember(dest => dest.OwnerContactNumber1, opt => opt.MapFrom(src => src.Owner.ContactNumber1))
            .ForMember(dest => dest.OwnerContactNumber2, opt => opt.MapFrom(src => src.Owner.ContactNumber2))
            .ForMember(dest => dest.OwnerContactNumber3, opt => opt.MapFrom(src => src.Owner.ContactNumber3))
            .ForMember(dest => dest.OwnerMembersLiving, opt => opt.MapFrom(src => src.Owner.MembersLiving))
            .ForMember(dest => dest.OwnerLivingStart, opt => opt.MapFrom(src => src.Owner.LivingStart))
            .ForMember(dest => dest.OwnerLivingEnd, opt => opt.MapFrom(src => src.Owner.LivingEnd));

        }
    }
}
