using BlackJack.BL.Services.Interfaces;
using BlackJack.Models;
//using BlackJack.Models;
using BlackJack.UI.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlackJack.UI.Controllers
{
    public class HomeController : Controller
    {
        private IPlayerService _playerService;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public HomeController(IPlayerService service, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _playerService = service;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            IEnumerable<Player> playerList = _playerService.ShowPlayers();
            return View(playerList);
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterPlayerModel model)
        {
            if (ModelState.IsValid)
            {
                IdentityUser user = new IdentityUser { UserName = model.Name};
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, false);
                    _playerService.SelectOrCreate(model.Name);
                    return RedirectToAction("Index", "Game");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginPlayerModel model)
        {
            if (ModelState.IsValid)
            {
                var result =
                    await _signInManager.PasswordSignInAsync(model.Login, model.Password, false, false);
                if (result.Succeeded)
                {
                        return RedirectToAction("Index", "Game");
                }
                ModelState.AddModelError("", "Incorrect username and / or password");
            }
            return View(model);
        }
    }
}