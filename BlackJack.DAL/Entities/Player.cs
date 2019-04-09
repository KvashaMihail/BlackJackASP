using System.Collections.Generic;

namespace BlackJack.DAL.Entities
{
    public class Player
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsBot { get; set; }


        public ICollection<RoundPlayer> RoundPlayers { get; set; }
    }
}
