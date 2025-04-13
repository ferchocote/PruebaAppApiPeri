using PruebaAppApi.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Contracts
{
    public interface IUserRepository
    {
            Task<User> GetByDocumentNumberAsync(string documentNumber);
    }
}
