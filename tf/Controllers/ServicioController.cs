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
    public class ServicioController : ControllerBase
    {
        private readonly transflashContext _context;

        public ServicioController(transflashContext context)
        {
            _context = context;
        }

        // GET: api/Servicio
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Servicio>>> GetServicios()
        {
            return await _context.Servicios.ToListAsync();
        }

        // GET: api/Servicio
        [HttpGet("/api/Servicio/Clientes/{id}")]
        public async Task<ActionResult<IEnumerable<ServiciosCliente>>> GetServiciosCliente(int id)
        {
            var query = (from ser in _context.Servicios
                         join mer in _context.Mercancia on ser.MercanciaFk equals mer.IdMercancia
                         join ciu in _context.Ciudads on ser.CiudadFk equals ciu.IdCiudad
                         join cli in _context.Clientes on mer.ClienteFk equals cli.IdCliente
                         join tm in _context.TipoMercancia on mer.TipoMercanciaFk equals tm.IdTipoMercancia
                         join con in _context.Conductors on ser.ConductorFk equals con.IdConductor
                         where cli.IdCliente == id
                         select new ServiciosCliente
                         {
                             NombreConductor = con.NombreConductor,
                             ApellidoConductor = con.ApellidoConductor,
                             NombreMercancia = mer.NombreMercancia,
                             TipoMercancia = tm.TipoMercancia,
                             FechaServicio = ser.FechaServicio,
                             DireccionOrigen = ser.DireccionOrigen,
                             DireccionDestino = ser.DireccionDestino,
                             CiudadServicio = ciu.Ciudad1
                         }).ToArrayAsync();
            return await query;
        }

        // GET: api/Servicio
        [HttpGet("/api/Servicio/ValorTotal/{id}")]
        public async Task<ActionResult<IEnumerable<ValorNetoServicios>>> GetValorTotalServicios(int id)
        {
            var query = (from ser in _context.Servicios
                         where ser.ConductorFk == id
                         select new ValorNetoServicios
                         {
                             ValorServicio = ser.ValorServicio
                         }).ToArrayAsync();

            return await query;
        }

        // GET: api/Servicio
        [HttpGet("/api/Servicio/Conductor/{id}")]
        public async Task<ActionResult<IEnumerable<ServiciosPublicados>>> GetServiciosConductor(int id)
        {
            var query = (from ser in _context.Servicios
                         join mer in _context.Mercancia on ser.MercanciaFk equals mer.IdMercancia
                         join ciu in _context.Ciudads on ser.CiudadFk equals ciu.IdCiudad
                         join cli in _context.Clientes on mer.ClienteFk equals cli.IdCliente
                         join tm in _context.TipoMercancia on mer.TipoMercanciaFk equals tm.IdTipoMercancia
                         where ser.ConductorFk == id
                         select new ServiciosPublicados
                         {
                             NombreCliente = cli.NombreCliente,
                             ApellidoCliente = cli.ApellidoCliente,
                             EmailCliente = cli.EmailCliente,
                             NombreMercancia = mer.NombreMercancia,
                             TipoMercancia = tm.TipoMercancia,
                             FechaServicio = ser.FechaServicio,
                             DireccionOrigen = ser.DireccionOrigen,
                             DireccionDestino = ser.DireccionDestino,
                             CiudadServicio = ciu.Ciudad1
                         }).ToArrayAsync();
            return await query;
        }

        // GET: api/Servicio
        [HttpGet("/api/Servicio/Conductor/Historial/{id}")]
        public async Task<ActionResult<IEnumerable<HistorialConductor>>> GetServiciosConductorHistorial(int id)
        {
            var query = (from ser in _context.Servicios
                         join mer in _context.Mercancia on ser.MercanciaFk equals mer.IdMercancia
                         join ciu in _context.Ciudads on ser.CiudadFk equals ciu.IdCiudad
                         join cli in _context.Clientes on mer.ClienteFk equals cli.IdCliente
                         where ser.ConductorFk == id
                         select new HistorialConductor
                         {
                             NombreCliente = cli.NombreCliente,
                             ApellidoCliente = cli.ApellidoCliente,
                             NombreMercancia = mer.NombreMercancia,
                             FechaServicio = ser.FechaServicio,
                             ValorServicio = ser.ValorServicio,
                             CiudadServicio = ciu.Ciudad1
                         }).ToArrayAsync();
            return await query;
        }

        // GET: api/Servicio
        [HttpGet("/api/Servicio/Cliente/Historial/{id}")]
        public async Task<ActionResult<IEnumerable<HistorialCliente>>> GetServiciosClienteHistorial(int id)
        {
            var query = (from ser in _context.Servicios
                         join mer in _context.Mercancia on ser.MercanciaFk equals mer.IdMercancia
                         join ciu in _context.Ciudads on ser.CiudadFk equals ciu.IdCiudad
                         join cli in _context.Clientes on mer.ClienteFk equals cli.IdCliente
                         join con in _context.Conductors on ser.ConductorFk equals con.IdConductor
                         where cli.IdCliente == id
                         select new HistorialCliente
                         {
                             NombreConductor = con.NombreConductor,
                             ApellidoConductor = con.ApellidoConductor,
                             NombreMercancia = mer.NombreMercancia,
                             FechaServicio = ser.FechaServicio,
                             ValorServicio = ser.ValorServicio,
                             CiudadServicio = ciu.Ciudad1
                         }).ToArrayAsync();
            return await query;
        }

        // GET: api/Servicio
        [HttpGet("/api/Servicio/Publicados")]
        public async Task<ActionResult<IEnumerable<ServiciosPublicados>>> GetServiciosPublicados()
        {
            var query = (from ser in _context.Servicios
                         join mer in _context.Mercancia on ser.MercanciaFk equals mer.IdMercancia
                         join ciu in _context.Ciudads on ser.CiudadFk equals ciu.IdCiudad
                         join cli in _context.Clientes on mer.ClienteFk equals cli.IdCliente
                         join tm in _context.TipoMercancia on mer.TipoMercanciaFk equals tm.IdTipoMercancia
                         select new ServiciosPublicados
                         {
                             NombreCliente = cli.NombreCliente,
                             ApellidoCliente = cli.ApellidoCliente,
                             EmailCliente = cli.EmailCliente,
                             NombreMercancia = mer.NombreMercancia,
                             TipoMercancia = tm.TipoMercancia,
                             FechaServicio = ser.FechaServicio,
                             DireccionOrigen = ser.DireccionOrigen,
                             DireccionDestino = ser.DireccionDestino,
                             CiudadServicio = ciu.Ciudad1
                         }).ToArrayAsync();
            return await query;
        }

        // GET: api/Servicio/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Servicio>> GetServicio(int id)
        {
            var servicio = await _context.Servicios.FindAsync(id);

            if (servicio == null)
            {
                return NotFound();
            }

            return servicio;
        }

        // PUT: api/Servicio/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutServicio(int id, Servicio servicio)
        {
            if (id != servicio.IdServicio)
            {
                return BadRequest();
            }

            _context.Entry(servicio).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServicioExists(id))
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

        // POST: api/Servicio
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Servicio>> PostServicio(Servicio servicio)
        {
            _context.Servicios.Add(servicio);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ServicioExists(servicio.IdServicio))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetServicio", new { id = servicio.IdServicio }, servicio);
        }

        // DELETE: api/Servicio/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteServicio(int id)
        {
            var servicio = await _context.Servicios.FindAsync(id);
            if (servicio == null)
            {
                return NotFound();
            }

            _context.Servicios.Remove(servicio);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ServicioExists(int id)
        {
            return _context.Servicios.Any(e => e.IdServicio == id);
        }
    }
}
