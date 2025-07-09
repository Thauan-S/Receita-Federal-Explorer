using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WorkerService1.Entityes
{
    public class Estabelecimento
    {
        [Key]
        [Required]
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }


        [Column("cnpj_basico")]
        public string CnpjBasico { get; set; }=string.Empty;


        [Column("cnpj_ordem")]
        public string CnpjOrdem { get; set; } = string.Empty;


        [Column("cnpj_dv")]
        public string CnpjDv { get; set; } = string.Empty;


        [Column("matriz_filial")]
        public string MatrizFilial { get; set; } = string.Empty;

        [Column("nome_fantasia")]
        public string NomeFantasia { get; set; } = string.Empty;


        [Column("situacao_cadastral")]
        public string SituacaoCadastral { get; set; } = string.Empty;


        [Column("data_situacao_cadastral")]
        public string DataSituacaoCadastral { get; set; } = string.Empty;


        [Column("nome_cidade_exterior")]
        public string NomeCidadeExterior { get; set; } = string.Empty;


        [Column("data_inicio_atividades")]
        public string DataInicioAtividades { get; set; } = string.Empty;


        [Column("cnae_fiscal_secundario")]
        public string CnaeFiscalSecundario { get; set; } = string.Empty;


        [Column("tipo_logradouro")]
        public string TipoLogradouro { get; set; } = string.Empty;


        [Column("logradouro")]
        public string Logradouro { get; set; } = string.Empty;


        [Column("numero")]
        public string Numero { get; set; } = string.Empty;


        [Column("complemento")]
        public string Complemento { get; set; } = string.Empty;


        [Column("bairro")]
        public string Bairro { get; set; } = string.Empty;


        [Column("cep")]
        public string Cep { get; set; } = string.Empty;


        [Column("uf")]
        public string Uf { get; set; } = string.Empty;

        [Column("ddd1")]
        public string Ddd1 { get; set; } = string.Empty;

        [Column("ddd2")]
        public string Ddd2 { get; set; } = string.Empty;

        [Column("telefone1")]
        public string Telefone1 { get; set; } = string.Empty;
        [Column("telefone2")]

        public string Telefone2 { get; set; } = string.Empty;

        [Column("ddd_fax")]
        public string DddFax { get; set; } = string.Empty;

        [Column("telefone_fax")]
        public string TelefoneFax { get; set; } = string.Empty;

        [Column("correio_eletronico")]
        public string CorreioEletronico { get; set; } = string.Empty;

        [Column("situacao_especial")]
        public string SituacaoEspecial { get; set; } = string.Empty;

        [Column("data_situacao_especial")]
        public string DataSituacaoEspecial { get; set; } = string.Empty;

        [ForeignKey(nameof(Motivos))]
        [Column("motivo_situacao_cadastral_id")]
        public string? IdMotivo { get; set; }
        public Motivo? Motivos { get; init; } 

        [ForeignKey(nameof(Empresa))]
        [Column("empresa_id")]
        public Guid? IdEmpresa { get; set; }
        public Empresa? Empresa { get; init; } 

        [ForeignKey(nameof(Municipios))]
        [Column("municipio_id")]
        public string? IdMunicipio { get; set; }
        public Municipio? Municipios { get; init; } 

        [ForeignKey(nameof(Pais))]
        [Column("pais_id")]
        public string? IdPais { get; set; }
        public Pais? Pais { get; set; } 

        [ForeignKey(nameof(Cnae))]
        [Column("cnae_id")]
        public string IdCnae { get; set; } = string.Empty;
        public Cnae? Cnae { get; set; } 
    }
}
