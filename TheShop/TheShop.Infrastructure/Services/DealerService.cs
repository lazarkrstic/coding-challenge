using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheShop.Application.Common.Interfaces;
using TheShop.Domain.Entities;

namespace TheShop.Infrastructure.Services
{
    public class DealerService : ISupplier
    {
        private readonly string _supplierUrl;

        public DealerService(string supplierUrl)
        {
            _supplierUrl = supplierUrl;
        }

        public bool ArticleInInventory(uint id)
        {
            throw new NotImplementedException();
        }

        public Article GetArticle(uint id)
        {
            throw new NotImplementedException();
        }
    }
}
