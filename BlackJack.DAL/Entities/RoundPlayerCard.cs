namespace BlackJack.DAL.Entities
{
    public class RoundPlayerCard
    {
        public int Id { get; set; }
        public int NumberCard { get; set; }

        public int RoundPlayerId { get; set; }
        public RoundPlayer RoundPlayer { get; set; }
        public int CardId { get; set; }
        public Card Card { get; set; }
    }
}
