using System.Collections.Generic;
using System.Collections.Immutable;

namespace BlackjackGameLibrary.PlayingCards
{
  public class MultipleCardDecks : GroupOfCards, ICardDeck
  {
    public ImmutableList<Card> Cards => _cards.ToImmutableList();
    private readonly int _numberOfCardsDecks;

    public MultipleCardDecks(int numberOfCardDecks)
    {
      _numberOfCardsDecks = numberOfCardDecks;
      _cards = new List<Card>();
      AddCardDecks();
    }

    private void AddCardDecks()
    {
      for (int i = 0; i < _numberOfCardsDecks; i++)
      {
        _cards.AddRange(new CardDeck().Cards);
      }
    }
  }
}