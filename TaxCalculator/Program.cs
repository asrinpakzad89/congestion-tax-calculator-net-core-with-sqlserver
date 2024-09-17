using Microsoft.EntityFrameworkCore;
using TaxCalculator.Application.Features;
using TaxCalculator.Persistence.Data;
using TaxCalculator.Persistence.Repositories;
using TaxCalculator.Application.Common.Interfaces;
using TaxCalculator.Application.Common.Services;
using System;

var builder = WebApplication.CreateBuilder(args);

#region connectionString
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
#endregion

#region Dependency Injection
builder.Services.AddScoped<ITaxRule, TaxRule>();
builder.Services.AddScoped<IVehicleRepository, VehicleRepository>();
builder.Services.AddScoped<CongestionTaxService>();
#endregion
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
