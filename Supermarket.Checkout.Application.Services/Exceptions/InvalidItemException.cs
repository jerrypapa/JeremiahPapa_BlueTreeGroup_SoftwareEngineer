using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Checkout.Application.Exceptions
{
    public class InvalidItemException : Exception
    {
        public InvalidItemException(string message) : base(message)
        {
        }
    }
}
