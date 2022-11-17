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
    public class ClienteController : ControllerBase
    {
        private readonly transflashContext _context;

        public ClienteController(transflashContext context)
        {
            _context = context;
        }

        // GET: api/Cliente
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cliente>>> GetClientes()
        {
            return await _context.Clientes.ToListAsync();
        }

        // GET: api/Cliente/Profile
        [HttpGet("/api/Cliente/AllProfiles")]
        public async Task<ActionResult<IEnumerable<InfoCliente>>> GetAllProfilesCliente()
        {
            var query = (from cli in _context.Clientes
                         join ciu in _context.Ciudads on cli.CiudadClienteFk equals ciu.IdCiudad
                         join gen in _context.Generos on cli.GeneroClienteFk equals gen.IdGenero
                         select new InfoCliente
                         {
                             DNI = cli.IdCliente,
                             Nombre = cli.NombreCliente,
                             Apellido = cli.ApellidoCliente,
                             Email = cli.EmailCliente,
                             Estado = cli.EstadoCliente,
                             Ciudad = ciu.Ciudad1,
                             Genero = gen.Genero1
                         }).ToArrayAsync();

            return await query;
        }

        // GET: api/Cliente/Profile
        [HttpGet("/api/Cliente/Profile/{id}")]
        public async Task<ActionResult<IEnumerable<InfoCliente>>> GetProfileCliente(int id)
        {
            var query = (from cli in _context.Clientes
                         join ciu in _context.Ciudads on cli.CiudadClienteFk equals ciu.IdCiudad
                         join gen in _context.Generos on cli.GeneroClienteFk equals gen.IdGenero
                         where cli.IdCliente == id
                         select new InfoCliente
                         {
                             DNI = cli.IdCliente,
                             Nombre = cli.NombreCliente,
                             Apellido = cli.ApellidoCliente,
                             Email = cli.EmailCliente,
                             Estado = cli.EstadoCliente,
                             Ciudad = ciu.Ciudad1,
                             Genero = gen.Genero1
                         }).ToArrayAsync();

            return await query;
        }

        // GET: api/Cliente/LogInCliente/123464567/abc123
        [HttpGet("/api/Cliente/LogIn/{id}/{clave}")]
        public async Task<ActionResult<IEnumerable<LogInCliente>>> GetLogInCliente(int id, string clave)
        {
            var query = (from cli in _context.Clientes
                         where cli.IdCliente == id && cli.PswCliente == clave 
                         select new LogInCliente
                         {
                             IdCliente = cli.IdCliente,
                             ClaveCliente = cli.PswCliente,
                             EstadoCliente = cli.EstadoCliente
                         }).ToListAsync();  

            return await query;
        }

        // GET: api/Cliente/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cliente>> GetCliente(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);

            if (cliente == null)
            {
                return NotFound();
            }

            return cliente;
        }

        // PUT: api/Cliente/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCliente(int id, Cliente cliente)
        {
            if (id != cliente.IdCliente)
            {
                return BadRequest();
            }

            _context.Entry(cliente).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClienteExists(id))
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

        // POST: api/Cliente
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Cliente>> PostCliente(Cliente cliente)
        {
            _context.Clientes.Add(cliente);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ClienteExists(cliente.IdCliente))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCliente", new { id = cliente.IdCliente }, cliente);
        }

        // DELETE: api/Cliente/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCliente(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente == null)
            {
                return NotFound();
            }

            _context.Clientes.Remove(cliente);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ClienteExists(int id)
        {
            return _context.Clientes.Any(e => e.IdCliente == id);
        }
    }
}
