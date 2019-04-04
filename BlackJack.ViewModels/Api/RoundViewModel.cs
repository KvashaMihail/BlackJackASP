using BlackJack.Models;
using System.Collections.Generic;

namespace BlackJack.ViewModels.Api
{
    public class RoundViewModel
    {
        public Round Round { get; set; }
        public List<string> Players { get; set; }
        public List<byte> Scores { get; set; }
        public List<bool?> IsWins { get; set; }
        public List<List<byte>> Cards { get; set; }
    }
}
