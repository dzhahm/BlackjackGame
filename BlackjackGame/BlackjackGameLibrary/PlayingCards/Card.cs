﻿namespace BlackjackGameLibrary.PlayingCards
{
  public class Card : ICard
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
  }
}