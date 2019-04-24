using BlackJack.BL.Services.Interfaces;
using BlackJack.DAL.Interfaces;
using BlackJack.Models;
using BlackJack.Shared.Enums;
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

        #region HellpersMethods

        private int GetCurrentRoundId(int gameId)
        {
            int number = _roundRepository.GetCountRoundsByGame(gameId);
            return _roundRepository.GetIdbyNumber(gameId, number);
        }

        private IEnumerable<RoundPlayer> GetRoundPlayers(int gameId, int roundId = -1)
        {
            if (roundId == -1)
            {
                roundId = GetCurrentRoundId(gameId);
            }
            return _roundPlayerRepository.GetRoundPlayersByRound(roundId);
        }

        private byte GetNormalizeScore(int gameId, int roundPlayerId)
        {
            int roundId = GetCurrentRoundId(gameId);
            byte score = _cardService.GetScorePlayer(roundPlayerId);
            if (score > (int)Constants.MaxScore)
            {
                score = (int)Constants.OverScore;
            }
            if (_cardService.CheckBlackJack(roundPlayerId))
            {
                score = (int)Constants.BlackJackScore;
            }
            return score;
        }

        public IEnumerable<int> GetPlayersId(int gameId)
        {
            var playersId = new List<int>();
            IEnumerable<RoundPlayer> roundPlayers = GetRoundPlayers(gameId);
            foreach (RoundPlayer round in roundPlayers)
            {
                playersId.Add(round.PlayerId);
            }
            return playersId;
        }

        #endregion

        #region MethodsFromGamePlay
        public void StartFirstRound(int gameId, IEnumerable<int> playersId)
        {
            int number = _roundRepository.GetCountRoundsByGame(gameId);
            Round round = new Round
            {
                GameId = gameId,
                NumberRound = number + 1,
                IsCompleted = false
            };
            round.Id = _roundRepository.Create(round);
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

        public void StartRound(int gameId)
        {
            int number = _roundRepository.GetCountRoundsByGame(gameId);
            var playersId = GetPlayersId(gameId);
            Round round = new Round
            {
                GameId = gameId,
                NumberRound = number + 1,
                IsCompleted = false
            };
            round.Id = _roundRepository.Create(round);
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

        public List<List<byte>> GetStartCards(int gameId)
        {
            var cards = new List<List<byte>>();
            var flags = new List<bool> { true, true, true, true, true, true, true, true, true };

            var cardsLine = GetCardsForPlayers(gameId, flags).ToList();
            var cardsLine2 = GetCardsForPlayers(gameId, flags).ToList();
            for (int i = 0; i < cardsLine.Count(); i++)
            {
                cards.Add(new List<byte>());
                cards[i].Add(cardsLine[i]);
                cards[i].Add(cardsLine2[i]);
            }
            return cards;
        }

        public List<byte> GetScores(int gameId)
        {
            var scores = new List<byte>();
            IEnumerable<RoundPlayer> roundPlayers = GetRoundPlayers(gameId);
            foreach (RoundPlayer roundPlayer in roundPlayers)
            {
                scores.Add(_cardService.GetScorePlayer(roundPlayer.Id));
            }
            return scores;
        }

        public List<bool> GetFlagsIsGiveCard(int gameId, bool playerChoice)
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

        public List<byte> GetCardsForPlayers(int gameId, List<bool> flags)
        {

            var cards = new List<byte>();
            IEnumerable<RoundPlayer> roundPlayers = GetRoundPlayers(gameId);
            for (int i = 0; i < roundPlayers.Count(); i++)
            {
                if (flags[i])
                {
                    cards.Add(_cardService.GetRandomCard(roundPlayers.ElementAt(i).Id));
                }
                if (!flags[i])
                {
                    cards.Add((byte)Constants.IdNullCard);
                }
            }
            return cards;
        }

        public bool GetIsRoundFinished(int gameId, IEnumerable<bool> flags)
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
            if (scoreDealer > (int)Constants.MaxScore)
            {
                theEnd = true;
            }
            return theEnd;
        }

        public List<bool> GetFlagsIsWin(int gameId)
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
                bool isWin = scores[i] >= scores[dealerId];
                if (scores[i] == (int)Constants.OverScore)
                {
                    isWin = false;
                }
                if (isBlackJack)
                {
                    isWin = true;
                }
                flags.Add(isWin);
            }
            return flags;
        }

        public void SaveRound(int gameId, List<bool> flags)
        {
            var roundPlayers = GetRoundPlayers(gameId).ToList();
            for (int i = 0; i < roundPlayers.Count - 1; i++)
            {
                roundPlayers[i].IsWin = flags[i];
                _roundPlayerRepository.Update(roundPlayers[i]);
            }
            int roundId = GetCurrentRoundId(gameId);
            Round round = _roundRepository.Get(roundId);
            round.IsCompleted = true;
            _roundRepository.Update(round);
        }
        #endregion

        #region MethodsFromHistoryGames
        public List<bool?> GetIsWinsByRound(int gameId, int roundId)
        {
            var isWins = new List<bool?>();
            IEnumerable<RoundPlayer> roundPlayers = GetRoundPlayers(gameId, roundId);
            foreach (RoundPlayer roundPlayer in roundPlayers)
            {
                isWins.Add(roundPlayer.IsWin);
            }
            return isWins;
        }

        public List<List<byte>> GetCardsByRound(int gameId, int roundId)
        {
            var cards = new List<List<byte>>();
            IEnumerable<RoundPlayer> roundPlayers = GetRoundPlayers(gameId, roundId);
            foreach (RoundPlayer roundPlayer in roundPlayers)
            {
                cards.Add(_cardService.GetCardsByRoundPlayer(roundPlayer.Id));
            }
            return cards;
        }

        public List<byte> GetScoresByRoundId(int gameId, int roundId)
        {
            var scores = new List<byte>();
            IEnumerable<RoundPlayer> roundPlayers = GetRoundPlayers(gameId, roundId);
            foreach (RoundPlayer roundPlayer in roundPlayers)
            {
                scores.Add(_cardService.GetScorePlayer(roundPlayer.Id));
            }
            return scores;
        }

        public List<Round> GetRounds(int gameId)
        {
            return _roundRepository.GetRoundsByGame(gameId).ToList();
        }
        #endregion

    }
}
