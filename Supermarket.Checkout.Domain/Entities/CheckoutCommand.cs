using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Checkout.Domain.Entities
{
    public class CheckoutCommand
    {
        public char Item { get; }

        public CheckoutCommand(char item)
        {
            Item = item;
        }
    }
}
