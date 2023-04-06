using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using TheShop.Application.Common.Interfaces;
using TheShop.Domain.Entities;

namespace TheShop.Infrastructure.Persistence
{
    public class ShopApplicationContext : DbContext, IShopApplicationContext
    {
        public DbSet<Article> Articles { get; set; }

        public ShopApplicationContext(DbContextOptions<ShopApplicationContext> options)
         : base(options)
        {
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            return await base.SaveChangesAsync(cancellationToken);
        }

        public async Task SeedAsync(CancellationToken cancellationToken)
        {

            var items = new List<Article>()
            {
                new Article() {Id = 1, Name = "demo article 1", Price = 100, Sold = true, SoldDate = DateTime.Now, BuyerId = 1},
                new Article() {Id = 2, Name = "demo article 2", Price = 200, Sold = true, SoldDate = DateTime.Now, BuyerId = 1},
                new Article() {Id = 3, Name = "demo article 3", Price = 300, Sold = true, SoldDate = DateTime.Now, BuyerId = 2},
                new Article() {Id = 4, Name = "demo article 4", Price = 400, Sold = true, SoldDate = DateTime.Now, BuyerId = 2},
            };
            await SeedAsync(items, cancellationToken);
        }

        public async Task SeedAsync(List<Article> articles,  CancellationToken cancellationToken)
        {
            Articles.AddRange(articles);
            await SaveChangesAsync(cancellationToken);
        }

    }
}
