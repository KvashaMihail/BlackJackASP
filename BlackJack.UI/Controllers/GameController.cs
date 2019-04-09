using BlackJack.BL.Services.Interfaces;
using BlackJack.ViewModels.Api;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlackJack.UI.Controllers
{
    [Authorize]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        IGameApiService _gameApiService;

        public GameController(IGameApiService gameApiService)
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
        public ActionResult<PlayerStatsViewModel> GetCards(int gameId)
        {
            var playerStatsViewModel = _gameApiService.GetCards(gameId);
            if (playerStatsViewModel == null)
            {

            }
            return Ok(playerStatsViewModel);
        }

        [HttpGet("{gameId}")]
        public JsonResult GetFlagsIsWin(int gameId)
        {
            var flags = _gameApiService.GetFlagsIsWin(gameId);
            return new JsonResult(flags);
        }

        [HttpGet("{gameId}")]
        public ActionResult GetRounds(int gameId)
        {
            var roundViewModels = _gameApiService.GetRoundsViewModel(gameId);
            return Ok(roundViewModels);
        }
    }
}