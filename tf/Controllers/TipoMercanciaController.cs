using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using tf.Models;

namespace tf.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoMercanciaController : ControllerBase
    {
        private readonly transflashContext _context;

        public TipoMercanciaController(transflashContext context)
        {
            _context = context;
        }

        // GET: api/TipoMercancia
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoMercancium>>> GetTipoMercancia()
        {
            return await _context.TipoMercancia.ToListAsync();
        }

        // GET: api/TipoMercancia/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TipoMercancium>> GetTipoMercancium(int id)
        {
            var tipoMercancium = await _context.TipoMercancia.FindAsync(id);

            if (tipoMercancium == null)
            {
                return NotFound();
            }

            return tipoMercancium;
        }

        // PUT: api/TipoMercancia/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTipoMercancium(int id, TipoMercancium tipoMercancium)
        {
            if (id != tipoMercancium.IdTipoMercancia)
            {
                return BadRequest();
            }

            _context.Entry(tipoMercancium).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoMercanciumExists(id))
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

        // POST: api/TipoMercancia
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TipoMercancium>> PostTipoMercancium(TipoMercancium tipoMercancium)
        {
            _context.TipoMercancia.Add(tipoMercancium);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TipoMercanciumExists(tipoMercancium.IdTipoMercancia))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTipoMercancium", new { id = tipoMercancium.IdTipoMercancia }, tipoMercancium);
        }

        // DELETE: api/TipoMercancia/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTipoMercancium(int id)
        {
            var tipoMercancium = await _context.TipoMercancia.FindAsync(id);
            if (tipoMercancium == null)
            {
                return NotFound();
            }

            _context.TipoMercancia.Remove(tipoMercancium);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TipoMercanciumExists(int id)
        {
            return _context.TipoMercancia.Any(e => e.IdTipoMercancia == id);
        }
    }
}
