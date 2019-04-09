using BlackJack.BL.Services.Interfaces;
using BlackJack.Models;
using BlackJack.ViewModels.Api;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;

namespace BlackJack.BL.Services.Api
{
    [Authorize]
    public class GameMenuService : IGameMenuService
    {
        private IGameService _gameService;
        private IRoundService _roundService;

        public GameMenuService(IGameService gameService,
            IRoundService roundService)
        {
            _gameService = gameService;
            _roundService = roundService;
        }

        public GameViewModel GetGameViewModel(int countBots, string playerName)
        {
            Game game = _gameService.Create(playerName);
            IEnumerable<Player> players = _gameService.GetPlayers(playerName, countBots);
            var playersId = new List<int>();
            foreach (Player player in players)
            {
                playersId.Add(player.Id);
            }
            _roundService.StartFirstRound(game.Id, playersId);
            GameViewModel gameViewModel = new GameViewModel(game, players);
            return gameViewModel;
        }

        public IEnumerable<Game> GetGames()
        {
            return _gameService.GetGames();
        }
    }
}
