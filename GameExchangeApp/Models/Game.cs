﻿using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace GameExchangeApp.Models
{
    public class Game
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        [JsonIgnore]
        public virtual ICollection<Gamer> Gamers { get; set; }

        public Game()
        {
            this.Gamers = new HashSet<Gamer>();
        }
    }
}
