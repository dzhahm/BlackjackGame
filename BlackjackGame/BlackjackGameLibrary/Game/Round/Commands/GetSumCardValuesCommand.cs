using BlackjackGameLibrary.PlayingCards;
using System.Collections.Generic;
using System.Linq;

namespace BlackjackGameLibrary.Game.Round.Commands
{
  public class GetSumCardValuesCommand
  {
    public int Execute(List<Card> cards)
    {
      int sum = cards.Where(c => c.CardType != ECardType.Ace).Sum(c => c.Value);
      foreach (Card ace in cards.Where(c => c.CardType == ECardType.Ace))
      {
        if (sum + 11 > 21)
        {
          sum += 1;
        }
        else
        {
          sum += 11;
        }
      }

      return sum;
    }
  }
}