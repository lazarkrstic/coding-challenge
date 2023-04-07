using Microsoft.OpenApi.Models;
using System.Reflection;
using System.Web.Http;
using TheShop.Infrastructure;
using TheShop.Application;
using Vendor.WebApi;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddXmlSerializerFormatters();

builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddWebApiServices();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllerRoute(name: "DefaultApi",
              pattern: "api/{controller}/{id}",
              defaults: new { id = RouteParameter.Optional });
app.MapControllers();
app.Run();
