﻿using BlackJack.BL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJack.BL.Services.Interfaces
{
    public interface IPlayerService
    {
        Player SelectOrCreate(string name);
        IEnumerable<Player> ShowPlayers();
    }
}
