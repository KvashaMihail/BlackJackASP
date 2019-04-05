using BlackJack.BL.Services.Interfaces;
using BlackJack.DAL.Interfaces;
using BlackJack.Models;
using BlackJack.Shared.Enums;
using System;
using System.Collections.Generic;

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
            int numberCard = _roundPlayerCardRepository.GetCountCardsByRoundPlayer(roundPlayerId) + 1;
            RoundPlayerCard roundPlayerCard = new RoundPlayerCard
            {
                CardId = cardId,
                RoundPlayerId = roundPlayerId,
                NumberCard = numberCard
            };
            _roundPlayerCardRepository.Create(roundPlayerCard);
            return cardId;
        }

        private byte GetScoreCard(byte idCard)
        {
            byte valueCard = _cardRepository.Get(idCard).Value;
            if (valueCard <= 8)
            {
                return (byte)(valueCard + 2);
            }
            if (valueCard > 8 && valueCard < 12)
            {
                return 10;
            }
            return (byte)Constants.AceCardScore;
        }       

        public byte GetScorePlayer(int roundPlayerId)
        {
            byte score = 0;
            int countAces = 0;
            var cards = _roundPlayerCardRepository.GetCardsByRoundPlayer(roundPlayerId);
            foreach (RoundPlayerCard card in cards)
            {
                score += GetScoreCard(Convert.ToByte(card.CardId));
                if (card.CardId > 48)
                {
                    countAces++;
                }
            }
            for (int i = 0; i < countAces; i++)
            {
                if (score > (byte)Constants.MaxScore)
                {
                    score -= 10;
                }
            }
            return score;
        }

        public bool CheckBlackJack(int roundPlayerId)
        {
            int cardsCount = _roundPlayerCardRepository.GetCountCardsByRoundPlayer(roundPlayerId);
            byte score = GetScorePlayer(roundPlayerId);
            return cardsCount == 2 && score == (byte)Constants.MaxScore;
        }

        public List<byte> GetCardsByRoundPlayer(int roundPlayerId)
        {
            var cardsId = new List<byte>();
            var cards = _roundPlayerCardRepository.GetCardsByRoundPlayer(roundPlayerId);
            foreach (RoundPlayerCard card in cards)
            {
                cardsId.Add((byte)card.CardId);
            }
            return cardsId;
        }
    }
}
