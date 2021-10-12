using Shop.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Shop.Domain.Services.Comunications
{
    public class LoginResponse : BaseResponse
    {
        public string Token { get; set; }
        public UserResource User { get; set; }

        public LoginResponse(bool success, string message, string token, UserResource user) : base(success, message)
        {
            Token = token;
            User = user;
        }
    }
}
