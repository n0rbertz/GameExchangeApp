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
    public class UsersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public UsersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Gamers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ApplicationUser>>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        [HttpGet]
        [Route("{id}/gamesowned")]
        public async Task<ActionResult<IEnumerable<Game>>> GetOwnedGamesOfUser(string id)
        {
            var user = await _context.Users.Include("GamesOwned").FirstOrDefaultAsync(u => u.Id.Equals(id));
            return user.GamesOwned.ToList();
        }

        [HttpGet]
        [Route("{id}/matches")]
        public async Task<ActionResult<IEnumerable<ApplicationUser>>> GetMatches(string id)
        {
            var user = await _context.Users.Include("GamesOwned").Include("GamesDemanded").FirstOrDefaultAsync(u => u.Id.Equals(id));
            var usersWithSameLocation = _context.Users.Include("GamesOwned").Include("GamesDemanded").Where(u => u.Location == user.Location);
            var gamesDemanded = user.GamesDemanded;
            var usersWithDemandedGame = new List<ApplicationUser>();
            foreach (Game game in gamesDemanded)
            {
                foreach(ApplicationUser u in usersWithSameLocation)
                {
                    if (u.GamesOwned.Contains(game))
                    {
                        usersWithDemandedGame.Add(u);
                    }
                }
            }
            var matches = new List<ApplicationUser>();
            foreach (ApplicationUser u in usersWithDemandedGame)
            {
                foreach (Game game in u.GamesDemanded)
                {
                    if (u.GamesOwned.Contains(game))
                    {
                            matches.Add(u);
                    }
                }
            }
            return matches.ToList();
        }

        // GET: api/Gamers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GamerDTO>> GetUser(string id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return new GamerDTO { Name = user.UserName, Location = user.Location };
        }

        // PUT: api/Gamers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(string id, ApplicationUser user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
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
        public async Task<ActionResult<Gamer>> PostUser([FromBody] ApplicationUser user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGamer", new { id = user.Id }, user);
        }

        // DELETE: api/Gamers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserExists(string id)
        {
            return _context.Users.Any(e => e.Id == id);
        }
    }
}
