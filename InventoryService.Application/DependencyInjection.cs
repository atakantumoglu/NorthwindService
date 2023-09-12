using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace InventoryService.Application
{
    public static class DependencyInjection
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            var asm = Assembly.GetExecutingAssembly();
            services.AddMediatR(cfg=>cfg.RegisterServicesFromAssembly(asm));
        }
    }
}
