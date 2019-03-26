using BlackJack.BL.Services.Interfaces;
using BlackJack.UI.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BlackJack.UI.Controllers
{
    public class GameMenuController : Controller
    {
        private IGameService _gameService;
        private readonly UserManager<IdentityUser> _userManager;

        public GameMenuController(IGameService service, UserManager<IdentityUser> userManager)
        {
            _gameService = service;
            _userManager = userManager;
        }

        public IActionResult Index()
        {            
            return View("Index", _userManager.GetUserName(HttpContext.User));
        }
    }
}