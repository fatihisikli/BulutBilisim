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
    public class TblurunsController : ControllerBase
    {
        private readonly BulutBilisimContext _context;

        public TblurunsController(BulutBilisimContext context)
        {
            _context = context;
        }

        // GET: api/Tbluruns
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tblurun>>> GetTbluruns()
        {
            return await _context.Tbluruns.ToListAsync();
        }

        // GET: api/Tbluruns/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tblurun>> GetTblurun(int id)
        {
            var tblurun = await _context.Tbluruns.FindAsync(id);

            if (tblurun == null)
            {
                return NotFound();
            }

            return tblurun;
        }

        // PUT: api/Tbluruns/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblurun(int id, Tblurun tblurun)
        {
            if (id != tblurun.Urunid)
            {
                return BadRequest();
            }

            _context.Entry(tblurun).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblurunExists(id))
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

        // POST: api/Tbluruns
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Tblurun>> PostTblurun(Tblurun tblurun)
        {
            _context.Tbluruns.Add(tblurun);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblurun", new { id = tblurun.Urunid }, tblurun);
        }

        // DELETE: api/Tbluruns/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTblurun(int id)
        {
            var tblurun = await _context.Tbluruns.FindAsync(id);
            if (tblurun == null)
            {
                return NotFound();
            }

            _context.Tbluruns.Remove(tblurun);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TblurunExists(int id)
        {
            return _context.Tbluruns.Any(e => e.Urunid == id);
        }
    }
}
