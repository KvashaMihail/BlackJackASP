using System.Collections.Generic;

namespace BlackJack.DAL.Entities
{
    public class Round
    {
        public int Id { get; set; }
        public int NumberRound { get; set; }
        public bool IsCompleted { get; set; }

        public ICollection<RoundPlayer> RoundPlayers { get; set; }

        public int RoundPlayerId { get; set; }
        public int GameId { get; set; }
        public Game Game { get; set; }
        
    }
}
