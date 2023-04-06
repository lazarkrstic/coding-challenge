using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheShop.Domain.Entities;

namespace TheShop.Application.Common.Interfaces
{
    public interface IShopApplicationContext
    {
        DbSet<Article> Articles { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
