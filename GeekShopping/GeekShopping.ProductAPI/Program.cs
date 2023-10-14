using AutoMapper;
using GeekShopping.ProductAPI.Config;
using GeekShopping.ProductAPI.Models.Context;
using GeekShopping.ProductAPI.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("Database");

builder.Services.AddDbContext<DatabaseContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
);

IMapper mapper = MappingConfig.RegisterMaps().CreateMapper();
builder.Services.AddSingleton(mapper);
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped<IProductRepository, ProductRepository>();

builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthorization();

app.MapControllers();

app.Run();
