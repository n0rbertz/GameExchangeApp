using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GameExchangeApp.Data;
using GameExchangeApp.Models;

namespace GameExchangeApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public GamersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Gamers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Gamer>>> GetGamers()
        {
            return await _context.Gamers.ToListAsync();
        }

        [HttpGet]
        [Route("{id}/games")]
        public async Task<ActionResult<IEnumerable<Game>>> GetGamesOfGamer(int id)
        {
            var gamer = await _context.Gamers.Include("Games").FirstOrDefaultAsync(g => g.Id.Equals(id));
            return gamer.Games.ToList();
        }

        // GET: api/Gamers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Gamer>> GetGamer(int id)
        {
            var gamer = await _context.Gamers.FindAsync(id);

            if (gamer == null)
            {
                return NotFound();
            }

            return gamer;
        }

        // PUT: api/Gamers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGamer(int id, Gamer gamer)
        {
            if (id != gamer.Id)
            {
                return BadRequest();
            }

            _context.Entry(gamer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GamerExists(id))
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

        // POST: api/Gamers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Gamer>> PostGamer(Gamer gamer)
        {
            _context.Gamers.Add(gamer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGamer", new { id = gamer.Id }, gamer);
        }

        // DELETE: api/Gamers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGamer(int id)
        {
            var gamer = await _context.Gamers.FindAsync(id);
            if (gamer == null)
            {
                return NotFound();
            }

            _context.Gamers.Remove(gamer);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GamerExists(int id)
        {
            return _context.Gamers.Any(e => e.Id == id);
        }
    }
}
