using System.Collections.Generic;

namespace BlackJack.UI.ViewModels
{
    public class GetViewModel
    {
        bool IsFinishedRound { get; set; }
        List<List<byte>> Cards { get; set; }
    }
}
