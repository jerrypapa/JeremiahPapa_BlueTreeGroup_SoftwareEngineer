using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Infrastructure.Dtos
{
    public class Checkout
    {
        private readonly Dictionary<char, Item> items = new Dictionary<char, Item>();
        private readonly Dictionary<char, int> scannedItems = new Dictionary<char, int>();

        public void SetPricing(IEnumerable<Item> pricingRules)
        {
            foreach (var rule in pricingRules)
            {
                items[rule.SKU] = rule;
            }
        }

        public void Scan(char sku)
        {
            if (!items.ContainsKey(sku))
            {
                throw new ArgumentException($"Invalid SKU: {sku}");
            }

            if (!scannedItems.ContainsKey(sku))
            {
                scannedItems[sku] = 1;
            }
            else
            {
                scannedItems[sku]++;
            }
        }

        public int GetTotalPrice()
        {
            int totalPrice = 0;
            foreach (var kvp in scannedItems)
            {
                char sku = kvp.Key;
                int itemCount = kvp.Value;
                Item item = items[sku];

                if (item.SpecialOffer != null)
                {
                    totalPrice += item.SpecialOffer.GetTotalPrice(itemCount);
                }
                else
                {
                    totalPrice += itemCount * item.UnitPrice;
                }
            }
            return totalPrice;
        }
    }
}
