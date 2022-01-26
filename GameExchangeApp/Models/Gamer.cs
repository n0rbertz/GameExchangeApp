using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameExchangeApp.Models
{
    public class Gamer
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Game> Games { get; set; }

        public Gamer()
        {
            this.Games = new HashSet<Game>();
        }
    }
}
