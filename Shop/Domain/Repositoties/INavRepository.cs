using Shop.Domain.Entities;
using Shop.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Domain.Repositoties
{
    public interface INavRepository
    {
        Task<IEnumerable<CategoryResource>> GetAllCategory();
    }
}
