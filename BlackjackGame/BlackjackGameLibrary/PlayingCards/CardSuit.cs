using System.Collections.Generic;
using System.Collections.Immutable;

namespace BlackjackGameLibrary.PlayingCards
{
  public class CardSuit : GroupOfCards, ICardSuit
  {
    private readonly ECardSuitTypes _suitType;
    private readonly CardDeckConfiguration _cardDeckConfiguration;

    public CardSuit(ECardSuitTypes suitType)
    {
      _suitType = suitType;
      _cardDeckConfiguration = new CardDeckConfigurationProvider().GetRules();
      _cards = new List<Card>();
      CreateSuit();
    }

    private void CreateSuit()
    {
      AddNumericalCards();
      AddFaceCards();
      _cards.Add(new Card(_cardDeckConfiguration.DefaultAceValue, _suitType, ECardType.Ace));
    }

    private void AddNumericalCards()
    {
      for (int i = 0; i < _cardDeckConfiguration.NumberOfNumericalCardsInASuit; i++)
      {
        int cardValue = _cardDeckConfiguration.SmallestValueOfNumericalCards + i;
        _cards.Add(new Card(cardValue, _suitType, ECardType.Numerical));
      }
    }

    private void AddFaceCards()
    {
      _cards.Add(new Card(_cardDeckConfiguration.FaceCardValue, _suitType, ECardType.Jack));
      _cards.Add(new Card(_cardDeckConfiguration.FaceCardValue, _suitType, ECardType.Queen));
      _cards.Add(new Card(_cardDeckConfiguration.FaceCardValue, _suitType, ECardType.King));
    }

    public ECardSuitTypes SuitType => _suitType;
    public IImmutableList<Card> Cards => _cards.ToImmutableList();
  }
}