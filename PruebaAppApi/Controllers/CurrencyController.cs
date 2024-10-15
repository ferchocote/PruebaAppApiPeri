using AplicationServices.Application.Contracts.Currency;
using AplicationServices.DTOs.Currency;
using AplicationServices.DTOs.Generics;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace PruebaAppApi.Controllers
{
    [ApiController]
    [Route("Api/Currency")]
    public class CurrencyController
    {
        /// <summary>
        /// Instancia al servicio de aplicación
        /// </summary>
        private readonly ICurrencyServices _CurrencyServices;

        public CurrencyController(ICurrencyServices ICurrencyServices)
        {

            _CurrencyServices = ICurrencyServices;
        }

        /// <summary>
        /// Consulta los tipos de moneda activas
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetCurrencies")]
        public async Task<RequestResult<List<GetCurrenciesDTO>>> GetCurrencies()
        {
            return await _CurrencyServices.GetCurrencies();
        }
    }
}
