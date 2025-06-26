

using WorkerService1.Entityes;

namespace WorkerService1.Repositories.CnaeRepository
{
    public interface ICnaeRepository
    {
        Task<Cnae?> FindByIdAsync(string id);
        Task<List<Cnae>> FindAll();
    }
}
