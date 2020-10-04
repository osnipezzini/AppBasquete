using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppBasquete.Models
{
    public class Player
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Team { get; set; }
        public DateTime Birthday { get; set; }
        [NotMapped]
        public List<Game> Games { get; set; }
        public override string ToString()
        {
            return Name;
        }
    }
}
