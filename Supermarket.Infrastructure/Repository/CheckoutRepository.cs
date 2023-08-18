using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Infrastructure.Repository
{
    public class CheckoutRepository: ICheckoutRepository
    {
        private Checkout _checkout;

        public CheckoutRepository()
        {
            _checkout = new Checkout();
        }

        public Checkout GetCheckout()
        {
            return _checkout;
        }

        public void SaveCheckout(Checkout checkout)
        {
            _checkout = checkout;
        }
    }
}
