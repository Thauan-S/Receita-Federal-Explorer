using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkerService1.Entityes
{
    public class Socio
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public Guid Id { get; set; }

        [Column("cnpj_basico")]
        public string CnpjBasico { get; set; } = string.Empty;

        [Column("identificador_socio")]
        public string IdentificadorSocio { get; set; } = string.Empty;

        [Column("nome_socio")]
        public string NomeSocio { get; set; } = string.Empty;

        [Column("cnpj_cpf_socio")]
        public string CnpjCpfSocio { get; set; } = string.Empty;

        [Column("data_entrada_sociedade")]
        public string DataEntradaSociedade { get; set; } = string.Empty;

        [Column("numero_cpf_representante_legal")]
        public string NumeroCpfRepresentanteLegal { get; set; } = string.Empty;

        [Column("nome_representante_legal")]
        public string NomeRepresentanteLegal { get; set; } = string.Empty;

        [Column("codigo_qualificacao_representante_legal")]
        public string CodigoQualificacaoRepresentanteLegal { get; set; } = string.Empty;

        [Column("faixa_etaria")]
        public string FaixaEtaria { get; set; } = string.Empty;


        [ForeignKey(nameof(QualificacaoSocio))]
        [Column("qualificacao_socio_id")]
        public string? IdQualificacaoSocio { get; set; }
        public QualificacaoSocio QualificacaoSocio { get; set; }= new QualificacaoSocio();

        [ForeignKey(nameof(Empresa))]
        [Column("empresa_id")]
        public Guid? IdEmpresa { get; set; }
        public Empresa Empresa { get; set; } = new Empresa();

        [ForeignKey(nameof(Pais))]
        [Column("pais_id")]
        public string? IdPais { get; set; }
        public Pais Pais { get; set; } = new Pais();
    }
}
