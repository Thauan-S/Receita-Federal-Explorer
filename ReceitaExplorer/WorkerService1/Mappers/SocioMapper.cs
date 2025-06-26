
using CsvHelper.Configuration;
using WorkerService1.Entityes;

namespace WorkerService1.Mappers
{
    public class SocioMapper:ClassMap<Socio>
    {
        public SocioMapper()
        {
            Map(s => s.CnpjBasico).Index(0);
            Map(s => s.IdentificadorSocio).Index(1);
            Map(s => s.NomeSocio).Index(2);
            Map(s => s.CnpjCpfSocio).Index(3);
            Map(s => s.IdQualificacaoSocio).Index(4);
            Map(s => s.DataEntradaSociedade).Index(5);
            Map(s => s.IdPais).Index(6);
            Map(s => s.NumeroCpfRepresentanteLegal).Index(7);
            Map(s => s.NomeRepresentanteLegal).Index(8);
            Map(s => s.CodigoQualificacaoRepresentanteLegal).Index(9);
            Map(s => s.FaixaEtaria).Index(10);
        }
    }
}
