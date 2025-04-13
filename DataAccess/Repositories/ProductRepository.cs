using DataAccess.Repositories.Base;
using DataAccess.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using PruebaAppApi.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly PruebaPeriContext _context;

        public ProductRepository(PruebaPeriContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Product>> GetAsync()
        {
            return await _context.Product.ToListAsync();
        }
    }
}
