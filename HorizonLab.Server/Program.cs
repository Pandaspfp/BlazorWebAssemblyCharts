using Blazorise;
using Blazorise.Icons.Material;
using Blazorise.Material;
using HorizonLab.DataLayer.Context;
using HorizonLab.DataLayer.Data;
using HorizonLab.DataLayer.Interfaces;
using HorizonLab.DataLayer.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DBAppSettings");
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

builder.Services
    .AddBlazorise(options =>
    {
        options.Immediate = true;
    })
    .AddMaterialProviders()
    .AddMaterialIcons();

// Database APP Settings
builder.Services.AddDbContext<greenhouse_dbContext>(options => options.UseMySql(connectionString, ServerVersion.Parse("10.5.16-MariaDB")));
// Add services to the container.
builder.Services.AddTransient<IDevice, SqlDevice>();
builder.Services.AddTransient<IGreenhouse, SqlGreenhouse>();
builder.Services.AddTransient<IMeasurementLight, SqlMeasurementLight>();
builder.Services.AddTransient<IMeasurementTemperature, SqlMeasurementTemperature>();
builder.Services.AddTransient<IDataService, DataService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("https://localhost:7195/",
                                              "http://localhost:5195")
                                                  .AllowAnyHeader()
                                                  .AllowAnyMethod();
                      });
});

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseCors(MyAllowSpecificOrigins);

app.UseAuthorization();

app.MapControllers();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
