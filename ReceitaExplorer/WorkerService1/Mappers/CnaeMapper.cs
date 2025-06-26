

using CsvHelper.Configuration;
using WorkerService1.Entityes;

namespace WorkerService1.Mappers
{
    public class CnaeMapper : ClassMap<Cnae>
    {
        public CnaeMapper()
        {
            Map(m => m.Codigo).Index(0);
            Map(m => m.Descricao).Index(1);
        }
    }
}
