using DomainServices.Domain.Contracts.Currency;
using Microsoft.EntityFrameworkCore;
using PruebaAppApi.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainServices.Domain.Currency
{
    public class CurrencyDomain : ICurrencyDomain
    {
        private readonly TestDBContext _context;
        public CurrencyDomain(TestDBContext testDBContext)
        {
            _context = testDBContext;
        }

        /// <summary>
        /// Consulta los tipos de moneda activas
        /// </summary>
        /// <returns></returns>
        public async Task<List<Currency_DM>> GetCurrencies()
        {
            return await _context.Currency_DM.Where(i => i.State == true).AsNoTracking().ToListAsync();

        }
    }
}
