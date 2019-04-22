using BlackJack.Models;
using System.Collections.Generic;

namespace BlackJack.ViewModels.Game
{
    public class GameViewModel
    {
        public Models.Game Game { get; set; }
        public IEnumerable<Player> Players { get; set; }
        public List<List<byte>> Cards { get; set; }
        public List<byte> Scores { get; set; }
    }
}
