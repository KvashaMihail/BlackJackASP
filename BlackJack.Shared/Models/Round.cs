namespace BlackJack.Shared.Models
{
    public class Round
    {
        public int Id { get; set; }
        public int NumberRound { get; set; }
        public bool IsCompleted { get; set; }
        public int GameId { get; set; }
    }
}
