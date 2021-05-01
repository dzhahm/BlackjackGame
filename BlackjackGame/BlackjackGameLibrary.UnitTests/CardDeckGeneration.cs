using BlackjackGameLibrary.PlayingCards;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace BlackjackGameLibrary.UnitTests
{
  [TestClass]
  public class CardDeckGeneration
  {
    [TestMethod]
    public void CardDeckHasCorrectNumberOfCards()
    {
      //Arrange
      CardDeckRules rules = new CardDeckRulesProvider().GetRules();
      //by default it is 13x4 = 52
      int numberOfExpectedCards = rules.NumberOfCardsInASuit * rules.CardSuits.Count;
      ICardDeck cardDeck;

      //Act
      cardDeck = new CardDeck();

      //Assert
      if (cardDeck.Cards.Count != numberOfExpectedCards)
      {
        string errorMessage = $"Created card deck does not have expected number of cards. Expected number is {numberOfExpectedCards}. Actual number of cards is {cardDeck.Cards.Count}";
        Assert.Fail(errorMessage);
      }
    }

    [TestMethod]
    public void CardDeckHasCorrectSuits()
    {
      //Arrange
      CardDeckRules rules = new CardDeckRulesProvider().GetRules();
      //by default four suits: Clubs, Diamonds, Hearts, Spades
      List<ECardSuitTypes> expectedCardSuits = rules.CardSuits;
      ICardDeck cardDeck;

      //Act
      cardDeck = new CardDeck();
      List<ECardSuitTypes> suitTypes = GetCardSuitTypesFromDeck(cardDeck);

      //Assert
      if (suitTypes.Count != expectedCardSuits.Count && expectedCardSuits.Any(t => !suitTypes.Contains(t)))
      {
        string errorMessage = "Created card deck does not contain all expected suit types!";
        Assert.Fail(errorMessage);
      }
    }

    private List<ECardSuitTypes> GetCardSuitTypesFromDeck(ICardDeck deck)
    {
      List<ECardSuitTypes> suitTypes = new List<ECardSuitTypes>();
      foreach (ICard card in deck.Cards)
      {
        if (!suitTypes.Contains(card.CardSuit))
        {
          suitTypes.Add(card.CardSuit);
        }
      }

      return suitTypes;
    }
  }
}