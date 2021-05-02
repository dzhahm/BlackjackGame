using BlackjackGameLibrary.PlayingCards;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace BlackjackGameLibrary.UnitTests.PlayingCards
{
  [TestClass]
  public class CardDeckRulesDeserialization
  {
    [TestMethod]
    public void CardSuitTypesIsCorrectlyDeserialized()
    {
      //Arrange
      CardDeckConfiguration configuration;
      ECardSuitTypes[] cardSuitTypes =
      {
        ECardSuitTypes.Clubs,
        ECardSuitTypes.Diamonds,
        ECardSuitTypes.Hearts,
        ECardSuitTypes.Spades
      };

      //Act
      configuration = new CardDeckConfigurationProvider().GetRules();

      //Assert
      if (configuration.CardSuits.Count != cardSuitTypes.Length && !cardSuitTypes.All(t => configuration.CardSuits.Contains(t)))
      {
        string errorMessage = "Expected card suit types could not ne acquired from the configuration file!";
        Assert.Fail(errorMessage);
      }
    }

    [TestMethod]
    public void StandardNumberOfCardsInASuitIsCorrectlyDeserialized()
    {
      //Arrange
      CardDeckConfiguration configuration;
      int numberOfCardsInASuit = 13;

      //Act
      configuration = new CardDeckConfigurationProvider().GetRules();

      //Assert

      if (configuration.NumberOfCardsInASuit != numberOfCardsInASuit)
      {
        string errorMessage = $"The value acquired for the number of cards in a suit is wrong! Excepted value is: {numberOfCardsInASuit}. Acquired value is: {configuration.NumberOfCardsInASuit}";
        Assert.Fail(errorMessage);
      }
    }

    [TestMethod]
    public void StandardNumberOfNumericalCardsInASuitIsCorrectlyDeserialized()
    {
      //Arrange
      CardDeckConfiguration configuration;
      int numberOfNumericalCardsInASuit = 9;

      //Act
      configuration = new CardDeckConfigurationProvider().GetRules();

      //Assert
      if (configuration.NumberOfNumericalCardsInASuit != numberOfNumericalCardsInASuit)
      {
        string errorMessage =
          $"The value acquired for the number of numerical cards in a suit is wrong! Excepted value is: {numberOfNumericalCardsInASuit}. Acquired value is: {configuration.NumberOfNumericalCardsInASuit}";
        Assert.Fail(errorMessage);
      }
    }

    [TestMethod]
    public void StandardSmallestValueOfNumericalCardsIsCorrectlyDeserialized()
    {
      //Arrange
      CardDeckConfiguration configuration;
      int smallestValueOfNumericalCards = 2;

      //Act
      configuration = new CardDeckConfigurationProvider().GetRules();

      //Assert
      if (configuration.SmallestValueOfNumericalCards != smallestValueOfNumericalCards)
      {
        string errorMessage =
          $"The value acquired for the smallest value of numerical cards is wrong! Excepted value is: {smallestValueOfNumericalCards}. Acquired value is: {configuration.SmallestValueOfNumericalCards}";
        Assert.Fail(errorMessage);
      }
    }

    [TestMethod]
    public void StandardFaceCardValueIsCorrectlyDeserialized()
    {
      //Arrange
      CardDeckConfiguration configuration;
      int faceCardValue = 10;

      //Act
      configuration = new CardDeckConfigurationProvider().GetRules();

      //Assert
      if (configuration.FaceCardValue != faceCardValue)
      {
        string errorMessage = $"The value acquired for the face card value is wrong! Excepted value is: {faceCardValue}. Acquired value is: {configuration.FaceCardValue}";
        Assert.Fail(errorMessage);
      }
    }

    [TestMethod]
    public void StandardDefaultAceValueIsCorrectlyDeserialized()
    {
      //Arrange
      CardDeckConfiguration configuration;
      int defaultAceValue = 10;

      //Act
      configuration = new CardDeckConfigurationProvider().GetRules();

      //Assert
      if (configuration.DefaultAceValue != defaultAceValue)
      {
        string errorMessage = $"The value acquired for the default ace value is wrong! Excepted value is: {defaultAceValue}. Acquired value is: {configuration.DefaultAceValue}";
        Assert.Fail(errorMessage);
      }
    }
  }
}