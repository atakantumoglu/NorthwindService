using AutoMapper;
using NorthwindService.Application.Mappers.CustomerMappers;

namespace NorthwindService.Api.Extensions
{
    public static class MapperExtension
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            MapperConfiguration mapperConfiguration = new MapperConfiguration(config =>
            {
                //Customer Mapping Profiles
                config.AddProfile<CustomerMappingProfile>();
            });

            IMapper mapper = mapperConfiguration.CreateMapper();

            services.AddSingleton(mapper);

            return services;
        }
    }
}
