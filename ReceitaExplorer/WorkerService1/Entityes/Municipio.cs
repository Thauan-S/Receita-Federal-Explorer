using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkerService1.Entityes
{
    public class Municipio
    {
        [Key]
        [Column("codigo")]
        public string Codigo { get; set; } = string.Empty;
        [Column("descricao")]
        public string Descricao { get; set; }=string.Empty;
    }
}
