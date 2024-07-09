using HolidayApi.DependencyInjection.Extensions;
using HolidayApi.DependencyInjection.Mapster;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
var projectName = Assembly.GetExecutingAssembly().GetName().Name;

// Add services to the container.
builder.Services.ConfigureCommonServices(builder.Configuration, projectName!);

var app = builder.Build();

var mapster = app.Configuration.Get<MapsterConfiguration>();

// Configure the HTTP request pipeline.
var isDevelopment = app.Environment.IsDevelopment();

app.ConfigureCommonPipeline(isDevelopment, mapster!);

app.MapControllers();

app.Run();