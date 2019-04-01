using BlackJack.BL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace BlackJack.UI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class GameApiController : ControllerBase
    {
        private ICardService _cardService;
        private IRoundService _roundService;


        public GameApiController(ICardService cardService,
            IRoundService roundService)
        {
            _cardService = cardService;
            _roundService = roundService;
        }

        public ActionResult<IEnumerable<byte>> GetCards(int gameId)
        {
            return _roundService.GetCards(gameId).ToList();
        }

        public ActionResult<IEnumerable<byte>> GetScores(int gameId)
        {
            return _roundService.GetScores(gameId).ToList();
        }

        public ActionResult<IEnumerable<bool>> GetFlags(int gameId, bool choice)
        {
            return _roundService.GetFlagsIsGiveCard(gameId, choice).ToList();
        }

        [HttpGet]
        public ActionResult<bool> CheckEnd(int gameId, IEnumerable<bool> flags)
        {
            return _roundService.EndCheck(gameId, flags);
        }
    }
}