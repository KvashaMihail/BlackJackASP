using BlackJack.Models;
using BlackJack.BL.Services.Interfaces;
using BlackJack.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BlackJack.BL.Services
{
    public class GameService : IGameService
    {
        private readonly IGameRepository _gameRepository;
        private readonly IPlayerRepository _playerRepository;

        public GameService(IGameRepository gameRepository, 
            IPlayerRepository playerRepository)
        {
            _gameRepository = gameRepository;
            _playerRepository = playerRepository;
        }
        
        public void UpdateTimeForGame(int gameId)
        {
            _gameRepository.Update(gameId);
        }

        public Game Create(string playerName)
        {
            string name = $"Game-{playerName}{DateTime.Now.Hour}:{DateTime.Now.Minute}";
            Game game = new Game
            {
                Name = name,
            };
            game.Id = _gameRepository.Create(game);
            return game;
        }

        public IEnumerable<Game> ShowGames()
        {
            return _gameRepository.GetAll();
        }

        public bool GetIsEmpty()
        {
            return !_gameRepository.GetAll().Any();
        }

        public IEnumerable<Player> GetPlayers(string playerName, int countBots)
        {
            var players = new List<Player>();
            players.Add(_playerRepository.Get(playerName));
            players.AddRange(_playerRepository.GetBots(countBots));
            players.Add(_playerRepository.Get(8));
            return players;
        }
    }
}
