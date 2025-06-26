

using WorkerService1.Entityes;

namespace WorkerService1.Repositories.PaisRepository
{
    public interface IPaisRepository
    {
        Task<Pais?> FindByIdAsync(string id);
        Task<List<Pais>> FindAll();
    }
}
