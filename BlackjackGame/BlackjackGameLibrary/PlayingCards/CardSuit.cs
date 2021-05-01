using System.Collections.Generic;
using System.Collections.Immutable;

namespace BlackjackGameLibrary.PlayingCards
{
  public class CardSuit : ICardSuit
  {
    private readonly List<Card> _cards;
    private readonly ECardSuitTypes _suitType;
    private readonly CardDeckRules _cardDeckRules;

    public CardSuit(ECardSuitTypes suitType)
    {
      _suitType = suitType;
      _cardDeckRules = new CardDeckRulesProvider().GetRules();
      _cards = new List<Card>();
      CreateSuit();
    }

    private void CreateSuit()
    {
      AddNumericalCards();
      AddFaceCards();
      _cards.Add(new Card(_cardDeckRules.DefaultAceValue, _suitType, ECardType.Ace));
    }

    private void AddNumericalCards()
    {
      for (int i = 0; i < _cardDeckRules.NumberOfNumericalCardsInASuit; i++)
      {
        int cardValue = _cardDeckRules.SmallestValueOfNumericalCards + i;
        _cards.Add(new Card(cardValue, _suitType, ECardType.Numerical));
      }
    }

    private void AddFaceCards()
    {
      _cards.Add(new Card(_cardDeckRules.FaceCardValue, _suitType, ECardType.Jack));
      _cards.Add(new Card(_cardDeckRules.FaceCardValue, _suitType, ECardType.Queen));
      _cards.Add(new Card(_cardDeckRules.FaceCardValue, _suitType, ECardType.King));
    }

    public ECardSuitTypes SuitType => _suitType;
    public IImmutableList<Card> Cards => _cards.ToImmutableList();

    public void Shuffle()
    {
      throw new System.NotImplementedException();
    }
  }
}