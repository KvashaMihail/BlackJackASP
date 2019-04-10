using BlackJack.BL.Services.Interfaces;
using BlackJack.ViewModels.Api;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BlackJack.UI.Controllers
{
    [Authorize]
    public class MenuController : Controller
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
            return View("Index", playerMenu);
        }

        public IActionResult BackToMenu()
        {
            _gameMenuService.FinishGame();
            return Redirect("Index");
        }

        public IActionResult StartGame(int countBots)
        {
            GameViewModel gameViewModel = _gameMenuService.CreateGameViewModel(countBots);
            return View("Game", gameViewModel);
        }

        public IActionResult ContinueGame()
        {
            GameViewModel gameViewModel = _gameMenuService.GetGameViewModel();
            return View("Game", gameViewModel);
        }

        public IActionResult ShowGames()
        {
            var games = _gameMenuService.GetGames();
            return View("List", games);
        }

        
    }
}