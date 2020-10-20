using GerenciarPatrimonios.Data;
using GerenciarPatrimonios.Models.Patrimonio;
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
    public class PatrimonioController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PatrimonioController(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Retorna a lista completa.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<Patrimonio>>> GetPatrimonio()
        {
            return await _context.Patrimonio.ToListAsync();
        }

        /// <summary>
        /// Retorna o patrimonio conforme o ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<Patrimonio>> GetPatrimonio(string id)
        {
            var patrimonio = await _context.Patrimonio.FindAsync(id);

            if (patrimonio == null)
            {
                return NotFound();
            }

            return patrimonio;
        }

        /// <summary>
        ///  Atualiza os patrimonios.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="patrimonio"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPatrimonio(string id, Patrimonio patrimonio)
        {
            if (id != patrimonio.MarcaId)
            {
                return BadRequest();
            }

            _context.Entry(patrimonio).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PatrimonioExists(id))
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
        /// Registra um novo Patrimonio.
        /// </summary>
        /// <param name="patrimonio"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<Patrimonio>> PostPatrimonio(Patrimonio patrimonio)
        {
            _context.Patrimonio.Add(patrimonio);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PatrimonioExists(patrimonio.MarcaId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPatrimonio", new { id = patrimonio.MarcaId }, patrimonio);
        }

        /// <summary>
        /// Remove um patrimonio.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult<Patrimonio>> DeletePatrimonio(string id)
        {
            var patrimonio = await _context.Patrimonio.FindAsync(id);
            if (patrimonio == null)
            {
                return NotFound();
            }

            _context.Patrimonio.Remove(patrimonio);
            await _context.SaveChangesAsync();

            return patrimonio;
        }

        private bool PatrimonioExists(string id)
        {
            return _context.Patrimonio.Any(e => e.MarcaId == id);
        }
    }
}