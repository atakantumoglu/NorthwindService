using Serilog;
namespace NorthwindService.Api.Extensions
{
    public static class SerilogExtensions
    {
        public static WebApplicationBuilder AddSerilog(this WebApplicationBuilder builder, string applicationName, IConfiguration configuration)
        {
            configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .CreateLogger();

            builder.Services.AddLogging(c =>
            {
                c.AddSerilog();
            });

            return builder;
        }
    }
}
