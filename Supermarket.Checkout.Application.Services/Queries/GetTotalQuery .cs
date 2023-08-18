using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Checkout.Application.Queries
{
    public class GetTotalQuery : IRequest<int>
    {
    }
}
