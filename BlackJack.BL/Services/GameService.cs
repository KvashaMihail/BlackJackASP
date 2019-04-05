using BlackJack.Models;
using BlackJack.BL.Services.Interfaces;
using BlackJack.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using BlackJack.Shared.Enums;

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

        public Player SelectPlayer(string name)
        {
            bool isEmptyPlayer = _playerRepository.GetIsEmptyByName(name);
            if (isEmptyPlayer)
            {
                _playerRepository.Create(new Player { Name = name });
            }
            return _playerRepository.Get(name);
        }

        public Game Create(string playerName)
        {
            string name = $"{playerName}-{DateTime.Now.Hour}-{DateTime.Now.Minute}";
            Game game = new Game
            {
                Name = name,
            };
            game.Id = _gameRepository.Create(game);
            return game;
        }

        public IEnumerable<Game> GetGames()
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
            players.Add(_playerRepository.Get((int)Constants.DealerId));
            return players;
        }

        public List<string> GetNamePlayers(List<int> playersId)
        {
            var namePlayers = new List<string>();
            foreach (int playerId in playersId)
            {
                namePlayers.Add(_playerRepository.Get(playerId).Name);
            }
            return namePlayers;
        }
    }
}
