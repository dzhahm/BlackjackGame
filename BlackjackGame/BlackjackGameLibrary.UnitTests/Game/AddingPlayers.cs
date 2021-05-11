using BlackjackGameLibrary.Game;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BlackjackGameLibrary.UnitTests.Game
{
  [TestClass]
  public class AddingPlayers
  {
    [TestMethod]
    public void AddPlayer()
    {
      //Arrange
      string playerFirstName = "testUserOneFirstName";
      string playerLastName = "testUserOneLastName";
      int playerIdentifier = 1;
      EPlayers player = EPlayers.Player1;
      BlackjackGame testGame;

      //Act
      testGame = new BlackjackGame(6);
      Player testPlayerOne = new(playerFirstName, playerLastName, playerIdentifier);
      testGame.AddNewPlayer(testPlayerOne);

      //Assert
      if (testGame.Players[player].PlayerIdentifier != playerIdentifier)
      {
        string errorMessage = $"Added player does not have the expected identifier! Expected identifier : {playerIdentifier}. Actual identifier: {testGame.Players[EPlayers.Player1].PlayerIdentifier}";
        Assert.Fail(errorMessage);
      }

      //Assert
      if (testGame.Players[player].FirstName != playerFirstName)
      {
        string errorMessage = $"Added player does not have the expected first name! Expected first name : {playerIdentifier}. Actual first name: {testGame.Players[EPlayers.Player1].PlayerIdentifier}";
        Assert.Fail(errorMessage);
      }

      //Assert
      if (testGame.Players[player].LastName != playerLastName)
      {
        string errorMessage = $"Added player does not have the expected last name! Expected last name : {playerIdentifier}. Actual last name: {testGame.Players[EPlayers.Player1].PlayerIdentifier}";
        Assert.Fail(errorMessage);
      }
    }

    [TestMethod]
    public void ThreePlayersCanBeAdded()
    {
      //Arrange
      string playerOneFirstName = "testUserOneFirstName";
      string playerOneLastName = "testUserOneLastName";
      int playerOneIdentifier = 1;

      string playerTwoFirstName = "testUserTwoFirstName";
      string playerTwoLastName = "testUserTwoLastName";
      int playerTwoIdentifier = 10;

      string playerThreeFirstName = "testUserThreeFirstName";
      string playerThreeLastName = "testUserThreeLastName";
      int playerThreeIdentifier = 100;

      EPlayers playerOne = EPlayers.Player1;
      EPlayers playerTwo = EPlayers.Player2;
      EPlayers playerThree = EPlayers.Player3;
      BlackjackGame testGame;

      //Act
      testGame = new BlackjackGame(6);
      Player testPlayerOne = new(playerOneFirstName, playerOneLastName, playerOneIdentifier);
      Player testPlayerTwo = new(playerTwoFirstName, playerTwoLastName, playerTwoIdentifier);
      Player testPlayerThree = new(playerThreeFirstName, playerThreeLastName, playerThreeIdentifier);


      testGame.AddNewPlayer(testPlayerOne);
      testGame.AddNewPlayer(testPlayerTwo);
      testGame.AddNewPlayer(testPlayerThree);

      //Assert
      if (testGame.Players[playerOne].PlayerIdentifier != playerOneIdentifier || testGame.Players[playerOne].FirstName != playerOneFirstName ||
          testGame.Players[playerOne].LastName != playerOneLastName)
      {
        string errorMessage = $"Added player {playerOne} does not exist in the players list of the game!";
        Assert.Fail(errorMessage);
      }

      //Assert
      if (testGame.Players[playerTwo].PlayerIdentifier != playerTwoIdentifier || testGame.Players[playerTwo].FirstName != playerTwoFirstName ||
          testGame.Players[playerTwo].LastName != playerTwoLastName)
      {
        string errorMessage = $"Added player {playerTwo} does not exist in the players list of the game!";
        Assert.Fail(errorMessage);
      }

      //Assert
      if (testGame.Players[playerThree].PlayerIdentifier != playerThreeIdentifier || testGame.Players[playerThree].FirstName != playerThreeFirstName ||
          testGame.Players[playerThree].LastName != playerThreeLastName)
      {
        string errorMessage = $"Added player {playerThree} does not exist in the players list of the game!";
        Assert.Fail(errorMessage);
      }
    }
  }
}