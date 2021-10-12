using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Domain.Services.Comunications
{
    public class RegisterResponse : BaseResponse
    {
      
        private RegisterResponse(bool success, string message) : base (success,message)
        {
            
        }

        public RegisterResponse():this(true,"")
        {

        }

        public RegisterResponse(string message):this(false,message)
        {

        }


    }
}
