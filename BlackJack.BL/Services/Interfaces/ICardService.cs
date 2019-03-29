namespace BlackJack.BL.Services.Interfaces
{
    public interface ICardService
    {
        byte GetRandomCard(int roundPlayerId);
    }
}
