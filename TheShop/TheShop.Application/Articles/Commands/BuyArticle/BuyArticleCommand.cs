using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheShop.Application.Common.Exceptions;
using TheShop.Application.Common.Interfaces;
using TheShop.Domain.Entities;

namespace TheShop.Application.Articles.Commands.BuyArticle
{
    public class BuyArticleCommand : IRequest
    {
        public uint Id { get; init; }
        public string? Name { get; init; }
        public uint Price { get; init; }
        public uint BuyerId { get; init; }
    }

    public class BuyArticleCommandHandler : IRequestHandler<BuyArticleCommand>
    {
        private readonly IShopApplicationContext _shopApplicationContext;
        private readonly ILogger _logger;

        public BuyArticleCommandHandler(IShopApplicationContext shopApplicationContext, ILogger logger)
        {
            _shopApplicationContext = shopApplicationContext;
            _logger = logger;
        }

        public async Task Handle(BuyArticleCommand request, CancellationToken cancellationToken)
        {
            if (request == null) {
                throw new CouldNotOrderArticleException("Request not defined");
            }

            _logger.LogDebug("Trying to sell article with id=" + request.Id);
            Article article = new Article()
            {
                Id = request.Id,
                Name = request.Name,
                Price = request.Price,
                BuyerId = request.BuyerId,
                Sold = true,
                SoldDate = DateTime.Now
            };

            try
            {
                _shopApplicationContext.Articles.Add(article);
                await _shopApplicationContext.SaveChangesAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                string logErrorMessage = "Could not save article with id=" + request.Id;
                _logger.LogError(logErrorMessage);
                throw new CouldNotSaveArticleException(logErrorMessage, ex);
            }
            _logger.LogInfo("Article with id=" + article.Id + " is sold.");
        }
    }
}
