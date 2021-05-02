using System.Collections.Immutable;

namespace BlackjackGameLibrary.PlayingCards
{
  public interface ICardDeck
  {
    ImmutableList<Card> Cards { get; }
    void Shuffle();
  }
}