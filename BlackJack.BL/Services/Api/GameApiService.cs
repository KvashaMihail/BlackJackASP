using BlackJack.BL.Services.Interfaces;
using BlackJack.Models;
using BlackJack.ViewModels.Api;
using System.Collections.Generic;
using System.Linq;

namespace BlackJack.BL.Services.Api
{
    public class GameApiService : IGameApiService
    {
        private ICardService _cardService;
        private IRoundService _roundService;
        private IGameService _gameService;

        public GameApiService(ICardService cardService,
            IRoundService roundService,
            IGameService gameService)
        {
            _cardService = cardService;
            _roundService = roundService;
            _gameService = gameService;
        }

        public PlayerStatsViewModel GetCards(int gameId)
        {
            if (_gameService.GetIsEmptyById(gameId))
            {
                return null;
            }
            var playerStatsViewModel = new PlayerStatsViewModel();
            var cards = new List<List<byte>>();
            var flags = _roundService.GetFlagsIsGiveCard(gameId, true).ToList();
            cards.Add(_roundService.GetCardsForPlayers(gameId, flags).ToList());
            playerStatsViewModel.Scores = _roundService.GetScores(gameId).ToList();
            flags = _roundService.GetFlagsIsGiveCard(gameId, playerStatsViewModel.Scores[0] < 20).ToList();
            playerStatsViewModel.Cards = cards;
            playerStatsViewModel.IsFinishedRound = _roundService.GetIsRoundFinished(gameId, flags);
            return playerStatsViewModel;
        }

        public void StartRound(int gameId)
        {
            _roundService.StartRound(gameId);
        }

        public PlayerStatsViewModel GetLastCards(int gameId)
        {
            if (_gameService.GetIsEmptyById(gameId))
            {
                return null;
            }
            var playerStatsViewModel = new PlayerStatsViewModel();
            var cards = new List<List<byte>>();
            var flags = _roundService.GetFlagsIsGiveCard(gameId, false).ToList();
            bool isFinishRound;
            do
            {
                cards.Add(_roundService.GetCardsForPlayers(gameId, flags).ToList());
                playerStatsViewModel.Scores = _roundService.GetScores(gameId).ToList();
                flags = _roundService.GetFlagsIsGiveCard(gameId, false).ToList();
                isFinishRound = _roundService.GetIsRoundFinished(gameId, flags);
            }
            while (!isFinishRound);
            playerStatsViewModel.Cards = cards;
            playerStatsViewModel.IsFinishedRound = true;
            return playerStatsViewModel;
        }

        public PlayerStatsViewModel GetStartCards(int gameId)
        {
            if (_gameService.GetIsEmptyById(gameId))
            {
                return null;
            }
            var playerStatsViewModel = new PlayerStatsViewModel()
            {
                IsFinishedRound = false,
                Cards = _roundService.GetStartCards(gameId),
                Scores = _roundService.GetScores(gameId).ToList()
            };
            return playerStatsViewModel;
        }

        public List<bool> GetFlagsIsWin(int gameId)
        {
            if (_gameService.GetIsEmptyById(gameId))
            {
                return null;
            }
            var flags = _roundService.GetFlagsIsWin(gameId).ToList();
            _roundService.SaveRound(gameId, flags);
            _gameService.UpdateTimeForGame(gameId);
            return flags;
        }

        public List<RoundViewModel> GetRoundsViewModel(int gameId)
        {
            if (_gameService.GetIsEmptyById(gameId))
            {
                return null;
            }
            var roundViewModels = new List<RoundViewModel>();
            var rounds = _roundService.GetRounds(gameId);
            foreach (Round round in rounds)
            {
                var playersId = _roundService.GetPlayersId(gameId).ToList();
                var roundViewModel = new RoundViewModel
                {
                    Round = round,
                    Players = _gameService.GetNamePlayers(playersId),
                    Scores = _roundService.GetScoresByRoundId(gameId, round.Id),
                    IsWins = _roundService.GetIsWinsByRound(gameId, round.Id),
                    Cards = _roundService.GetCardsByRound(gameId, round.Id)
                };
                roundViewModels.Add(roundViewModel);
            }
            return roundViewModels;
        }
    }
}
