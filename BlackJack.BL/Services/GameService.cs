using BlackJack.BL.Exception;
using BlackJack.BL.Models;
using BlackJack.BL.Services.Interfaces;
using BlackJack.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace BlackJack.BL.Services
{
    public class GameService : IGameService
    {
        private readonly IGameRepository _gameRepository;

        public GameService(IGameRepository gameRepository)
        {
            _gameRepository = gameRepository;
        }

        public Game Create(string name)
        {
            bool isCorrectly = Regex.IsMatch(name, "^[a-zA-Z][a-zA-Z0-9]*$");
            if (!isCorrectly)
            {
                throw new ValidationException("Error! Only letters and numbers!");
            }
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
