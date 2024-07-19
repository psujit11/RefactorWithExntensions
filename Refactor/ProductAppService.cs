using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refactor
{
    public  class ProductAppService
    {
        public Product GetProduct(int productID)
        {

            return new Product { ProductId = productID, Quantity = 10 };
        }
    }
}
