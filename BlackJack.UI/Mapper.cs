using BlackJack.UI.Models;
using System.Collections.Generic;

namespace BlackJack.UI
{
    public static class Mapper
    {
        public static PlayerModel ToViewModel(Shared.Models.Player player)
        {
            var playerOut = new PlayerModel
            {
                Id = player.Id,
                Name = player.Name,
            };
            return playerOut;
        }

        public static IEnumerable<PlayerModel> ToViewModel(IEnumerable<Shared.Models.Player> players)
        {
            var playersOut = new List<PlayerModel>();
            foreach (Shared.Models.Player player in players)
            {
                playersOut.Add(ToViewModel(player));
            }
            return playersOut;
        }

        public static GameModel ToViewModel(Shared.Models.Game game)
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
