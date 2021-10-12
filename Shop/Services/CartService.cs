using AutoMapper;
using Shop.Domain.Entities;
using Shop.Domain.Repositoties;
using Shop.Domain.Services;
using Shop.Domain.Services.Comunications;
using Shop.Persistence.Contexts;
using Shop.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Shop.Services
{
    public class CartService : ICartService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CartService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<CartResponse> AddToCart(AddToCartResource cartResource, CancellationToken cancellationToken = default)
        {
            try
            {
                cartResource.Bill.billDetailResources=cartResource.BillDetail;

                var bill = _mapper.Map<Bill>(cartResource.Bill);

                await _unitOfWork.billRepository.AddBill(bill);
                await _unitOfWork.SaveChangesAsync(cancellationToken);

                return new CartResponse(true, "");
            }
            catch (Exception e)
            {

                return new CartResponse(false, e.Message);
            }
        }
    }
}
