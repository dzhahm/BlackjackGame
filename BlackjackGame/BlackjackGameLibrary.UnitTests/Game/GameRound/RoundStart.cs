using BlackjackGameLibrary.Game;
using BlackjackGameLibrary.Game.Round;
using BlackjackGameLibrary.Game.Round.Enums;
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
      gameRound = new BlackjackGameRound(_cards, _numberOfPlayers);
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
      gameRound = new BlackjackGameRound(_cards, _numberOfPlayers);
      EPlayerRoundState playerOneCall = gameRound.PlayerRoundStates[EPlayers.Player1];
      EPlayerRoundState playerTwoCall = gameRound.PlayerRoundStates[EPlayers.Player2];
      EPlayerRoundState playerThreeCall = gameRound.PlayerRoundStates[EPlayers.Player3];

      //Assert
      if (playerOneCall != EPlayerRoundState.None || playerTwoCall != EPlayerRoundState.None || playerThreeCall != EPlayerRoundState.None)
      {
        string errorMessage = $"Players should have no calls at the round start. Actual player calls - Player1 : {playerOneCall} - Player2 : {playerTwoCall} - Player3 : {playerThreeCall}";
        Assert.Fail(errorMessage);
      }
    }

    [TestMethod]
    public void AllUsersHaveNoRoundResultsAtTheStart()
    {
      //Arrange
      IBlackjackGameRound gameRound;

      //Act
      gameRound = new BlackjackGameRound(_cards, _numberOfPlayers);
      ERoundResult playerOneResult = gameRound.PlayerResults[EPlayers.Player1];
      ERoundResult playerTwoResult = gameRound.PlayerResults[EPlayers.Player2];
      ERoundResult playerThreeResult = gameRound.PlayerResults[EPlayers.Player3];

      //Assert
      if (playerOneResult != ERoundResult.None || playerTwoResult != ERoundResult.None || playerThreeResult != ERoundResult.None)
      {
        string errorMessage =
          $"Players should have no round results at the round start. Actual player round results - Player1 : {playerOneResult} - Player2 : {playerTwoResult} - Player3 : {playerThreeResult}";
        Assert.Fail(errorMessage);
      }
    }
  }
}