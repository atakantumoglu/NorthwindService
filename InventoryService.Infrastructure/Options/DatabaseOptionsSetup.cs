using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace NorthwindService.Infrastructure.Options
{
    public class DatabaseOptionsSetup(IConfiguration configuration) : IConfigureOptions<DatabaseOptions>
    {
        private const string ConfigurationSectionName = "DatabaseOptions";

        public void Configure(DatabaseOptions options)
        {
            var connectionString = configuration.GetConnectionString("Database")!;

            var migrationsAssembly = configuration.GetSection("DatabaseOptions:MigrationsAssembly").Value;

            options.ConnectionString = connectionString;

            options.MigrationAssembly = migrationsAssembly;

            configuration.GetSection(ConfigurationSectionName).Bind(options);
        }
    }
}
