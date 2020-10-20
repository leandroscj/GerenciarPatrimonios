using GerenciarPatrimonios.Data;
using GerenciarPatrimonios.Models.Marca;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciarPatrimonios.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarcaController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public MarcaController(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Retorna a lista completa.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<Marca>>> GetMarca()
        {
            return await _context.Marca.ToListAsync();
        }

        /// <summary>
        /// Retorna a marca conforme o ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [Authorize()]
        public async Task<ActionResult<Marca>> GetMarca(string id)
        {
            var marca = await _context.Marca.FindAsync(id);

            if (marca == null)
            {
                return NotFound();
            }

            return marca;
        }

        /// <summary>
        /// Registra uma nova marca.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="marca"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> PutMarca(string id, Marca marca)
        {
            if (id != marca.MarcaId)
            {
                return BadRequest();
            }

            _context.Entry(marca).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MarcaExists(id))
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

        /// <summary>
        /// Registra uma nova marca.
        /// </summary>
        /// <param name="marca"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<Marca>> PostMarca(Marca marca)
        {
            _context.Marca.Add(marca);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (MarcaExists(marca.MarcaId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetMarca", new { id = marca.MarcaId }, marca);
        }

        /// <summary>
        /// Remove uma marca.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult<Marca>> DeleteMarca(string id)
        {
            var marca = await _context.Marca.FindAsync(id);
            if (marca == null)
            {
                return NotFound();
            }

            _context.Marca.Remove(marca);
            await _context.SaveChangesAsync();

            return marca;
        }

        private bool MarcaExists(string id)
        {
            return _context.Marca.Any(e => e.MarcaId == id);
        }
    }
}