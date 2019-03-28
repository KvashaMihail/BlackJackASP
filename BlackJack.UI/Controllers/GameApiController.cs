using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlackJack.BL.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlackJack.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameApiController : ControllerBase
    {
        private ICardService _cardService;
        private readonly ICacheService _cacheService;

        public GameApiController(ICardService cardService,
            ICacheService cacheService)
        {
            _cardService = cardService;
            _cacheService = cacheService;
        }

        [HttpGet]
        public ActionResult<byte> GetRandomCard()
        {
            return _cardService.GetRandomCard();
        }

        [HttpGet("players")]
        public ActionResult<IEnumerable<int>> Get()
        {
            return _cacheService.GetIdPlayers().ToList();
        }
    }
}