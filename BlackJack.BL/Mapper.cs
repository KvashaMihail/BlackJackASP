using BlackJack.BL.Models;
using System.Collections.Generic;

namespace BlackJack.BL
{
    public static class Mapper
    {
        public static Player ToModel(DAL.Entities.Player player)
        {
            Player playerOut = new Player
            {
                Id = player.Id,
                Name = player.Name,
                IsBot = player.IsBot
            };
            return playerOut;
        }

        public static IEnumerable<Player> ToModel(IEnumerable<DAL.Entities.Player> players)
        {
            var playersOut = new List<Player>();
            foreach (DAL.Entities.Player player in players)
            {
                playersOut.Add(ToModel(player));
            }
            return playersOut;
        }

        public static DAL.Entities.Player ToEntity(Player player)
        {
            DAL.Entities.Player playerOut = new DAL.Entities.Player
            {
                Id = player.Id,
                Name = player.Name,
                IsBot = player.IsBot
            };
            return playerOut;
        }

        public static Game ToModel(DAL.Entities.Game game)
        {
            Game gameOut = new Game
            {
                Id = game.Id,
                Name = game.Name,
                DateStart = game.DateStart,
                DateEnd = game.DateEnd
            };
            return gameOut;
        }

        public static IEnumerable<Game> ToModel(IEnumerable<DAL.Entities.Game> games)
        {
            var gamesOut = new List<Game>();
            foreach (DAL.Entities.Game game in games)
            {
                gamesOut.Add(ToModel(game));
            }
            return gamesOut;
        }

        public static DAL.Entities.Game ToEntity(Game game)
        {
            DAL.Entities.Game gameOut = new DAL.Entities.Game
            {
                Name = game.Name,
                DateStart = game.DateStart,
                DateEnd = game.DateEnd
            };
            return gameOut;
        }
    }
}
