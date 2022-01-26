using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameExchangeApp.Models;

namespace GameExchangeApp.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Gamers.Any())
            {
                return;   // DB has been seeded
            }

            var games = new Game[]
            {
                new Game {Title = "Last of Us"},
                new Game {Title = "Devil May Cry"},
                new Game {Title = "Fable"}
            };

            var gamers = new Gamer[]
            {
                new Gamer {Name = "James"},
                new Gamer {Name = "Brian"},
                new Gamer {Name = "John"}
            };

            games[0].Gamers.Add(gamers[0]);
            games[1].Gamers.Add(gamers[0]);
            games[2].Gamers.Add(gamers[1]);


            foreach(Game game in games)
            {
                context.Games.Add(game);
            }
            context.SaveChanges();

        }
    }
}
