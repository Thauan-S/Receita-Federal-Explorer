

using CsvHelper.Configuration;
using WorkerService1.Entityes;

namespace WorkerService1.Mappers
{
    public class EstabelecimentoMapper:ClassMap<Estabelecimento>
    {
        public EstabelecimentoMapper() {
            Map(m => m.CnpjBasico).Index(0);
            Map(m => m.CnpjOrdem).Index(1);
            Map(m => m.CnpjDv).Index(2);
            Map(m => m.MatrizFilial).Index(3);
            Map(m => m.NomeFantasia).Index(4);
            Map(m => m.SituacaoCadastral).Index(5);
            Map(m => m.DataSituacaoCadastral).Index(6);
            Map(m => m.IdMotivo).Index(7);
            Map(m => m.NomeCidadeExterior).Index(8);
            Map(m => m.IdPais).Index(9);
            Map(m => m.DataInicioAtividades).Index(10);
            Map(m => m.IdCnae).Index(11);
            Map(m => m.CnaeFiscalSecundario).Index(12);
            Map(m => m.TipoLogradouro).Index(13);
            Map(m => m.Logradouro).Index(14);
            Map(m => m.Numero).Index(15);
            Map(m => m.Complemento).Index(16);
            Map(m => m.Bairro).Index(17);
            Map(m => m.Cep).Index(18);
            Map(m => m.Uf).Index(19);
            Map(m => m.IdMunicipio).Index(20);
            Map(m => m.Ddd1).Index(21);
            Map(m => m.Telefone1).Index(22);
            Map(m => m.Ddd2).Index(23);
            Map(m => m.Telefone2).Index(24);
            Map(m => m.DddFax).Index(25);
            Map(m => m.TelefoneFax).Index(26);
            Map(m => m.CorreioEletronico).Index(27);
            Map(m => m.SituacaoEspecial).Index(28);
            Map(m => m.DataSituacaoEspecial).Index(29);
        }
    }
}
