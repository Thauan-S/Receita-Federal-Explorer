using CsvHelper.Configuration;

namespace WorkerService1.Services
{
    public interface ICSVParserService
    {
        Task<List<Entity>> ParseToEntities<Entity, EntityMap>(string CSVfilePath) where EntityMap : ClassMap<Entity> where Entity : class;
    }
}
