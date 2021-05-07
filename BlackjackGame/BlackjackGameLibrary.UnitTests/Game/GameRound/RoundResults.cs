using BlackjackGameLibrary.Game;
using BlackjackGameLibrary.Game.Round;
using BlackjackGameLibrary.Game.Round.Enums;
using BlackjackGameLibrary.PlayingCards;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

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
  }
}