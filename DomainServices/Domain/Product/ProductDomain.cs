using DataAccess.Repository.Interfaces;
using DomainServices.Domain.Contracts.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainServices.Domain.Product
{
    public class ProductDomain : IProductDomain
    {
        private readonly IProductRepository _productRepository;

        public ProductDomain(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<List<PruebaAppApi.DataAccess.Entities.Product>> GetAllProducts() =>
            await _productRepository.GetAllAsync();

        public async Task<PruebaAppApi.DataAccess.Entities.Product?> GetProductById(Guid id) =>
            await _productRepository.GetByIdAsync(id);

        public async Task AddProduct(PruebaAppApi.DataAccess.Entities.Product product)
        {
            await _productRepository.AddAsync(product);
            await _productRepository.SaveChangesAsync();
        }
    }
}
