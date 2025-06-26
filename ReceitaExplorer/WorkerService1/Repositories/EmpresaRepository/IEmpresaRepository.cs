
using WorkerService1.Entityes;

namespace WorkerService1.Repositories.EmpresaRepository
{
    public interface IEmpresaRepository
    {
        Task<Empresa?> FindByIdAsync(Guid? id);
    }
}
