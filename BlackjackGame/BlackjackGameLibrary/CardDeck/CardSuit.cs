using System.Collections.Generic;

namespace BlackjackGameLibrary.CardDeck
{
  public class CardSuit
  {
    private readonly List<Card> _cards;
    private readonly ECardSuitTypes _suitType;
    private readonly CardDeckRules _cardDeckRules;

    public CardSuit(ECardSuitTypes suitType)
    {
      _suitType = suitType;
      _cards = new List<Card>(_cardDeckRules.NumberOfCardsInASuit);
      _cardDeckRules = new CardDeckRulesProvider().GetRules();
      CreateSuit();
    }

    private void CreateSuit()
    {
      AddNumericalCards();
      AddFaceCards();
      _cards[_cardDeckRules.NumberOfCardsInASuit - 1] = new Card(_cardDeckRules.DefaultAceValue, _suitType, ECardType.Ace);
    }

    private void AddNumericalCards()
    {
      for (int i = 0; i < _cardDeckRules.NumberOfCardsInASuit; i++)
      {
        int cardValue = _cardDeckRules.SmallestValueOfNumericalCards + i;
        _cards[i] = new Card(cardValue, _suitType, ECardType.Numerical);
      }
    }

    private void AddFaceCards()
    {
      _cards[_cardDeckRules.NumberOfNumericalCardsInASuit] = new Card(_cardDeckRules.FaceCardValue, _suitType, ECardType.Jack);
      _cards[_cardDeckRules.NumberOfNumericalCardsInASuit + 1] = new Card(_cardDeckRules.FaceCardValue, _suitType, ECardType.Queen);
      _cards[_cardDeckRules.NumberOfNumericalCardsInASuit + 2] = new Card(_cardDeckRules.FaceCardValue, _suitType, ECardType.King);
    }
  }
}