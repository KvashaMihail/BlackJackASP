using BlackJack.BL.Services.Interfaces;
using BlackJack.UI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace BlackJack.UI.Controllers
{
    public class HomeController : Controller
    {
        private IPlayerService _playerService;

        public HomeController(IPlayerService service)
        {
            _playerService = service;
        }

        public IActionResult Index()
        {
            IEnumerable<PlayerViewModel> playerList = Mapper.ToViewModel(_playerService.ShowPlayers());
            return View(playerList);
        }

        public IActionResult Login(string name)
        {
            try
            {
                PlayerViewModel player = Mapper.ToViewModel(_playerService.SelectOrCreate(name));
                return RedirectToAction("Index", "GameMenu", player);
            }
            catch (Exception exception)
            {
                ViewBag.Message = exception.Message;
                return View("Error");
            } 
        }
    }
}