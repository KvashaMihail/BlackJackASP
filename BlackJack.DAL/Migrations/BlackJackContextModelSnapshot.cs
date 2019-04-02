﻿// <auto-generated />
using System;
using BlackJack.DAL.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BlackJack.DAL.Migrations
{
    [DbContext(typeof(BlackJackContext))]
    partial class BlackJackContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.8-servicing-32085")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BlackJack.DAL.Entities.Card", b =>
                {
                    b.Property<byte>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<byte>("Suit");

                    b.Property<byte>("Value");

                    b.HasKey("Id");

                    b.ToTable("Cards");

                    b.HasData(
                        new { Id = (byte)1, Suit = (byte)0, Value = (byte)0 },
                        new { Id = (byte)2, Suit = (byte)1, Value = (byte)0 },
                        new { Id = (byte)3, Suit = (byte)2, Value = (byte)0 },
                        new { Id = (byte)4, Suit = (byte)3, Value = (byte)0 },
                        new { Id = (byte)5, Suit = (byte)0, Value = (byte)1 },
                        new { Id = (byte)6, Suit = (byte)1, Value = (byte)1 },
                        new { Id = (byte)7, Suit = (byte)2, Value = (byte)1 },
                        new { Id = (byte)8, Suit = (byte)3, Value = (byte)1 },
                        new { Id = (byte)9, Suit = (byte)0, Value = (byte)2 },
                        new { Id = (byte)10, Suit = (byte)1, Value = (byte)2 },
                        new { Id = (byte)11, Suit = (byte)2, Value = (byte)2 },
                        new { Id = (byte)12, Suit = (byte)3, Value = (byte)2 },
                        new { Id = (byte)13, Suit = (byte)0, Value = (byte)3 },
                        new { Id = (byte)14, Suit = (byte)1, Value = (byte)3 },
                        new { Id = (byte)15, Suit = (byte)2, Value = (byte)3 },
                        new { Id = (byte)16, Suit = (byte)3, Value = (byte)3 },
                        new { Id = (byte)17, Suit = (byte)0, Value = (byte)4 },
                        new { Id = (byte)18, Suit = (byte)1, Value = (byte)4 },
                        new { Id = (byte)19, Suit = (byte)2, Value = (byte)4 },
                        new { Id = (byte)20, Suit = (byte)3, Value = (byte)4 },
                        new { Id = (byte)21, Suit = (byte)0, Value = (byte)5 },
                        new { Id = (byte)22, Suit = (byte)1, Value = (byte)5 },
                        new { Id = (byte)23, Suit = (byte)2, Value = (byte)5 },
                        new { Id = (byte)24, Suit = (byte)3, Value = (byte)5 },
                        new { Id = (byte)25, Suit = (byte)0, Value = (byte)6 },
                        new { Id = (byte)26, Suit = (byte)1, Value = (byte)6 },
                        new { Id = (byte)27, Suit = (byte)2, Value = (byte)6 },
                        new { Id = (byte)28, Suit = (byte)3, Value = (byte)6 },
                        new { Id = (byte)29, Suit = (byte)0, Value = (byte)7 },
                        new { Id = (byte)30, Suit = (byte)1, Value = (byte)7 },
                        new { Id = (byte)31, Suit = (byte)2, Value = (byte)7 },
                        new { Id = (byte)32, Suit = (byte)3, Value = (byte)7 },
                        new { Id = (byte)33, Suit = (byte)0, Value = (byte)8 },
                        new { Id = (byte)34, Suit = (byte)1, Value = (byte)8 },
                        new { Id = (byte)35, Suit = (byte)2, Value = (byte)8 },
                        new { Id = (byte)36, Suit = (byte)3, Value = (byte)8 },
                        new { Id = (byte)37, Suit = (byte)0, Value = (byte)9 },
                        new { Id = (byte)38, Suit = (byte)1, Value = (byte)9 },
                        new { Id = (byte)39, Suit = (byte)2, Value = (byte)9 },
                        new { Id = (byte)40, Suit = (byte)3, Value = (byte)9 },
                        new { Id = (byte)41, Suit = (byte)0, Value = (byte)10 },
                        new { Id = (byte)42, Suit = (byte)1, Value = (byte)10 },
                        new { Id = (byte)43, Suit = (byte)2, Value = (byte)10 },
                        new { Id = (byte)44, Suit = (byte)3, Value = (byte)10 },
                        new { Id = (byte)45, Suit = (byte)0, Value = (byte)11 },
                        new { Id = (byte)46, Suit = (byte)1, Value = (byte)11 },
                        new { Id = (byte)47, Suit = (byte)2, Value = (byte)11 },
                        new { Id = (byte)48, Suit = (byte)3, Value = (byte)11 },
                        new { Id = (byte)49, Suit = (byte)0, Value = (byte)12 },
                        new { Id = (byte)50, Suit = (byte)1, Value = (byte)12 },
                        new { Id = (byte)51, Suit = (byte)2, Value = (byte)12 },
                        new { Id = (byte)52, Suit = (byte)3, Value = (byte)12 }
                    );
                });

            modelBuilder.Entity("BlackJack.DAL.Entities.Game", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateEnd");

                    b.Property<DateTime>("DateStart");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("BlackJack.DAL.Entities.Player", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsBot");

                    b.Property<string>("Name")
                        .HasMaxLength(15);

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasFilter("[Name] IS NOT NULL");

                    b.ToTable("Players");

                    b.HasData(
                        new { Id = 1, IsBot = true, Name = "Bob" },
                        new { Id = 2, IsBot = true, Name = "Kate" },
                        new { Id = 3, IsBot = true, Name = "Harry" },
                        new { Id = 4, IsBot = true, Name = "Randolph" },
                        new { Id = 5, IsBot = true, Name = "William" },
                        new { Id = 6, IsBot = true, Name = "Adam" },
                        new { Id = 7, IsBot = true, Name = "Olivia" },
                        new { Id = 8, IsBot = true, Name = "Dealer" }
                    );
                });

            modelBuilder.Entity("BlackJack.DAL.Entities.Round", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("GameId");

                    b.Property<bool>("IsCompleted");

                    b.Property<int>("NumberRound");

                    b.HasKey("Id");

                    b.HasIndex("GameId");

                    b.ToTable("Rounds");
                });

            modelBuilder.Entity("BlackJack.DAL.Entities.RoundPlayer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool?>("IsWin");

                    b.Property<int>("PlayerId");

                    b.Property<int>("RoundId");

                    b.HasKey("Id");

                    b.HasIndex("PlayerId");

                    b.HasIndex("RoundId");

                    b.ToTable("RoundPlayers");
                });

            modelBuilder.Entity("BlackJack.DAL.Entities.RoundPlayerCard", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CardId");

                    b.Property<byte?>("CardId1");

                    b.Property<int>("NumberCard");

                    b.Property<int>("RoundPlayerId");

                    b.HasKey("Id");

                    b.HasIndex("CardId1");

                    b.HasIndex("RoundPlayerId");

                    b.ToTable("RoundPlayerCards");
                });

            modelBuilder.Entity("BlackJack.DAL.Entities.Round", b =>
                {
                    b.HasOne("BlackJack.DAL.Entities.Game", "Game")
                        .WithMany("Rounds")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BlackJack.DAL.Entities.RoundPlayer", b =>
                {
                    b.HasOne("BlackJack.DAL.Entities.Player", "Player")
                        .WithMany("RoundPlayers")
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BlackJack.DAL.Entities.Round", "Round")
                        .WithMany("RoundPlayers")
                        .HasForeignKey("RoundId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BlackJack.DAL.Entities.RoundPlayerCard", b =>
                {
                    b.HasOne("BlackJack.DAL.Entities.Card", "Card")
                        .WithMany()
                        .HasForeignKey("CardId1");

                    b.HasOne("BlackJack.DAL.Entities.RoundPlayer", "RoundPlayer")
                        .WithMany("RoundPlayerCards")
                        .HasForeignKey("RoundPlayerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
