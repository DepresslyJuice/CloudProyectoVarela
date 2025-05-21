using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VarelaProyectoCloud.Models
{
    [Table("asistencias")]
    public class Asistencia
    {
        [Key]
        public int asistencia_id { get; set; }
        public int inscripcion_id { get; set; }
        public int sesion_id { get; set; }
        public DateTime fecha_hora { get; set; }
        public bool asistio { get; set; }
        // Propiedades de navegación con ForeignKey explícito
        [ForeignKey("inscripcion_id")]
        public Inscripcion? inscripcion { get; set; }
        [ForeignKey("sesion_id")]
        public Sesion? sesion { get; set; }
    }
}
