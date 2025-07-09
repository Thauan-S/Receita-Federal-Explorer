
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WorkerService1.Entityes
{
    public class Empresa
    {
        [Key]
        [Required]
        [Column("id")]
        public Guid Id { get; set; } = NewSequentialGuid();

        [Column("cnpj_basico")]
        public string CnpjBasico { get; set; } = string.Empty;


        [Column("razao_social")]
        public string RazaoSocial { get; set; } = string.Empty;


        [Column("qualificacao_responsavel")]
        public string QualificacaoResponsavel { get; set; } = string.Empty;


        [Column("capital_social")]
        public float? CapitalSocial { get; set; }


        [Column("porte")]
        public string? PorteEmpresa { get; set; }


        [Column("ente_responsavel")]
        public string EnteFederativoResponsavel { get; set; } = string.Empty;

        [ForeignKey(nameof(NaturezaJuridica))]
        [Column("natureza_juridica_id")]
        public string? IdNaturezaJuridica { get; set; }
        public NaturezaJuridica NaturezaJuridica { get; set; }



        private static Guid NewSequentialGuid()
        {
            byte[] guidArray = Guid.NewGuid().ToByteArray();

            DateTime now = DateTime.UtcNow;

            byte[] timeArray = BitConverter.GetBytes(now.Ticks);
            Array.Copy(timeArray, 0, guidArray, 0, 8);

            return new Guid(guidArray);
        }
    }
}
