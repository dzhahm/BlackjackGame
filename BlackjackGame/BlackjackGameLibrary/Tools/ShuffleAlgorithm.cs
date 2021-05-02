using BlackjackGameLibrary.PlayingCards;
using System;
using System.Collections.Generic;

namespace BlackjackGameLibrary.Tools
{
  public class ShuffleAlgorithm
  {
    /// <summary>
    /// Fisher-Yates shuffle algorithm
    /// </summary>
    /// <param name="numberOfCardDecks"></param>
    /// <param name="cards"></param>
    public void Shuffle(int numberOfCardDecks, ref List<Card> cards)
    {
      List<Card> tempList = cards;
      Random random = new Random();
      int numberOfCards = tempList.Count;
      for (int i = 0; i < numberOfCards; i++)
      {
        int randomIndex = random.Next(0, numberOfCards);
        Card tempCard = tempList[randomIndex];
        tempList[randomIndex] = tempList[i];
        tempList[i] = tempCard;
      }

      if (CalculateNumberOfDisplacedCards(numberOfCardDecks, tempList) < tempList.Count / 2)
      {
        Shuffle(numberOfCardDecks, ref cards);
      }

      cards = tempList;
    }

    private int CalculateNumberOfDisplacedCards(int numberOfCardDecks, List<Card> shuffledCards)
    {
      int numberOfNotMatchingCards = 0;
      List<Card> tempCardList = new List<Card>();
      for (int i = 0; i < numberOfCardDecks; i++)
      {
        tempCardList.AddRange(new CardDeck().Cards);
      }

      for (int i = 0; i < tempCardList.Count; i++)
      {
        if (!tempCardList[i].IsEqual(shuffledCards[i]))
        {
          numberOfNotMatchingCards++;
        }
      }

      return numberOfNotMatchingCards;
    }
  }
}