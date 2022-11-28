using System.Text.Json.Serialization;
using LeadManagement.Services.Api.Configurations;
using MediatR;
using NetDevPack.Identity.User;

var builder = WebApplication.CreateBuilder(args);

builder.Host.ConfigureAppConfiguration((hostingContext, config) =>
{
    var env = hostingContext.HostingEnvironment;

    config.AddJsonFile($"appsettings.{env.EnvironmentName}.json", true, true);
});

// Add services to the container.

// WebAPI Config
builder.Services.AddControllers(options => options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true).AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});

// Swagger Config
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerConfiguration(builder.Environment.EnvironmentName);

// Setting DBContexts
builder.Services.AddDatabaseConfiguration(builder.Configuration);

// Interactive AspNetUser (logged in)
// NetDevPack.Identity dependency
builder.Services.AddAspNetUserConfiguration();

// AutoMapper Settings
builder.Services.AddAutoMapperConfiguration();

// Adding MediatR for Domain Events and Notifications
builder.Services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());

// .NET Native DI Abstraction
builder.Services.AddDependencyInjectionConfiguration();

// Problem Details Config
builder.Services.AddProblemDetailsModelStateConfiguration();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwaggerSetup();
}

app.UseHttpsRedirection();

app.UseRouting();

// Cors policy
var corsPolicy = builder.Configuration.GetSection("CorsPolicy").Value.Split(';').ToArray();
app.UseCors(policyBuilder => policyBuilder.WithOrigins(corsPolicy).AllowAnyHeader().AllowAnyMethod());

app.MapControllers();

app.Run();