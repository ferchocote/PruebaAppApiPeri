using DataAccess.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using PruebaAppApi.DataAccess.DataAccess;
using PruebaAppApi.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly PruebaPeriContext _context;

        public UserRepository(PruebaPeriContext context)
        {
            _context = context;
        }

        public async Task<User> GetByDocumentNumberAsync(string documentNumber)
        {
            return await _context.User
                                 .Where(x => x.DocumentNumber == documentNumber)
                                 .FirstOrDefaultAsync();
        }
    }
}
