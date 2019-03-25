using BlackJack.BL.Services.Interfaces;
using BlackJack.UI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BlackJack.UI.Controllers
{
    public class GameMenuController : Controller
    {
        private IGameService _gameService;

        public GameMenuController(IGameService service)
        {
            _gameService = service;
        }

        public IActionResult Index(string name)
        {            
            return View("Index", name);
        }

        //public IActionResult StartGame()
        //{
        //    //try
        //    //{
        //    //    PlayerViewModel player = Mapper.ToViewModel(_playerService.SelectOrCreate(name));
        //    //    ViewBag.Message = $"Welcome to game BlackJack {player.Name} ";
        //    //    return RedirectToAction("Index", "GameMenu", player);
        //    //}
        //    //catch (Exception exception)
        //    //{
        //    //    ViewBag.Message = exception.Message;
        //    //    return View("Error");
        //    //}
        //}
    }
}