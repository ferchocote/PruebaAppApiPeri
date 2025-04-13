using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AplicationServices.DTOs.Product;

namespace AplicationServices.Application.Contracts.Product
{
    public interface IProductAppService
    {
        Task<List<ProductDto>> GetAllAsync();
        Task<ProductDto> GetByIdAsync(Guid id);
        Task<bool> CreateAsync(CreateProductDto createDto);
    }
}
