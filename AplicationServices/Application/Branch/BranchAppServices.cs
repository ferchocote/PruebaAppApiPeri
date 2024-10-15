using AplicationServices.Application.Contracts.Branch;
using AplicationServices.Application.Contracts.Helpers;
using AplicationServices.DTOs.Branch;
using AplicationServices.DTOs.Generics;
using AplicationServices.Helpers.TextResorce;
using AutoMapper;
using DomainServices.Domain.Contracts.Branch;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using PruebaAppApi.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;



namespace AplicationServices.Application.Branch
{
    public class BranchAppServices : IBranchServices
    {
        /// <summary>
        /// Instancia al servicio de Dominio
        /// </summary>
        private readonly IBranchDomain _branchDomain;
        private readonly ILoggerServices _loggerService;

        /// <summary>
        /// Mapper
        /// </summary>
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;


        public BranchAppServices(IBranchDomain branchDomain, IConfiguration configuration, IMapper mapper, ILoggerServices loggerService)
        {
            _branchDomain = branchDomain;
            _configuration = configuration;
            _mapper = mapper;
            _loggerService = loggerService;
        }

        /// <summary>
        /// Agrega o actualiza una sucursal una sucursal
        /// </summary>
        /// <returns></returns>
        public async Task<RequestResult<ResponseAddBranchDto>> AddorUpdateBranch(RequestAddBranchDto request)
        {
            try
            {
                ResponseAddBranchDto responseAddDesiredProductDto = new ResponseAddBranchDto();

                #region Validaciones
                List<string> errorMessageValidations = new List<string>();
                AddBranchValidations(ref errorMessageValidations, request);
                if (errorMessageValidations.Any())
                    return RequestResult<ResponseAddBranchDto>.CreateUnsuccessful(null, errorMessageValidations);
                #endregion

                Branch_DM branch_DM = _mapper.Map<RequestAddBranchDto, Branch_DM>(request);

                Guid? result = await _branchDomain.AddorUpdateBranch(branch_DM, request.UpdateDto);

                string resultJson = JsonSerializer.Serialize(result);
                _loggerService.LogInfo(string.Concat("Acción ejecutada. AddorUpdateBranch ", resultJson));

                if (result == null)
                {
                    return RequestResult<ResponseAddBranchDto>.CreateUnsuccessful(null, new string[] { ResourceUserMsm.ErrorAddingBranch });
                }
                else
                {
                    responseAddDesiredProductDto.IdBranchDto = result.Value;
                    return RequestResult<ResponseAddBranchDto>.CreateSuccessful(responseAddDesiredProductDto);
                }

            }
            catch (Exception ex)
            {
                _loggerService.LogError(string.Concat("Error AddorUpdateBranch. ", ex.InnerException));
                return RequestResult<ResponseAddBranchDto>.CreateError(ex.Message);

            }
        }

        /// <summary>
        /// Obtiene las sucursales activas
        /// </summary>
        /// <returns></returns>
        public async Task<RequestResult<List<GetBranchesDTO>>> GetBranches()
        {
            try
            {
                // Configuración del serializador JSON
                var options = new JsonSerializerOptions
                {
                    ReferenceHandler = ReferenceHandler.Preserve, // Habilita el manejo de referencias cíclicas
                    WriteIndented = true
                };

                var result = await _branchDomain.GetBranches();

                string resultJson = JsonSerializer.Serialize(result, options);
                _loggerService.LogInfo(string.Concat("Acción ejecutada. GetBranches ", resultJson));

                return RequestResult<List<GetBranchesDTO>>.CreateSuccessful(_mapper.Map<List<Branch_DM>, List<GetBranchesDTO>>(result));

            }
            catch (Exception ex)
            {
                _loggerService.LogError(string.Concat("Error GetBranches. ", ex.InnerException));
                return RequestResult<List<GetBranchesDTO>>.CreateError(ex.Message);

            }
        }

        /// <summary>
        /// Elimina una sucursal
        /// </summary>
        /// <returns></returns>
        public async Task<RequestResult<bool>> DeleteBranch(Guid IDBranch)
        {
            try
            {
                #region Validaciones
                if (IDBranch == Guid.Empty)
                {
                    return RequestResult<bool>.CreateUnsuccessful(false, new string[] { ResourceUserMsm.InvalidGuid });
                }
                #endregion

                await _branchDomain.DeleteBranch(IDBranch);

                _loggerService.LogInfo(string.Concat("Acción ejecutada. DeleteBranch ", IDBranch.ToString()));

                return RequestResult<bool>.CreateSuccessful(true);

            }
            catch (Exception ex)
            {
                _loggerService.LogError(string.Concat("Error DeleteBranch. ", ex.InnerException));
                return RequestResult<bool>.CreateError(ex.Message);

            }
        }

        #region Private Methods

        /// <summary>
        /// Valida los datos para crear una sucursal.
        /// </summary>
        /// <author>Diego Molina</author>
        /// <param name="request">objeto para guardar una sucursal</param>
        private void AddBranchValidations(ref List<string> errorMessageValidations, RequestAddBranchDto request)
        {
            if (request.CodeDto <= 0)
            {
                errorMessageValidations.Add(ResourceUserMsm.InvalidCodeDto);
            }
            if (string.IsNullOrEmpty(request.DescriptionDto))
            {
                errorMessageValidations.Add(ResourceUserMsm.InvalidDescriptionDto);
            }
            if (string.IsNullOrEmpty(request.AddressDto))
            {
                errorMessageValidations.Add(ResourceUserMsm.InvalidAddressDto);
            }
            if (string.IsNullOrEmpty(request.IdentificationDto))
            {
                errorMessageValidations.Add(ResourceUserMsm.InvalidIdentificationDto);
            }
            if (request.CreationDateDto < DateTime.Now)
            {
                errorMessageValidations.Add(ResourceUserMsm.InvalidCreationDateDto);
            }
            if (request.IdCurrencyDto == Guid.Empty)
            {
                errorMessageValidations.Add(ResourceUserMsm.InvalidIdCurrencyDto);
            }
        }

        #endregion
    }
}
