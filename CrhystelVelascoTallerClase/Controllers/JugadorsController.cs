using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CrhystelVelascoTallerClase.Data;
using CrhystelVelascoTallerClase.Models;

namespace CrhystelVelascoTallerClase.Controllers
{
    public class JugadorsController : Controller
    {
        private readonly CrhystelVelascoTallerClaseContext _context;

        public JugadorsController(CrhystelVelascoTallerClaseContext context)
        {
            _context = context;
        }

        // GET: Jugadors
        [HttpPost]
        public string Index(String searchString, bool notUsed)
        {
            return "From [HttpPost]Index: filter on " + searchString;
        }
        public async Task<IActionResult> Index(string searchString, string jugadorEquipo)
        {
            if (_context.Jugador == null)
            {
                return Problem("Nada");
            }
            IQueryable<string> equipoQuery = from j in _context.Jugador
                                             orderby j.Equipo.Nombre
                                             select j.Equipo.Nombre;
            var jugadores = from j in _context.Jugador
                            select j;
            if(!String.IsNullOrEmpty(searchString))
            {
                jugadores = jugadores.Where(s => s.Equipo.Nombre.ToUpper().Contains(searchString.ToUpper()));
            }
            if(!String.IsNullOrEmpty(jugadorEquipo))
            {
                jugadores = jugadores.Where(s => s.Equipo.Nombre == jugadorEquipo);
            }

            var jugadoresVM = new JugadorEquipo
            {
                Jugadores = await jugadores.Include(j => j.Equipo).ToListAsync(),
                Equipo = new SelectList(await equipoQuery.Distinct().ToListAsync()),
                JugadorEquipo = string.Empty,
                SearchString = searchString,
            };
            return View(jugadoresVM);



            //var crhystelVelascoTallerClaseContext = _context.Jugador.Include(j => j.Equipo);
            //if (equipo is not null)
            //{
            //    crhystelVelascoTallerClaseContext= crhystelVelascoTallerClaseContext.Where(j => j.idEquipo == equipo);
            //}
               
            //ViewBag.Equipos = await _context.Equipo.ToListAsync();
            //return View(await crhystelVelascoTallerClaseContext.ToListAsync());
        }

        // GET: Jugadors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jugador = await _context.Jugador
                .Include(j => j.Equipo)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (jugador == null)
            {
                return NotFound();
            }

            return View(jugador);
        }

        // GET: Jugadors/Create
        public IActionResult Create()
        {
            ViewData["IdEquipo"] = new SelectList(_context.Equipo, "Id", "Nombre");
            return View();
        }
        //gg
        // POST: Jugadors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Posicion,Edad,IdEquipo")] Jugador jugador)
        {
            if (ModelState.IsValid)
            {
                _context.Add(jugador);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdEquipo"] = new SelectList(_context.Equipo, "Id", "Id", jugador.IdEquipo);
            return View(jugador);
        }

        // GET: Jugadors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jugador = await _context.Jugador.FindAsync(id);
            if (jugador == null)
            {
                return NotFound();
            }
            ViewData["IdEquipo"] = new SelectList(_context.Equipo, "Id", "Id", jugador.IdEquipo);
            return View(jugador);
        }

        // POST: Jugadors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Posicion,Edad,IdEquipo")] Jugador jugador)
        {
            if (id != jugador.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(jugador);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JugadorExists(jugador.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdEquipo"] = new SelectList(_context.Equipo, "Id", "Id", jugador.IdEquipo);
            return View(jugador);
        }

        // GET: Jugadors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jugador = await _context.Jugador
                .Include(j => j.Equipo)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (jugador == null)
            {
                return NotFound();
            }

            return View(jugador);
        }

        // POST: Jugadors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var jugador = await _context.Jugador.FindAsync(id);
            if (jugador != null)
            {
                _context.Jugador.Remove(jugador);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        //jfb
        private bool JugadorExists(int id)
        {
            return _context.Jugador.Any(e => e.Id == id);
        }
    }
}
