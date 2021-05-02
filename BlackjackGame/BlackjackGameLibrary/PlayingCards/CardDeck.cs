using System.Collections.Generic;
using System.Collections.Immutable;

namespace BlackjackGameLibrary.PlayingCards
{
  public class CardDeck : GroupOfCards, ICardDeck
  {
    private readonly CardDeckConfiguration _cardDeckConfiguration;
    private ImmutableList<CardSuit> _cardSuits;
    public ImmutableList<Card> Cards => _cards.ToImmutableList();

    public CardDeck()
    {
      _cardDeckConfiguration = new CardDeckConfigurationProvider().GetRules();
      AddCardSuits();
      AddCards();
    }

    private void AddCardSuits()
    {
      List<CardSuit> cardSuits = new List<CardSuit>();
      foreach (ECardSuitTypes cardSuitType in _cardDeckConfiguration.CardSuits)
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
  }
}