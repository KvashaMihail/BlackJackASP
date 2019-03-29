using BlackJack.BL.Services.Interfaces;
using BlackJack.DAL.Interfaces;
using BlackJack.Models;
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

        public byte GetRandomCard(int roundPlayerId)
        {
            var random = new Random();
            byte cardId = (byte)random.Next(1, 52);
            RoundPlayerCard roundPlayerCard = new RoundPlayerCard
            {
                CardId = cardId,
                RoundPlayerId = roundPlayerId
            };
            _roundPlayerCardRepository.Create(roundPlayerCard);
            return cardId;
        }
    }
}
