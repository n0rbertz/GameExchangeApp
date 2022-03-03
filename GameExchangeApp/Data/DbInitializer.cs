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
                new Game {Title = "Last of Us", ReleaseDate = 2013, Genre = "Action-Adventure"},
                new Game {Title = "Devil May Cry", ReleaseDate = 2006, Genre = "Hack & Slash"},
                new Game {Title = "Fable", ReleaseDate = 2004, Genre = "RPG"},
                new Game {Title = "FIFA22", ReleaseDate = 2021, Genre = "Sports"},
                new Game {Title = "NBA 2K22", ReleaseDate = 2021, Genre = "Sports"}
            };

            var gamers = new Gamer[]
            {
                new Gamer {Name = "James", Location="Budapest"},
                new Gamer {Name = "Brian", Location="Budapest"},
                new Gamer {Name = "John", Location="Vienna"},
                new Gamer {Name = "Franklin", Location="London"},
                new Gamer {Name = "Arnold", Location="London"}
            };



            gamers[0].GamesOwned.Add(games[0]);
            gamers[0].GamesDemanded.Add(games[1]);
            gamers[1].GamesOwned.Add(games[1]);
            gamers[1].GamesDemanded.Add(games[0]);
            gamers[2].GamesOwned.Add(games[2]);
            gamers[3].GamesDemanded.Add(games[3]);
            gamers[4].GamesOwned.Add(games[3]);
            gamers[4].GamesDemanded.Add(games[4]);



            foreach (Gamer gamer in gamers)
            {
                context.Gamers.Add(gamer);
            }
            context.SaveChanges();

        }
    }
}
