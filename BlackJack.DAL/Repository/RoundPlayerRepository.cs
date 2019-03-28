using BlackJack.DAL.EF;
using BlackJack.DAL.Entities;
using BlackJack.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data.Common;

namespace BlackJack.DAL.Repository
{
    public class RoundPlayerRepository : IRoundPlayerRepository
    {

        protected readonly BlackJackContext _context;

        public RoundPlayerRepository(DbConnection connection)
        {
            _context = new BlackJackContext(connection);
        }


        public void Create(ref Shared.Models.RoundPlayer item)
        {
            RoundPlayer roundPlayer = Mapper.ToEntity(item);
            _context.RoundPlayers.Add(roundPlayer);
            _context.SaveChanges();
            item = Mapper.ToModel(roundPlayer);
        }

        public void Delete(int id)
        {
            RoundPlayer item = _context.RoundPlayers.Find(id);
            if (item != null)
            {
                _context.RoundPlayers.Remove(item);
                _context.SaveChanges();
            }
        }

        public Shared.Models.RoundPlayer Get(int id)
        {
            return Mapper.ToModel(_context.RoundPlayers.Find(id));
        }

        public IEnumerable<Shared.Models.RoundPlayer> GetAll()
        {
            return Mapper.ToModel(_context.RoundPlayers);
        }

        public void Update(Shared.Models.RoundPlayer item)
        {

            _context.Entry(Mapper.ToEntity(item)).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}