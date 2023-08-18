using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Service.Commands.Handlers
{
    public class ScanItemCommandHandler
    {
        private readonly ICheckoutRepository _repository;

        public ScanItemCommandHandler(ICheckoutRepository repository)
        {
            _repository = repository;
        }

        public void Handle(ScanItemCommand command)
        {
            var checkout = _repository.GetCheckout();
            checkout.Scan(command.SKU);
            _repository.SaveCheckout(checkout);
        }
    }
}
