using Shop.Domain.Repositoties;
using Shop.Domain.Services;
using Shop.Domain.Services.Comunications;
using Shop.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Services
{
    public class ProductService : IProductService
    {

        private readonly IUnitOfWork _unitOfWork;

        public ProductService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ProductResponse<IEnumerable<ProductResource>>> GetProductByCategoryAndBrand(string categoryName, string brandName)
        {
            var products = await _unitOfWork.productRepository.GetProductByCategoryAndBrand(categoryName,brandName);
            if (products == null)
            {
                return new ProductResponse<IEnumerable<ProductResource>>(false, $"There are no products match to {categoryName}&{brandName}",null);
            }
            return new ProductResponse<IEnumerable<ProductResource>>(true, "", products);
        }

        public async Task<ProductResponse<IEnumerable<ProductResource>>> FindProductByName(string name)
        {
            var products = await _unitOfWork.productRepository.FindProductByName(name);
            return new ProductResponse<IEnumerable<ProductResource>>(true, "", products);
        }

        public async Task<ProductResponse<ProductDetailResource>> GetProductById(int id)
        {
            var product = await _unitOfWork.productRepository.GetProductById(id);
            if (product == null)
            {
                return new ProductResponse<ProductDetailResource>(false, $"Not Found for {id}", null);
            }
            return new ProductResponse<ProductDetailResource>(true, "", product);
        }
    }
}
