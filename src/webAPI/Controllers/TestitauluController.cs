using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webAPI.Models;

namespace webAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestitauluController : ControllerBase
    {
        private readonly TestDatabaseContext _context;

        public TestitauluController(TestDatabaseContext context)
        {
            _context = context;
        }

        // GET: api/Testitaulu
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Testitaulu>>> GetTestitaulu()
        {
            return await _context.Testitaulus.ToListAsync();
        }

        // GET: api/Testitaulu/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Testitaulu>> GetTestitaulu(int id)
        {
            var testitaulu = await _context.Testitaulus.FindAsync(id);

            if (testitaulu == null)
            {
                return NotFound();
            }

            return testitaulu;
        }

        // POST: api/Testitaulu
        [HttpPost]
        public async Task<ActionResult<Testitaulu>> PostTestitaulu(Testitaulu testitaulu)
        {
            _context.Testitaulus.Add(testitaulu);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTestitaulu", new { id = testitaulu.TestitauluId }, testitaulu);
        }

        // PUT: api/Testitaulu/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTestitaulu(int id, Testitaulu testitaulu)
        {
            if (id != testitaulu.TestitauluId)
            {
                return BadRequest();
            }

            _context.Entry(testitaulu).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TestitauluExists(id))
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

        // DELETE: api/Testitaulu/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTestitaulu(int id)
        {
            var testitaulu = await _context.Testitaulus.FindAsync(id);
            if (testitaulu == null)
            {
                return NotFound();
            }

            _context.Testitaulus.Remove(testitaulu);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TestitauluExists(int id)
        {
            return _context.Testitaulus.Any(e => e.TestitauluId == id);
        }
    }
}
