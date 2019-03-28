using BlackJack.BL.Services.Interfaces;
using BlackJack.DAL.Interfaces;
using BlackJack.Models;
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
        //private IEnumerable<int> getPlayersId(int gameId)
        //{
        //    var playersId = new List<int>();
        //}
        public void StartRound(int gameId, IEnumerable<int> playersId)
        {
            Round round = new Round
            {
                GameId = gameId,
                NumberRound = _roundRepository.GetCountRoundsByGame(gameId) + 1,
                IsCompleted = false               
            };
            _roundRepository.Create(round);


        }
    }
}
