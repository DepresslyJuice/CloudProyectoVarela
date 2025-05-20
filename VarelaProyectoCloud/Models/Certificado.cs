using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VarelaProyectoCloud.Models
{
    [Table("certificados")]
    public class Certificado
    {
        [Key]
        public int certificado_id { get; set; }
        public DateTime fecha_emision { get; set; }
        public string codigo_verificacion { get; set; } = null!;
        public string url_certificado { get; set; } = null!;
        public int inscripcion_id { get; set; }
        // Propiedades de navegación con ForeignKey explícito
        [ForeignKey("inscripcion_id")]
        public Inscripcion? inscripcion { get; set; }
    }

}
