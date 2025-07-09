
using Microsoft.EntityFrameworkCore;
using WorkerService1.Context;
using WorkerService1.Entityes;

namespace WorkerService1.Repositories.MunicipioRepository
{
    public class MunicipioRepository: IMunicipioRepository
    {
        private readonly AppDbContext _appDbContext;
        public MunicipioRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<List<Municipio>> FindAll()
        {
            return await _appDbContext.Municipios.AsNoTracking().ToListAsync();
        }

        public async Task<Municipio?> FindByIdAsync(string id)
        {
            return await _appDbContext.Municipios.FindAsync(id);
        }
    }
}
