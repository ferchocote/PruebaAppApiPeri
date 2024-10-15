using AplicationServices.DTOs.Branch;
using AplicationServices.DTOs.Generics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicationServices.Application.Contracts.Branch
{
    public interface IBranchServices
    {
        Task<RequestResult<ResponseAddBranchDto>> AddorUpdateBranch(RequestAddBranchDto request);
        Task<RequestResult<List<GetBranchesDTO>>> GetBranches();
        Task<RequestResult<bool>> DeleteBranch(Guid IDBranch);
    }
}
