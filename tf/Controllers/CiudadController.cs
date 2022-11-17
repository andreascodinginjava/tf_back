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
    public class CiudadController : ControllerBase
    {
        private readonly transflashContext _context;

        public CiudadController(transflashContext context)
        {
            _context = context;
        }

        // GET: api/Ciudad
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ciudad>>> GetCiudads()
        {
            return await _context.Ciudads.ToListAsync();
        }

        // GET: api/Ciudad/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Ciudad>> GetCiudad(int id)
        {
            var ciudad = await _context.Ciudads.FindAsync(id);

            if (ciudad == null)
            {
                return NotFound();
            }

            return ciudad;
        }

        // PUT: api/Ciudad/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCiudad(int id, Ciudad ciudad)
        {
            if (id != ciudad.IdCiudad)
            {
                return BadRequest();
            }

            _context.Entry(ciudad).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CiudadExists(id))
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

        // POST: api/Ciudad
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Ciudad>> PostCiudad(Ciudad ciudad)
        {
            _context.Ciudads.Add(ciudad);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CiudadExists(ciudad.IdCiudad))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCiudad", new { id = ciudad.IdCiudad }, ciudad);
        }

        // DELETE: api/Ciudad/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCiudad(int id)
        {
            var ciudad = await _context.Ciudads.FindAsync(id);
            if (ciudad == null)
            {
                return NotFound();
            }

            _context.Ciudads.Remove(ciudad);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CiudadExists(int id)
        {
            return _context.Ciudads.Any(e => e.IdCiudad == id);
        }
    }
}
