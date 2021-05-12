using BlackjackGameLibrary.Game;
using BlackjackGameLibrary.Game.Round;
using BlackjackGameLibrary.Game.Round.Enums;
using BlackjackGameLibrary.PlayingCards;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace BlackjackGameLibrary.UnitTests.Game.GameRound
{
  [TestClass]
  public class RoundScenariosAfterAllPlayersCallStand
  {
    #region Scenario One

    private List<Card> CardsForScenarioOne()
    {
      List<Card> cardsForRound = new();

      #region FirstCard

      //Player one first card
      cardsForRound.Add(new NumericalCard(7, ECardSuitTypes.Hearts));
      //Player two first card
      cardsForRound.Add(new FaceCard(ECardSuitTypes.Diamonds, ECardType.Jack));
      //Player three first card
      cardsForRound.Add(new NumericalCard(2, ECardSuitTypes.Diamonds));
      //Dealers first card
      cardsForRound.Add(new NumericalCard(5, ECardSuitTypes.Clubs));

      #endregion

      #region SecondCard

      //Player one second card
      cardsForRound.Add(new FaceCard(ECardSuitTypes.Spades, ECardType.Queen));
      //Player two second card
      cardsForRound.Add(new FaceCard(ECardSuitTypes.Hearts, ECardType.Jack));
      //Player three second card
      cardsForRound.Add(new NumericalCard(4, ECardSuitTypes.Spades));
      //Dealers second card
      cardsForRound.Add(new NumericalCard(9, ECardSuitTypes.Clubs));

      #endregion

      #region ThirdCard

      //Player three third card
      cardsForRound.Add(new NumericalCard(9, ECardSuitTypes.Diamonds));

      #endregion

      //Player one's cards : Hearts 7, Queens of Spades => Sum is 17
      //Player two's cards : Jack of Diamonds, Jack of Hearts => Sum is 20
      //Player three's cards : Diamonds 2, Spades 4, Diamonds 9 => Sum is 15
      //Dealers' cards : Clubs 5, Clubs 9 => Sum is 14

      return cardsForRound;
    }

    [TestMethod]
    public void ScenarioOne_PlayerCardsSummedCorrectly()
    {
      //Arrange
      int numberOfPlayers = 3;
      List<Card> cardsForRound = CardsForScenarioOne();

      //Player one's cards : Hearts 7, Queens of Spades => Sum is 17
      //Player two's cards : Jack of Diamonds, Jack of Hearts => Sum is 20
      //Player three's cards : Diamonds 2, Spades 4, Diamonds 9 => Sum is 15
      //Dealers' cards : Clubs 5, Clubs 9 => Sum is 14

      //Act
      IBlackjackGameRound gameRound = new BlackjackGameRound(cardsForRound, numberOfPlayers);
      gameRound.DealCards();

      gameRound.PlayerCall(EPlayers.Player1, ERoundCalls.Stand);
      gameRound.PlayerCall(EPlayers.Player2, ERoundCalls.Stand);
      gameRound.PlayerCall(EPlayers.Player3, ERoundCalls.Hit);
      gameRound.PlayerCall(EPlayers.Player3, ERoundCalls.Stand);

      gameRound.FinalizeRoundResults();

      //Assert
      if (gameRound.PlayersSumOfCards[EPlayers.Player1] != 17)
      {
        Assert.Fail();
      }

      if (gameRound.PlayersSumOfCards[EPlayers.Player2] != 20)
      {
        Assert.Fail();
      }

      if (gameRound.PlayersSumOfCards[EPlayers.Player3] != 15)
      {
        Assert.Fail();
      }

      if (gameRound.PlayersSumOfCards[EPlayers.Dealer] != 14)
      {
        Assert.Fail();
      }
    }

    [TestMethod]
    public void ScenarioOne_PlayerWinsIfCardsSumIsBiggerThanDealers()
    {
      //Arrange
      int numberOfPlayers = 3;
      List<Card> cardsForRound = CardsForScenarioOne();

      //Player one's cards : Hearts 7, Queens of Spades => Sum is 17
      //Player two's cards : Jack of Diamonds, Jack of Hearts => Sum is 20
      //Player three's cards : Diamonds 2, Spades 4, Diamonds 9 => Sum is 15
      //Dealers' cards : Clubs 5, Clubs 9 => Sum is 14


      //Act
      IBlackjackGameRound gameRound = new BlackjackGameRound(cardsForRound, numberOfPlayers);
      gameRound.DealCards();

      gameRound.PlayerCall(EPlayers.Player1, ERoundCalls.Stand);
      gameRound.PlayerCall(EPlayers.Player2, ERoundCalls.Stand);
      gameRound.PlayerCall(EPlayers.Player3, ERoundCalls.Hit);
      gameRound.PlayerCall(EPlayers.Player3, ERoundCalls.Stand);

      gameRound.FinalizeRoundResults();

      //Assert
      if (gameRound.PlayerResults[EPlayers.Player1] != ERoundResult.PlayerWins)
      {
        Assert.Fail();
      }

      if (gameRound.PlayerResults[EPlayers.Player2] != ERoundResult.PlayerWins)
      {
        Assert.Fail();
      }

      if (gameRound.PlayerResults[EPlayers.Player3] != ERoundResult.PlayerWins)
      {
        Assert.Fail();
      }
    }

    #endregion

    #region Scenario Two

    private List<Card> CardsForScenarioTwo()
    {
      List<Card> cardsForRound = new();

      #region FirstCard

      //Player one first card
      cardsForRound.Add(new NumericalCard(2, ECardSuitTypes.Clubs));
      //Player two first card
      cardsForRound.Add(new NumericalCard(4, ECardSuitTypes.Spades));
      //Player three first card
      cardsForRound.Add(new FaceCard(ECardSuitTypes.Diamonds, ECardType.King));
      //Dealers first card
      cardsForRound.Add(new NumericalCard(8, ECardSuitTypes.Diamonds));

      #endregion

      #region SecondCard

      //Player one second card
      cardsForRound.Add(new NumericalCard(3, ECardSuitTypes.Spades));
      //Player two second card
      cardsForRound.Add(new FaceCard(ECardSuitTypes.Diamonds, ECardType.Jack));
      //Player three second card
      cardsForRound.Add(new NumericalCard(2, ECardSuitTypes.Spades));
      //Dealers second card
      cardsForRound.Add(new FaceCard(ECardSuitTypes.Spades, ECardType.King));

      #endregion

      #region ThirdCard

      //Player one third card
      cardsForRound.Add(new NumericalCard(7, ECardSuitTypes.Diamonds));
      //Player three third card
      cardsForRound.Add(new NumericalCard(5, ECardSuitTypes.Clubs));

      #endregion

      //Player one's cards : Clubs 2, Spades 3, Diamonds 7  => Sum is 12
      //Player two's cards : Spades 4, Jack of Diamonds => Sum is 14
      //Player three's cards : King of Diamonds, Spades 2, Clubs 5 => Sum is 17
      //Dealers' cards : Diamonds 8, King of Spades => Sum is 18

      return cardsForRound;
    }

    [TestMethod]
    public void ScenarioTwo_PlayerCardsSummedCorrectly()
    {
      //Arrange
      int numberOfPlayers = 3;
      List<Card> cardsForRound = CardsForScenarioTwo();
      //Player one's cards : Clubs 2, Spades 3, Diamonds 7  => Sum is 12
      //Player two's cards : Spades 4, Jack of Diamonds => Sum is 14
      //Player three's cards : King of Diamonds, Spades 2, Clubs 5 => Sum is 17
      //Dealers' cards : Diamonds 8, King of Spades => Sum is 18

      //Act
      IBlackjackGameRound gameRound = new BlackjackGameRound(cardsForRound, numberOfPlayers);
      gameRound.DealCards();

      gameRound.PlayerCall(EPlayers.Player1, ERoundCalls.Hit);
      gameRound.PlayerCall(EPlayers.Player1, ERoundCalls.Stand);
      gameRound.PlayerCall(EPlayers.Player2, ERoundCalls.Stand);
      gameRound.PlayerCall(EPlayers.Player3, ERoundCalls.Hit);
      gameRound.PlayerCall(EPlayers.Player3, ERoundCalls.Stand);

      gameRound.FinalizeRoundResults();

      //Assert
      if (gameRound.PlayersSumOfCards[EPlayers.Player1] != 12)
      {
        Assert.Fail();
      }

      if (gameRound.PlayersSumOfCards[EPlayers.Player2] != 14)
      {
        Assert.Fail();
      }

      if (gameRound.PlayersSumOfCards[EPlayers.Player3] != 17)
      {
        Assert.Fail();
      }

      if (gameRound.PlayersSumOfCards[EPlayers.Dealer] != 18)
      {
        Assert.Fail();
      }
    }

    [TestMethod]
    public void ScenarioTwo_PlayerLosesIfCardsSumIsLessThanDealers()
    {
      //Arrange
      int numberOfPlayers = 3;
      List<Card> cardsForRound = CardsForScenarioTwo();
      //Player one's cards : Clubs 2, Spades 3, Diamonds 7  => Sum is 12
      //Player two's cards : Spades 4, Jack of Diamonds => Sum is 14
      //Player three's cards : King of Diamonds, Spades 2, Clubs 5 => Sum is 17
      //Dealers' cards : Diamonds 8, King of Spades => Sum is 18

      //Act
      IBlackjackGameRound gameRound = new BlackjackGameRound(cardsForRound, numberOfPlayers);
      gameRound.DealCards();

      gameRound.PlayerCall(EPlayers.Player1, ERoundCalls.Hit);
      gameRound.PlayerCall(EPlayers.Player1, ERoundCalls.Stand);
      gameRound.PlayerCall(EPlayers.Player2, ERoundCalls.Stand);
      gameRound.PlayerCall(EPlayers.Player3, ERoundCalls.Hit);
      gameRound.PlayerCall(EPlayers.Player3, ERoundCalls.Stand);

      gameRound.FinalizeRoundResults();

      //Assert
      if (gameRound.PlayerResults[EPlayers.Player1] != ERoundResult.DealerWins)
      {
        Assert.Fail();
      }

      if (gameRound.PlayerResults[EPlayers.Player2] != ERoundResult.DealerWins)
      {
        Assert.Fail();
      }

      if (gameRound.PlayerResults[EPlayers.Player3] != ERoundResult.DealerWins)
      {
        Assert.Fail();
      }
    }

    #endregion

    #region Scenario Three

    private List<Card> CardsForScenarioThree()
    {
      List<Card> cardsForRound = new();

      #region FirstCard

      //Player one first card
      cardsForRound.Add(new NumericalCard(6, ECardSuitTypes.Clubs));
      //Player two first card
      cardsForRound.Add(new NumericalCard(10, ECardSuitTypes.Diamonds));
      //Player three first card
      cardsForRound.Add(new NumericalCard(3, ECardSuitTypes.Diamonds));
      //Dealers first card
      cardsForRound.Add(new AceCard(ECardSuitTypes.Spades));

      #endregion

      #region SecondCard

      //Player one second card
      cardsForRound.Add(new FaceCard(ECardSuitTypes.Spades, ECardType.Queen));
      //Player two second card
      cardsForRound.Add(new FaceCard(ECardSuitTypes.Hearts, ECardType.Jack));
      //Player three second card
      cardsForRound.Add(new NumericalCard(2, ECardSuitTypes.Clubs));
      //Dealers second card
      cardsForRound.Add(new NumericalCard(9, ECardSuitTypes.Hearts));

      #endregion

      #region ThirdCard

      //Player one third card
      cardsForRound.Add(new NumericalCard(5, ECardSuitTypes.Hearts));
      //Player three third card
      cardsForRound.Add(new NumericalCard(9, ECardSuitTypes.Diamonds));

      #endregion

      //Player one's cards : Clubs 6, Spades 10, Hearts 5 => Sum is 21
      //Player two's cards : Diamonds 10, Jack of Hearts => Sum is 20
      //Player three's cards : Diamonds 3, Clubs 2, Diamonds 9 => Sum is 14
      //Dealers' cards : Ace of Spades, Hearts 9 => Sum is 20

      return cardsForRound;
    }

    [TestMethod]
    public void ScenarioThree_PlayerCardsSummedCorrectly()
    {
      //Arrange
      int numberOfPlayers = 3;
      List<Card> cardsForRound = CardsForScenarioThree();

      //Player one's cards : Clubs 6, Spades 10, Hearts 5 => Sum is 21
      //Player two's cards : Diamonds 10, Jack of Hearts => Sum is 20
      //Player three's cards : Diamonds 3, Clubs 2, Diamonds 9 => Sum is 14
      //Dealers' cards : Ace of Spades, Hearts 9 => Sum is 20

      //Act
      IBlackjackGameRound gameRound = new BlackjackGameRound(cardsForRound, numberOfPlayers);
      gameRound.DealCards();

      gameRound.PlayerCall(EPlayers.Player1, ERoundCalls.Hit);
      gameRound.PlayerCall(EPlayers.Player1, ERoundCalls.Stand);
      gameRound.PlayerCall(EPlayers.Player2, ERoundCalls.Stand);
      gameRound.PlayerCall(EPlayers.Player3, ERoundCalls.Hit);
      gameRound.PlayerCall(EPlayers.Player3, ERoundCalls.Stand);

      gameRound.FinalizeRoundResults();

      //Assert
      if (gameRound.PlayersSumOfCards[EPlayers.Player1] != 21)
      {
        Assert.Fail();
      }

      if (gameRound.PlayersSumOfCards[EPlayers.Player2] != 20)
      {
        Assert.Fail();
      }

      if (gameRound.PlayersSumOfCards[EPlayers.Player3] != 14)
      {
        Assert.Fail();
      }

      if (gameRound.PlayersSumOfCards[EPlayers.Dealer] != 20)
      {
        Assert.Fail();
      }
    }

    [TestMethod]
    public void ScenarioThree_PlayersHaveDifferentResults()
    {
      //Arrange
      int numberOfPlayers = 3;
      List<Card> cardsForRound = CardsForScenarioThree();

      //Player one's cards : Clubs 6, Spades 10, Hearts 5 => Sum is 21
      //Player two's cards : Diamonds 10, Jack of Hearts => Sum is 20
      //Player three's cards : Diamonds 3, Clubs 2, Diamonds 9 => Sum is 14
      //Dealers' cards : Ace of Spades, Hearts 9 => Sum is 20

      //Act
      IBlackjackGameRound gameRound = new BlackjackGameRound(cardsForRound, numberOfPlayers);
      gameRound.DealCards();

      gameRound.PlayerCall(EPlayers.Player1, ERoundCalls.Hit);
      gameRound.PlayerCall(EPlayers.Player1, ERoundCalls.Stand);
      gameRound.PlayerCall(EPlayers.Player2, ERoundCalls.Stand);
      gameRound.PlayerCall(EPlayers.Player3, ERoundCalls.Hit);
      gameRound.PlayerCall(EPlayers.Player3, ERoundCalls.Stand);

      gameRound.FinalizeRoundResults();

      //Assert
      if (gameRound.PlayerResults[EPlayers.Player1] != ERoundResult.PlayerWins)
      {
        Assert.Fail();
      }

      if (gameRound.PlayerResults[EPlayers.Player2] != ERoundResult.Push)
      {
        Assert.Fail();
      }

      if (gameRound.PlayerResults[EPlayers.Player3] != ERoundResult.DealerWins)
      {
        Assert.Fail();
      }
    }

    #endregion

    #region Scenario Four

    private List<Card> CardsForScenarioFour()
    {
      List<Card> cardsForRound = new();

      #region FirstCard

      //Player one first card
      cardsForRound.Add(new AceCard(ECardSuitTypes.Clubs));
      //Player two first card
      cardsForRound.Add(new AceCard(ECardSuitTypes.Diamonds));
      //Player three first card
      cardsForRound.Add(new NumericalCard(3, ECardSuitTypes.Diamonds));
      //Dealers first card
      cardsForRound.Add(new NumericalCard(8, ECardSuitTypes.Hearts));

      #endregion

      #region SecondCard

      //Player one second card
      cardsForRound.Add(new AceCard(ECardSuitTypes.Clubs));
      //Player two second card
      cardsForRound.Add(new NumericalCard(4, ECardSuitTypes.Hearts));
      //Player three second card
      cardsForRound.Add(new NumericalCard(2, ECardSuitTypes.Clubs));
      //Dealers second card
      cardsForRound.Add(new NumericalCard(9, ECardSuitTypes.Hearts));

      #endregion

      #region ThirdCard

      //Player one third card
      cardsForRound.Add(new NumericalCard(7, ECardSuitTypes.Spades));
      //Player two third card
      cardsForRound.Add(new AceCard(ECardSuitTypes.Hearts));
      //Player three third card
      cardsForRound.Add(new NumericalCard(9, ECardSuitTypes.Diamonds));

      #endregion


      //Player one's cards : Ace of Clubs, Ace of Clubs, Spades 7 => Sum is 11 + 1 + 7 = 19
      //Player two's cards : Ace of Diamonds, Hearts 4, Ace of Hearts => Sum is 11 + 4 + 1 = 16
      //Player three's cards : Diamonds 3, Clubs 2, Diamonds 9 => Sum is 14
      //Dealers' cards : Hearts 8, Hearts 9 => Sum is 17

      return cardsForRound;
    }

    [TestMethod]
    public void ScenarioFour_PlayerCardsSummedCorrectly()
    {
      //Arrange
      int numberOfPlayers = 3;
      List<Card> cardsForRound = CardsForScenarioFour();

      //Player one's cards : Ace of Clubs, Ace of Clubs, Spades 7 => Sum is 11 + 1 + 7 = 19
      //Player two's cards : Ace of Diamonds, Hearts 4, Ace of Hearts => Sum is 11 + 4 + 1 = 16
      //Player three's cards : Diamonds 3, Clubs 2, Diamonds 9 => Sum is 14
      //Dealers' cards : Hearts 8, Hearts 9 => Sum is 17

      //Act
      IBlackjackGameRound gameRound = new BlackjackGameRound(cardsForRound, numberOfPlayers);
      gameRound.DealCards();

      gameRound.PlayerCall(EPlayers.Player1, ERoundCalls.Hit);
      gameRound.PlayerCall(EPlayers.Player1, ERoundCalls.Stand);
      gameRound.PlayerCall(EPlayers.Player2, ERoundCalls.Hit);
      gameRound.PlayerCall(EPlayers.Player2, ERoundCalls.Stand);
      gameRound.PlayerCall(EPlayers.Player3, ERoundCalls.Hit);
      gameRound.PlayerCall(EPlayers.Player3, ERoundCalls.Stand);

      gameRound.FinalizeRoundResults();

      //Assert
      if (gameRound.PlayersSumOfCards[EPlayers.Player1] != 19)
      {
        Assert.Fail();
      }

      if (gameRound.PlayersSumOfCards[EPlayers.Player2] != 16)
      {
        Assert.Fail();
      }

      if (gameRound.PlayersSumOfCards[EPlayers.Player3] != 14)
      {
        Assert.Fail();
      }

      if (gameRound.PlayersSumOfCards[EPlayers.Dealer] != 17)
      {
        Assert.Fail();
      }
    }

    [TestMethod]
    public void ScenarioFour_PlayersHaveDifferentResults()
    {
      //Arrange
      int numberOfPlayers = 3;
      List<Card> cardsForRound = CardsForScenarioFour();

      //Player one's cards : Ace of Clubs, Ace of Clubs, Spades 7 => Sum is 11 + 1 + 7 = 19
      //Player two's cards : Ace of Diamonds, Hearts 4, Ace of Hearts => Sum is 11 + 4 + 1 = 16
      //Player three's cards : Diamonds 3, Clubs 2, Diamonds 9 => Sum is 14
      //Dealers' cards : Hearts 8, Hearts 9 => Sum is 17

      //Act
      IBlackjackGameRound gameRound = new BlackjackGameRound(cardsForRound, numberOfPlayers);
      gameRound.DealCards();

      gameRound.PlayerCall(EPlayers.Player1, ERoundCalls.Hit);
      gameRound.PlayerCall(EPlayers.Player1, ERoundCalls.Stand);
      gameRound.PlayerCall(EPlayers.Player2, ERoundCalls.Hit);
      gameRound.PlayerCall(EPlayers.Player2, ERoundCalls.Stand);
      gameRound.PlayerCall(EPlayers.Player3, ERoundCalls.Hit);
      gameRound.PlayerCall(EPlayers.Player3, ERoundCalls.Stand);

      gameRound.FinalizeRoundResults();

      //Assert
      if (gameRound.PlayerResults[EPlayers.Player1] != ERoundResult.PlayerWins)
      {
        Assert.Fail();
      }

      if (gameRound.PlayerResults[EPlayers.Player2] != ERoundResult.DealerWins)
      {
        Assert.Fail();
      }

      if (gameRound.PlayerResults[EPlayers.Player3] != ERoundResult.DealerWins)
      {
        Assert.Fail();
      }
    }

    #endregion
  }
}