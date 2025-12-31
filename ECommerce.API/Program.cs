using Ecommerce.Infrastructure;
using Ecommerce.Core;
using ECommerce.API.Middlewares;
using System.Text.Json.Serialization;
using Ecommerce.Core.Mappers;
using FluentValidation.AspNetCore;
var builder = WebApplication.CreateBuilder(args);


//Add Infrastructure service
builder.Services.AddInfrastructure();

// Add Core Services 
builder.Services.AddCore();

// Add controllers to the service Collection
//builder.Services.AddControllers();
builder.Services.AddControllers().AddJsonOptions
    (options =>
    {
        options.JsonSerializerOptions.Converters.Add
        (new JsonStringEnumConverter());
    });
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddAutoMapper(typeof
    (ApplicationUserMappingProfile).Assembly);
var app = builder.Build();
app.UseExceptionHandlingMiddleware();

//app.MapGet("/", () => "Hello World!");

// Routing
app.UseRouting();

// Auth 
app.UseAuthentication();
app.UseAuthorization();

//Controller routes
app.MapControllers();

app.Run();
