using WorkerService1.Entityes;

namespace WorkerService1.Repositories.NaturezaJuridicaRepository
{
    public interface INaturezaRepository
    {
        Task<NaturezaJuridica?> FindByIdAsync(string id);
        Task<List<NaturezaJuridica>> FindAll();
    }
}
