using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CrhystelVelascoTallerClase.Models
{
    public class Equipo
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(100)]
        public string Nombre { get; set; }
        [MaxLength(100)]
        public string Ciudad { get; set; }
        [MaxLength(100)]
        public string Titulo { get; set; }
        public bool AceptaExtranjeros {  get; set; }
        public Estadio Estadio { get; set; }
        [ForeignKey(nameof(Estadio))]
        public int IdEstadio { get; set; }
    }
}
