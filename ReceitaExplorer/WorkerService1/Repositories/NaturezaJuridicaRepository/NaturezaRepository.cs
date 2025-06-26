
using Microsoft.EntityFrameworkCore;
using WorkerService1.Context;
using WorkerService1.Entityes;

namespace WorkerService1.Repositories.NaturezaJuridicaRepository
{
    public class NaturezaRepository:INaturezaRepository
    {
        private readonly AppDbContext _appDbContext;

        public NaturezaRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<List<NaturezaJuridica>> FindAll()
        {
            return await _appDbContext.NaturezasJuridicas.ToListAsync();
        }

        public async Task<NaturezaJuridica?> FindByIdAsync(string id)
        {
            return await _appDbContext.NaturezasJuridicas.FindAsync(id);
        }
    }
}
