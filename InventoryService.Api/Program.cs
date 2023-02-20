using AutoMapper;
using InventoryService.Application.Mapper.PersonelMapper;
using InventoryService.Application.Services;
using InventoryService.Infrastructure.ContextDb;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<ApplicationDbContext>(options => 
    options.UseSqlServer("Server=KARGA;Initial Catalog=InventoryServiceDb; Integrated Security=true;TrustServerCertificate=true;",
       m=>m.MigrationsAssembly("InventoryService.Api")));


//MAPPER
var assembly = Assembly.GetExecutingAssembly();
builder.Services.AddAutoMapper(assembly);
var mapConfig = new MapperConfiguration(x =>
{
    x.AddProfile<PersonelMappingProfile>();
});
var mapper = mapConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

builder.Services.AddScoped<IPersonelService, PersonelService>();

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
