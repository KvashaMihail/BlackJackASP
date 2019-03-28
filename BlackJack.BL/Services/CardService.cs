using System;
using System.Collections.Generic;
using BlackJack.BL.Services.Interfaces;

namespace BlackJack.BL.Services
{
    public class CardService : ICardService
    {

        //private void AddDeck(ref List<byte> cards)
        //{
        //    for (byte i = 1; i < 53; i++)
        //    {
        //        cards.Add(i);
        //    }
        //}

        //public IEnumerable<byte> GetMixedCards()
        //{
        //    var cards = new List<byte>();
        //    for (int i = 0; i < 4; i++)
        //    {
        //        AddDeck(ref cards);
        //    }
        //    var random = new Random();
        //    for (int i = cards.Count - 1; i >= 0; i--)
        //    {
        //        int j = random.Next(i);
        //        byte temp = cards[i];
        //        cards[i] = cards[j];
        //        cards[j] = temp;
        //    }
        //    return cards;
        //}

        public byte GetRandomCard()
        {
            var random = new Random();

            return (byte)random.Next(1, 52);
        }
    }
}
