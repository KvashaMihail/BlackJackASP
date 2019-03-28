using BlackJack.Models;
using System.Collections.Generic;

namespace BlackJack.DAL
{
    public static class Mapper
    {
        #region ToModel
        public static Player ToModel(DAL.Entities.Player player)
        {
            Player playerOut = new Player
            {
                Id = player.Id,
                Name = player.Name,
                //IsBot = player.IsBot
            };
            return playerOut;
        }

        public static Game ToModel(DAL.Entities.Game game)
        {
            Game gameOut = new Game
            {
                Id = game.Id,
                Name = game.Name,
                //DateStart = game.DateStart,
                //DateEnd = game.DateEnd
            };
            return gameOut;
        }

        public static Round ToModel(Entities.Round round)
        {
            Round roundOut = new Round
            {
                Id = round.Id,
                IsCompleted = round.IsCompleted,
                NumberRound = round.NumberRound,
                GameId = round.GameId
            };
            return roundOut;
        }

        public static RoundPlayer ToModel(DAL.Entities.RoundPlayer roundPlayer)
        {
            RoundPlayer roundPlayerOut = new RoundPlayer
            {
                Id = roundPlayer.Id,
                PlayerId = roundPlayer.PlayerId,
                RoundId = roundPlayer.RoundId,
                IsWin = roundPlayer.IsWin
            };
            return roundPlayerOut;
        }

        public static RoundPlayerCard ToModel(DAL.Entities.RoundPlayerCard roundPlayerCard)
        {
            RoundPlayerCard roundPlayerCardOut = new RoundPlayerCard
            {
                CardId = roundPlayerCard.CardId,
                RoundPlayerId = roundPlayerCard.RoundPlayerId,
                NumberCard = roundPlayerCard.NumberCard
            };
            return roundPlayerCardOut;
        }

        public static Card ToModel(DAL.Entities.Card card)
        {
            Card cardOut = new Card
            {
                Id = card.Id,
                Suit = card.Suit,
                Value = card.Value
            };
            return cardOut;
        }

        public static IEnumerable<Player> ToModel(IEnumerable<DAL.Entities.Player> players)
        {
            var playersOut = new List<Player>();
            foreach (DAL.Entities.Player player in players)
            {
                playersOut.Add(ToModel(player));
            }
            return playersOut;
        }

        public static IEnumerable<Game> ToModel(IEnumerable<DAL.Entities.Game> games)
                {
                    var gamesOut = new List<Game>();
                    foreach (DAL.Entities.Game game in games)
                    {
                        gamesOut.Add(ToModel(game));
                    }
                    return gamesOut;
                }

        public static IEnumerable<Round> ToModel(IEnumerable<DAL.Entities.Round> rounds)
        {
            var roundsOut = new List<Round>();
            foreach (DAL.Entities.Round round in rounds)
            {
                roundsOut.Add(ToModel(round));
            }
            return roundsOut;
        }

        public static IEnumerable<RoundPlayer> ToModel(IEnumerable<DAL.Entities.RoundPlayer> roundPlayers)
        {
            var roundPlayersOut = new List<RoundPlayer>();
            foreach (DAL.Entities.RoundPlayer roundPlayer in roundPlayers)
            {
                roundPlayersOut.Add(ToModel(roundPlayer));
            }
            return roundPlayersOut;
        }

        public static IEnumerable<RoundPlayerCard> ToModel(IEnumerable<DAL.Entities.RoundPlayerCard> roundPlayerCards)
        {
            var roundPlayerCardsOut = new List<RoundPlayerCard>();
            foreach (DAL.Entities.RoundPlayerCard roundPlayerCard in roundPlayerCards)
            {
                roundPlayerCardsOut.Add(ToModel(roundPlayerCard));
            }
            return roundPlayerCardsOut;
        }
        #endregion

        #region ToEntity
        public static DAL.Entities.Game ToEntity(Game game)
        {
            DAL.Entities.Game gameOut = new DAL.Entities.Game
            {
                Name = game.Name,
                //DateStart = game.DateStart,
                //DateEnd = game.DateEnd
            };
            return gameOut;
        }

        public static DAL.Entities.Player ToEntity(Player player)
                {
                    DAL.Entities.Player playerOut = new DAL.Entities.Player
                    {
                        Id = player.Id,
                        Name = player.Name,
                        //IsBot = player.IsBot
                    };
                    return playerOut;
                }

        public static DAL.Entities.Round ToEntity(Round round)
        {
            DAL.Entities.Round roundOut = new DAL.Entities.Round
            {
                Id = round.Id,
                IsCompleted = round.IsCompleted,
                NumberRound = round.NumberRound,
                GameId = round.GameId
            };
            return roundOut;
        }

        public static DAL.Entities.RoundPlayer ToEntity(RoundPlayer roundPlayer)
        {
            DAL.Entities.RoundPlayer roundPlayerOut = new DAL.Entities.RoundPlayer
            {
                Id = roundPlayer.Id,
                PlayerId = roundPlayer.PlayerId,
                RoundId = roundPlayer.RoundId,
                IsWin = roundPlayer.IsWin
            };
            return roundPlayerOut;
        }

        public static DAL.Entities.RoundPlayerCard ToEntity(RoundPlayerCard roundPlayerCard)
        {
            DAL.Entities.RoundPlayerCard roundPlayerCardOut = new DAL.Entities.RoundPlayerCard
            {
                CardId = roundPlayerCard.CardId,
                RoundPlayerId = roundPlayerCard.RoundPlayerId,
                NumberCard = roundPlayerCard.NumberCard
            };
            return roundPlayerCardOut;
        }

        public static DAL.Entities.Card ToEntity(Card card)
        {
            DAL.Entities.Card cardOut = new DAL.Entities.Card
            {
                Id = card.Id,
                Suit = card.Suit,
                Value = card.Value
            };
            return cardOut;
        }
        #endregion
    }
}
