using Microsoft.AspNetCore.Authorization;
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
    public class CartController : ControllerBase
    {
        private readonly ICartService _cartService;

        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }

        [Authorize(Roles = "User")]
        [HttpPost]
        public async Task<IActionResult> AddToCart(AddToCartResource addToCart)
        {

            if (addToCart == null)
            {
                throw new BadRequestException("Object is null");
            }

            if (addToCart.Bill == null)
            {
                throw new BadRequestException(" Bill Object is null");
            }

            if (addToCart.BillDetail == null || addToCart.BillDetail.Count <= 0)
            {
                throw new BadRequestException(" Bill detail Object is null");
            }

            if (!ModelState.IsValid)
            {
                throw new BadRequestException("Invalid Object");
            }

            var result = await _cartService.AddToCart(addToCart);

            if (!result.Success)
            {
                throw new BadRequestException(result.Message);
            }

            return Ok(result);
        }
    }
}
