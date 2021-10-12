using AutoMapper;
using Shop.Domain.Entities;
using Shop.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Mapping
{
    public class EntityToResourceProfile : Profile
    {
        public EntityToResourceProfile()
        {

            // map for product

            CreateMap<Category, ProductResource>();
            CreateMap<Brand, ProductResource>();

            CreateMap<Product, ProductResource>()
                .IncludeMembers(p => p.Category, p => p.Brand);

            //map for bill and bill detail
            CreateMap<BillDetail, BillDetailResource>().ReverseMap();

            CreateMap<Bill, BillResource>()
                .ForMember(dist => dist.billDetailResources, src => src.MapFrom(x => x.BillDetails))
                .ReverseMap();

           

            //map for product detail

            CreateMap<ProductDetail, ProductDetailResource>();

            CreateMap<Category, ProductDetailResource>();
            CreateMap<Brand, ProductDetailResource>();

            CreateMap<Product, ProductDetailResource>()
                .IncludeMembers(p => p.Detail, p => p.Category, p => p.Brand);


            //Map for nav
            CreateMap<Brand, BrandResource>();


            CreateMap<Category, CategoryResource>()
               .ForMember(opt => opt.brands, src => src.MapFrom(x => x.CategoryBrands.Select(y => y.Brand).ToList()));







        }
    }
}
