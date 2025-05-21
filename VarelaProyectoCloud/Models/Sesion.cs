using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace VarelaProyectoCloud.Models
{
    [Table("sesiones")]
    public class Sesion
    {
        [Key]
        public int sesion_id { get; set; }
        public int evento_id { get; set; }
        public int espacio_id { get; set; }
        public DateTime fecha { get; set; }
        public TimeSpan hora_inicio { get; set; }
        public TimeSpan hora_fin { get; set; }
        public string descripcion { get; set; } = null!;
        public string titulo { get; set; } = null!;

        // Propiedades de navegación con ForeignKey explícito
        [ForeignKey("evento_id")]
        public Evento? evento { get; set; }
        [ForeignKey("espacio_id")]
        public Espacio? espacio { get; set; }


        public ICollection<PonenteSesion> ponente_sesiones { get; set; } = new List<PonenteSesion>();
    }
}
