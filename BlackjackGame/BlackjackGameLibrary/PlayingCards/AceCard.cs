namespace BlackjackGameLibrary.PlayingCards
{
  public class AceCard : Card
  {
    public AceCard(ECardSuitTypes cardSuitType) : base(11, cardSuitType, ECardType.Ace)
    {
      CardDeckConfiguration config = new CardDeckConfigurationProvider().GetRules();
      _value = config.DefaultAceValue;
    }
  }
}