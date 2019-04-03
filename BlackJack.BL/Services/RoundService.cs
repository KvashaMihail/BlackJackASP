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

        private byte GetNormalizeScore(int gameId, int roundPlayerId)
        {
            int roundId = GetCurrentRoundId(gameId);
            byte score = _cardService.GetScorePlayer(roundPlayerId);
            if (score > 21)
            {
                score = 0;
            }
            if (_cardService.CheckBlackJack(roundPlayerId))
            {
                score = 100;
            }
            return score;
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
                flags.Add(scoreAmbitions > scores[i]);
            }
            flags.Add(scores[idDealer] <= 16);
            return flags;
        }

        public IEnumerable<bool> GetFlagsIsWin(int gameId)
        {
            var flags = new List<bool>();
            var roundPlayers = GetRoundPlayers(gameId).ToList();
            var scores = new List<byte>();
            foreach (RoundPlayer roundPlayer in roundPlayers)
            {
                scores.Add(GetNormalizeScore(gameId, roundPlayer.Id));
            }
            int dealerId = scores.Count - 1;
            for (int i = 0; i < dealerId; i++)
            {
                bool isBlackJack = _cardService.CheckBlackJack(roundPlayers[i].Id);
                bool isWin = scores[i] > scores[dealerId];
                if (isBlackJack)
                {
                    isWin = true;
                }
                
                roundPlayers[i].IsWin = isWin;
                _roundPlayerRepository.Update(roundPlayers[i]);
                flags.Add(isWin);
            }
            int roundId = GetCurrentRoundId(gameId);
            Round round = _roundRepository.Get(roundId);
            round.IsCompleted = true;
            _roundRepository.Update(round);

            return flags;
        }

        public bool CheckIsRoundFinished(int gameId, IEnumerable<bool> flags)
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

        //public List<List<byte>> GetStartCards(int gameId)
        //{
        //    var cards = new List<List<byte>>();
        //    cards.Add(GetCards(gameId, null).ToList());
        //    return cards;
        //}

        public IEnumerable<byte> GetCards(int gameId, List<bool> flags)
        {
            
            var cards = new List<byte>();
            IEnumerable<RoundPlayer> roundPlayers = GetRoundPlayers(gameId);
            if (flags == null)
            {
                flags = new List<bool>();
                for (int i = 0; i < roundPlayers.Count(); i++)
                {
                    flags.Add(true);
                }
            }
            for (int i = 0; i < roundPlayers.Count(); i++)
            {
                if (flags[i])
                {
                    cards.Add(_cardService.GetRandomCard(roundPlayers.ElementAt(i).Id));                   
                }
                if (!flags[i])
                {
                    cards.Add(53);
                }
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
