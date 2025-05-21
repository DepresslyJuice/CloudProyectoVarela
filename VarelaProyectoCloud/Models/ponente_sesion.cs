using System.ComponentModel.DataAnnotations.Schema;

namespace VarelaProyectoCloud.Models
{
    [Table("ponentes_sesiones")]
    public class PonenteSesion
    {
        public int ponente_id { get; set; }
        public int sesion_id { get; set; }

        // Propiedades de navegación (sin ? si son requeridas y con inicializador)
        [ForeignKey("ponente_id")]
        public Ponente? ponente { get; set; } = null!;

        [ForeignKey("sesion_id")]
        public Sesion? sesion { get; set; } = null!;
    }
}