using TheShop.Domain.Entities;

namespace TheShop.Application.Common.Interfaces
{
    public interface IArticleInventory
    {
        bool ArticleInInventory(uint id);
        Article GetArticle(uint id);
    }
}
