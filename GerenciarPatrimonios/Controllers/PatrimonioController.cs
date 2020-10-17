using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GerenciarPatrimonios.Data;
using GerenciarPatrimonios.Models.Patrimonio;

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

        // GET: api/Patrimonio
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Patrimonio>>> GetPatrimonio()
        {
            return await _context.Patrimonio.ToListAsync();
        }

        // GET: api/Patrimonio/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Patrimonio>> GetPatrimonio(string id)
        {
            var patrimonio = await _context.Patrimonio.FindAsync(id);

            if (patrimonio == null)
            {
                return NotFound();
            }

            return patrimonio;
        }

        // PUT: api/Patrimonio/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
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

        // POST: api/Patrimonio
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
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

        // DELETE: api/Patrimonio/5
        [HttpDelete("{id}")]
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
