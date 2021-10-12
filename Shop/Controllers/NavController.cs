using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.Domain.Entities;
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
    public class NavController : ControllerBase
    {
        private readonly INavService _navService;

        public NavController(INavService navService)
        {
            _navService = navService;
        }

        [HttpGet]
        public async Task<IActionResult> get()
        {
            var productResponse = await _navService.GetAllCategory();

            return Ok(productResponse);
        }
    }
}
