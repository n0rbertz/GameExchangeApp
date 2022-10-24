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
using GameExchangeApp.Repositories;

namespace GameExchangeApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationUserController : ControllerBase
    {
        private readonly IApplicationUserRepository userRepository;
        private readonly IGameRepository gameRepository;

        public ApplicationUserController(IApplicationUserRepository userRepository, IGameRepository gameRepository)
        {
            this.userRepository = userRepository;
            this.gameRepository = gameRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ApplicationUser>>> GetUsers()
        {
            return await userRepository.GetUsers();
        }

        [HttpGet]
        [Route("{id}/gamesowned")]
        public async Task<ActionResult<IEnumerable<Game>>> GetOwnedGamesOfUser(string id)
        {
            return await userRepository.GetOwnedGamesOfUser(id);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ApplicationUser>> GetUser(string id)
        {
            var user = await userRepository.GetUserById(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        [HttpPost]
        [Route("{userId}/addgame")]
        public async Task<ActionResult<ApplicationUser>> AddGame(string userId, [FromBody] int gameId)
        {
            var game = await gameRepository.GetGameById(gameId);
            var user = await userRepository.GetUserById(userId);

            if (game == null || user == null)
            {
                return NotFound();
            }

            userRepository.AddGame(user.Value, game.Value);
            gameRepository.AddUserToGame(user.Value, game.Value);

            userRepository.Save();
            gameRepository.Save();

            return CreatedAtAction(userId, game.Value);          
        }

        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public ActionResult<ApplicationUser> PostUser([FromBody] ApplicationUser user)
        {
            userRepository.InsertUser(user);
            userRepository.Save();

            return CreatedAtAction("GetUser", new { id = user.Id }, user);
        }

        


    }
}
