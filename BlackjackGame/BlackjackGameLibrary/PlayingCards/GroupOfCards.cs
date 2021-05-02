using BlackjackGameLibrary.Tools;
using System.Collections.Generic;


namespace BlackjackGameLibrary.PlayingCards
{
  public abstract class GroupOfCards
  {
    protected List<Card> _cards;

    public List<Card> CloneCards()
    {
      List<Card> tempCards = new List<Card>();
      foreach (Card card in _cards)
      {
        tempCards.Add(card.Clone());
      }

      return tempCards;
    }

    public void Shuffle()
    {
      new ShuffleAlgorithm().Shuffle(ref _cards);
    }
  }
}