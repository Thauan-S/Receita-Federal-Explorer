
using Microsoft.EntityFrameworkCore;
using WorkerService1.Context;
using WorkerService1.Entityes;

namespace WorkerService1.Repositories.QualificacoesRepository
{
    public class QualificacaoRepository : IQualificacaoRepository
    {
        private readonly AppDbContext _appDbContext;

        public QualificacaoRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<List<QualificacaoSocio>> FindAll()
        {
            return await _appDbContext.QualificacoesSocios.ToListAsync();
        }

        public async Task<QualificacaoSocio?> FindByIdAsync(string id)
        {
            return await _appDbContext.QualificacoesSocios.FindAsync(id);
        }
    }
}
