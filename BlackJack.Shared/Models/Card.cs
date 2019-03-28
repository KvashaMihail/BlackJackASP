using System.ComponentModel.DataAnnotations.Schema;

namespace BlackJack.Shared.Models
{
    public class Card
    {
        public byte Id { get; set; }
        public byte Value { get; set; }
        public byte Suit { get; set; }
    }
}
