using BlackJack.BL.Services.Interfaces;
using BlackJack.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace BlackJack.UI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class GameApiController : ControllerBase
    {
        IGameApiService _gameApiService;

        public GameApiController(IGameApiService gameApiService)
        {
            _gameApiService = gameApiService;
        }

        [HttpPost("{gameId}")]
        public ActionResult StartNextRound(int gameId)
        {
            _gameApiService.StartRound(gameId);
            return Ok();
        }

        [HttpGet("{gameId}")]
        public ActionResult GetStartCards(int gameId)
        {
            var playerStatsViewModel = _gameApiService.GetStartCards(gameId);
            return Ok(playerStatsViewModel);
        }

        [HttpGet("{gameId}")]
        public ActionResult GetLastCards(int gameId)
        {
            var playerStatsViewModel = _gameApiService.GetLastCards(gameId);
            return Ok(playerStatsViewModel);
        }

        [HttpGet("{gameId}")]
        public ActionResult GetCards(int gameId)
        {
            var playerStatsViewModel = _gameApiService.GetCards(gameId);
            return Ok(playerStatsViewModel);
        }

        [HttpGet("{gameId}")]
        public ActionResult GetFlagsIsWin(int gameId)
        {
            var flags = _gameApiService.GetFlagsIsWin(gameId);
            return Ok(flags);
        }

        [HttpGet("{gameId}")]
        public ActionResult GetRounds(int gameId)
        {
            var roundViewModels = _gameApiService.GetRoundsViewModel(gameId);
            return Ok(roundViewModels);
        }
    }
}