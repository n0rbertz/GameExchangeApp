using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GameExchangeApp.Data;
using GameExchangeApp.Models;
using GameExchangeApp.DTOs;

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
        [Route("{id}/gamesowned")]
        public async Task<ActionResult<IEnumerable<Game>>> GetOwnedGamesOfGamer(int id)
        {
            var gamer = await _context.Gamers.Include("GamesOwned").FirstOrDefaultAsync(g => g.Id.Equals(id));
            return gamer.GamesOwned.ToList();
        }

        [HttpGet]
        [Route("{id}/matches")]
        public async Task<ActionResult<IEnumerable<Gamer>>> GetMatches(int id)
        {
            var gamer = await _context.Gamers.Include("GamesOwned").Include("GamesDemanded").FirstOrDefaultAsync(g => g.Id.Equals(id));
            var gamersWithSameLocation = _context.Gamers.Include("GamesOwned").Include("GamesDemanded").Where(g => g.Location == gamer.Location);
            var gamesDemanded = gamer.GamesDemanded;
            var gamersWithDemandedGame = new List<Gamer>();
            foreach (Game game in gamesDemanded)
            {
                foreach(Gamer g in gamersWithSameLocation)
                {
                    if (g.GamesOwned.Contains(game))
                    {
                        gamersWithDemandedGame.Add(g);
                    }
                }
            }
            var matches = new List<Gamer>();
            foreach (Gamer g in gamersWithDemandedGame)
            {
                foreach (Game game in g.GamesDemanded)
                {
                    if (gamer.GamesOwned.Contains(game))
                    {
                            matches.Add(g);
                    }
                }
            }
            return matches.ToList();
        }

        // GET: api/Gamers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GamerDTO>> GetGamer(int id)
        {
            var gamer = await _context.Gamers.FindAsync(id);

            if (gamer == null)
            {
                return NotFound();
            }

            return new GamerDTO { Name = gamer.Name, Location = gamer.Location };
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
        public async Task<ActionResult<Gamer>> PostGamer([FromBody] Gamer gamer)
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
