using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace InventoryService.Infrastructure.Options
{
    public class DatabaseOptionsSetup : IConfigureOptions<DatabaseOptions>
    {
        private const string ConfigurationSectionName = "DatabaseOptions";
        private readonly IConfiguration _configuration;

        public DatabaseOptionsSetup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void Configure(DatabaseOptions options)
        {
            var connectionString = _configuration.GetConnectionString("Database");

            var migrationsAssembly = _configuration.GetSection("DatabaseOptions:MigrationsAssembly").Value;

            options.ConnectionString = connectionString;

            options.MigrationAssembly = migrationsAssembly;

            _configuration.GetSection(ConfigurationSectionName).Bind(options);
        }
    }
}
