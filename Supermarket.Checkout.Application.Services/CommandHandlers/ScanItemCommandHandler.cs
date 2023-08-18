using MediatR;
using Supermarket.Checkout.Application.Commands;
using Supermarket.Checkout.Application.Exceptions;
using Supermarket.Checkout.Application.Services;
using Supermarket.Checkout.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Supermarket.Checkout.Application.CommandHandlers
{
    public class ScanItemCommandHandler: IRequestHandler<ScanItemCommand,Unit>
    {
        private readonly Dictionary<char, Product> _pricingRules;
        private readonly Dictionary<char, int> _items;

        public ScanItemCommandHandler(Dictionary<char, Product> pricingRules)
        {
            _pricingRules = pricingRules;
            _items = new Dictionary<char, int>();
        }

        public Task<Unit> Handle(ScanItemCommand request, CancellationToken cancellationToken)
        {
            char item = request.Product;

            if (_pricingRules.ContainsKey(item))
            {
                if (_items.ContainsKey(item))
                {
                    _items[item]++;
                }
                else
                {
                    _items[item] = 1;
                }
            }
            else
            {
                throw new InvalidItemException("Invalid item scanned.");
            }

            return Task.FromResult(Unit.Value);
        }

    }
}