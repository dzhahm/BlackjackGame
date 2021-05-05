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
      foreach (var aces in cards.Where(c => c.CardType == ECardType.Ace))
      {
        if (sum + 11 > 21)
        {
          sum++;
        }
        else
        {
          sum = sum + 10;
        }
      }

      return sum;
    }
  }
}