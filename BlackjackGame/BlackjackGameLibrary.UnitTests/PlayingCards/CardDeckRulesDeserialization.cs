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
      CardDeckRules rules;
      ECardSuitTypes[] cardSuitTypes =
      {
        ECardSuitTypes.Clubs,
        ECardSuitTypes.Diamonds,
        ECardSuitTypes.Hearts,
        ECardSuitTypes.Spades
      };

      //Act
      rules = new CardDeckRulesProvider().GetRules();

      //Assert
      if (rules.CardSuits.Count != cardSuitTypes.Length && !cardSuitTypes.All(t => rules.CardSuits.Contains(t)))
      {
        string errorMessage = "Expected card suit types could not ne acquired from the configuration file!";
        Assert.Fail(errorMessage);
      }
    }

    [TestMethod]
    public void StandardNumberOfCardsInASuitIsCorrectlyDeserialized()
    {
      //Arrange
      CardDeckRules rules;
      int numberOfCardsInASuit = 13;

      //Act
      rules = new CardDeckRulesProvider().GetRules();

      //Assert

      if (rules.NumberOfCardsInASuit != numberOfCardsInASuit)
      {
        string errorMessage = $"The value acquired for the number of cards in a suit is wrong! Excepted value is: {numberOfCardsInASuit}. Acquired value is: {rules.NumberOfCardsInASuit}";
        Assert.Fail(errorMessage);
      }
    }

    [TestMethod]
    public void StandardNumberOfNumericalCardsInASuitIsCorrectlyDeserialized()
    {
      //Arrange
      CardDeckRules rules;
      int numberOfNumericalCardsInASuit = 9;

      //Act
      rules = new CardDeckRulesProvider().GetRules();

      //Assert
      if (rules.NumberOfNumericalCardsInASuit != numberOfNumericalCardsInASuit)
      {
        string errorMessage =
          $"The value acquired for the number of numerical cards in a suit is wrong! Excepted value is: {numberOfNumericalCardsInASuit}. Acquired value is: {rules.NumberOfNumericalCardsInASuit}";
        Assert.Fail(errorMessage);
      }
    }

    [TestMethod]
    public void StandardSmallestValueOfNumericalCardsIsCorrectlyDeserialized()
    {
      //Arrange
      CardDeckRules rules;
      int smallestValueOfNumericalCards = 2;

      //Act
      rules = new CardDeckRulesProvider().GetRules();

      //Assert
      if (rules.SmallestValueOfNumericalCards != smallestValueOfNumericalCards)
      {
        string errorMessage =
          $"The value acquired for the smallest value of numerical cards is wrong! Excepted value is: {smallestValueOfNumericalCards}. Acquired value is: {rules.SmallestValueOfNumericalCards}";
        Assert.Fail(errorMessage);
      }
    }

    [TestMethod]
    public void StandardFaceCardValueIsCorrectlyDeserialized()
    {
      //Arrange
      CardDeckRules rules;
      int faceCardValue = 10;

      //Act
      rules = new CardDeckRulesProvider().GetRules();

      //Assert
      if (rules.FaceCardValue != faceCardValue)
      {
        string errorMessage = $"The value acquired for the face card value is wrong! Excepted value is: {faceCardValue}. Acquired value is: {rules.FaceCardValue}";
        Assert.Fail(errorMessage);
      }
    }

    [TestMethod]
    public void StandardDefaultAceValueIsCorrectlyDeserialized()
    {
      //Arrange
      CardDeckRules rules;
      int defaultAceValue = 10;

      //Act
      rules = new CardDeckRulesProvider().GetRules();

      //Assert
      if (rules.DefaultAceValue != defaultAceValue)
      {
        string errorMessage = $"The value acquired for the default ace value is wrong! Excepted value is: {defaultAceValue}. Acquired value is: {rules.DefaultAceValue}";
        Assert.Fail(errorMessage);
      }
    }
  }
}