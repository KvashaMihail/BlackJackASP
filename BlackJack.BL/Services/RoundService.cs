using BlackJack.Shared.Models;
using BlackJack.BL.Services.Interfaces;
using BlackJack.DAL.Interfaces;
using System.Collections;
using System.Collections.Generic;

namespace BlackJack.BL.Services
{
    public class RoundService : IRoundService
    {
        private IRoundRepository _roundRepository;
        private IRoundPlayerRepository _roundPlayerRepository;

        public RoundService(IRoundRepository roundRepository,
            IRoundPlayerRepository roundPlayerRepository)
        {
            _roundRepository = roundRepository;
            _roundPlayerRepository = roundPlayerRepository;
        }

        public void StartRound(int gameId)
        {
            Round round = new Round
            {
                GameId = gameId,
                NumberRound = _roundRepository.GetCountRoundsByGame(gameId) + 1,
                IsCompleted = false               
            };

        }
    }
}
