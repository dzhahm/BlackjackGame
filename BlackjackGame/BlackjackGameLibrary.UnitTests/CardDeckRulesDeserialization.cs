using Microsoft.VisualStudio.TestTools.UnitTesting;
using BlackjackGameLibrary.CardDeck;

namespace BlackjackGameLibrary.UnitTests
{
  [TestClass]
  public class CardDeckRulesDeserialization
  {
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
        Assert.Fail("");
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