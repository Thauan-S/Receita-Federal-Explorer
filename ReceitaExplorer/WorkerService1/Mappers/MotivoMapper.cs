

using CsvHelper.Configuration;
using WorkerService1.Entityes;

namespace WorkerService1.Mappers
{
    public class MotivoMapper:ClassMap<Motivo>
    {
        public MotivoMapper()
        {
            Map(m => m.Codigo).Index(0);
            Map(m => m.Descricao).Index(1);
        }
    }
}
