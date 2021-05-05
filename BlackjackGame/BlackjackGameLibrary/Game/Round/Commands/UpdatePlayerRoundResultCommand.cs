using BlackjackGameLibrary.Game.Round.Enums;
using System.Collections.Generic;

namespace BlackjackGameLibrary.Game.Round.Commands
{
  public class UpdatePlayerRoundResultCommand
  {
    private readonly Dictionary<EPlayers, int> _playersSumOfCards;
    private readonly Dictionary<EPlayers, EPlayerRoundState> _playerRoundStates;
    private readonly Dictionary<EPlayers, ERoundResult> _playerResults;

    public UpdatePlayerRoundResultCommand(Dictionary<EPlayers, int> playersSumOfCards, Dictionary<EPlayers, EPlayerRoundState> playerRoundStates, Dictionary<EPlayers, ERoundResult> playerResults)
    {
      _playersSumOfCards = playersSumOfCards;
      _playerRoundStates = playerRoundStates;
      _playerResults = playerResults;
    }

    public void Execute(EPlayers player)
    {
      int sum = _playersSumOfCards[player];

      if (sum > 21)
      {
        _playerResults[player] = ERoundResult.DealerWins;
        _playerRoundStates[player] = EPlayerRoundState.ExceededTwentyOne;
      }
    }
  }
}