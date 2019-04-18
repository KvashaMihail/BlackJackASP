﻿using BlackJack.BL.Services.Interfaces;
using BlackJack.Shared.Options;
using BlackJack.ViewModels.Account;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.UI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private IGameService _gameService;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly JwtSettingsOptions _jwtSettings;

        public AccountController(IGameService gameService, 
            UserManager<IdentityUser> userManager, 
            SignInManager<IdentityUser> signInManager,
            IOptions<JwtSettingsOptions> options)
        {
            _gameService = gameService;
            _userManager = userManager;
            _signInManager = signInManager;
            _jwtSettings = options.Value;
        }

        [HttpPost]
        public IActionResult TempAction()
        {
            var i = 5;
            return Ok(i);
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromBody]RegisterAccountView model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            IdentityUser user = new IdentityUser { UserName = model.Name};
            var result = await _userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                return BadRequest(ModelState);
            }
            await _signInManager.SignInAsync(user, false);
            var tokenHandler = new JwtSecurityTokenHandler();
            byte[] key = Encoding.ASCII.GetBytes(_jwtSettings.TokenSecret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, model.Name.ToLower())
                }),
                Expires = DateTime.Now.AddMinutes(30),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);
            string serializedToken = tokenHandler.WriteToken(token);
            _gameService.SelectPlayer(model.Name);
            var response = new AccountResponseView
            {
                Name = model.Name,
                Token = serializedToken
            };
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody]LoginAccountView model)
        {
            var result =
                    await _signInManager.PasswordSignInAsync(model.Login, model.Password, false, false);
            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Incorrect username and / or password");
                return BadRequest(ModelState);
            }
            var tokenHandler = new JwtSecurityTokenHandler();
            byte[] key = Encoding.ASCII.GetBytes(_jwtSettings.TokenSecret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, model.Login.ToLower())
                }),
                Expires = DateTime.Now.AddMinutes(30),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);
            string serializedToken = tokenHandler.WriteToken(token);
            var response = new AccountResponseView
            {
                Name = model.Login,
                Token = serializedToken
            };
            return Ok(response);
        }


    }
}