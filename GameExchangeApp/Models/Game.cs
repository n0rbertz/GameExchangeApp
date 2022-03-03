using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace GameExchangeApp.Models
{
    public class Game
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public int ReleaseDate { get; set; }
        public string Genre { get; set; }
        [JsonIgnore]
        public virtual ICollection<Gamer> OwnedBy { get; set; }
        [JsonIgnore]
        public virtual ICollection<Gamer> DemandedBy { get; set; }

        public Game()
        {
            this.OwnedBy = new HashSet<Gamer>();
            this.DemandedBy = new HashSet<Gamer>();
        }
    }
}
