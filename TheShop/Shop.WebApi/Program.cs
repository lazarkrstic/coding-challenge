using Microsoft.OpenApi.Models;
using System.Reflection;
using System.Web.Http;
using TheShop.Infrastructure;
using TheShop.Application;
using Shop.WebApi;
using TheShop.Domain.Entities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers()
    .AddXmlSerializerFormatters();

List<Article> articlesDbSeed = new List<Article>()
{
    new Article() {Id = 1, Name = "Article 1", Price = 100, Sold = true, SoldDate = DateTime.Now, BuyerId = 1},
    new Article() {Id = 2, Name = "Article 2", Price = 200, Sold = true, SoldDate = DateTime.Now, BuyerId = 1},
    new Article() {Id = 3, Name = "Article 3", Price = 300, Sold = true, SoldDate = DateTime.Now, BuyerId = 2},
    new Article() {Id = 4, Name = "Article 4", Price = 400, Sold = true, SoldDate = DateTime.Now, BuyerId = 2},
    new Article() {Id = 5, Name = "Article 5", Price = 500, Sold = true, SoldDate = DateTime.Now, BuyerId = 3},
    new Article() {Id = 6, Name = "Article 6", Price = 600, Sold = true, SoldDate = DateTime.Now, BuyerId = 3}
};

builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(builder.Configuration, true, articlesDbSeed);
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
