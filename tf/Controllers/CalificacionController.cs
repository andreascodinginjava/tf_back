using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using tf.Models;
using tf.ModelsView;

namespace tf.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalificacionController : ControllerBase
    {
        private readonly transflashContext _context;

        public CalificacionController(transflashContext context)
        {
            _context = context;
        }

        // GET: api/Calificacion
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Calificacion>>> GetCalificacions()
        {
            return await _context.Calificacions.ToListAsync();
        }

        // GET: api/Calificacion
        [HttpGet("/api/Calificacion/Conductor/{id}")]
        public async Task<ActionResult<IEnumerable<CalificacionConductor>>> GetCalificacionConductor(int id)
        {
            var query = (from cal in _context.Calificacions
                         where cal.ConductorFk == id
                         select new CalificacionConductor
                         {
                             RecoPositiva = cal.RecoPositiva,
                             RecoNegativa = cal.RecoNegativa,
                             Comentario = cal.Comentario,
                             CanEstrellas = cal.CanEstrellas
                         }).ToArrayAsync();

            return await query;
        }

        // GET: api/Calificacion/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Calificacion>> GetCalificacion(int id)
        {
            var calificacion = await _context.Calificacions.FindAsync(id);

            if (calificacion == null)
            {
                return NotFound();
            }

            return calificacion;
        }

        // PUT: api/Calificacion/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCalificacion(int id, Calificacion calificacion)
        {
            if (id != calificacion.IdCalificacion)
            {
                return BadRequest();
            }

            _context.Entry(calificacion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CalificacionExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Calificacion
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Calificacion>> PostCalificacion(Calificacion calificacion)
        {
            _context.Calificacions.Add(calificacion);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CalificacionExists(calificacion.IdCalificacion))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCalificacion", new { id = calificacion.IdCalificacion }, calificacion);
        }

        // DELETE: api/Calificacion/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCalificacion(int id)
        {
            var calificacion = await _context.Calificacions.FindAsync(id);
            if (calificacion == null)
            {
                return NotFound();
            }

            _context.Calificacions.Remove(calificacion);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CalificacionExists(int id)
        {
            return _context.Calificacions.Any(e => e.IdCalificacion == id);
        }
    }
}
