using System;

namespace AppBasquete.Models
{
    public class Game
    {
        public string Id { get; set; }
        public DateTime Date { get; set; }
        public string PlayerId { get; set; }
        public Player Player { get; set; }
    }
}
