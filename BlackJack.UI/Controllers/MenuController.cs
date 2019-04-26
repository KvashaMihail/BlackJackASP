using BlackJack.BL.Services.Interfaces;
using BlackJack.ViewModels.Game;
using BlackJack.ViewModels.Menu;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BlackJack.UI.Controllers
{
    [Authorize]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private IGameMenuService _gameMenuService;
        private readonly UserManager<IdentityUser> _userManager;

        public MenuController(IGameMenuService gameMenuService,
            UserManager<IdentityUser> userManager)
        {
            _gameMenuService = gameMenuService;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult GetPlayerMenu()
        {
            var playerMenu = _gameMenuService.GetPlayerMenuViewModel();
            return Ok(playerMenu);
        }

        [HttpGet]
        [Route("{countBots}")]
        public IActionResult StartGame(int countBots)
        {
            GameViewModel gameViewModel = _gameMenuService.CreateGameViewModel(countBots);
            return Ok(gameViewModel);
        }

        [HttpGet]
        public IActionResult ContinueGame()
        {
            GameViewModel gameViewModel = _gameMenuService.GetGameViewModel();
            return Ok(gameViewModel);
        }

        [HttpGet]
        public IActionResult GetGames()
        {
            var games = _gameMenuService.GetGames();
            return Ok(games);
        }

        
    }
}