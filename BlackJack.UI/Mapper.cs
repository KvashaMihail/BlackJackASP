using BlackJack.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlackJack.UI
{
    public static class Mapper
    {
        public static PlayerViewModel ToViewModel(BL.Models.Player player)
        {
            var playerOut = new PlayerViewModel
            {
                Name = player.Name,
            };
            return playerOut;
        }

        public static IEnumerable<PlayerViewModel> ToViewModel(IEnumerable<BL.Models.Player> players)
        {
            var playersOut = new List<PlayerViewModel>();
            foreach (BL.Models.Player player in players)
            {
                playersOut.Add(ToViewModel(player));
            }
            return playersOut;
        }
    }
}
