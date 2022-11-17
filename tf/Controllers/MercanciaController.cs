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
    public class MercanciaController : ControllerBase
    {
        private readonly transflashContext _context;

        public MercanciaController(transflashContext context)
        {
            _context = context;
        }

        // GET: api/Mercancia
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Mercancium>>> GetMercancia()
        {
            return await _context.Mercancia.ToListAsync();
        }

        // GET: api/Mercancia/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Mercancium>> GetMercancium(int id)
        {
            var mercancium = await _context.Mercancia.FindAsync(id);

            if (mercancium == null)
            {
                return NotFound();
            }

            return mercancium;
        }

        // PUT: api/Mercancia/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMercancium(int id, Mercancium mercancium)
        {
            if (id != mercancium.IdMercancia)
            {
                return BadRequest();
            }

            _context.Entry(mercancium).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MercanciumExists(id))
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

        // POST: api/Mercancia
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Mercancium>> PostMercancium(Mercancium mercancium)
        {
            _context.Mercancia.Add(mercancium);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (MercanciumExists(mercancium.IdMercancia))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetMercancium", new { id = mercancium.IdMercancia }, mercancium);
        }

        // DELETE: api/Mercancia/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMercancium(int id)
        {
            var mercancium = await _context.Mercancia.FindAsync(id);
            if (mercancium == null)
            {
                return NotFound();
            }

            _context.Mercancia.Remove(mercancium);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MercanciumExists(int id)
        {
            return _context.Mercancia.Any(e => e.IdMercancia == id);
        }
    }
}
