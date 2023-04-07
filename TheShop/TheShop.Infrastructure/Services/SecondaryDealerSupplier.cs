using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheShop.Application.Common.Interfaces;

namespace TheShop.Infrastructure.Services
{
    public class SecondaryDealerSupplier : DealerService, ISecondaryDealerSupplier
    {
        public SecondaryDealerSupplier(string supplierUrl) : base(supplierUrl)
        {
        }
    }
}
