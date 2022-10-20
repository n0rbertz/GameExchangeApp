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
            if (context.Users.Any())
            {
                return;   // DB has been seeded
            }

            var games = new Game[]
            {
                new Game {Title = "Last of Us", ReleaseDate = 2013, Genre = "Action-Adventure", Image = "C:\\Programozás\\GameExchangeApp\\GameExchangeApp\\GameExchangeApp\\ClientApp\\src\\images\\TLOU.png"},
                new Game {Title = "Devil May Cry", ReleaseDate = 2006, Genre = "Hack & Slash", Image = "C:\\Programozás\\GameExchangeApp\\GameExchangeApp\\GameExchangeApp\\ClientApp\\src\\images\\DMC5.png"},
                new Game {Title = "Fable", ReleaseDate = 2004, Genre = "RPG", Image = "C:\\Programozás\\GameExchangeApp\\GameExchangeApp\\GameExchangeApp\\ClientApp\\src\\images\\Fable.png"},
                new Game {Title = "FIFA22", ReleaseDate = 2021, Genre = "Sports", Image = "C:\\Programozás\\GameExchangeApp\\GameExchangeApp\\GameExchangeApp\\ClientApp\\src\\images\\FIFA23.png"},
                new Game {Title = "NBA 2K22", ReleaseDate = 2021, Genre = "Sports", Image = "C:\\Programozás\\GameExchangeApp\\GameExchangeApp\\GameExchangeApp\\ClientApp\\src\\images\\NBA2K23.png"}
            };

            var gamers = new ApplicationUser[]
            {
                new ApplicationUser {UserName = "James", Location="Budapest"},
                new ApplicationUser {UserName = "Brian", Location="Budapest"},
                new ApplicationUser {UserName = "John", Location="Vienna"},
                new ApplicationUser {UserName = "Franklin", Location="London"},
                new ApplicationUser {UserName = "Arnold", Location="London"}
            };



            gamers[0].GamesOwned.Add(games[0]);
            gamers[0].GamesDemanded.Add(games[1]);
            gamers[1].GamesOwned.Add(games[1]);
            gamers[1].GamesDemanded.Add(games[0]);
            gamers[2].GamesOwned.Add(games[2]);
            gamers[3].GamesDemanded.Add(games[3]);
            gamers[4].GamesOwned.Add(games[3]);
            gamers[4].GamesDemanded.Add(games[4]);



            foreach (ApplicationUser user in gamers)
            {
                context.Users.Add(user);
            }
            context.SaveChanges();

        }
    }
}
