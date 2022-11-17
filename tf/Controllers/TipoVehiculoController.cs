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
    public class TipoVehiculoController : ControllerBase
    {
        private readonly transflashContext _context;

        public TipoVehiculoController(transflashContext context)
        {
            _context = context;
        }

        // GET: api/TipoVehiculo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoVehiculo>>> GetTipoVehiculos()
        {
            return await _context.TipoVehiculos.ToListAsync();
        }

        // GET: api/TipoVehiculo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TipoVehiculo>> GetTipoVehiculo(int id)
        {
            var tipoVehiculo = await _context.TipoVehiculos.FindAsync(id);

            if (tipoVehiculo == null)
            {
                return NotFound();
            }

            return tipoVehiculo;
        }

        // PUT: api/TipoVehiculo/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTipoVehiculo(int id, TipoVehiculo tipoVehiculo)
        {
            if (id != tipoVehiculo.IdTipoVehiculo)
            {
                return BadRequest();
            }

            _context.Entry(tipoVehiculo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoVehiculoExists(id))
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

        // POST: api/TipoVehiculo
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TipoVehiculo>> PostTipoVehiculo(TipoVehiculo tipoVehiculo)
        {
            _context.TipoVehiculos.Add(tipoVehiculo);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TipoVehiculoExists(tipoVehiculo.IdTipoVehiculo))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTipoVehiculo", new { id = tipoVehiculo.IdTipoVehiculo }, tipoVehiculo);
        }

        // DELETE: api/TipoVehiculo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTipoVehiculo(int id)
        {
            var tipoVehiculo = await _context.TipoVehiculos.FindAsync(id);
            if (tipoVehiculo == null)
            {
                return NotFound();
            }

            _context.TipoVehiculos.Remove(tipoVehiculo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TipoVehiculoExists(int id)
        {
            return _context.TipoVehiculos.Any(e => e.IdTipoVehiculo == id);
        }
    }
}
