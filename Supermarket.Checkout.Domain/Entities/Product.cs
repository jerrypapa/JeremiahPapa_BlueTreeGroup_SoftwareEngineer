using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Checkout.Domain.Entities
{
    public class Product
    {
        public char SKU { get; }
        public int UnitPrice { get; }
        public int SpecialPriceQuantity { get; }
        public int SpecialPrice { get; }
        public Product(char sku, int unitPrice)
        {
            SKU = sku;
            UnitPrice = unitPrice;
            SpecialPriceQuantity = 1;
            SpecialPrice = unitPrice;
        }

        public Product(char sku, int unitPrice, int specialPriceQuantity, int specialPrice)
        {
            SKU = sku;
            UnitPrice = unitPrice;
            SpecialPriceQuantity = specialPriceQuantity;
            SpecialPrice = specialPrice;
        }
    }
}
