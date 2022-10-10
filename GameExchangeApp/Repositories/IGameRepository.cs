using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GameExchangeApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace GameExchangeApp.Repositories
{
    public interface IGameRepository
    {

        Task<ActionResult<IEnumerable<Game>>> GetGames();
        Task<ActionResult<Game>> GetGameById(int id);

    }
}
