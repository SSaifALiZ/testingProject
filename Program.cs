using testingProject.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    EnvironmentConstants.EnvironmentName = "Development";
    EnvironmentConstants.BaseURL = "https://qaconnect.tcscourier.com/gworkflow/api/";
}
else if (app.Environment.IsProduction())
{
    EnvironmentConstants.EnvironmentName = "Production";
    EnvironmentConstants.BaseURL = "https://qaconnect.tcscourier.com/gworkflow/api/";
}
else
{
    EnvironmentConstants.EnvironmentName = "Local";
    EnvironmentConstants.BaseURL = "http://localhost:5015/api/";
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html"); ;

app.Run();
