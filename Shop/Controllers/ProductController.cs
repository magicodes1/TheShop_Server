using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.Domain.Exceptions;
using Shop.Domain.Services;
using Shop.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("{productId}")]
        public async Task<IActionResult> GetProductByID(int? productId)
        {
            if (productId == null)
            {
                throw new BadRequestException("Your Id is null");
            }

            var productResponse = await _productService.GetProductById((int)productId);

            if (!productResponse.Success)
            {
                throw new BadRequestException(productResponse.Message);
            }
            return Ok(productResponse);
        }

        [HttpGet]
        [Route("search/{productName}")]
        public async Task<IActionResult> GetProductByName(string productName)
        {
            if (string.IsNullOrEmpty(productName))
            {
                throw new BadRequestException("Your Id is null");
            }

            var productResponse = await _productService.FindProductByName(productName);

            return Ok(productResponse);
        }

        [HttpGet]
        public async Task<IActionResult> GetProductByCategoryAndBrand([FromQuery] string categoryName, string brandName)
        {
            if (string.IsNullOrEmpty(categoryName) || string.IsNullOrEmpty(brandName))
            {
                throw new BadRequestException("Your Id is null");
            }

            var productResponse = await _productService.GetProductByCategoryAndBrand(categoryName, brandName);

            if (!productResponse.Success)
            {
                throw new BadRequestException(productResponse.Message);
            }
            return Ok(productResponse);
        }
    }
}
