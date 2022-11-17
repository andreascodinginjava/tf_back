using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using tf.Models;
using tf.ModelsView;

namespace tf.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConductorController : ControllerBase
    {
        private readonly transflashContext _context;

        public ConductorController(transflashContext context)
        {
            _context = context;
        }

        // GET: api/Conductor
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Conductor>>> GetConductors()
        {
            return await _context.Conductors.ToListAsync();
        }

        // GET: api/Conductor/Profile
        [HttpGet("/api/Conductor/AllProfiles")]
        public async Task<ActionResult<IEnumerable<InfoConductor>>> GetAllProfilesConductor()
        {
            var query = (from con in _context.Conductors
                         join ciu in _context.Ciudads on con.CiudadConductorFk equals ciu.IdCiudad
                         join gen in _context.Generos on con.GeneroConductorFk equals gen.IdGenero
                         join ve in _context.Vehiculos on con.VehiculoFk equals ve.IdVehiculo
                         join tv in _context.TipoVehiculos on ve.TipoVehiculoFk equals tv.IdTipoVehiculo
                         join col in _context.Colors on ve.ColorVehiculoFk equals col.IdColor
                         select new InfoConductor
                         {
                             DNI = con.IdConductor,
                             Nombre = con.NombreConductor,
                             Apellido = con.ApellidoConductor,
                             Email = con.EmailConductor,
                             Estado = con.EstadoConductor,
                             Ciudad = ciu.Ciudad1,
                             Genero = gen.Genero1,
                             Placa = ve.IdVehiculo,
                             CapacidadVehiculo = ve.Capacidad,
                             TipoVeviculo = tv.TipoVehiculo1,
                             ColorVehiculo = col.Color1
                         }).ToListAsync();

            return await query;
        }

        // GET: api/Conductor/Profile
        [HttpGet("/api/Conductor/Profile/{id}")]
        public async Task<ActionResult<IEnumerable<InfoConductor>>> GetProfileConductor(int id)
        {
            var query = (from con in _context.Conductors
                         join ciu in _context.Ciudads on con.CiudadConductorFk equals ciu.IdCiudad
                         join gen in _context.Generos on con.GeneroConductorFk equals gen.IdGenero
                         join ve in _context.Vehiculos on con.VehiculoFk equals ve.IdVehiculo
                         join tv in _context.TipoVehiculos on ve.TipoVehiculoFk equals tv.IdTipoVehiculo
                         join col in _context.Colors on ve.ColorVehiculoFk equals col.IdColor
                         where con.IdConductor == id
                         select new InfoConductor
                         {
                             DNI = con.IdConductor,
                             Nombre = con.NombreConductor,
                             Apellido = con.ApellidoConductor,
                             Email = con.EmailConductor,
                             Estado = con.EstadoConductor,
                             Ciudad = ciu.Ciudad1,
                             Genero = gen.Genero1,
                             Placa = ve.IdVehiculo,
                             CapacidadVehiculo = ve.Capacidad,
                             TipoVeviculo = tv.TipoVehiculo1,
                             ColorVehiculo = col.Color1
                         }).ToListAsync();

            return await query;
        }

        // GET: api/Cliente/LogInConductor/123464567/abc123
        [HttpGet("/api/Conductor/LogIn/{id}/{clave}")]
        public async Task<ActionResult<IEnumerable<LogInConductor>>> GetLogInConductor(int id, string clave)
        {
            var query = (from con in _context.Conductors
                         where con.IdConductor == id && con.PswConductor == clave
                         select new LogInConductor
                         {
                             IdConductor = con.IdConductor,
                             ClaveConductor = con.PswConductor,
                             EstadoConductor = con.EstadoConductor
                         }).ToListAsync();

            return await query;
        }

        // GET: api/Conductor/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Conductor>> GetConductor(int id)
        {
            var conductor = await _context.Conductors.FindAsync(id);

            if (conductor == null)
            {
                return NotFound();
            }

            return conductor;
        }

        // PUT: api/Conductor/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutConductor(int id, Conductor conductor)
        {
            if (id != conductor.IdConductor)
            {
                return BadRequest();
            }

            _context.Entry(conductor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConductorExists(id))
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

        // POST: api/Conductor
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Conductor>> PostConductor(Conductor conductor)
        {
            _context.Conductors.Add(conductor);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ConductorExists(conductor.IdConductor))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetConductor", new { id = conductor.IdConductor }, conductor);
        }

        // DELETE: api/Conductor/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteConductor(int id)
        {
            var conductor = await _context.Conductors.FindAsync(id);
            if (conductor == null) 
            {
                return NotFound();
            }

            _context.Conductors.Remove(conductor);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ConductorExists(int id)
        {
            return _context.Conductors.Any(e => e.IdConductor == id);
        }
    }
}
