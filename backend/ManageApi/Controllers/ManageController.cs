using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ManageApi.Data;
using ManageApi.Models;

namespace ManageApi.Controllers
{
    [Route("api/manages")]
    [ApiController]
    public class ManageController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ManageController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/manages
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Manage>>> GetManages()
        {
            var manages = await _context.Manages.ToListAsync();
            return Ok(manages);
        }

        // GET: api/manages/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Manage>> GetManage(long id)
        {
            var manage = await _context.Manages.FindAsync(id);

            if (manage == null)
            {
                return NotFound();
            }

            return Ok(manage);
        }

        // POST: api/manages
        [HttpPost]
        public async Task<ActionResult<Manage>> CreateManage(Manage manage)
        {
            _context.Manages.Add(manage);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetManage), new { id = manage.Id }, manage);
        }

        // PUT: api/manages/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateManage(long id, Manage manage)
        {
            if (id != manage.Id)
            {
                return BadRequest();
            }

            _context.Entry(manage).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ManageExists(id))
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

        // DELETE: api/manages/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteManage(long id)
        {
            var manage = await _context.Manages.FindAsync(id);
            if (manage == null)
            {
                return NotFound();
            }

            _context.Manages.Remove(manage);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ManageExists(long id)
        {
            return _context.Manages.Any(e => e.Id == id);
        }
    }
}
