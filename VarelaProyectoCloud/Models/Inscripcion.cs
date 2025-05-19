using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VarelaProyectoCloud.Models
{
    [Table("inscripciones")]
    public class Inscripcion
    {
        [Key]
        public int inscripcion_id { get; set; }

        public int participante_id { get; set; }

        public int evento_id { get; set; }

        public DateTime fecha_inscripcion { get; set; }

        public string estado { get; set; } = null!;

        public int tipo_inscripcion_id { get; set; }

        // Propiedades de navegación con ForeignKey explícito
        [ForeignKey("participante_id")]
        public Participante? participante { get; set; }

        [ForeignKey("evento_id")]
        public Evento? evento { get; set; }

        [ForeignKey("tipo_inscripcion_id")]
        public TipoInscripcion? tipo_inscripcion { get; set; }
    }
}