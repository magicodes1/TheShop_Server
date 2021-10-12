using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Resources
{
    public class ProductResource
    {

        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int ProductPrice { get; set; }
        public string Image { get; set; }

        public string CategoryName { get; set; }
        public string BrandName { get; set; }
    }
}
