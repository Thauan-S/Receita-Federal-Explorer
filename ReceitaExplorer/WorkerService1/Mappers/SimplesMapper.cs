
using CsvHelper.Configuration;
using WorkerService1.Entityes;

namespace WorkerService1.Mappers
{
    public class SimplesMapper:ClassMap<Simples>
    {
        public SimplesMapper() {
            Map(m => m.CnpjBasico).Index(0);
            Map(m => m.OpcaoSimples).Index(1);
            Map(m => m.DataOpcaoSimples).Index(2);
            Map(m => m.DataExclusaoSimples).Index(3);
            Map(m => m.OpcaoMei).Index(4);
            Map(m => m.DataOpcaoMei).Index(5);
            Map(m => m.DataExclusaoMei).Index(6);
        }
    }
}
