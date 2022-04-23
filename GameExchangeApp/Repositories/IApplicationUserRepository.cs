using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GameExchangeApp.DTOs;
using GameExchangeApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace GameExchangeApp.Repositories
{
    public interface IApplicationUserRepository 
    {
        Task<ActionResult<IEnumerable<ApplicationUser>>> GetUsers();
        Task<ActionResult<ApplicationUser>> GetApplicationUserById(string id);
        Task<ActionResult<ApplicationUser>> GetUserWithOwnedAndDemandedGames(string id);
        Task<ActionResult<IEnumerable<Game>>> GetOwnedGamesOfUser(string id);
        void InsertApplicationUser(ApplicationUser applicationUser);
        void Save();
    }
}
