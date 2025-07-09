

using WorkerService1.Entityes;

namespace WorkerService1.Repositories.MunicipioRepository
{
    public interface IMunicipioRepository
    {
        Task<Municipio?> FindByIdAsync(string id);
        Task<List<Municipio>> FindAll();
    }
}
