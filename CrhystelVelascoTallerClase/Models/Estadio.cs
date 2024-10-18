using System.ComponentModel.DataAnnotations;

namespace CrhystelVelascoTallerClase.Models
{
    public class Estadio
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(100)]
        public string Direccion { get; set; }
        [MaxLength(100)]
        public string Ciudad { get; set; }
        [Range(1, 10000)]
        public int Capacidad { get; set; }
    }
}
