using BlackjackGameLibrary.Game.Round.Enums;
using System;
using System.Collections.Generic;

namespace BlackjackGameLibrary.Game.Round.Commands
{
  public class FinalizeRoundResultsCommand
  {
    private readonly Dictionary<EPlayers, EPlayerRoundState> _playerRoundStates;
    private readonly Dictionary<EPlayers, int> _playersSumOfCards;
    private readonly Dictionary<EPlayers, ERoundResult> _playerResults;

    public FinalizeRoundResultsCommand(Dictionary<EPlayers, EPlayerRoundState> playerRoundStates, Dictionary<EPlayers, int> playersSumOfCards, Dictionary<EPlayers, ERoundResult> playerResults)
    {
      _playerRoundStates = playerRoundStates;
      _playersSumOfCards = playersSumOfCards;
      _playerResults = playerResults;
    }

    public void Execute()
    {
      int dealerCardsSum = _playersSumOfCards[EPlayers.Dealer];
      foreach (KeyValuePair<EPlayers, EPlayerRoundState> playerRoundState in _playerRoundStates)
      {
        if (playerRoundState.Key != EPlayers.Dealer && playerRoundState.Value == EPlayerRoundState.Stand)
        {
          EPlayers player = playerRoundState.Key;
          int playerCardsSum = _playersSumOfCards[player];
          if (playerCardsSum <= 21)
          {
            if (dealerCardsSum > playerCardsSum)
            {
              _playerResults[player] = ERoundResult.DealerWins;
            }

            if (dealerCardsSum == playerCardsSum)
            {
              _playerResults[player] = ERoundResult.Push;
            }

            if (dealerCardsSum < playerCardsSum)
            {
              _playerResults[player] = ERoundResult.PlayerWins;
            }
          }
          else
          {
            throw new InvalidOperationException();
          }
        }

        else
        {
          throw new InvalidOperationException();
        }
      }
    }
  }
}