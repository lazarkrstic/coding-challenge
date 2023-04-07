using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheShop.Application.Common.Interfaces;
using TheShop.Domain.Entities;
using TheShop.Infrastructure.Vendor;

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
            using HttpClient client = new HttpClient();
            VendorClient vendorClient = new VendorClient(_supplierUrl, client);

            try
            {
                vendorClient.ArticleInInventoryAsync((int)id).GetAwaiter().GetResult();
                return true;
            }
            catch (ApiException)
            {
                return false;
            }

        }

        public Article GetArticle(uint id)
        {
            using HttpClient client = new HttpClient();
            VendorClient vendorClient = new VendorClient(_supplierUrl, client);

            try
            {
                var dto = vendorClient.GetArticeAsync((int)id).GetAwaiter().GetResult();
                return new Article()
                {
                    Id = (uint)dto.Id,
                    Name = dto.Name,
                    Price = (uint)dto.Price
                };
            }
            catch (ApiException)
            {

                return null;
            }
        }
    }
}
