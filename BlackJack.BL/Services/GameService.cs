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

        public GameService(IGameRepository gameRepository)
        {
            _gameRepository = gameRepository;
        }

        public Game Create(string playerName)
        {
            string name = playerName + DateTime.Now.Date.ToString();
            Game game = new Game { Name = name, DateStart = DateTime.Now, DateEnd = DateTime.Now };
            _gameRepository.Create(Mapper.ToEntity(game));
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
    }
}
