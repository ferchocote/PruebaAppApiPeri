using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PruebaAppApi.DataAccess.Entities;

namespace DomainServices.Domain.Contracts.Product
{
    public interface IProductDomain
    {
        Task<List<PruebaAppApi.DataAccess.Entities.Product>> GetAllProducts();
        Task<PruebaAppApi.DataAccess.Entities.Product?> GetProductById(Guid id);
        Task AddProduct(PruebaAppApi.DataAccess.Entities.Product product);
    }
}
