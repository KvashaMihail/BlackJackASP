namespace BlackJack.Models
{
    public class RoundPlayer
    {
        public int Id { get; set; }
        public bool? IsWin { get; set; }
        public int PlayerId { get; set; }
        public int RoundId { get; set; }
    }
}
