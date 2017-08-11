using AutoMapper;
using WAES.Application.ViewModels;
using WAES.Domain.ValueObjects;

namespace WAES.Application.AutoMapper
{
    public class DomainToApplicationMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "DomainToApplicationMapping"; }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<ValidationResult, ValidationResultViewModel>();
        }
    }
}
