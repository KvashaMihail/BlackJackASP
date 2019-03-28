using BlackJack.UI.Models;
using System.Collections.Generic;

namespace BlackJack.UI.ViewModels
{
    public class GameViewModel
    {
        public GameViewModel(GameModel game, IEnumerable<PlayerModel> players)
        {
            Game = game;
            Players = players;
        }

        public GameModel Game { get; set; }
        public IEnumerable<PlayerModel> Players { get; set; }
    }
}
