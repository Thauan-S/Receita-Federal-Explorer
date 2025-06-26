using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

using WorkerService1.Context;
using WorkerService1.Entityes;

namespace WorkerService1.Repositories.PaisRepository
{
    public class PaisRepository:IPaisRepository
    {
        private readonly AppDbContext _appDbContext;
        public PaisRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<Pais?> FindByIdAsync(string id)
        {
            return await _appDbContext.Paises.FindAsync(id);
        }

        public Task<List<Pais>> FindAll()
        {
            return _appDbContext.Paises.ToListAsync();
        }
    }
}
