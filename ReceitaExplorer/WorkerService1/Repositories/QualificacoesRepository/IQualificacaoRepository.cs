
using WorkerService1.Entityes;

namespace WorkerService1.Repositories.QualificacoesRepository
{
    public interface IQualificacaoRepository
    {
        Task<QualificacaoSocio?> FindByIdAsync(string id);
        Task<List<QualificacaoSocio>> FindAll();
    }
}
