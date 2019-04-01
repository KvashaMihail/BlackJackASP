namespace BlackJack.BL.Services.Interfaces
{
    public interface ICardService
    {
        byte GetRandomCard(int roundPlayerId);
        byte GetScorePlayer(int roundPlayerId);
        bool CheckBlackJack(int roundPlayerId);
    }
}
