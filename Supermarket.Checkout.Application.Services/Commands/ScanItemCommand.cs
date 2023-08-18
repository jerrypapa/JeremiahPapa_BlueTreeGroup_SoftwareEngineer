using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Checkout.Application.Commands
{
    public class ScanItemCommand:IRequest<Unit>
    {
        public char Product { get; }

        public ScanItemCommand(char product)
        {
            Product = product;
        }
    }
}
