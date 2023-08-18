using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Service.Queries
{
    public class GetTotalPriceQuery
    {
        public int Execute()
        {
            var checkout = _repository.GetCheckout();
            return checkout.GetTotalPrice();
        }
    }
}
