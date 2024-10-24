using Microsoft.AspNetCore.Mvc.Rendering;

namespace CrhystelVelascoTallerClase.Models
{
    public class JugadorEquipo
    {
        public SelectList Equipo { get; set; }
        public IEnumerable<Jugador>? Jugadores { get; set; }
        public string SearchString { get; set; }
        public string JugadorEquipos { get; set; }
    }
}
