using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheShop.Application.Common.Interfaces;
using TheShop.Domain.Entities;

namespace TheShop.Infrastructure.Services
{
    public class WarehouseService : IArticleInventory
    {
        public bool ArticleInInventory(uint id)
        {
            return new Random().NextDouble() >= 0.5;
        }

        public Article GetArticle(uint id)
        {
            return new Article()
            {
                Id = id,
                Name = $"Article {id}",
                Price = (uint) new Random().Next(100, 500)
            };
        }
    }
}
