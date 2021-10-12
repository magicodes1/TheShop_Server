using Shop.Domain.Entities;
using Shop.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Domain.Repositoties
{
    public interface IProductRepository
    {
        Task<ProductDetailResource> GetProductById(int id);
        Task<IEnumerable<ProductResource>> FindProductByName(string name);
        Task<IEnumerable<ProductResource>> GetProductByCategoryAndBrand(string categoryName,string brandName);
    }
}
