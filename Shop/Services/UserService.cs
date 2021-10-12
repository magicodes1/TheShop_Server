using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Shop.Common;
using Shop.Domain.Entities;
using Shop.Domain.JwtConfig;
using Shop.Domain.Services;
using Shop.Domain.Services.Comunications;
using Shop.Resources;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Shop.Services
{
    public class UserService : IUserService
    {

        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        private readonly RoleManager<IdentityRole> roleManager;

        private readonly JwtConfigs jwtOption;

        public UserService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, RoleManager<IdentityRole> roleManager, IOptions<JwtConfigs> jwtOption)
        {
            
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
            this.jwtOption = jwtOption.Value;

        }


        private string TokenGeneration(string username,List<string> roles)
        {
            var secretKey = Hash.Hashkey(jwtOption.Secret);

            var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);


            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier,username),
                new Claim(ClaimTypes.Name,username)
            };

            foreach (var item in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role,item));
            }

            var tokeOptions = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(5),
                signingCredentials: signinCredentials
            );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);

            return tokenString;
        }

        public async Task<LoginResponse> LoginAccount(LoginResource login)
        {
            var result = await signInManager.PasswordSignInAsync(login.UserName, login.Password,false,false);

            if (!result.Succeeded)
            {
                return new LoginResponse(false,"Either user name or password is wrong.","",null);
            }

            var user = await userManager.FindByNameAsync(login.UserName);

            var roles = await userManager.GetRolesAsync(user);
            
           
            var token = TokenGeneration(login.UserName,roles as List<string>);

            var userResource = new UserResource { UserId = user.Id,UserName=user.UserName};

            return new LoginResponse(true,"",token,userResource);
        }

        public async Task<RegisterResponse> RegisterAccount(RegisterResource register)
        {
            var user = new ApplicationUser { UserName=register.UserName};

            var result = await userManager.CreateAsync(user, register.Password);


            if (!result.Succeeded)
            {
                return new RegisterResponse($"Register user {register.UserName} has been fail.");
            }

            if (!await roleManager.RoleExistsAsync(register.Role))
            {
                await roleManager.CreateAsync(new IdentityRole(register.Role));
            }

            var existUser = await userManager.FindByNameAsync(register.UserName);

            if (existUser == null)
            {
                return new RegisterResponse($"User {register.UserName} has not found.");
            }

            await userManager.AddToRoleAsync(existUser, register.Role);

            return new RegisterResponse();
        }
    }
}
