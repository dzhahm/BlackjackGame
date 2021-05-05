using BlackjackGameLibrary.Game.Round.Enums;
using System.Collections.Generic;
using System.Linq;

namespace BlackjackGameLibrary.Game.Round.Commands
{
  public class FinalizeRoundResultsCommand
  {
    private readonly Dictionary<EPlayers, int> _playersSumOfCards;
    private readonly Dictionary<EPlayers, ERoundResult> _playerResults;

    public FinalizeRoundResultsCommand(Dictionary<EPlayers, int> playersSumOfCards, Dictionary<EPlayers, ERoundResult> playerResults)
    {
      _playersSumOfCards = playersSumOfCards;
      _playerResults = playerResults;
    }

    public void Execute()
    {
      int dealerCardsSum = _playersSumOfCards[EPlayers.Dealer];
      foreach (KeyValuePair<EPlayers, int> playerCardsSum in _playersSumOfCards.Where(p => p.Key != EPlayers.Dealer))
      {
        if (playerCardsSum.Value > 21)
        {
          _playerResults[playerCardsSum.Key] = ERoundResult.DealerWins;
        }

        if (playerCardsSum.Value == 21)
        {
          if (dealerCardsSum == 21)
          {
            _playerResults[playerCardsSum.Key] = ERoundResult.Push;
            return;
          }

          _playerResults[playerCardsSum.Key] = ERoundResult.PlayerWins;
        }

        if (playerCardsSum.Value < 21)
        {
          if (dealerCardsSum > playerCardsSum.Value)
          {
            _playerResults[playerCardsSum.Key] = ERoundResult.DealerWins;
            return;
          }

          if (dealerCardsSum == playerCardsSum.Value)
          {
            _playerResults[playerCardsSum.Key] = ERoundResult.Push;
            return;
          }

          if (dealerCardsSum < playerCardsSum.Value)
          {
            _playerResults[playerCardsSum.Key] = ERoundResult.PlayerWins;
            return;
          }
        }
      }
    }
  }
}