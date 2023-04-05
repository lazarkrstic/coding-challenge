using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheShop.Domain.Common;

namespace TheShop.Domain.Entities
{
    public class Article : BaseEntity
    {
        public string Name { get; set; }
        public uint Price { get; set; }
        public bool Sold { get; set; }
        public DateTime SoldDate { get; set; }
        public uint BuyerId { get; set; }
    }
}
