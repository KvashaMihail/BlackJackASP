using BlackJack.DAL.EF;
using BlackJack.DAL.Entities;
using BlackJack.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data.Common;

namespace BlackJack.DAL.Repository
{
    public class RoundPlayerCardRepository : IRoundPlayerCardRepository
    {

        protected readonly BlackJackContext _context;

        public RoundPlayerCardRepository(DbConnection connection)
        {
            _context = new BlackJackContext(connection);
        }

        public void Create(ref Shared.Models.RoundPlayerCard item)
        {
            RoundPlayerCard roundPlayerCard = Mapper.ToEntity(item);
            _context.RoundPlayerCards.Add(roundPlayerCard);
            _context.SaveChanges();
            item = Mapper.ToModel(roundPlayerCard);
        }

        public void Delete(int id)
        {
            RoundPlayerCard item = _context.RoundPlayerCards.Find(id);
            if (item != null)
            {
                _context.RoundPlayerCards.Remove(item);
                _context.SaveChanges();
            }
        }

        public Shared.Models.RoundPlayerCard Get(int id)
        {
            return Mapper.ToModel(_context.RoundPlayerCards.Find(id));
        }

        public IEnumerable<Shared.Models.RoundPlayerCard> GetAll()
        {
            return Mapper.ToModel(_context.RoundPlayerCards);
        }

        public void Update(Shared.Models.RoundPlayerCard item)
        {

            _context.Entry(Mapper.ToEntity(item)).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}