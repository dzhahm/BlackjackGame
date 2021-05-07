using BlackjackGameLibrary.Game;
using BlackjackGameLibrary.Game.Round;
using BlackjackGameLibrary.PlayingCards;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace BlackjackGameLibrary.UnitTests.Game.GameRound
{
  [TestClass]
  public class CardDeal
  {
    private List<Card> _cards;
    private int _numberOfPlayers;

    [TestInitialize]
    public void Initialize()
    {
      _cards = new(new CardDeck().Cards);
      _numberOfPlayers = 3;
    }

    [TestMethod]
    public void DealerGetsTwoCardsInTheDealRound()
    {
      //Arrange
      IBlackjackGameRound gameRound;

      //Act
      gameRound = new BlackjackGameRound(_cards, _numberOfPlayers);
      gameRound.DealCards();

      //Assert
      if (gameRound.DealersFirstPlayedCard.Value == 0 || gameRound.DealersSecondPlayedCard.Value == 0)
      {
        string errorMessage = $"Dealer should have 2 cards after the deal round, but it doesn't!";
        Assert.Fail(errorMessage);
      }
    }

    [TestMethod]
    public void DealersFirstCardIsClosedAfterCardDeal()
    {
    }

    [TestMethod]
    public void DealersSecondCardIsClosedAfterCardDeal()
    {
    }

    [TestMethod]
    public void PlayerGetsTwoCardsInTheDealRound()
    {
      //Arrange
      IBlackjackGameRound gameRound;
      int numberOfCardsPerPlayer = 2;

      //Act
      gameRound = new BlackjackGameRound(_cards, _numberOfPlayers);
      gameRound.DealCards();
      int playerOneCards = gameRound.PlayerCards[EPlayers.Player1].Count;
      int playerTwoCards = gameRound.PlayerCards[EPlayers.Player2].Count;
      int playerThreeCards = gameRound.PlayerCards[EPlayers.Player3].Count;

      //Assert
      if (playerOneCards != numberOfCardsPerPlayer || playerTwoCards != numberOfCardsPerPlayer || playerThreeCards != numberOfCardsPerPlayer)
      {
        string errorMessage = $"Players should have 2 cards after the deal round. Actual number of cards for Player1 : {playerTwoCards} - Player2 : {playerTwoCards} - Player3 : {playerThreeCards}";
        Assert.Fail(errorMessage);
      }
    }
  }
}