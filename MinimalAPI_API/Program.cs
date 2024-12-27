using System.Reflection;
using MinimalAPI_Application.Models.Settings;
using MinimalAPI_DependencyInjections.Extensions;
using MinimalAPI_DependencyInjections.Mapster;
using MinimalAPIWebApplication;

var builder = WebApplication.CreateBuilder(args);
var projectName = Assembly.GetExecutingAssembly().GetName().Name;

builder.Services.ConfigureCommonServices(builder.Configuration, projectName!);

var app = builder.Build();

var mapster = app.Configuration.Get<MapsterConfiguration>();

var isDevelopment = app.Environment.IsDevelopment();

var securitySettings = app.Configuration.GetSection("Security").Get<SecuritySettings>();

app.ConfigureCommonPipeline(isDevelopment, mapster!, securitySettings!);

app.UseHttpsRedirection();

app.RegisterEndpointDefinitions();

app.Run();