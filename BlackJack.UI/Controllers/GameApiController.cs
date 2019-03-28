using BlackJack.BL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BlackJack.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameApiController : ControllerBase
    {
        private ICardService _cardService;

        public GameApiController(ICardService cardService)
        {
            _cardService = cardService;
        }

        [HttpGet]
        public ActionResult<byte> GetRandomCard()
        {
            return _cardService.GetRandomCard();
        }
    }
}