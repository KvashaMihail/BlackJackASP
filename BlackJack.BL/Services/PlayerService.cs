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
    public class PlayerService : IPlayerService
    {
        private readonly IPlayerRepository _playerRepository;
        public Player Player { get; set; }

        public PlayerService(IPlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
        }

        public void Select(string name)
        {
            if (GetIsEmpty(name))
            {
                throw new ValidationException("Такого игрока нет, введите имя игрока из списка!");
            }
            Player = Mapper.ToModel(_playerRepository.Get(name));
        }

        public void Create(string name)
        {
            bool isCorrectly = Regex.IsMatch(name, "^[a-zA-Z][a-zA-Z0-9]*$");
            bool isEmptyPlayer = GetIsEmpty(name);
            if (!isCorrectly)
            {
                throw new ValidationException("Только латинские буквы и цифры!");
            }
            if (!isEmptyPlayer)
            {
                throw new ValidationException("Такое имя занято.");
            }
            _playerRepository.Create(Mapper.ToEntity(new Player { Name = name, IsBot = false }));
            Player = Mapper.ToModel(_playerRepository.Get(name));
        }

        public IEnumerable<Player> ShowPlayers()
        {
            return Mapper.ToModel(_playerRepository.GetPlayers());
        }

        private bool GetIsEmpty()
        {
            return !ShowPlayers().Any();
        }

        private bool GetIsEmpty(string name)
        {
            return _playerRepository.Get(name) == null;
        }

    }
}
