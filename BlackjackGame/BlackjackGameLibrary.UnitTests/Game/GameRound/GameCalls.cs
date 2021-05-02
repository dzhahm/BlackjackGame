using BlackjackGameLibrary.Game;
using BlackjackGameLibrary.Game.Round;
using BlackjackGameLibrary.PlayingCards;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace BlackjackGameLibrary.UnitTests.Game.GameRound
{
  [TestClass]
  public class GameCalls
  {
    private IBlackjackGameRound _blackjackGameRound;
    private int _numberOfCardDecks;
    private List<Card> _cards;
    private int _numberOfPlayers;


    [TestInitialize]
    public void Initialize()
    {
      _numberOfCardDecks = 6;
      _numberOfPlayers = 3;
      _cards = new List<Card>(new MultipleCardDecks(_numberOfCardDecks).Cards);
      _blackjackGameRound = new BlackjackGameRound(ref _cards, _numberOfPlayers);
      _blackjackGameRound.DealCards();
    }

    [TestMethod]
    public void PlayerIsAbleToMakeHitCall()
    {
      //Arrange
      ERoundCalls playerCall = ERoundCalls.Hit;
      ERoundCalls actualCall = _blackjackGameRound.PlayerCalls[EPlayers.Player1];
      int numberOfPlayerOneCards = _blackjackGameRound.PlayerCards[EPlayers.Player1].Count;

      //Act
      _blackjackGameRound.UpdatePlayersCall(EPlayers.Player1, playerCall);
      int numberOfPlayerOneCardsAfterHit = _blackjackGameRound.PlayerCards[EPlayers.Player1].Count;
      ERoundCalls actualCallAfterHit = _blackjackGameRound.PlayerCalls[EPlayers.Player1];

      //Assert
      if (numberOfPlayerOneCards != 2 || numberOfPlayerOneCardsAfterHit != 3)
      {
        string errorMessage = "Player one does not have expected number of cards before and after the hit call. " +
                              $"Expected number of cards before the hit call is {2}, actual number of cards before the hit call is {numberOfPlayerOneCards}" +
                              $"Expected number of cards after the hit call is {3}, actual number of cards after the hit call is {numberOfPlayerOneCardsAfterHit}";
        Assert.Fail(errorMessage);
      }

      if (actualCall != ERoundCalls.None || actualCallAfterHit != playerCall)
      {
        string errorMessage = "Player one does not have expected recorded calls before and after the hit call. " +
                              $"Expected recorded call before the hit call is {ERoundCalls.None}, actual recorded call before the hit call is {actualCall}" +
                              $"Expected recorded call after the hit call is {ERoundCalls.Hit}, actual recorded call after the hit call is {actualCallAfterHit}";
        Assert.Fail(errorMessage);
        Assert.Fail();
      }
    }

    [TestMethod]
    public void PlayerIsAbleToMakeStandCall()
    {
      //Arrange
      ERoundCalls playerCall = ERoundCalls.Stand;
      ERoundCalls actualCall = _blackjackGameRound.PlayerCalls[EPlayers.Player1];
      int numberOfPlayerOneCards = _blackjackGameRound.PlayerCards[EPlayers.Player1].Count;

      //Act
      _blackjackGameRound.UpdatePlayersCall(EPlayers.Player1, playerCall);
      int numberOfPlayerOneCardsAfterStand = _blackjackGameRound.PlayerCards[EPlayers.Player1].Count;
      ERoundCalls actualCallAfterStand = _blackjackGameRound.PlayerCalls[EPlayers.Player1];

      //Assert
      if (numberOfPlayerOneCards != 2 || numberOfPlayerOneCardsAfterStand != 2)
      {
        string errorMessage = "Player one does not have expected number of cards before and after the stand call. " +
                              $"Expected number of cards before the stand call is {2}, actual number of cards before the stand call is {numberOfPlayerOneCards}" +
                              $"Expected number of cards after the stand call is {2}, actual number of cards after the stand call is {numberOfPlayerOneCardsAfterStand}";
        Assert.Fail(errorMessage);
      }

      if (actualCall != ERoundCalls.None || actualCallAfterStand != playerCall)
      {
        string errorMessage = "Player one does not have expected recorded calls before and after the stand call. " +
                              $"Expected recorded call before the stand call is {ERoundCalls.None}, actual recorded call before the stand call is {actualCall}" +
                              $"Expected recorded call after the stand call is {ERoundCalls.Stand}, actual recorded call after the stand call is {actualCallAfterStand}";
        Assert.Fail(errorMessage);
        Assert.Fail();
      }
    }
  }
}