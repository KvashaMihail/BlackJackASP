using BlackJack.Models;
using System.Collections.Generic;

namespace BlackJack.BL.Services.Interfaces
{
    public interface IRoundService
    {
        void StartFirstRound(int gameId, IEnumerable<int> playersId);
        void StartRound(int gameId);

        List<byte> GetCardsForPlayers(int gameId, List<bool> flags);
        List<byte> GetScores(int gameId);       
        List<bool> GetFlagsIsGiveCard(int gameId, bool playerChoice);
        bool GetIsRoundFinished(int gameId, IEnumerable<bool> flags);
        List<bool> GetFlagsIsWin(int gameId);
        List<List<byte>> GetStartCards(int gameId);
        void SaveRound(int gameId, List<bool> flags);

        List<Round> GetRounds(int gameId);
        List<byte> GetScoresByRoundId(int gameId, int roundId);
        List<bool?> GetIsWinsByRound(int gameId, int roundId);
        List<List<byte>> GetCardsByRound(int gameId, int roundId);
        IEnumerable<int> GetPlayersId(int gameId);

    }
}
