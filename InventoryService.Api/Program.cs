using AutoMapper;
using InventoryService.Application.Services.Data.Abstract;
using InventoryService.Application.Services.Data.EFCore;
using InventoryService.Infrastructure.Data.Context;
using InventoryService.Infrastructure.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);



// Add services to the container.
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
var assembly = Assembly.GetExecutingAssembly();
builder.Services.AddAutoMapper(assembly);
//var mapConfig = new MapperConfiguration(x =>
//{
//    x.AddProfile<ItemMapperProfile>();
//    x.AddProfile<PersonelMapperProfile>();
//});
//var mapper = mapConfig.CreateMapper();
//builder.Services.AddSingleton(mapper);

// Interface implementations
//builder.Services.AddScoped(typeof(IRepository<>), typeof(EFCoreRepository<>));

builder.Services.AddScoped(typeof(IUnitOfWork<>), typeof(UnitOfWork<>));
builder.Services.AddHttpContextAccessor();
//builder.Services.AddScoped<IPersonelRepository, PersonelRepository>();
//builder.Services.AddScoped<IItemRepository, ItemRepository>();
builder.Services.AddControllers().AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);

// Register the Swagger generator and the Swagger UI middlewares
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "InventoryService.Api", Version = "v1" });
});


var app = builder.Build();
//using (var scope = app.Services.CreateScope())
//{
//    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
//    dbContext.Database.Migrate();
//}
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseCors(builder => builder
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "InventoryService.Api v1");
    });

}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
