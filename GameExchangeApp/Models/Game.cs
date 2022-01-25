using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameExchangeApp.Models
{
    public class Game
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public ICollection<Gamer> Gamers { get; set; }

        public Game()
        {
            this.Gamers = new HashSet<Gamer>();
        }
    }
}
