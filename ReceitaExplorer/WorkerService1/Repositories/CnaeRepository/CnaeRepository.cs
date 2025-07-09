
using Microsoft.EntityFrameworkCore;
using WorkerService1.Context;
using WorkerService1.Entityes;

namespace WorkerService1.Repositories.CnaeRepository
{
    public class CnaeRepository:ICnaeRepository
    {
        private readonly AppDbContext _appDbContext;

        public CnaeRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<List<Cnae>> FindAll()
        {
            return await _appDbContext.Cnaes.AsNoTracking().ToListAsync();
        }

        public async Task<Cnae?> FindByIdAsync(string id)
        {
            return await _appDbContext.Cnaes.FindAsync(id);
        }
    }
}
