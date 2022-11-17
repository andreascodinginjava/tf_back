using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using tf.Models;
using File = tf.Models.File;

namespace tf.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilesController : ControllerBase
    {
        private readonly transflashContext _context;

        public FilesController(transflashContext context)
        {
            _context = context;
        }

        // GET: api/Files
        [HttpGet]
        public async Task<ActionResult<IEnumerable<File>>> GetFiles()
        {
            return await _context.Files.ToListAsync();
        }

        // GET: api/Files/5
        [HttpGet("{id}")]
        public async Task<ActionResult<File>> GetFile(int id)
        {
            var file = await _context.Files.FindAsync(id);

            if (file == null)
            {
                return NotFound();
            }

            return file;
        }

        // PUT: api/Files/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFile(int id, File file)
        {
            if (id != file.IdFile)
            {
                return BadRequest();
            }

            _context.Entry(file).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FileExists(id))
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

        // POST: api/Files
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /*[HttpPost]
        public async Task<ActionResult<File>> PostFile(File file)
        {
            _context.Files.Add(file);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFile", new { id = file.IdFile }, file);
        }*/

        [HttpPost("{idVehiculo}")]
        public ActionResult PostArchivo([FromForm] List<IFormFile> files, string idVehiculo)
        {
            List<File> archivos = new List<File>();
            try
            {
                if (files.Count > 0)
                {
                    foreach (var file in files)
                    {
                        File archivo = new File();
                        //archivo.NombreFile = new Guid().ToString();
                        var filePath = "C:\\Users\\User\\Documents\\Proyecto\\tf\\tf\\Uploads\\" + idVehiculo + file.FileName;
                        using (var stream = System.IO.File.Create(filePath))
                        {
                            file.CopyToAsync(stream);
                        }
                        double tamanio = file.Length;
                        tamanio = tamanio / 1000000;
                        tamanio = Math.Round(tamanio, 2);
                        archivo.NombreFile = Path.GetFileNameWithoutExtension(file.FileName) + idVehiculo;
                        archivo.ExtensionFile = Path.GetExtension(file.FileName).Substring(1);
                        archivo.TamanioFile = tamanio;
                        archivo.UbicacionFile = filePath;
                        archivo.VehiculoFk = idVehiculo;
                        archivos.Add(archivo);
                    }
                    _context.Files.AddRange(archivos);
                    _context.SaveChanges();

                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            return Ok(archivos);
        }

        // DELETE: api/Files/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFile(int id)
        {
            var file = await _context.Files.FindAsync(id);
            if (file == null)
            {
                return NotFound();
            }

            _context.Files.Remove(file);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FileExists(int id)
        {
            return _context.Files.Any(e => e.IdFile == id);
        }
    }
}
