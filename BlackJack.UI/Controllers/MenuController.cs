using BlackJack.BL.Services.Interfaces;
using BlackJack.ViewModels.Api;
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

        public IActionResult Index()
        {
            var playerMenu = _gameMenuService.GetPlayerMenuViewModel();
            return Ok(playerMenu);
        }

        public IActionResult BackToMenu()
        {
            _gameMenuService.FinishGame();
            return Redirect("Index");
        }

        public IActionResult StartGame(int countBots)
        {
            GameViewModel gameViewModel = _gameMenuService.CreateGameViewModel(countBots);
            return Ok(gameViewModel);
        }

        public IActionResult ContinueGame()
        {
            GameViewModel gameViewModel = _gameMenuService.GetGameViewModel();
            return Ok(gameViewModel);
        }

        public IActionResult ShowGames()
        {
            var games = _gameMenuService.GetGames();
            return Ok(games);
        }

        
    }
}