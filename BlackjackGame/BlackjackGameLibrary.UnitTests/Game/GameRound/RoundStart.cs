using BlackjackGameLibrary.Game;
using BlackjackGameLibrary.Game.GameRound;
using BlackjackGameLibrary.PlayingCards;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace BlackjackGameLibrary.UnitTests.Game.GameRound
{
  [TestClass]
  public class RoundStart
  {
    private List<Card> _cards = new(new CardDeck().Cards);
    private int _numberOfPlayers = 3;

    [TestInitialize]
    public void Initialize()
    {
      _cards = new List<Card>(new CardDeck().Cards);
      _numberOfPlayers = 3;
    }


    [TestMethod]
    public void AllUsersHaveZeroCardsAtTheStart()
    {
      //Arrange
      IBlackjackGameRound gameRound;

      //Act
      gameRound = new BlackjackGameRound(ref _cards, _numberOfPlayers);
      int playerOneCards = gameRound.PlayerCards[EPlayers.Player1].Count;
      int playerTwoCards = gameRound.PlayerCards[EPlayers.Player2].Count;
      int playerThreeCards = gameRound.PlayerCards[EPlayers.Player3].Count;

      //Assert
      if (playerOneCards != 0 || playerTwoCards != 0 || playerThreeCards != 0)
      {
        string errorMessage = $"Players should have 0 cards at the round start. Actual number of cards for Player1 : {playerTwoCards} - Player2 : {playerTwoCards} - Player3 : {playerThreeCards}";
        Assert.Fail(errorMessage);
      }
    }


    [TestMethod]
    public void AllUsersHaveNoCallsAtTheStart()
    {
      //Arrange
      IBlackjackGameRound gameRound;

      //Act
      gameRound = new BlackjackGameRound(ref _cards, _numberOfPlayers);
      ERoundCalls playerOneCall = gameRound.PlayerCalls[EPlayers.Player1];
      ERoundCalls playerTwoCall = gameRound.PlayerCalls[EPlayers.Player2];
      ERoundCalls playerThreeCall = gameRound.PlayerCalls[EPlayers.Player3];

      //Assert
      if (playerOneCall != ERoundCalls.None || playerTwoCall != ERoundCalls.None || playerThreeCall != ERoundCalls.None)
      {
        string errorMessage = $"Players should have no calls at the round start. Actual player calls - Player1 : {playerOneCall} - Player2 : {playerTwoCall} - Player3 : {playerThreeCall}";
        Assert.Fail(errorMessage);
      }
    }
  }
}