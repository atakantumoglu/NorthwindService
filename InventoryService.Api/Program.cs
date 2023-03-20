using AutoMapper;
using InventoryService.Application.Mapper.ItemMapper;
using InventoryService.Application.Mapper.PersonelMapper;
using InventoryService.Application.Services.Abstract;
using InventoryService.Application.Services.Concrete;
using InventoryService.Application.Services.Data;
using InventoryService.Application.Services.Data.EFCore;
using InventoryService.Infrastructure.ContextDb;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer("Server=KARGA;Initial Catalog=InventoryServiceDb; Integrated Security=true;TrustServerCertificate=true;",
       m => m.MigrationsAssembly("InventoryService.Api")));

// Mapper Configurations
var assembly = Assembly.GetExecutingAssembly();
builder.Services.AddAutoMapper(assembly);
var mapConfig = new MapperConfiguration(x =>
{
    x.AddProfile<ItemMapperProfile>();
    x.AddProfile<PersonelMapperProfile>();
});
var mapper = mapConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

// Interface implementations
builder.Services.AddScoped<IPersonelRepository, PersonelRepository>();
builder.Services.AddScoped<IItemRepository, ItemRepository>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(EFCoreRepository<>));
builder.Services.AddTransient<IPersonelRepository, PersonelRepository>();
builder.Services.AddTransient<IItemRepository, ItemRepository>();
builder.Services.AddControllers();

// Register the Swagger generator and the Swagger UI middlewares
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "InventoryService.Api", Version = "v1" });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "InventoryService.Api v1");
        c.RoutePrefix = string.Empty;
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
