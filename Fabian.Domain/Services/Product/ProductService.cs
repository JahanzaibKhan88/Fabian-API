using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fabian.Domain.Services.Product
{
    public class ProductService : IProductService
    {
        public bool ValidateProductSku(string sku)
        {
            // perform some domain service operations like validating sku over a predefined pattern according to company policy etc...
            // this is just a demo service method
            return true;
        }
    }
}
