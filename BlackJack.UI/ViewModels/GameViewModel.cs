using BlackJack.Models;
using System.Collections.Generic;

namespace BlackJack.UI.ViewModels
{
    public class GameViewModel
    {
        public GameViewModel(Game game, IEnumerable<Player> players)
        {
            Game = game;
            Players = players;
        }

        public Game Game { get; set; }
        public IEnumerable<Player> Players { get; set; }
        public int NumberRound { get; set; }
    }
}
