using BlackJack.BL.Services.Interfaces;
using BlackJack.UI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace BlackJack.UI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class GameApiController : ControllerBase
    {
        private ICardService _cardService;
        private IRoundService _roundService;
        private IGameService _gameService;


        public GameApiController(ICardService cardService,
            IRoundService roundService,
            IGameService gameService)
        {
            _cardService = cardService;
            _roundService = roundService;
            _gameService = gameService;
        }

        [HttpPost("{gameId}")]
        public ActionResult StartNextRound(int gameId)
        {
            _roundService.StartRound(gameId);
            return Ok();
        }

        [HttpGet("{gameId}")]
        public ActionResult GetStartCards(int gameId)
        {
            var getViewModel = new GetViewModel
            {
                IsFinishedRound = false,
                Cards = _roundService.GetStartCards(gameId),
                Scores = _roundService.GetScores(gameId).ToList()
            };
            return Ok(getViewModel);
        }

        [HttpGet("{gameId}")]
        public ActionResult GetLastCards(int gameId)
        {
            var getViewModel = new GetViewModel();
            var cards = new List<List<byte>>();
            var flags = _roundService.GetFlagsIsGiveCard(gameId, false).ToList();
            bool isFinishRound;
            do
            {
                cards.Add(_roundService.GetCards(gameId, flags).ToList());
                getViewModel.Scores = _roundService.GetScores(gameId).ToList();
                flags = _roundService.GetFlagsIsGiveCard(gameId, false).ToList();
                isFinishRound = _roundService.GetIsRoundFinished(gameId, flags);
            }
            while (!isFinishRound);
            getViewModel.Cards = cards;
            getViewModel.IsFinishedRound = true;
            return Ok(getViewModel);
        }

        [HttpGet("{gameId}")]
        public ActionResult GetCards(int gameId)
        {
            var getViewModel = new GetViewModel();
            var cards = new List<List<byte>>();
            var flags = _roundService.GetFlagsIsGiveCard(gameId, true).ToList();
            cards.Add(_roundService.GetCards(gameId, flags).ToList());
            getViewModel.Scores = _roundService.GetScores(gameId).ToList();
            flags = _roundService.GetFlagsIsGiveCard(gameId, getViewModel.Scores[0] < 20).ToList();
            getViewModel.Cards = cards;
            getViewModel.IsFinishedRound = _roundService.GetIsRoundFinished(gameId, flags);
            return Ok(getViewModel);
        }

        [HttpGet("{gameId}")]
        public ActionResult GetFlagsIsWin(int gameId)
        {
            var flags = _roundService.GetFlagsIsWin(gameId).ToList();
            _roundService.SaveRound(gameId, flags);
            _gameService.UpdateTimeForGame(gameId);
            return Ok(flags);
        }
    }
}