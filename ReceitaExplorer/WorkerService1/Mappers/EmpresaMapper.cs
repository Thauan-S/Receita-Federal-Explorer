

using CsvHelper.Configuration;
using WorkerService1.Entityes;

namespace WorkerService1.Mappers
{
    public class EmpresaMapper:ClassMap<Empresa>
    {
        public EmpresaMapper() {
            Map(m => m.CnpjBasico).Index(0);
            Map(m => m.RazaoSocial).Index(1);
            Map(m => m.IdNaturezaJuridica).Index(2);
            Map(m => m.QualificacaoResponsavel).Index(3);
            Map(m => m.CapitalSocial).Index(4);
            Map(m => m.PorteEmpresa).Index(5);
            Map(m => m.EnteFederativoResponsavel).Index(6);
        }
    }
}
