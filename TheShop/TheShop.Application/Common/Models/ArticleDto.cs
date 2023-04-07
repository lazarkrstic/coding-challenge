using TheShop.Application.Common.Mappings;
using TheShop.Domain.Entities;

namespace TheShop.Application.Common.Models
{
    public class ArticleDto: IMapFrom<Article>
    {

        public int Id { get; init; }
        public string? Name { get; init; }
        public uint Price { get; init; }

    }
}