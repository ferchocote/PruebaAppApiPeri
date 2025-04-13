using AutoMapper;
using PruebaAppApi.DataAccess.Entities;
using AplicationServices.DTOs.Product;

namespace PruebaAppApi.AutoMapper
{
    public class ProductMapperProfile : Profile
    {
        public ProductMapperProfile()
        {
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<CreateProductDto, Product>();
        }
    }
}
