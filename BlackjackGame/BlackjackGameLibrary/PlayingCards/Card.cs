using System;

namespace BlackjackGameLibrary.PlayingCards
{
  public class Card : ICard
  {
    protected int _value;
    private readonly ECardSuitTypes _cardSuitType;
    private readonly ECardType _cardType;

    public Card(int value, ECardSuitTypes cardSuitType, ECardType cardType)
    {
      _value = value;
      _cardSuitType = cardSuitType;
      _cardType = cardType;
    }


    public Card GetNumericalCard(int value, ECardSuitTypes cardSuitType)
    {
      if (value <= 10)
      {
        return new Card(value, cardSuitType, ECardType.Numerical);
      }

      throw new ArgumentException();
    }

    public int Value => _value;
    public ECardType CardType => _cardType;
    public ECardSuitTypes CardSuit => _cardSuitType;

    public bool IsEqual(ICard card)
    {
      if (card.CardSuit != CardSuit)
      {
        return false;
      }

      if (card.CardType != CardType)
      {
        return false;
      }

      if (card.Value != Value)
      {
        return false;
      }

      return true;
    }

    public Card Clone()
    {
      Card tempCard = new Card(_value, _cardSuitType, _cardType);
      return tempCard;
    }
  }
}