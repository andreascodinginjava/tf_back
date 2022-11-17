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
    public class MedioPagoController : ControllerBase
    {
        private readonly transflashContext _context;

        public MedioPagoController(transflashContext context)
        {
            _context = context;
        }

        // GET: api/MedioPago
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MedioPago>>> GetMedioPagos()
        {
            return await _context.MedioPagos.ToListAsync();
        }

        // GET: api/MedioPago/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MedioPago>> GetMedioPago(int id)
        {
            var medioPago = await _context.MedioPagos.FindAsync(id);

            if (medioPago == null)
            {
                return NotFound();
            }

            return medioPago;
        }

        // PUT: api/MedioPago/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMedioPago(int id, MedioPago medioPago)
        {
            if (id != medioPago.IdMedioPago)
            {
                return BadRequest();
            }

            _context.Entry(medioPago).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MedioPagoExists(id))
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

        // POST: api/MedioPago
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MedioPago>> PostMedioPago(MedioPago medioPago)
        {
            _context.MedioPagos.Add(medioPago);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (MedioPagoExists(medioPago.IdMedioPago))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetMedioPago", new { id = medioPago.IdMedioPago }, medioPago);
        }

        // DELETE: api/MedioPago/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMedioPago(int id)
        {
            var medioPago = await _context.MedioPagos.FindAsync(id);
            if (medioPago == null)
            {
                return NotFound();
            }

            _context.MedioPagos.Remove(medioPago);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MedioPagoExists(int id)
        {
            return _context.MedioPagos.Any(e => e.IdMedioPago == id);
        }
    }
}
