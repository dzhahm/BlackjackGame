using BlackjackGameLibrary.Game;
using BlackjackGameLibrary.PlayingCards;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace BlackjackGameLibrary.UnitTests.Game
{
  [TestClass]
  public class CardShuffling
  {
    [TestMethod]
    public void CardsAreCorrectlyShuffled()
    {
      //Arrange
      int numberOfCardDecks = 6;
      IBlackjackGame game;

      //Act
      game = new BlackjackGame(numberOfCardDecks, 3);
      game.ShuffleCards();
      int numberOfDisplacedCards = CalculateDisplacedNumberOfCards(numberOfCardDecks, game.PlayingCards);
      //Assert
      if (numberOfDisplacedCards < game.PlayingCards.Count / 2)
      {
        string errorMessage = $"Minimum accepted number of displaced cards is {game.PlayingCards.Count / 2}. Actual number of displaced cards is {numberOfDisplacedCards}.";
        Assert.Fail(errorMessage);
      }
    }

    private int CalculateDisplacedNumberOfCards(int numberOfCardDecks, List<Card> cards)
    {
      int numberOfNotMatchingCards = 0;
      List<Card> tempCardList = new List<Card>();
      for (int i = 0; i < numberOfCardDecks; i++)
      {
        tempCardList.AddRange(new CardDeck().Cards);
      }

      for (int i = 0; i < tempCardList.Count; i++)
      {
        if (!tempCardList[i].IsEqual(cards[i]))
        {
          numberOfNotMatchingCards++;
        }
      }

      return numberOfNotMatchingCards;
    }
  }
}