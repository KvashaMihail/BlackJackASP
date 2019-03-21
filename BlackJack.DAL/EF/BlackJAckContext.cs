using BlackJack.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data.Common;

namespace BlackJack.DAL.EF
{

    public class BlackJackContext : DbContext
    {
        private readonly string _connectionString = @"Data Source=(LocalDb)\MSSQLLocalDB;Database=BlackJack";

        public DbSet<Game> Games { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<Round> Rounds { get; set; }
        public DbSet<RoundPlayer> RoundPlayers { get; set; }
        public DbSet<RoundPlayerCard> RoundPlayerCards { get; set; }

        public BlackJackContext(DbConnection connectionString)
        {
            //_connectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Player
            modelBuilder.Entity<Player>()
                .Property(p => p.IsBot)
                .IsRequired();
            modelBuilder.Entity<Player>()
                .Property(p => p.Name)
                .HasMaxLength(15);
            modelBuilder.Entity<Player>()
                .HasIndex(property => property.Name)
                .IsUnique();
            modelBuilder.Entity<Player>()
                .HasMany(p => p.RoundPlayers)
                .WithOne(rp => rp.Player)
                .HasForeignKey(rp => rp.PlayerId);

            modelBuilder.Entity<Player>()
                .HasData(InitialPlayers());
            #endregion

            #region Game
            modelBuilder.Entity<Game>()
                .Property(g => g.Name)
                .IsRequired().HasMaxLength(20);
            modelBuilder.Entity<Game>()
                .HasMany(g => g.Rounds)
                .WithOne(r => r.Game)
                .HasForeignKey(r => r.GameId);
            #endregion

            #region Round
            modelBuilder.Entity<Round>()
                .Property(rp => rp.NumberRound)
                .IsRequired();
            modelBuilder.Entity<Round>()
                .HasMany(r => r.RoundPlayers)
                .WithOne(rp => rp.Round)
                .HasForeignKey(rp => rp.RoundId);
            #endregion

            #region RoundPlayer
            modelBuilder.Entity<RoundPlayer>()
                .Property(rp => rp.IsWin)
                .IsRequired();
            modelBuilder.Entity<RoundPlayer>()
                .HasMany(rp => rp.RoundPlayerCards)
                .WithOne(rpc => rpc.RoundPlayer)
                .HasForeignKey(rpc => rpc.RoundPlayerId);
            #endregion

            #region RoundPlayerCard
            modelBuilder.Entity<RoundPlayerCard>()
                .Property(rpc => rpc.NumberCard)
                .IsRequired();
            //modelBuilder.Entity<RoundPlayerCard>()
            //    .HasOne<Card>()
            //    .WithOne()
            //    .HasForeignKey(rpc => rpc.CardId);
            #endregion

            #region Card
            modelBuilder.Entity<Card>()
                .HasData(InitialCards());
            #endregion
        }

        private Card[] InitialCards()
        {
            var cards = new List<Card>();
            for (byte cardRank = 0; cardRank < 13; cardRank++)
            {
                for (byte suit = 0; suit < 4; suit++)
                {
                    cards.Add(new Card
                    {
                        Id = (byte)(cardRank * 4 + suit + 1),
                        Value = cardRank,
                        Suit = suit
                    });
                }
            }
            return cards.ToArray();
        }

        private Player[] InitialPlayers()
        {
            var players = new List<Player>
            {
                new Player { Id = 1, Name = "Bob", IsBot = true },
                new Player { Id = 2, Name = "Kate", IsBot = true },
                new Player { Id = 3, Name = "Harry", IsBot = true },
                new Player { Id = 4, Name = "Randolph", IsBot = true },
                new Player { Id = 5, Name = "William", IsBot = true },
                new Player { Id = 6, Name = "Adam", IsBot = true },
                new Player { Id = 7, Name = "Olivia", IsBot = true },
                new Player { Id = 8, Name = "Dealer", IsBot = true }
            };
            return players.ToArray();
        }
    }
}
