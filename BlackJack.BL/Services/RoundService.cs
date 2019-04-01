using BlackJack.BL.Services.Interfaces;
using BlackJack.DAL.Interfaces;
using BlackJack.Models;
using System;
using System.Collections.Generic;
using System.Linq;

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

        private int GetCurrentRoundId(int gameId)
        {
            int number = _roundRepository.GetCountRoundsByGame(gameId);
            return _roundRepository.GetIdbyNumber(gameId, number);
        }

        private IEnumerable<RoundPlayer> GetRoundPlayers(int gameId)
        {
            int roundId = GetCurrentRoundId(gameId);
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

        public IEnumerable<byte> GetScores(int gameId)
        {
            var scores = new List<byte>();
            IEnumerable<RoundPlayer> roundPlayers = GetRoundPlayers(gameId);
            foreach (RoundPlayer roundPlayer in roundPlayers)
            {
                scores.Add(_cardService.GetScorePlayer(roundPlayer.Id));
            }
            return scores;
        }

        public IEnumerable<bool> GetFlagsIsGiveCard(int gameId, bool playerChoice)
        {
            var flags = new List<bool>();
            flags.Add(playerChoice);
            var scores = GetScores(gameId).ToList();
            int idDealer = scores.Count - 1;
            for (int i = 1; i < idDealer; i++)
            {
                Random random = new Random();
                int scoreAmbitions = random.Next(7, 19);
                if (scoreAmbitions <= scores[i])
                {
                    flags.Add(false);
                }
            }
            if (scores[idDealer] > 16)
            {
                flags.Add(false);
            }
            return flags;
        }

        //private byte GetScorePlayer()
        //{

        //}

        

        public bool EndCheck(int gameId, IEnumerable<bool> flags)
        {
            int roundId = GetCurrentRoundId(gameId);
            bool theEnd = true;
            foreach (bool flag in flags)
            {
                if (flag)
                {
                    theEnd = false;
                }
            }
            int idDealer = _roundPlayerRepository.GetPlayer(roundId, 8).Id;
            int scoreDealer = _cardService.GetScorePlayer(idDealer);
            if (scoreDealer > 21)
            {
                theEnd = true;
            }
            if (_cardService.CheckBlackJack(idDealer))
            {
                theEnd = true;
            }
            return theEnd;
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
