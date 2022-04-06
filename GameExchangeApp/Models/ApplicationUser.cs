using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameExchangeApp.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Location { get; set; }
        [InverseProperty("OwnedBy")]
        public virtual ICollection<Game> GamesOwned { get; set; }
        [InverseProperty("DemandedBy")]
        public virtual ICollection<Game> GamesDemanded { get; set; }
        public ApplicationUser()
        {
            this.GamesOwned = new HashSet<Game>();
            this.GamesDemanded = new HashSet<Game>();
        }
    }
}
