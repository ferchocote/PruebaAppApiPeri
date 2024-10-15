using AplicationServices.DTOs.Currency;
using AplicationServices.DTOs.Generics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicationServices.Application.Contracts.Currency
{
    public interface ICurrencyServices
    {
        Task<RequestResult<List<GetCurrenciesDTO>>> GetCurrencies();
    }
}
