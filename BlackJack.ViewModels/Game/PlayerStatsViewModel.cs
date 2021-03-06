﻿using System.Collections.Generic;

namespace BlackJack.ViewModels.Game
{
    public class PlayerStatsViewModel
    {
        public bool IsFinishedRound { get; set; }
        public List<List<byte>> Cards { get; set; }
        public List<byte> Scores { get; set; }
    }
}
