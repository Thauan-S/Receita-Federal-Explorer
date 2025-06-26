

using CsvHelper.Configuration;
using WorkerService1.Entityes;

namespace WorkerService1.Mappers
{
    public class NaturezaJuridicaMapper : ClassMap<NaturezaJuridica>
    {
        public NaturezaJuridicaMapper()
        {
            Map(m => m.Codigo).Index(0);
            Map(m => m.Descricao).Index(1);
        }
    }
}
