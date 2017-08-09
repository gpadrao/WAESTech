using AutoMapper;

namespace WAES.Application.AutoMapper
{
    public class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            Mapper.Initialize(x =>
            {
                x.AddProfile<ViewModelToDomainMappingProfile>();
                x.AddProfile<DomainToApplicationMappingProfile>();
            });
        }
    }
}
