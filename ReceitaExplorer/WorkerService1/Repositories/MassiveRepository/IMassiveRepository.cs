
namespace WorkerService1.Repositories.MassiveRepository
{
    public interface IMassiveRepository
    {
        Task InsertDataAsync<T>(List<T> entities) where T : class;
    }
}
