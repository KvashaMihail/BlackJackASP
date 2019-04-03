﻿using BlackJack.BL.Services.Interfaces;
using BlackJack.UI.ViewModels;
using Microsoft.AspNetCore.Mvc;
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

        //[HttpGet("{gameId}")]
        //public ActionResult GetStartCards(int gameId)
        //{

        //    return Ok();
        //}

        [HttpPost]
        public ActionResult GetCards([FromBody]PostViewModel postViewModel)
        {
            var cards = _roundService.GetCards(postViewModel.GameId, postViewModel.Flags).ToList();
            return Ok(cards);
        }
        
        [HttpGet("{gameId}")]
        public ActionResult GetScores(int gameId)
        {
            var scores = _roundService.GetScores(gameId).ToList();
            return Ok(scores);
        }

        [HttpPost]
        public ActionResult GetFlags([FromBody]PostViewModel postViewModel)
        {
            var flags = _roundService.GetFlagsIsGiveCard(postViewModel.GameId, postViewModel.Choice).ToList();
            return Ok(flags);
        }

        [HttpGet("{gameId}")]
        public ActionResult GetFlagsIsWin(int gameId)
        {
            var flags = _roundService.GetFlagsIsWin(gameId).ToList();
            _gameService.UpdateTimeForGame(gameId);
            return Ok(flags);
        }

        [HttpPost]
        public ActionResult CheckFinishRound([FromBody]PostViewModel postViewModel)
        {
            bool isFinished = _roundService.CheckIsRoundFinished(postViewModel.GameId, postViewModel.Flags);
            return Ok(isFinished);
        }
    }
}