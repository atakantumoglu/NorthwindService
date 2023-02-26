using AutoMapper;
using InventoryService.Application.Mapper.ItemMapper;
using InventoryService.Application.Mapper.PersonelMapper;
using InventoryService.Application.Services.Abstract;
using InventoryService.Application.Services.Concrete;
using InventoryService.Infrastructure.ContextDb;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<ApplicationDbContext>(options => 
    options.UseSqlServer("Server=KARGA;Initial Catalog=InventoryServiceDb; Integrated Security=true;TrustServerCertificate=true;",
       m=>m.MigrationsAssembly("InventoryService.Api")));


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
builder.Services.AddScoped<IPersonelService, PersonelService>();
builder.Services.AddScoped<IItemService, ItemService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
