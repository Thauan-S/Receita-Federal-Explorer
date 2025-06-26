
using WorkerService1.Entityes;

namespace WorkerService1.Repositories.MotivoRepository
{
    public interface IMotivoRepository
    {
        Task<Motivo?> FindByIdAsync(string id);
        Task<List<Motivo?>> FindAll();
    }
}
