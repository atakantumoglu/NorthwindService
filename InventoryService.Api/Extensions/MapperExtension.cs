using AutoMapper;
using InventoryService.Application.Mappers.CustomerMappers;

namespace InventoryService.Api.Extensions
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
