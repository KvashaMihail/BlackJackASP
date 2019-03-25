using BlackJack.BL.Exception;
using BlackJack.BL.Models;
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
                Create(name);
                return Mapper.ToModel(_playerRepository.Get(name));
            }
            return Mapper.ToModel(_playerRepository.Get(name));          
        }

        private void Create(string name)
        {
            bool isCorrectly = Regex.IsMatch(name, "^[a-zA-Z][a-zA-Z0-9]*$");            
            if (!isCorrectly)
            {
                throw new ValidationException("Error! Only letters and numbers!");
            }
            _playerRepository.Create(Mapper.ToEntity(new Player { Name = name, IsBot = false }));
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
