using GameExchangeApp.Data;
using GameExchangeApp.DTOs;
using GameExchangeApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameExchangeApp.Repositories
{
    public class ApplicationUserRepository : Repository<ApplicationUser>, IApplicationUserRepository
    {
        

        public ApplicationUserRepository(ApplicationDbContext context) : base(context)
        {
        }

        //public async Task<ActionResult<IEnumerable<ApplicationUser>>> GetUsers()
        //{
        //    return await context.Users.ToListAsync();
        //}

        //public async Task<ActionResult<ApplicationUser>> GetUserById(string id)
        //{
        //    return await context.Users.FindAsync(id);
        //}

        //public void InsertUser(ApplicationUser applicationUser)
        //{
        //    context.Users.Add(applicationUser);           
        //}

        public async Task<ActionResult<ApplicationUser>> GetUserWithOwnedAndDemandedGames(string id)
        {
            return await  context.Users.Include("GamesOwned").Include("GamesDemanded").FirstOrDefaultAsync(u => u.Id.Equals(id));
        }

        public async Task<ActionResult<IEnumerable<Game>>> GetOwnedGamesOfUser(string id)
        {
            var user = await context.Users.Include("GamesOwned").FirstOrDefaultAsync(u => u.Id.Equals(id));
            return user.GamesOwned.ToList();
        }
    }
}
