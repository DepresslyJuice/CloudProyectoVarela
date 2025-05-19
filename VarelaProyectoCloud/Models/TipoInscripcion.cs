using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VarelaProyectoCloud.Models
{
    [Table("tipo_inscripcion")]
    public class TipoInscripcion
    {
        [Key]
        public int tipo_inscripcion_id { get; set; }
        public string detalle { get; set; }
        public double costo { get; set; }
    }
}
