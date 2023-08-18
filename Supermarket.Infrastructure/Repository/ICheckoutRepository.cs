using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Infrastructure.Repository
{
    public interface ICheckoutRepository
    {
        Checkout GetCheckout();
        void SaveCheckout(Checkout checkout);
    }
}
