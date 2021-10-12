using Shop.Domain.Entities;
using Shop.Domain.Repositoties;
using Shop.Domain.Services;
using Shop.Domain.Services.Comunications;
using Shop.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Services
{
    public class NavService : INavService
    {
        private readonly IUnitOfWork _unitOfWork;

        public NavService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<NavResponse> GetAllCategory()
        {
            var categories = await _unitOfWork.navRepository.GetAllCategory();

            return new NavResponse(true, "", categories);
        }
    }
}
