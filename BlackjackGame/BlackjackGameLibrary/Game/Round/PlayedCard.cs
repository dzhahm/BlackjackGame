using BlackjackGameLibrary.PlayingCards;

namespace BlackjackGameLibrary.Game.Round
{
  public class PlayedCard : Card
  {
    public bool IsOpen;

    public PlayedCard(Card card, bool isOpen) : base(card.Value, card.CardSuit, card.CardType)
    {
    }

    public PlayedCard(int value, ECardSuitTypes cardSuitType, ECardType cardType) : base(value, cardSuitType, cardType)
    {
    }
  }
}