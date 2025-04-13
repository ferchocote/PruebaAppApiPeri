using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AplicationServices.Application.Contracts.Product;
using AplicationServices.DTOs.Product;
using AutoMapper;
using DataAccess.Repository.Interfaces;
using DomainServices.Domain.Contracts.Product;
using PruebaAppApi.DataAccess.Entities;

namespace AplicationServices.Application.Product
{
    

    public class ProductAppService : IProductAppService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductAppService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<List<ProductDto>> GetAllAsync()
        {
            var products = await _productRepository.GetAllAsync();
            return _mapper.Map<List<ProductDto>>(products);
        }

        public async Task<ProductDto> GetByIdAsync(Guid id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            return _mapper.Map<ProductDto>(product);
        }

        public async Task<bool> CreateAsync(CreateProductDto createDto)
        {
            var product = _mapper.Map<PruebaAppApi.DataAccess.Entities.Product>(createDto);
            product.ID = Guid.NewGuid();
            return await _productRepository.AddAsync(product);
        }
    }
}
