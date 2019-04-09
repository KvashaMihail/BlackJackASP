using System;
using System.Collections.Generic;

namespace BlackJack.DAL.Entities
{
    public class Game
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateFinishLastRound { get; set; }
        public bool IsFinished { get; set; }
        public ICollection<Round> Rounds { get; set; }
    }
}
