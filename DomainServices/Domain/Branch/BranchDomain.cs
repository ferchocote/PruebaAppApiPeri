using DomainServices.Domain.Contracts.Branch;
using Microsoft.EntityFrameworkCore;
using PruebaAppApi.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainServices.Domain.Branch
{
    public class BranchDomain : IBranchDomain
    {
        private readonly TestDBContext _context;
        public BranchDomain(TestDBContext testDBContext)
        {
            _context = testDBContext;
        }

        /// <summary>
        /// Obtiene las sucursales activas
        /// </summary>
        /// <returns></returns>
        public async Task<List<Branch_DM>> GetBranches()
        {
            return await _context.Branch_DM
                                 .Include(i => i.CurrencyNavigation)
                                 .Where(i => i.State == true)
                                 .AsNoTracking()
                                 .ToListAsync();

        }

        /// <summary>
        /// Elimina una sucursal
        /// </summary>
        /// <returns></returns>
        public async Task<bool> DeleteBranch(Guid IDBranch)
        {
            var productoDeseadoGrabado = _context.Branch_DM.Where(i => i.ID.Equals(IDBranch))?.FirstOrDefault();

            if (productoDeseadoGrabado != null)
            {
                if (productoDeseadoGrabado.State)
                {
                    productoDeseadoGrabado.State = false;
                    _context.SaveChanges();
                }
            }

            return true;
        }

        /// <summary>
        /// Agrega o actualiza una sucursal una sucursal
        /// </summary>
        /// <returns></returns>
        public async Task<Guid?> AddorUpdateBranch(Branch_DM branch_DM, bool update)
        {
            Guid? IDBranch = null;

            var branch_DMR = _context.Branch_DM.Where(i => i.ID.Equals(branch_DM.ID)).FirstOrDefault();

            if (branch_DMR != null)
            {
                IDBranch = branch_DMR.ID;
                if (update)
                {
                    branch_DMR.Code = branch_DM.Code;
                    branch_DMR.Description = branch_DM.Description;
                    branch_DMR.Address = branch_DM.Address;
                    branch_DMR.Identification = branch_DM.Identification;
                    branch_DMR.Currency = branch_DM.Currency;


                    _context.Branch_DM.Attach(branch_DMR);

                    // Solo actualizar propiedades específicas
                    _context.Entry(branch_DMR).Property(p => p.Code).IsModified = true;
                    _context.Entry(branch_DMR).Property(p => p.Description).IsModified = true;
                    _context.Entry(branch_DMR).Property(p => p.Address).IsModified = true;
                    _context.Entry(branch_DMR).Property(p => p.Identification).IsModified = true;
                    _context.Entry(branch_DMR).Property(p => p.Currency).IsModified = true;

                    _context.SaveChanges();
                }
            }

            if (IDBranch == null)
            {
                branch_DM.ID = Guid.NewGuid();
                branch_DM.State = true;
                _context.Branch_DM.Add(branch_DM);
                _context.SaveChanges();
                IDBranch = branch_DM.ID;
            }

            return IDBranch;
        }
    }
}
