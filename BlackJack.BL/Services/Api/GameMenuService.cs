using BlackJack.BL.Services.Interfaces;
using BlackJack.Models;
using BlackJack.ViewModels.Game;
using BlackJack.ViewModels.Menu;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;

namespace BlackJack.BL.Services.Api
{
    public class GameMenuService : IGameMenuService
    {
        private IGameService _gameService;
        private IRoundService _roundService;
        private string _playerName;


        public GameMenuService(IGameService gameService,
            IRoundService roundService,
            IHttpContextAccessor httpContextAccessor)
        {
            _gameService = gameService;
            _roundService = roundService;
            _playerName = httpContextAccessor.HttpContext.User.Identity.Name;

        }

        public GameViewModel CreateGameViewModel(int countBots)
        {
            Game game = _gameService.Create(_playerName);
            var players = _gameService.GetPlayers(_playerName, countBots);
            var playersId = new List<int>();
            foreach (Player player in players)
            {
                playersId.Add(player.Id);
            }
            _roundService.StartFirstRound(game.Id, playersId);
            GameViewModel gameViewModel = new GameViewModel
            {
                Game = game,
                Players = players,
                Cards = null
            };
            return gameViewModel;
        }

        public GameViewModel GetGameViewModel()
        {
            var game = _gameService.GetCurrentGame(_playerName);
            var count = _roundService.GetPlayersId(game.Id).Count() - 2;
            var players = _gameService.GetPlayers(_playerName, count);
            List<List<byte>> cards = null;
            List<byte> scores = null;
            var rounds = _roundService.GetRounds(game.Id);
            var round = rounds[rounds.Count()-1];
            bool isCompletedRound = round.IsCompleted;
            if (isCompletedRound)
            {
                _roundService.StartRound(game.Id);
            }
            if (!isCompletedRound)
            {
                cards = _roundService.GetCardsByRound(game.Id, round.Id);
                scores = _roundService.GetScores(game.Id);
            }
            GameViewModel gameViewModel = new GameViewModel
            {
                Game = game,
                Players = players,
                Cards = cards,
                Scores = scores
            };
            return gameViewModel;
        }

        public PlayerMenuViewModel GetPlayerMenuViewModel()
        {
            return _gameService.GetPlayerMenu(_playerName);
        }

        public IEnumerable<Game> GetGames()
        {
            return _gameService.GetGames();
        }      
    }
}
