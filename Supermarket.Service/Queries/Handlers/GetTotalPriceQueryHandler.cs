using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Service.Queries.Handlers
{
    public class GetTotalPriceQueryHandler
    {
        private readonly ICheckoutRepository _repository;

        public GetTotalPriceQueryHandler(ICheckoutRepository repository)
        {
            _repository = repository;
        }

        public int Handle(GetTotalPriceQuery query)
        {
            return query.Execute();
        }
    }
}
