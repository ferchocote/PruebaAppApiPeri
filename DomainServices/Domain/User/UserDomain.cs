using DataAccess.Repositories.Contracts;
using DomainServices.Domain.Contracts.User;
using Microsoft.EntityFrameworkCore;
using PruebaAppApi.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainServices.Domain.User
{
    public class UserDomain : IUserDomain
    {
        private readonly IUserRepository _userRepository;

        public UserDomain(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<PruebaAppApi.DataAccess.Entities.User> GetUser(string documentNumber)
        {
            return await _userRepository.GetByDocumentNumberAsync(documentNumber);
        }
    }
}
