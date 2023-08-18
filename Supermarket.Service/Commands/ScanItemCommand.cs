using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Service.Commands
{
    public class ScanItemCommand
    {
        public char SKU { get; }

        public ScanItemCommand(char sku)
        {
            SKU = sku;
        }
    }
}
