using System;
using System.Collections.Generic;

namespace AppBasquete.Models
{
    public class Player
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Time { get; set; }
        public DateTime Birthday { get; set; }
        public virtual List<Game> Games { get; set; }
    }
}
