using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VarelaProyectoCloud.Models;

namespace VarelaProyectoCloud.Services
{
    [Table("pagos")]
    public class Pago
    {
        [Key]
        public int pago_id { get; set; }
        public int inscripcion_id { get; set; }
        public double monto { get; set; }
        public DateTime fecha_pago { get; set; }
        public string metodo_pago { get; set; } = null!;
        //Propiedades de navegación con ForeignKey explícito
        [ForeignKey("inscripcion_id")]
        public Inscripcion? inscripcion { get; set; }
    }
}
