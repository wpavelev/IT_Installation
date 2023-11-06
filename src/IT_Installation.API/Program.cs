using IT_Installation.API.Repository.ApplicationRepository.Data;
using IT_Installation.API.Service.Implementation;
using IT_Installation.API.Service.Interface;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

IConfiguration configuration;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers().AddJsonOptions(o => o.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationdbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ApplicationDb")));

builder.Services.AddTransient<IProductService, ProductService>();
builder.Services.AddTransient<IAdressService, AdressService>();
builder.Services.AddTransient<ISupplierService, SupplierService>();
builder.Services.AddTransient<ICustomerService, CustomerService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "AllowMyOrigins",
                      policy =>
                      {
                          policy.WithOrigins("https://localhost:7270");
                      });
});

var app = builder.Build();
configuration = app.Configuration;
// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
