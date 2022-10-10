using GameExchangeApp.Data;
using GameExchangeApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameExchangeApp.Repositories
{
    public class GameRepository : IGameRepository
    {
        private readonly ApplicationDbContext context;

        public GameRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<ActionResult<Game>> GetGameById(int id)
        {
            return await context.Games.FindAsync(id);
        }

        public async Task<ActionResult<IEnumerable<Game>>> GetGames()
        {
            return await context.Games.ToListAsync();
        }
    }
}
