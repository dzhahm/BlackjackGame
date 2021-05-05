using BlackjackGameLibrary.Game;
using BlackjackGameLibrary.Game.Round;
using BlackjackGameLibrary.PlayingCards;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
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
      int numberOfPlayerOneCards = _blackjackGameRound.PlayerCards[EPlayers.Player1].Count;

      //Act
      _blackjackGameRound.ProcessPlayerCall(EPlayers.Player1, playerCall);
      int numberOfPlayerOneCardsAfterHit = _blackjackGameRound.PlayerCards[EPlayers.Player1].Count;

      //Assert
      if (numberOfPlayerOneCards != 2 || numberOfPlayerOneCardsAfterHit != 3)
      {
        string errorMessage = Environment.NewLine + "Player one does not have expected number of cards before and after the hit call. " + Environment.NewLine +
                              $"Expected number of cards before the hit call is {2}, actual number of cards before the hit call is {numberOfPlayerOneCards}" + Environment.NewLine +
                              $"Expected number of cards after the hit call is {3}, actual number of cards after the hit call is {numberOfPlayerOneCardsAfterHit}";
        Assert.Fail(errorMessage);
      }
    }

    [TestMethod]
    public void PlayerIsAbleToMakeStandCall()
    {
      //Arrange
      ERoundCalls playerCall = ERoundCalls.Stand;
      int numberOfPlayerOneCards = _blackjackGameRound.PlayerCards[EPlayers.Player1].Count;

      //Act
      _blackjackGameRound.ProcessPlayerCall(EPlayers.Player1, playerCall);
      int numberOfPlayerOneCardsAfterStand = _blackjackGameRound.PlayerCards[EPlayers.Player1].Count;

      //Assert
      if (numberOfPlayerOneCards != 2 || numberOfPlayerOneCardsAfterStand != 2)
      {
        string errorMessage = Environment.NewLine + "Player one does not have expected number of cards before and after the stand call. " + Environment.NewLine +
                              $"Expected number of cards before the stand call is {2}, actual number of cards before the stand call is {numberOfPlayerOneCards}" + Environment.NewLine +
                              $"Expected number of cards after the stand call is {2}, actual number of cards after the stand call is {numberOfPlayerOneCardsAfterStand}";
        Assert.Fail(errorMessage);
      }
    }

    [TestMethod]
    public void UserIsNotAllowedToMakeCallsAfterExceedingTwentyOne()
    {
      //Arrange
      while (_blackjackGameRound.PlayersSumOfCards[EPlayers.Player1] < 21)
      {
        _blackjackGameRound.ProcessPlayerCall(EPlayers.Player1, ERoundCalls.Hit);
      }

      //Act
      EPlayerRoundState callStateBeforeActCall = _blackjackGameRound.PlayerRoundStates[EPlayers.Player1];
      _blackjackGameRound.ProcessPlayerCall(EPlayers.Player1, ERoundCalls.Hit);
      EPlayerRoundState callStateAfterActCall = _blackjackGameRound.PlayerRoundStates[EPlayers.Player1];

      //Assert
      if (callStateAfterActCall != EPlayerRoundState.ExceededTwentyOne || callStateBeforeActCall != EPlayerRoundState.ExceededTwentyOne)
      {
        string errorMessage =
          "After exceeding 21, user shall automatically fail and latest call state of player is set to Stand. However, here after exceeding 21 player latest call state is not set to Stand";
        Assert.Fail(errorMessage);
      }
    }

    [TestMethod]
    public void SinglePlayerCanContinueMakingCallsAfterOtherPlayersExceedTwentyOne()
    {
      //Arrange
      while (_blackjackGameRound.PlayersSumOfCards[EPlayers.Player1] < 21)
      {
        _blackjackGameRound.ProcessPlayerCall(EPlayers.Player1, ERoundCalls.Hit);
      }

      while (_blackjackGameRound.PlayersSumOfCards[EPlayers.Player2] < 21)
      {
        _blackjackGameRound.ProcessPlayerCall(EPlayers.Player2, ERoundCalls.Hit);
      }

      ERoundCalls playerCall = ERoundCalls.Hit;
      int numberOfPlayerThreesCards = _blackjackGameRound.PlayerCards[EPlayers.Player3].Count;

      //Act
      _blackjackGameRound.ProcessPlayerCall(EPlayers.Player3, playerCall);
      int numberOfPlayerThreesCardsAfterHit = _blackjackGameRound.PlayerCards[EPlayers.Player3].Count;

      //Assert
      if (numberOfPlayerThreesCards != 2 || numberOfPlayerThreesCardsAfterHit != 3)
      {
        string errorMessage = Environment.NewLine + "Player three does not have expected number of cards before and after the hit call. " + Environment.NewLine +
                              $"Expected number of cards before the hit call is {2}, actual number of cards before the hit call is {numberOfPlayerThreesCards}." + Environment.NewLine +
                              $"Expected number of cards after the hit call is {3}, actual number of cards after the hit call is {numberOfPlayerThreesCardsAfterHit}.";
        Assert.Fail(errorMessage);
      }
    }
  }
}