using System.Collections.Immutable;

namespace BlackjackGameLibrary.PlayingCards
{
  public interface ICardSuit
  {
    ECardSuitTypes SuitType { get; }

    IImmutableList<Card> Cards { get; }

    void Shuffle();
  }
}