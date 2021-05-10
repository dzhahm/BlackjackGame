using BlackjackGameLibrary.PlayingCards;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BlackjackGameLibrary.UnitTests.PlayingCards
{
  [TestClass]
  public class CardGeneration
  {
    [TestMethod]
    public void NumericalCardCanBeCreated()
    {
      //Act
      int value = 7;
      ECardSuitTypes cardSuitType = ECardSuitTypes.Spades;
      ECardType cardType = ECardType.Numerical;
      Card testCard;
      //Arrange
      testCard = new Card(value, cardSuitType, cardType);

      //Assert
      if (testCard.Value != value)
      {
        string errorMessage = $"Card is created with the wrong value. Expected card value is {value}. Actual card value is {testCard.Value}";
        Assert.Fail(errorMessage);
      }

      if (testCard.CardSuit != cardSuitType)
      {
        string errorMessage = $"Card is created with the wrong card suit type. Expected card suit type is {cardSuitType}. Actual card suit type is {testCard.CardSuit}";
        Assert.Fail(errorMessage);
      }

      if (testCard.CardType != cardType)
      {
        string errorMessage = $"Card is created with the wrong card type. Expected card type is {cardType}. Actual card suit type is {testCard.CardType}";
        Assert.Fail(errorMessage);
      }
    }

    [TestMethod]
    public void FaceCardJackCanBeCreated()
    {
      //Act
      int value = 10;
      ECardSuitTypes cardSuitType = ECardSuitTypes.Hearts;
      ECardType cardType = ECardType.Jack;
      Card testCard;
      //Arrange
      testCard = new FaceCard(cardSuitType, cardType);

      //Assert
      if (testCard.Value != value)
      {
        string errorMessage = $"Card is created with the wrong value. Expected card value is {value}. Actual card value is {testCard.Value}";
        Assert.Fail(errorMessage);
      }

      if (testCard.CardSuit != cardSuitType)
      {
        string errorMessage = $"Card is created with the wrong card suit type. Expected card suit type is {cardSuitType}. Actual card suit type is {testCard.CardSuit}";
        Assert.Fail(errorMessage);
      }

      if (testCard.CardType != cardType)
      {
        string errorMessage = $"Card is created with the wrong card type. Expected card type is {cardType}. Actual card suit type is {testCard.CardType}";
        Assert.Fail(errorMessage);
      }
    }

    [TestMethod]
    public void FaceCardQueenCanBeCreated()
    {
      //Act
      int value = 10;
      ECardSuitTypes cardSuitType = ECardSuitTypes.Clubs;
      ECardType cardType = ECardType.Queen;
      Card testCard;
      //Arrange
      testCard = new FaceCard(cardSuitType, cardType);

      //Assert
      if (testCard.Value != value)
      {
        string errorMessage = $"Card is created with the wrong value. Expected card value is {value}. Actual card value is {testCard.Value}";
        Assert.Fail(errorMessage);
      }

      if (testCard.CardSuit != cardSuitType)
      {
        string errorMessage = $"Card is created with the wrong card suit type. Expected card suit type is {cardSuitType}. Actual card suit type is {testCard.CardSuit}";
        Assert.Fail(errorMessage);
      }

      if (testCard.CardType != cardType)
      {
        string errorMessage = $"Card is created with the wrong card type. Expected card type is {cardType}. Actual card suit type is {testCard.CardType}";
        Assert.Fail(errorMessage);
      }
    }

    [TestMethod]
    public void FaceCardKingCanBeCreated()
    {
      //Act
      int value = 10;
      ECardSuitTypes cardSuitType = ECardSuitTypes.Diamonds;
      ECardType cardType = ECardType.King;
      Card testCard;
      //Arrange
      testCard = new FaceCard(cardSuitType, cardType);

      //Assert
      if (testCard.Value != value)
      {
        string errorMessage = $"Card is created with the wrong value. Expected card value is {value}. Actual card value is {testCard.Value}";
        Assert.Fail(errorMessage);
      }

      if (testCard.CardSuit != cardSuitType)
      {
        string errorMessage = $"Card is created with the wrong card suit type. Expected card suit type is {cardSuitType}. Actual card suit type is {testCard.CardSuit}";
        Assert.Fail(errorMessage);
      }

      if (testCard.CardType != cardType)
      {
        string errorMessage = $"Card is created with the wrong card type. Expected card type is {cardType}. Actual card suit type is {testCard.CardType}";
        Assert.Fail(errorMessage);
      }
    }

    [TestMethod]
    public void FaceCardWithModifiedValueCanBeCreated()
    {
      //Act
      int value = 5;
      ECardSuitTypes cardSuitType = ECardSuitTypes.Diamonds;
      ECardType cardType = ECardType.King;
      Card testCard;
      //Arrange
      testCard = new Card(value, cardSuitType, cardType);

      //Assert
      if (testCard.Value != value)
      {
        string errorMessage = $"Card is created with the wrong value. Expected card value is {value}. Actual card value is {testCard.Value}";
        Assert.Fail(errorMessage);
      }

      if (testCard.CardSuit != cardSuitType)
      {
        string errorMessage = $"Card is created with the wrong card suit type. Expected card suit type is {cardSuitType}. Actual card suit type is {testCard.CardSuit}";
        Assert.Fail(errorMessage);
      }

      if (testCard.CardType != cardType)
      {
        string errorMessage = $"Card is created with the wrong card type. Expected card type is {cardType}. Actual card suit type is {testCard.CardType}";
        Assert.Fail(errorMessage);
      }
    }

    [TestMethod]
    public void AceCardCanBeCreated()
    {
      //Act
      int value = 11;
      ECardSuitTypes cardSuitType = ECardSuitTypes.Spades;
      ECardType cardType = ECardType.Ace;
      Card testCard;
      //Arrange
      testCard = new AceCard(cardSuitType);

      //Assert
      if (testCard.Value != value)
      {
        string errorMessage = $"Card is created with the wrong value. Expected card value is {value}. Actual card value is {testCard.Value}";
        Assert.Fail(errorMessage);
      }

      if (testCard.CardSuit != cardSuitType)
      {
        string errorMessage = $"Card is created with the wrong card suit type. Expected card suit type is {cardSuitType}. Actual card suit type is {testCard.CardSuit}";
        Assert.Fail(errorMessage);
      }

      if (testCard.CardType != cardType)
      {
        string errorMessage = $"Card is created with the wrong card type. Expected card type is {cardType}. Actual card suit type is {testCard.CardType}";
        Assert.Fail(errorMessage);
      }
    }
  }
}