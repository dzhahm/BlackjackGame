using BlackjackGameLibrary.Game;
using BlackjackGameLibrary.Game.Round;
using BlackjackGameLibrary.Game.Round.Enums;
using BlackjackGameLibrary.PlayingCards;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace BlackjackGameLibrary.UnitTests.Game.GameRound
{
  [TestClass]
  public class RoundResults
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
      _cards = CardDeckWithFivesTensAndFaceCards();
      _blackjackGameRound = new BlackjackGameRound(_cards, _numberOfPlayers);
      _blackjackGameRound.DealCards();
    }

    private List<Card> CardDeckWithFivesTensAndFaceCards()
    {
      List<Card> tempCardsList = new(new MultipleCardDecks(_numberOfCardDecks).Cards);
      tempCardsList.RemoveAll(c => c.Value != 5 && c.Value != 10);
      return tempCardsList;
    }

    [TestMethod]
    public void PlayerLosesTheRoundAfterExceedingTwentyOne()
    {
      //Arrange
      while (_blackjackGameRound.PlayersSumOfCards[EPlayers.Player1] < 21)
      {
        _blackjackGameRound.PlayerCall(EPlayers.Player1, ERoundCalls.Hit);
      }

      //Act
      int playerOneSumOfCards = _blackjackGameRound.PlayersSumOfCards[EPlayers.Player1];
      ERoundResult playerOneRoundResult = _blackjackGameRound.PlayerResults[EPlayers.Player1];

      //Assert
      if (playerOneSumOfCards <= 21)
      {
        string errorMessage = $"Player one is excepted to have a card collection where the sum of card values exceed 21! Actual sum of player one's cards is: {playerOneSumOfCards}";
        Assert.Fail(errorMessage);
      }

      if (playerOneRoundResult != ERoundResult.DealerWins)
      {
        string errorMessage = $"Player one is excepted to have the round result {ERoundResult.DealerWins}! Actual round result of player one is: {playerOneRoundResult}";
        Assert.Fail(errorMessage);
      }
    }

    [TestMethod]
    public void DealersSecondCardIsOpenedIfAllPlayersStand()
    {
      //Arrange
      ERoundCalls playerCall = ERoundCalls.Stand;
      bool isDealersSecondCardOpenAfterDeal = _blackjackGameRound.DealersSecondPlayedCard.IsOpen;

      //Act
      foreach (EPlayers player in _blackjackGameRound.PlayerRoundStates.Keys)
      {
        _blackjackGameRound.PlayerCall(player, playerCall);
      }

      bool isDealersSecondCardOpenAfterAllPlayersStand = _blackjackGameRound.DealersSecondPlayedCard.IsOpen;

      //Assert
      if (isDealersSecondCardOpenAfterDeal)
      {
        string errorMessage = "Dealer's second card is expected to be closed after the deal session and before players start making calls. However, the card is open!";
        Assert.Fail(errorMessage);
      }

      if (_blackjackGameRound.PlayerRoundStates.Any(p => p.Value != EPlayerRoundState.Stand))
      {
        string errorMessage = $"All player round states are expected to be {EPlayerRoundState.Stand}. However, not all players have this round state!";
        Assert.Fail(errorMessage);
      }

      if (!isDealersSecondCardOpenAfterAllPlayersStand)
      {
        string errorMessage = "Dealer's second card is expected to be open after all players make a stand call. However, the card is closed!";
        Assert.Fail(errorMessage);
      }
    }

    [TestMethod]
    public void DealersSecondCardIsOpenedIfPlayerCallSessionsEndsWithAtLeastOneStandCall()
    {
      //Arrange
      ERoundCalls playerOneCall = ERoundCalls.Stand;
      ERoundCalls playerTwoCall = ERoundCalls.Stand;
      ERoundCalls playerThreeCall = ERoundCalls.Hit;
      bool isDealersSecondCardOpenAfterDeal = _blackjackGameRound.DealersSecondPlayedCard.IsOpen;

      //Act
      _blackjackGameRound.PlayerCall(EPlayers.Player1, playerOneCall);
      _blackjackGameRound.PlayerCall(EPlayers.Player2, playerTwoCall);

      while (_blackjackGameRound.PlayersSumOfCards[EPlayers.Player3] < 21)
      {
        _blackjackGameRound.PlayerCall(EPlayers.Player3, playerThreeCall);
      }

      bool isDealersSecondCardOpenAfterAtLeastOnePlayerStandAndOtherPlayersExceedTwentyOne = _blackjackGameRound.DealersSecondPlayedCard.IsOpen;


      //Assert
      if (isDealersSecondCardOpenAfterDeal)
      {
        string errorMessage = "Dealer's second card is expected to be closed after the deal session and before players start making calls. However, the card is open!";
        Assert.Fail(errorMessage);
      }

      if (_blackjackGameRound.PlayerRoundStates.Any(p => p.Value != EPlayerRoundState.Stand && p.Value != EPlayerRoundState.ExceededTwentyOne))
      {
        string errorMessage = $"All player round states are expected to be {EPlayerRoundState.Stand} or {EPlayerRoundState.ExceededTwentyOne}. However, not all players have these round state!";
        Assert.Fail(errorMessage);
      }

      if (!isDealersSecondCardOpenAfterAtLeastOnePlayerStandAndOtherPlayersExceedTwentyOne)
      {
        string errorMessage = "Dealer's second card is expected to be open after at least one player makes a stand call and other players exceed twenty one. However, the card is closed!";
        Assert.Fail(errorMessage);
      }
    }

    [TestMethod]
    public void DealersSecondCardIsNotOpenedIfAllPlayersExceedTwentyOne()
    {
      //Arrange
      ERoundCalls playerCall = ERoundCalls.Hit;
      bool isDealersSecondCardOpenAfterDeal = _blackjackGameRound.DealersSecondPlayedCard.IsOpen;

      //Act
      foreach (EPlayers player in _blackjackGameRound.PlayerRoundStates.Keys)
      {
        while (_blackjackGameRound.PlayersSumOfCards[player] < 21)
        {
          _blackjackGameRound.PlayerCall(player, playerCall);
        }
      }

      bool isDealersSecondCardOpenAfterAllPlayersStand = _blackjackGameRound.DealersSecondPlayedCard.IsOpen;

      //Assert
      if (isDealersSecondCardOpenAfterDeal)
      {
        string errorMessage = "Dealer's second card is expected to be closed after the deal session and before players start making calls. However, the card is open!";
        Assert.Fail(errorMessage);
      }

      if (_blackjackGameRound.PlayerRoundStates.Any(p => p.Value != EPlayerRoundState.ExceededTwentyOne))
      {
        string errorMessage = $"All player round states are expected to be {EPlayerRoundState.ExceededTwentyOne}. However, not all players have this round state!";
        Assert.Fail(errorMessage);
      }

      if (isDealersSecondCardOpenAfterAllPlayersStand)
      {
        string errorMessage = "Dealer's second card is expected to be closed after all players exceed twenty one. However, the card is open!";
        Assert.Fail(errorMessage);
      }
    }
  }
}