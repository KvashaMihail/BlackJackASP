using BlackJack.BL.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BlackJack.UI.Controllers
{
    public class GameController : Controller
    {
        private IGameService _gameService;
        private readonly UserManager<IdentityUser> _userManager;

        public GameController(IGameService service, UserManager<IdentityUser> userManager)
        {
            _gameService = service;
            _userManager = userManager;
        }

        public IActionResult Index()
        {            
            return View("Index", _userManager.GetUserName(HttpContext.User));
        }

        public IActionResult StartGame(string countBotsString)
        {
            int countBots = Convert.ToInt32(countBotsString);

            return View();
        }
    }
}