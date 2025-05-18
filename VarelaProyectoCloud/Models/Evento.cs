using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace VarelaProyectoCloud.Models
{
    [Table("eventos")]
    public class Evento
    {
        [Key]
        public int evento_id { get; set;}
        public string nombre { get; set; } = null!;
        public string descripcion { get; set; }
        public DateTime fecha_inicio { get; set; }
        public DateTime fecha_fin { get; set; }
        public string tipo_evento { get; set; } = null!;
        public string lugar { get; set; } = null!;
    }
}
