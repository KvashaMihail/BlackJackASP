using BlackJack.BL.Services.Interfaces;
using BlackJack.ViewModels.Game;
using BlackJack.ViewModels.Menu;
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

        [HttpGet]
        public ActionResult StartNextRound()
        {
            _gameApiService.StartRound();
            var playerStatsViewModel = _gameApiService.GetStartCards();
            return Ok(playerStatsViewModel);
        }

        [HttpGet]
        public ActionResult GetStartCards()
        {
            var playerStatsViewModel = _gameApiService.GetStartCards();
            return Ok(playerStatsViewModel);
        }

        [HttpGet]
        public ActionResult GetLastCards()
        {
            var playerStatsViewModel = _gameApiService.GetLastCards();
            return Ok(playerStatsViewModel);
        }

        [HttpGet]
        public ActionResult<PlayerStatsViewModel> GetCards()
        {
            var playerStatsViewModel = _gameApiService.GetCards();
            if (playerStatsViewModel == null)
            {

            }
            return Ok(playerStatsViewModel);
        }

        [HttpGet]
        public ActionResult GetPlayerStates()
        {
            var states = _gameApiService.GetPlayerStates();
            return Ok(states);
        }

        [HttpGet]
        [Route("{gameid}")]
        public ActionResult GetRounds(int gameId)
        {
            var roundViewModels = _gameApiService.GetRoundsViewModel(gameId);
            return Ok(roundViewModels);
        }

        [HttpPost]
        public ActionResult FinishGame()
        {
            _gameApiService.FinishGame();
            return Ok();
        }
    }
}