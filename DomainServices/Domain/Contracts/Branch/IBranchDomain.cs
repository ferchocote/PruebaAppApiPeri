using PruebaAppApi.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainServices.Domain.Contracts.Branch
{
    public interface IBranchDomain
    {
        Task<Guid?> AddorUpdateBranch(Branch_DM branch_DM, bool update);
        Task<List<Branch_DM>> GetBranches();
        Task<bool> DeleteBranch(Guid IDBranch);
        
    }
}
