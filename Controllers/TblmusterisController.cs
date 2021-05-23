using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BulutBilisim.Models;

namespace BulutBilisim.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TblmusterisController : ControllerBase
    {
        private readonly BulutBilisimContext _context;

        public TblmusterisController(BulutBilisimContext context)
        {
            _context = context;
        }

        // GET: api/Tblmusteris
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tblmusteri>>> GetTblmusteris()
        {
            return await _context.Tblmusteris.ToListAsync();
        }

        // GET: api/Tblmusteris/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tblmusteri>> GetTblmusteri(int id)
        {
            var tblmusteri = await _context.Tblmusteris.FindAsync(id);

            if (tblmusteri == null)
            {
                return NotFound();
            }

            return tblmusteri;
        }

        // PUT: api/Tblmusteris/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblmusteri(int id, Tblmusteri tblmusteri)
        {
            if (id != tblmusteri.Musteriid)
            {
                return BadRequest();
            }

            _context.Entry(tblmusteri).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblmusteriExists(id))
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

        // POST: api/Tblmusteris
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Tblmusteri>> PostTblmusteri(Tblmusteri tblmusteri)
        {
            _context.Tblmusteris.Add(tblmusteri);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblmusteri", new { id = tblmusteri.Musteriid }, tblmusteri);
        }

        // DELETE: api/Tblmusteris/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTblmusteri(int id)
        {
            var tblmusteri = await _context.Tblmusteris.FindAsync(id);
            if (tblmusteri == null)
            {
                return NotFound();
            }

            _context.Tblmusteris.Remove(tblmusteri);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TblmusteriExists(int id)
        {
            return _context.Tblmusteris.Any(e => e.Musteriid == id);
        }
    }
}
