

using Microsoft.EntityFrameworkCore;
using WorkerService1.Context;
using WorkerService1.Entityes;

namespace WorkerService1.Repositories.EmpresaRepository
{
    internal class EmpresaRepository : IEmpresaRepository
    {
        private readonly AppDbContext _appDbContext;

        public EmpresaRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async  Task<Empresa?> FindByIdAsync(Guid? id)
        {
            return await _appDbContext.Empresa.FirstOrDefaultAsync(e => e.Id == id);
        }
    }
}
