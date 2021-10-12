using Shop.Domain.Entities;
using Shop.Domain.Services.Comunications;
using Shop.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Domain.Services
{
    public interface INavService
    {
        Task<NavResponse> GetAllCategory();
    }
}
