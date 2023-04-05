using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheShop.Domain.Entities;

namespace TheShop.Application.Common.Interfaces
{
    public interface IArticleInventory
    {
        bool ArticleInInventory(uint id);
        Article GetArticle(uint id);
    }
}
