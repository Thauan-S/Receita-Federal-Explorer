
using CsvHelper.Configuration;
using WorkerService1.Entityes;

namespace WorkerService1.Mappers
{
    public class MunicipioMapper:ClassMap<Municipio>
    {
        public MunicipioMapper()
        {
            Map(m => m.Codigo).Index(0);
            Map(m => m.Descricao).Index(1);

        }
    }
}
