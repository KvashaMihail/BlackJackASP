using BlackJack.Models;
using System.Collections.Generic;

namespace BlackJack.UI.ViewModels
{
    public class GameViewModel
    {
        public GameViewModel(Models.Game game, IEnumerable<Player> players)
        {
            Game = game;
            Players = players;
        }

        public Models.Game Game { get; set; }
        public IEnumerable<Player> Players { get; set; }
        public int NumberRound { get; set; }
    }
}
