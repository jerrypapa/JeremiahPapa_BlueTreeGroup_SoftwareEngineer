using Supermarket.Checkout.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Checkout.Application.Services
{
    public class CheckoutQueryService : ICheckoutQueryService
    {
        private readonly Dictionary<char, Product> _pricingRules;
        private readonly Dictionary<char, int> _products;

        public CheckoutQueryService(Dictionary<char, Product> pricingRules, Dictionary<char, int> items)
        {
            _pricingRules = pricingRules;
            _products = items;
        }

        public int GetTotal()
        {
            int total = 0;

            foreach (var kvp in _products)
            {
                var product = _pricingRules[kvp.Key];
                int productCount = kvp.Value;

                if (product.SpecialPriceQuantity > 1 && productCount >= product.SpecialPriceQuantity)
                {
                    int specialPriceGroups = productCount / product.SpecialPriceQuantity;
                    int remainder = productCount % product.SpecialPriceQuantity;

                    total += specialPriceGroups * product.SpecialPrice + remainder * product.UnitPrice;
                }
                else
                {
                    total += productCount * product.UnitPrice;
                }
            }

            return total;
        }
    }
}