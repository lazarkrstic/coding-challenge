using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheShop.Application.Common.Interfaces;
using TheShop.Domain.Entities;

namespace TheShop.Infrastructure.Services
{
    public class CachedSupplier : ICashedSupplier
    {
        private Dictionary<uint, Article> _cachedArticles = new Dictionary<uint, Article>();
        public bool ArticleInInventory(uint id)
        {
            return _cachedArticles.ContainsKey(id);
        }

        public Article GetArticle(uint id)
        {
            Article? article;
            _cachedArticles.TryGetValue(id, out article);
            return article;
        }

        public void SetArticle(Article article)
        {
            _cachedArticles[article.Id] = article;
        }
    }
}
