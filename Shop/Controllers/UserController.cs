using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.Domain.Services;
using Shop.Domain.Exceptions;
using Shop.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace Shop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IUserService userService;


        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register(RegisterResource register)
        {
            if (register == null)
            {
                throw new BadRequestException("Object is null");
            }

            if (!ModelState.IsValid)
            {
               throw new BadRequestException("Invalid model Oject");
            }

            var result = await userService.RegisterAccount(register);

            if (!result.Success)
            {
               throw new BadRequestException(result.Message);
            }
            return Ok(result);
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(LoginResource login)
        {
            if (login == null)
            {
                throw new BadRequestException("Object is null");
            }

            if (!ModelState.IsValid)
            {
                throw new BadRequestException("Invalid model Oject");
            }

            var result = await userService.LoginAccount(login);

            if (!result.Success)
            {
                throw new BadRequestException(result.Message);
            }
            return Ok(result);
        }

    }
}
