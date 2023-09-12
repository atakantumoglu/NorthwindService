//namespace NorthwindService.Api.Extensions
//{
//    using System;
//    using System.Collections.Generic;
//    using System.Linq;
//    using System.Text;
//    using System.Threading.Tasks;

//    namespace NorthwindService.Infrastructure.Extensions
//    {
//        public static class SerilogExtensions
//        {
//            public static WebApplicationBuilder AddSerilog(this WebApplicationBuilder builder, string applicationName, IConfiguration configuration)
//            {
//                Log.Logger = new LoggerConfiguration()
//                    .MinimumLevel.Override("Microsoft.AspNetCore", LogEventLevel.Information)
//                    .MinimumLevel.Override("MassTransit", LogEventLevel.Debug)
//                    .Enrich.FromLogContext()
//                    .Enrich.WithCorrelationId()
//                    .Enrich.WithExceptionDetails()
//                    .Enrich.WithProperty("ApplicationName", $"{applicationName}")
//                    .Filter.ByExcluding(Matching.FromSource("Microsoft.AspNetCore.StaticFiles"))
//                    .WriteTo.Async(writeTo => writeTo.Console(outputTemplate: "[{Timestamp:HH:mm:ss} {Level:u3}] {Message:lj} {Properties:j}{NewLine}{Exception}"))
//                    .WriteTo.Async(writeTo => writeTo.Elasticsearch(new ElasticsearchSinkOptions(new Uri(configuration["ElasticsearchSettings:uri"]))
//                    {
//                        TypeName = null,
//                        AutoRegisterTemplate = true,
//                        IndexFormat = configuration["ElasticsearchSettings:defaultIndex"],
//                        BatchAction = ElasticOpType.Create,
//                        CustomFormatter = new EcsTextFormatter(),
//                        ModifyConnectionSettings = x => x.BasicAuthentication(configuration["ElasticsearchSettings:username"], configuration["ElasticsearchSettings:password"])
//                    }))
//                    .CreateLogger();

//                builder.Logging.ClearProviders();
//                builder.Host.UseSerilog(Log.Logger, true);

//                return builder;
//            }
//        }
//    }

//}
