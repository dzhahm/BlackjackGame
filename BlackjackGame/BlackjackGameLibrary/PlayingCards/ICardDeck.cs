using System.Collections.Immutable;

namespace BlackjackGameLibrary.PlayingCards
{
  public interface ICardDeck
  {
    IImmutableList<Card> Cards { get; }
    void Shuffle();
  }
}