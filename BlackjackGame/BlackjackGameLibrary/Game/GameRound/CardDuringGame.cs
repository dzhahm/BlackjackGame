using BlackjackGameLibrary.PlayingCards;


namespace BlackjackGameLibrary.Game.GameRound
{
  public class CardDuringGame : Card
  {
    public bool IsOpen;

    public CardDuringGame(Card card, bool isOpen) : base(card.Value, card.CardSuit, card.CardType)
    {
    }

    public CardDuringGame(int value, ECardSuitTypes cardSuitType, ECardType cardType) : base(value, cardSuitType, cardType)
    {
    }
  }
}