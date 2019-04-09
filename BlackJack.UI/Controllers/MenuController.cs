using BlackJack.BL.Services.Interfaces;
using BlackJack.ViewModels.Api;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;

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
            return View("Index", _userManager.GetUserName(HttpContext.User));
        }

        public IActionResult StartGame(int countBots)
        {
            string playerName = _userManager.GetUserName(HttpContext.User);
            GameViewModel gameViewModel = _gameMenuService.GetGameViewModel(countBots, playerName);
            return View("Game", gameViewModel);
        }

        public IActionResult ShowGames()
        {
            var games = _gameMenuService.GetGames();
            return View("List", games);
        }

        
    }
}