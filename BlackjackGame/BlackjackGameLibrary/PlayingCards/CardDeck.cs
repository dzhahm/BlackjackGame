using System.Collections.Generic;
using System.Collections.Immutable;

namespace BlackjackGameLibrary.PlayingCards
{
  public class CardDeck : ICardDeck
  {
    private CardDeckRules _cardDeckRules;
    private ImmutableList<CardSuit> _cardSuits;
    private List<Card> _cards;

    public CardDeck()
    {
      _cardDeckRules = new CardDeckRulesProvider().GetRules();
      AddCardSuits();
      AddCards();
    }

    private void AddCardSuits()
    {
      List<CardSuit> cardSuits = new List<CardSuit>();
      foreach (ECardSuitTypes cardSuitType in _cardDeckRules.CardSuits)
      {
        CardSuit cardSuit = new CardSuit(cardSuitType);
        cardSuits.Add(cardSuit);
      }

      _cardSuits = cardSuits.ToImmutableList();
    }

    private void AddCards()
    {
      _cards = new List<Card>();
      foreach (CardSuit cardSuit in _cardSuits)
      {
        _cards.AddRange(cardSuit.Cards);
      }
    }

    public IImmutableList<Card> Cards => _cards.ToImmutableList();

    public void Shuffle()
    {
      throw new System.NotImplementedException();
    }
  }
}