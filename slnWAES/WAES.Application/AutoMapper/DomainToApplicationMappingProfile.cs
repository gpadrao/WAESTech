using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
