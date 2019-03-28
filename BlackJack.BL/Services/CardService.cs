using BlackJack.BL.Services.Interfaces;
using BlackJack.DAL.Interfaces;
using System;

namespace BlackJack.BL.Services
{
    public class CardService : ICardService
    {
        private IRoundPlayerCardRepository _roundPlayerCardRepository;
        private ICardRepository _cardRepository;

        public CardService(IRoundPlayerCardRepository roundPlayerCardRepository,
            ICardRepository cardRepository)
        {
            _roundPlayerCardRepository = roundPlayerCardRepository;
            _cardRepository = cardRepository;
        }

        public byte GetRandomCard()
        {
            var random = new Random();
            return (byte)random.Next(1, 52);
        }
    }
}
