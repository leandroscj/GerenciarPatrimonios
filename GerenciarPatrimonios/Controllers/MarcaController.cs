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

        // GET: api/Marca
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<MarcaModel>>> GetMarca()
        {
            return await _context.Marca.ToListAsync();
        }

        // GET: api/Marca/5
        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<MarcaModel>> GetMarca(string id)
        {
            var marca = await _context.Marca.FindAsync(id);

            if (marca == null)
            {
                return NotFound();
            }

            return marca;
        }

        // PUT: api/Marca/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> PutMarca(string id, MarcaModel marca)
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

        // POST: api/Marca
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<MarcaModel>> PostMarca(MarcaModel marca)
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

        // DELETE: api/Marca/5
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult<MarcaModel>> DeleteMarca(string id)
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