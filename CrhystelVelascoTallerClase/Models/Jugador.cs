using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CrhystelVelascoTallerClase.Models
{
    public class Jugador
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(50)]
        public string Nombre { get; set; }
        [MaxLength(50)]
        public string Posicion { get; set; }
        [Range(1, 100)]
        public int Edad { get; set; }
        public Equipo? Equipo { get; set; }
        [ForeignKey(nameof(Equipo))]
        public int IdEquipo { get; set; }
        
    }
}
