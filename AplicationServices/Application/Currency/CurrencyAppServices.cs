using AplicationServices.Application.Contracts.Currency;
using AplicationServices.Application.Contracts.Helpers;
using AplicationServices.DTOs.Currency;
using AplicationServices.DTOs.Generics;
using AutoMapper;
using DomainServices.Domain.Contracts.Currency;
using Microsoft.Extensions.Configuration;
using PruebaAppApi.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AplicationServices.Application.Currency
{
    public class CurrencyAppServices : ICurrencyServices
    {
        /// <summary>
        /// Instancia al servicio de Dominio
        /// </summary>
        private readonly ICurrencyDomain _currencyDomain;
        private readonly ILoggerServices _loggerService;

        /// <summary>
        /// Mapper
        /// </summary>
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public CurrencyAppServices(ICurrencyDomain currencyDomain, IConfiguration configuration, IMapper mapper, ILoggerServices loggerService)
        {
            _currencyDomain = currencyDomain;
            _configuration = configuration;
            _mapper = mapper;
            _loggerService = loggerService;
        }

        /// <summary>
        /// Consulta los tipos de moneda activas
        /// </summary>
        /// <returns></returns>
        public async Task<RequestResult<List<GetCurrenciesDTO>>> GetCurrencies()
        {
            try
            {

                var result = await _currencyDomain.GetCurrencies();

                string resultJson = JsonSerializer.Serialize(result);
                _loggerService.LogInfo(string.Concat("Acción ejecutada. GetCurrencies ", resultJson));

                return RequestResult<List<GetCurrenciesDTO>>.CreateSuccessful(_mapper.Map<List<Currency_DM>, List<GetCurrenciesDTO>>(result));

            }
            catch (Exception ex)
            {
                _loggerService.LogError(string.Concat("Error GetCurrencies. ", ex.InnerException));
                return RequestResult<List<GetCurrenciesDTO>>.CreateError(ex.Message);

            }
        }
    }
}
