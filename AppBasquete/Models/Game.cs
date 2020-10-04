using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppBasquete.Models
{
    public class Game
    {
        public string Id { get; set; }
        public DateTime Date { get; set; }
        public int Placar { get; set; }
        public int MaxRecord { get; set; }
        public int MinRecord { get; set; }
        public int MinRecordBroken { get; set; }
        public int MaxRecordBroken { get; set; }
        public string PlayerId { get; set; }
        public Player Player { get; set; }
    }
}
