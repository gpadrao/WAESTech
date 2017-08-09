using AutoMapper;
using WAES.Application.ViewModels;
using WAES.Domain.ValueObjects;

namespace WAES.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "ViewModelToDomainMappings"; }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<ValidationResultViewModel, ValidationResult>();
           
        }
    }
}
