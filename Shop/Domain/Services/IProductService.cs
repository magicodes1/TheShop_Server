using Shop.Domain.Services.Comunications;
using Shop.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Domain.Services
{
    public interface IProductService
    {
        Task<ProductResponse<ProductDetailResource>> GetProductById(int id);
        Task<ProductResponse<IEnumerable<ProductResource>>> FindProductByName(string name);
        Task<ProductResponse<IEnumerable<ProductResource>>> GetProductByCategoryAndBrand(string categoryName, string brandName);
    }
}
