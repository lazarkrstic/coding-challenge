using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheShop.Application.Common.Exceptions;
using TheShop.Application.Common.Interfaces;
using TheShop.Application.Common.Models;

namespace TheShop.Application.Articles.Queries.GetArticle
{
    public class GetArticleQuery : IRequest<ArticleDto>
    {
        public uint Id { get; set; }
    }

    public class GetArticleQueryHandler : IRequestHandler<GetArticleQuery, ArticleDto>
    {
        private ISupplier _supplier;
        private IMapper _mapper;


        public GetArticleQueryHandler(ISupplier supplier, IMapper mapper)
        {
            _supplier = supplier;
            _mapper = mapper;
        }

        public Task<ArticleDto> Handle(GetArticleQuery request, CancellationToken cancellationToken)
        {
            bool articleExists = _supplier.ArticleInInventory(request.Id);
            if (articleExists)
            {
                var article = _supplier.GetArticle(request.Id);
                var articleDto = _mapper.Map<ArticleDto>(article);
                return Task.FromResult(articleDto);
            }
            else
            {
                throw new ArticleNotExistException($"Not exist Article with id: {request.Id}");
            }


        }
    }
}
