using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheShop.Application.Common.Interfaces;

namespace TheShop.Application.Articles.Queries.GetArticleAvailability
{
    public class GetArticleAvailabilityQuery : IRequest<bool>
    {
        public uint Id { get; set; }
    }

    public class GetArticleAvailabilityQueryHandler : IRequestHandler<GetArticleAvailabilityQuery, bool>
    {
        private readonly IBaseDealerSuplier _baseDealerSuplier;

        public GetArticleAvailabilityQueryHandler(IBaseDealerSuplier baseDealerSuplier)
        {
            _baseDealerSuplier = baseDealerSuplier;
        }

        public Task<bool> Handle(GetArticleAvailabilityQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_baseDealerSuplier.ArticleInInventory(request.Id));
        }
    }
}
