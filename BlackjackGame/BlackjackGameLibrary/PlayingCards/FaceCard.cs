namespace BlackjackGameLibrary.PlayingCards
{
  public class FaceCard : Card
  {
    public FaceCard(ECardSuitTypes cardSuitType, ECardType cardType) : base(10, cardSuitType, cardType)
    {
      CardDeckConfiguration config = new CardDeckConfigurationProvider().GetRules();
      _value = config.FaceCardValue;
    }
  }
}