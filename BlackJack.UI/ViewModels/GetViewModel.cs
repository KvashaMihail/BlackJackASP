using System.Collections.Generic;

namespace BlackJack.UI.ViewModels
{
    public class GetViewModel
    {
        public bool IsFinishedRound { get; set; }
        public List<List<byte>> Cards { get; set; }
        public List<byte> Scores { get; set; }
    }
}
