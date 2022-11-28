using AutoMapper;
using LeadManagement.Application.ViewModels.v1.Lead;
using LeadManagement.Domain.Commands.Lead;

namespace LeadManagement.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            // Lead
            CreateMap<RegisterNewLeadViewModel, RegisterNewLeadCommand>()
                .ConstructUsing(src => new RegisterNewLeadCommand(src.ContactFirstName, src.ContactFullName, src.ContactPhoneNumber, src.ContactEmail,
                    src.Suburb, src.Category, src.Description, src.Price));
        }
    }
}