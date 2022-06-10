using Microsoft.OpenApi.Models;
using RealEstateManagement.Application;
using RealEstateManagement.Application.Features.Profiles;
using RealEstateManagement.Persistence;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddApplicationServices();
builder.Services.AddPersistenceServices(builder.Configuration);
builder.Services.AddAutoMapper(c => c.AddProfile(new MappingProfile(builder.Configuration)));
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "RealEstateManagement", Version = "v1" });
});

builder.Services.AddCors(c =>
{
    c.AddPolicy("RealEstateManagementPolicy",
     options => options.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Real Estate Management v1"));
}

app.UseCors("RealEstateManagementPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();
