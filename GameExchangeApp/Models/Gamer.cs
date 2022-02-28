using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameExchangeApp.Models
{
    public class Gamer
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Location { get; set; }
        [InverseProperty("OwnedBy")]
        public virtual ICollection<Game> GamesOwned { get; set; }
        [InverseProperty("DemandedBy")]
        public virtual ICollection<Game> GamesDemanded { get; set; }
        public Gamer()
        {
            this.GamesOwned = new HashSet<Game>();
            this.GamesDemanded = new HashSet<Game>();
        }
    }
}
