using Supermarket.Checkout.Application.Exceptions;
using Supermarket.Checkout.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Checkout.Application.Services
{
    public class CheckoutCommandService : ICheckoutCommandService
    {
        private readonly Dictionary<char, Product> _pricingRules;
        private readonly Dictionary<char, int> _products;

        public CheckoutCommandService(Dictionary<char, Product> pricingRules)
        {
            _pricingRules = pricingRules;
            _products = new Dictionary<char, int>();
        }

        public void Scan(char item)
        {
            if (_pricingRules.ContainsKey(item))
            {
                if (_products.ContainsKey(item))
                {
                    _products[item]++;
                }
                else
                {
                    _products[item] = 1;
                }
            }
            else
            {
                throw new InvalidItemException("Invalid product scanned.");
            }
        }
    }
}
