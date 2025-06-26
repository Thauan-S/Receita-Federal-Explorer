using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkerService1.Context;
using WorkerService1.Entityes;

namespace WorkerService1.Repositories.MotivoRepository
{
    public class MotivoRepository:IMotivoRepository
    {
        private readonly AppDbContext _appDbContext;
        
        public MotivoRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<List<Motivo?>> FindAll()
        {
            return await _appDbContext.Motivos.ToListAsync();
        }

        public async Task<Motivo?> FindByIdAsync(string id)
        {
            return await _appDbContext.Motivos.FindAsync(id);
        }
    }
}
