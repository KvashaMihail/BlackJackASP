using BlackJack.BL.Models;
using BlackJack.BL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BlackJack.UI.Controllers
{
    public class PlayerPageController : Controller
    {
        private IPlayerService _playerService;

        public PlayerPageController(IPlayerService service)
        {
            _playerService = service;
        }

        public IActionResult Index()
        {
            IEnumerable<Player> playerList = _playerService.ShowPlayers();
            return View(playerList);
        }

        public IActionResult CreatePlayer(string name)
        {
            _playerService.Create(name);
            return View();
        }

        //public IActionResult Index()
        //{
        //    return View();
        //}
    }
}