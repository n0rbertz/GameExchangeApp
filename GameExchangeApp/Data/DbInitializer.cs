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

            

            gamers[0].Games.Add(games[0]);
            gamers[0].Games.Add(games[1]);
            gamers[1].Games.Add(games[2]);



            foreach (Gamer g in gamers)
            {
                context.Gamers.Add(g);
            }
            context.SaveChanges();

        }
    }
}
