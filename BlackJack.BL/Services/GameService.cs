using BlackJack.BL.Models;
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
        private readonly ICacheService _cacheService;

        public GameService(IGameRepository gameRepository, 
            IPlayerRepository playerRepository,
            ICacheService cacheService)
        {
            _gameRepository = gameRepository;
            _playerRepository = playerRepository;
            _cacheService = cacheService;
        }

        public Game Create(string playerName)
        {
            string name = $"{playerName}-{DateTime.Now.DayOfYear}{DateTime.Now.Minute}{DateTime.Now.Second}";
            Game game = new Game
            {
                Name = name,
                DateStart = DateTime.Now,
                DateEnd = DateTime.Now
            };
            _gameRepository.Create(Mapper.ToEntity(game));
            game = Mapper.ToModel(_gameRepository.Get(name));
            return game;
        }

        public IEnumerable<Game> ShowGames()
        {
            return Mapper.ToModel(_gameRepository.GetAll());
        }

        public bool GetIsEmpty()
        {
            return !_gameRepository.GetAll().Any();
        }

        public IEnumerable<Player> GetPlayers(string playerName, int countBots)
        {
            var players = new List<Player>();
            players.Add(Mapper.ToModel(_playerRepository.Get(playerName)));
            players.AddRange(Mapper.ToModel(_playerRepository.GetBots(countBots)));
            players.Add(Mapper.ToModel(_playerRepository.Get(8)));
            _cacheService.SetPlayers(players);
            return players;
        }
    }
}
