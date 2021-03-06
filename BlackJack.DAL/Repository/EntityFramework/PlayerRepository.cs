﻿using BlackJack.DAL.EF;
using BlackJack.DAL.Entities;
using BlackJack.DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace BlackJack.DAL.Repository.EntityFramework
{
    public class PlayerRepository : IPlayerRepository
    {
        
        protected readonly BlackJackContext _context;

        public PlayerRepository(BlackJackContext context)
        {
            _context = context;
        }


        public int Create(Models.Player item)
        {
            Player player = Mapper.ToEntity(item);
            player.IsBot = false;
            _context.Players.Add(player);
            _context.SaveChanges();
            return player.Id;
        }

        public void Delete(int id)
        {
            Player item = _context.Players.Find(id);
            if (item != null)
            {
                _context.Players.Remove(item);
                _context.SaveChanges();
            }
        }

        public Models.Player Get(int id)
        {
            return Mapper.ToModel(_context.Players.Find(id));
        }

        public IEnumerable<Models.Player> GetAll()
        {
            return Mapper.ToModel(_context.Players);
        }

        public IEnumerable<Models.Player> GetPlayers()
        {
            return Mapper.ToModel(_context.Players.Where(p => p.IsBot == false));
        }

        public IEnumerable<Models.Player> GetBots(int countBots)
        {
            return Mapper.ToModel(_context.Players.Where(p => p.Id <= countBots));
        }

        public Models.Player Get(string name)
        {
            return Mapper.ToModel(_context.Players.Where(p => p.Name == name).FirstOrDefault());
        }

        public bool GetIsEmptyByName(string name)
        {
            return _context.Players.Where(p => p.Name == name).FirstOrDefault() == null;
        }

        public Models.Player GetDealer()
        {
            return Mapper.ToModel(_context.Players.Find(8));
        }
    }
}
