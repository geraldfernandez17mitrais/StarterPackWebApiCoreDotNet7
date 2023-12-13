using Microsoft.EntityFrameworkCore;
using RefreshFW.Application.Handlers;
using RefreshFW.Application.Interfaces;
using RefreshFW.Application.Mappers;
using RefreshFW.Domain.Interfaces;
using RefreshFW.Persistance;
using RefreshFW.Persistance.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Configure DBContext.
builder.Services.AddDbContext<RefreshFrameWorkDBContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")
));

// Repository Dependency Injections.
builder.Services.AddScoped<ICustomerIndividuRepository, CustomerIndividuRepository>();

// Service Dependency Injections.
builder.Services.AddScoped<ICustomerIndividuService, CustomerIndividuService>();

// Auto Mapper Dependency Injections.
builder.Services.AddAutoMapper(typeof(MappingProfiles));


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
