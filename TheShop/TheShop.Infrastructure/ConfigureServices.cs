using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheShop.Application.Common.Interfaces;
using TheShop.Infrastructure.Persistence;
using Microsoft.Extensions.Configuration;
using TheShop.Infrastructure.Services;


namespace TheShop.Infrastructure
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            if (configuration != null)
            {
                bool useInMemoryDatabese = true;
                bool.TryParse(configuration["UseInMemoryDatabase"], out useInMemoryDatabese);

                if (useInMemoryDatabese)
                {
                    services.AddDbContext<ShopApplicationContext>(options =>
                        options.UseInMemoryDatabase("ShopApplicationDatabase"));
                }
                else
                {
                    // TODO
                }

                services.AddScoped<IShopApplicationContext>(provider => provider.GetRequiredService<ShopApplicationContext>());

                if (useInMemoryDatabese)
                {
                    ShopApplicationContext shopApplicationContext = services.BuildServiceProvider().GetRequiredService<ShopApplicationContext>();
                    shopApplicationContext.SeedAsync(default).GetAwaiter().GetResult();

                }

                services.AddTransient<IArticleInventory, WarehouseService>();
                services.AddTransient<ISupplier, SupplierService>();
                services.AddTransient<ILogger, ConsoleLoggerService>();


                services.AddTransient<IPrimaryDealerSupplier>(provider => new PrimaryDealerService(configuration["Dealers:Primary"]));
                services.AddTransient<ISecondaryDealerSupplier>(provider => new SecondaryDealerSupplier(configuration["Dealers:Secondary"]));

            }
            return services;
        }
    }
}
