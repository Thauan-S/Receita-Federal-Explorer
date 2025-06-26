

using CsvHelper.Configuration;
using WorkerService1.Entityes;

namespace WorkerService1.Mappers
{
    public class QualificacoesSocioMapper : ClassMap<QualificacaoSocio>
    {
        public QualificacoesSocioMapper(){
             Map(m => m.Codigo).Index(0);
             Map(m => m.Descricao).Index(1);
        }
    }
}
