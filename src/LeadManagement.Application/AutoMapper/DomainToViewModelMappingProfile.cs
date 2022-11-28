using AutoMapper;
using LeadManagement.Application.ViewModels.v1.Lead;
using LeadManagement.Domain.Core.Helpers;
using LeadManagement.Domain.Models;

namespace LeadManagement.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            // Lead
            CreateMap<Lead, LeadViewModel>()
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => (int)src.Status))
                .ForMember(dest => dest.StatusDescription, opt => opt.MapFrom(src => src.Status.GetDescriptionFromEnumValue()));
        }
    }
}