using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using NorthwindService.Api.Extensions;
using NorthwindService.Application;
using NorthwindService.Application.Services.Data.Abstract;
using NorthwindService.Application.Services.Data.EFCore;
using NorthwindService.Infrastructure.Data.Context;
using NorthwindService.Infrastructure.Options;
using Serilog;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
var assembly = Assembly.GetExecutingAssembly();
var configuration = builder.Configuration;
// Add services to the container.
builder.AddSerilog("NorthwindService.API", configuration);
builder.Services.ConfigureOptions<DatabaseOptionsSetup>();
builder.Services.AddCors();
builder.Services.AddDbContext<ApplicationDbContext>(
    (serviceProvider, dbContextOptionsBuilder) =>
    {
        var databaseOptions = serviceProvider.GetService<IOptions<DatabaseOptions>>()!.Value;
        dbContextOptionsBuilder.UseSqlServer(databaseOptions.ConnectionString, sqlServerAction =>
        {
            sqlServerAction.MigrationsAssembly(databaseOptions.MigrationAssembly);
            sqlServerAction.CommandTimeout(databaseOptions.CommandTimeout);
            sqlServerAction.EnableRetryOnFailure(databaseOptions.MaxRetryCount);
        });

        dbContextOptionsBuilder.EnableDetailedErrors(databaseOptions.EnableDetailedErrors);
        dbContextOptionsBuilder.EnableSensitiveDataLogging(databaseOptions.EnableSensitiveDataLogging);
    });

// Mapper Configurations

builder.Services.AddApplication();

// Interface implementations
builder.Services.AddScoped(typeof(IUnitOfWork<>), typeof(UnitOfWork<>));


builder.Services.AddHttpContextAccessor();

builder.Services.AddControllers().AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);
builder.Services.AddApiConfiguration(configuration);
builder.Services.RegisterServices();

// Register the Swagger generator and the Swagger UI middlewares

var app = builder.Build();
app.UseMiddleware<TraceLogExtension>();
// Configure the HTTP request pipeline.
app.UseApiConfigurations();


app.Run();


