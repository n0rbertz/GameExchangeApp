using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GameExchangeApp.DTOs;
using GameExchangeApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace GameExchangeApp.Repositories
{
    public interface IApplicationUserRepository : IRepository<ApplicationUser>
    {
        
        Task<ActionResult<ApplicationUser>> GetUserWithOwnedAndDemandedGames(string id);
        Task<ActionResult<IEnumerable<Game>>> GetOwnedGamesOfUser(string id);       
    }
}
