using Shop.Domain.Services.Comunications;
using Shop.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Domain.Services
{
    public interface IUserService
    {
        Task<RegisterResponse> RegisterAccount(RegisterResource register);
        Task<LoginResponse> LoginAccount(LoginResource login);
    }
}
