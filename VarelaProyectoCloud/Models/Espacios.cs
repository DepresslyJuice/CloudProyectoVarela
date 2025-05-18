using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace VarelaProyectoCloud.Models
{
    [Table("espacios")]
    public class Espacio
    {
        [Key]
        public int espacio_id { get; set; }
        public string nombre { get; set; } = null!;
        public string? descripcion { get; set; }
        public string? ubicacion { get; set; }
        public int capacidad { get; set; }
    }
}
