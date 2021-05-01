namespace BlackjackGameLibrary.CardDeck
{
  public class Card
  {
    private readonly int _value;
    private readonly ECardSuitTypes _cardSuitType;
    private readonly ECardType _cardType;

    public Card(int value, ECardSuitTypes cardSuitType, ECardType cardType)
    {
      _value = value;
      _cardSuitType = cardSuitType;
      _cardType = cardType;
    }
  }
}