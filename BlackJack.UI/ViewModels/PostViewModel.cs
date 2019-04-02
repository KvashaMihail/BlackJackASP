using System.Collections.Generic;

namespace BlackJack.UI.ViewModels
{
    public class PostViewModel
    {
        public int GameId { get; set; }
        public List<bool> Flags { get; set; }
        public bool Choice { get; set; }
    }
}
