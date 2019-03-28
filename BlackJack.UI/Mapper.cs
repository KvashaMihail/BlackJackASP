using BlackJack.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlackJack.UI
{
    public static class Mapper
    {
        public static PlayerModel ToViewModel(BL.Models.Player player)
        {
            var playerOut = new PlayerModel
            {
                Id = player.Id,
                Name = player.Name,
            };
            return playerOut;
        }

        public static IEnumerable<PlayerModel> ToViewModel(IEnumerable<BL.Models.Player> players)
        {
            var playersOut = new List<PlayerModel>();
            foreach (BL.Models.Player player in players)
            {
                playersOut.Add(ToViewModel(player));
            }
            return playersOut;
        }

        public static GameModel ToViewModel(BL.Models.Game game)
        {
            var gameOut = new GameModel
            {
                Id = game.Id,
                Name = game.Name
            };
            return gameOut;
        }
    }
}
