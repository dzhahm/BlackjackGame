using System;

namespace BlackjackGameLibrary.PlayingCards
{
  public class FaceCard : Card
  {
    public FaceCard(ECardSuitTypes cardSuitType, ECardType cardType) : base(10, cardSuitType, cardType)
    {
      if (cardType != ECardType.Jack && cardType != ECardType.Queen && cardType != ECardType.King)
      {
        throw new ArgumentException($@"Card type for face card must be either: 1) {ECardType.Jack} 2) {ECardType.Queen} 3) {ECardType.King}", nameof(cardType));
      }

      CardDeckConfiguration config = new CardDeckConfigurationProvider().GetRules();
      _value = config.FaceCardValue;
    }
  }
}