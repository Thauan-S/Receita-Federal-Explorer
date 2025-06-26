
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WorkerService1.Entityes
{
    public class Cnae
    {
        [Key]
        [Column("codigo")]
        public string Codigo { get; set; } = string.Empty;
        [Column("descricao")]
        public string Descricao { get; set; } = string.Empty;
    }
}
