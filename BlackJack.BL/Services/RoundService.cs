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
        private readonly ICardService _cardService;

        public RoundService(IRoundRepository roundRepository,
            IRoundPlayerRepository roundPlayerRepository,
            ICardService cardService)
        {
            _roundRepository = roundRepository;
            _roundPlayerRepository = roundPlayerRepository;
            _cardService = cardService;
        }

        private IEnumerable<RoundPlayer> GetRoundPlayers(int gameId)
        {
            int number = _roundRepository.GetCountRoundsByGame(gameId);
            int roundId = _roundRepository.GetIdbyNumber(gameId, number);
            return _roundPlayerRepository.GetRoundPlayersByRound(roundId); 
        }

        private IEnumerable<int> GetPlayersId(int gameId)
        {
            var playersId = new List<int>();
            IEnumerable<RoundPlayer> roundPlayers = GetRoundPlayers(gameId);
            foreach (RoundPlayer round in roundPlayers)
            {
                playersId.Add(round.PlayerId);
            }
            return playersId;
        }

        public IEnumerable<byte> GetCards(int gameId)
        {
            var cards = new List<byte>();
            IEnumerable<RoundPlayer> roundPlayers = GetRoundPlayers(gameId);
            foreach (RoundPlayer roundPlayer in roundPlayers)
            {
                cards.Add(_cardService.GetRandomCard(roundPlayer.Id));
            }           
            return cards;
        }

        public void StartRound(int gameId, IEnumerable<int> playersId)
        {
            int number = _roundRepository.GetCountRoundsByGame(gameId);
            Round round = new Round
            {
                GameId = gameId,
                NumberRound = number + 1,
                IsCompleted = false               
            };
            round.Id = _roundRepository.Create(round);
            if (playersId == null)
            {
                playersId = GetPlayersId(gameId);
            }
            foreach (int id in playersId)
            {
                RoundPlayer roundPlayer = new RoundPlayer
                {
                    RoundId = round.Id,
                    PlayerId = id
                };
                _roundPlayerRepository.Create(roundPlayer);
            }
        }
    }
}
