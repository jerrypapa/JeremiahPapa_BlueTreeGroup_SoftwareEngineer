using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Infrastructure.Dtos
{
    public class Item
    {
        public char SKU { get; }
        public int UnitPrice { get; }
        public ISpecialOffer SpecialOffer { get; }

        public Item(char sku, int unitPrice, ISpecialOffer specialOffer = null)
        {
            SKU = sku;
            UnitPrice = unitPrice;
            SpecialOffer = specialOffer;
        }
    }
}
