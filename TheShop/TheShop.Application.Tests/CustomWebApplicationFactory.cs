using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Moq;

using TheShop.Domain.Entities;
using TheShop.Application.Common.Interfaces;

namespace TheShop.Application.Tests
{
    internal class CustomWebApplicationFactory : WebApplicationFactory<Program>
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureAppConfiguration(configurationBuilder =>
            {
                //var integrationConfig = new ConfigurationBuilder()
                //    .AddJsonFile("appsettings.json")
                //    .AddEnvironmentVariables()
                //    .Build();

                //configurationBuilder.AddConfiguration(integrationConfig);
            });

            builder.ConfigureServices((builder, services) =>
            {

                services.AddTransient<ISupplier>(provider =>
                {
                    var mock = new Mock<ISupplier>();
                    mock.Setup(x => x.ArticleInInventory(It.Is<uint>(id => id == 1))).Returns(true);
                    mock.Setup(x => x.ArticleInInventory(It.Is<uint>(id => id > 1))).Returns(false);

                    mock.Setup(x => x.GetArticle(It.Is<uint>(n => n == 1)))
                        .Returns(new Article() { Id = 1, Name = "Article 1", Price = 100, Sold = true, BuyerId = 1, SoldDate = DateTime.Now });
                    mock.Setup(x => x.GetArticle(It.Is<uint>(n => n > 1)))
                        .Returns(new Article());


                    return mock.Object;
                });
            });
        }

    }

}