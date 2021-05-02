using BlackjackGameLibrary.PlayingCards;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BlackjackGameLibrary.Tools
{
  public class ShuffleAlgorithm
  {
    /// <summary>
    /// Fisher-Yates shuffle algorithm
    /// </summary>
    /// <param name="cards"></param>
    public void Shuffle(ref List<Card> cards)
    {
      List<Card> tempList = new();
      tempList.AddRange(cards.Select(c => c.Clone()));
      Random random = new();
      int numberOfCards = tempList.Count;
      for (int i = 0; i < numberOfCards; i++)
      {
        int randomIndex = random.Next(0, numberOfCards);
        Card tempCard = tempList[randomIndex];
        tempList[randomIndex] = tempList[i];
        tempList[i] = tempCard;
      }

      if (CalculateNumberOfDisplacedCards(tempList, cards) < tempList.Count / 2)
      {
        Shuffle(ref cards);
      }

      cards = tempList;
    }

    private int CalculateNumberOfDisplacedCards(List<Card> shuffledCards, List<Card> originalCardList)
    {
      return originalCardList.Where((t, i) => !t.IsEqual(shuffledCards[i])).Count();
    }
  }
}