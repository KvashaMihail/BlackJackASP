using BlackJack.BL.Exception;
using BlackJack.Shared.Models;
using BlackJack.BL.Services.Interfaces;
using BlackJack.DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace BlackJack.BL.Services
{
    public class PlayerService : IPlayerService
    {
        private readonly IPlayerRepository _playerRepository;

        public PlayerService(IPlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
        }

        public Player SelectOrCreate(string name)
        {
            bool isEmptyPlayer = GetIsEmpty(name);
            if (isEmptyPlayer)
            {
                _playerRepository.Create(new Player { Name = name, IsBot = false });
            }
            return _playerRepository.Get(name);          
        }

        public IEnumerable<Player> ShowPlayers()
        {
            return _playerRepository.GetPlayers();
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
