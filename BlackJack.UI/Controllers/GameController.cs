using BlackJack.BL.Services.Interfaces;
using BlackJack.UI.Models;
using BlackJack.UI.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

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

        public IActionResult StartGame(int countBots)
        {
            string playerName = _userManager.GetUserName(HttpContext.User);
            GameModel game = Mapper.ToViewModel(_gameService.Create(playerName));
            IEnumerable<PlayerModel> players = Mapper.ToViewModel(_gameService.GetPlayers(playerName, countBots));
            
            GameViewModel gameViewModel = new GameViewModel(game, players);                      
            return View("Game", gameViewModel);
        }  
    }
}