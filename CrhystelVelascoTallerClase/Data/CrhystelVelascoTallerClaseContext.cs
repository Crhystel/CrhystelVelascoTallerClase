using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CrhystelVelascoTallerClase.Models;

namespace CrhystelVelascoTallerClase.Data
{
    public class CrhystelVelascoTallerClaseContext : DbContext
    {
        public CrhystelVelascoTallerClaseContext (DbContextOptions<CrhystelVelascoTallerClaseContext> options)
            : base(options)
        {
        }

        public DbSet<CrhystelVelascoTallerClase.Models.Estadio> Estadio { get; set; } = default!;
        public DbSet<CrhystelVelascoTallerClase.Models.Equipo> Equipo { get; set; } = default!;
        public DbSet<CrhystelVelascoTallerClase.Models.Jugador> Jugador { get; set; } = default!;
    }
}
