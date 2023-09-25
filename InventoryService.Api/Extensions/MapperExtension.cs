using AutoMapper;
using NorthwindService.Application.Mappers.CustomerMappers;
using NorthwindService.Application.Mappers.UserMappers;

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
                config.AddProfile<UserMappingProfile>();
            });

            IMapper mapper = mapperConfiguration.CreateMapper();

            services.AddSingleton(mapper);

            return services;
        }
    }
}
