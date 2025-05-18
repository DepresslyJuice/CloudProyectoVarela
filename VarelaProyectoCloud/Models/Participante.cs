using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace VarelaProyectoCloud.Models
{
    [Table("participantes")]
    public class Participante
    {
        [Key]
        public int participante_id { get; set; }

        public string nombre { get; set; } = null!;
        public string apellido { get; set; } = null!;
        public string  email { get; set; } = null!;
        public string? telefono { get; set; }
        public string? institucion { get; set; }
        public DateTime fecha_nacimiento { get; set; }
    }
}
