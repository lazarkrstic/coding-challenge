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
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration, bool addDealers = false)
        {
            if (configuration != null)
            {

                bool.TryParse(configuration["UseInMemoryDatabase"], out bool useInMemoryDatabese);

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
                services.AddTransient<ICashedSupplier, CachedSupplier>();

                LogLevel logLevel = LogLevel.Debug;
                if (Enum.TryParse(configuration["Logging:LogLevel:Default"], out logLevel))
                {
                    services.AddTransient<ILogger>(provider => new ConsoleLoggerService(logLevel));
                }
                else
                {
                    services.AddTransient<ILogger, ConsoleLoggerService>();
                }

                string? primaryDealerUrl = configuration["Dealers:PrimaryUrl"];
                string? secondaryDealerUrl = configuration["Dealers:SecondaryUrl"];

                if (addDealers)
                {
                    if (string.IsNullOrEmpty(primaryDealerUrl))
                    {
                        throw new ArgumentException("Primary Dealer URL not set");
                    }
                    if (string.IsNullOrEmpty(secondaryDealerUrl))
                    {
                        throw new ArgumentException("Secundary Dealer URL not set");
                    }
                }
                else
                {
                    primaryDealerUrl =  string.Empty;
                    secondaryDealerUrl = string.Empty;
                }
                services.AddTransient<IPrimaryDealerSupplier>(provider => new PrimaryDealerService(primaryDealerUrl));
                services.AddTransient<ISecondaryDealerSupplier>(provider => new SecondaryDealerSupplier(secondaryDealerUrl));

            }

            return services;
        }
    }
}
