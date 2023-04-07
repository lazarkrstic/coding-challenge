using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheShop.Application.Articles.Queries.GetArticle;
using TheShop.Application.Common.Exceptions;
using TheShop.Application.Common.Interfaces;
using TheShop.Application.Common.Models;

namespace TheShop.Application.Articles.Queries.SearchForArticle
{
    public class SearchForArticleQuery : GetArticleQuery
    {
        [DefaultValue(200)]
        public uint MaxExpectedPrice { get; init; }
    }

    public class SearchForArticleQueryHandler : IRequestHandler<SearchForArticleQuery, ArticleDto>
    {
        private readonly ICashedSupplier _cashedSupplier;
        private readonly List<IArticleInventory> articleInventories;

        private readonly IMapper _autoMapper;

        public SearchForArticleQueryHandler(
            ICashedSupplier cashedSupplier, 
            IArticleInventory articleInventory, 
            IPrimaryDealerSupplier primaryDealerSupplier, 
            ISecondaryDealerSupplier secondaryDealerSupplier,
            IMapper mapper)
        {
            _cashedSupplier = cashedSupplier;
            articleInventories = new List<IArticleInventory>
            {
                cashedSupplier,
                articleInventory,
                primaryDealerSupplier,
                secondaryDealerSupplier
            };
            
            _autoMapper = mapper;
        }

        public Task<ArticleDto> Handle(SearchForArticleQuery request, CancellationToken cancellationToken)
        {

            foreach (var item in articleInventories)
            {
                bool articleExists = item.ArticleInInventory(request.Id);
                if (articleExists) {
                    var article = item.GetArticle(request.Id);
                    if  (article != null && article.Price <= request.MaxExpectedPrice)
                    {
                        if (item != _cashedSupplier)
                        {
                            _cashedSupplier.SetArticle(article);
                        }
                        ArticleDto articleDto = _autoMapper.Map<ArticleDto>(article);
                        return Task.FromResult(articleDto);
                    }

                }
            }

            throw new ArticleNotExistException($"Not exist Article with id: {request.Id} and price lower or equal {request.MaxExpectedPrice}");
        }
    }
}
