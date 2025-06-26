using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkerService1.Entityes
{
    public class Simples
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public Guid Id { get; set; }

        [Column("cnpj_basico")]
        public string CnpjBasico { get; set; } = string.Empty;

        [ForeignKey(nameof(Empresa))]
        [Column("empresa_id")]
        public Guid? IdEmpresa { get; set; }
        public Empresa Empresa { get; set; }= new Empresa();

        [Column("opcao_pelo_simples")]
        public string OpcaoSimples { get; set; }=string.Empty;

        [Column("data_opcao_simples")]
        public string DataOpcaoSimples { get; set; } = string.Empty;

        [Column("data_exclusao_simples")]
        public string DataExclusaoSimples { get; set; } = string.Empty;

        [Column("opcao_pelo_mei")]
        public string OpcaoMei { get; set; } = string.Empty;

        [Column("data_opcao_mei")]
        public string DataOpcaoMei { get; set; } = string.Empty;

        [Column("data_exclusao_mei")]
        public string DataExclusaoMei { get; set; } = string.Empty;
    }
}
