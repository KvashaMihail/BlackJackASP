using BlackJack.BL.Services.Interfaces;
using BlackJack.Models;
using BlackJack.UI.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BlackJack.UI.Controllers
{
    public class GameController : Controller
    {
        private IGameService _gameService;
        private IRoundService _roundService;
        private readonly UserManager<IdentityUser> _userManager;

        public GameController(IGameService gameService,
            IRoundService roundService,
            UserManager<IdentityUser> userManager)
        {
            _gameService = gameService;
            _roundService = roundService;
            _userManager = userManager;
        }

        public IActionResult Index()
        {            
            return View("Index", _userManager.GetUserName(HttpContext.User));
        }

        public IActionResult StartGame(int countBots)
        {
            string playerName = _userManager.GetUserName(HttpContext.User);
            Game game = _gameService.Create(playerName);
            IEnumerable<Player> players = _gameService.GetPlayers(playerName, countBots);
            var playersId = new List<int>();
            foreach (Player player in players)
            {
                playersId.Add(player.Id);
            }
            _roundService.StartRound(game.Id, playersId);
            GameViewModel gameViewModel = new GameViewModel(game, players);                      
            return View("Game", gameViewModel);
        }  
    }
}