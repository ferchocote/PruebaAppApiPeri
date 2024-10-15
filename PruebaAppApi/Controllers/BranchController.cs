using AplicationServices.Application.Contracts.Branch;
using AplicationServices.DTOs.Branch;
using AplicationServices.DTOs.Generics;
using Microsoft.AspNetCore.Mvc;

namespace PruebaAppApi.Controllers
{
    [ApiController]
    [Route("Api/Branch")]
    public class BranchController
    {
        /// <summary>
        /// Instancia al servicio de aplicación
        /// </summary>
        private readonly IBranchServices _branchServices;

        public BranchController(IBranchServices branchServices)
        {

            _branchServices = branchServices;
        }

        /// <summary>
        /// Agrega o actualiza una sucursal una sucursal
        /// </summary>
        /// <returns></returns>
        [HttpPost("AddorUpdateBranch")]
        public async Task<RequestResult<ResponseAddBranchDto>> AddorUpdateBranch(RequestAddBranchDto request)
        {
            return await _branchServices.AddorUpdateBranch(request);
        }

        /// <summary>
        /// Obtiene las sucursales activas
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetBranches")]
        public async Task<RequestResult<List<GetBranchesDTO>>> GetBranches()
        {
            return await _branchServices.GetBranches();
        }

        /// <summary>
        /// Elimina una sucursal
        /// </summary>
        /// <returns></returns>
        [HttpPost("DeleteBranch")]
        public async Task<RequestResult<bool>> DeleteBranch(Guid IDBranch)
        {
            return await _branchServices.DeleteBranch(IDBranch);
        }
    }
}
