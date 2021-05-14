using BlackjackGameLibrary.Game.Round.Enums;
using System.Collections.Generic;
using System.Linq;

namespace BlackjackGameLibrary.Game.Round.Commands
{
  public class UpdateRoundStateAfterPlayerCallCommand
  {
    private readonly Dictionary<EPlayers, EPlayerRoundState> _playerRoundStates;

    public UpdateRoundStateAfterPlayerCallCommand(Dictionary<EPlayers, EPlayerRoundState> playerRoundStates)
    {
      _playerRoundStates = playerRoundStates;
    }

    public ERoundState Execute()
    {
      if (_playerRoundStates.All(p => p.Value == EPlayerRoundState.ExceededTwentyOne))
      {
        return ERoundState.AllPlayersExceedTwentyOne;
      }

      if (_playerRoundStates.All(p => p.Value == EPlayerRoundState.Stand))
      {
        return ERoundState.AllPlayersStand;
      }

      if (_playerRoundStates.All(c => c.Value == EPlayerRoundState.Stand || c.Value == EPlayerRoundState.ExceededTwentyOne))
      {
        return ERoundState.AtLeastOnePlayerStandAndOtherPlayersExceedTwentyOne;
      }

      return ERoundState.WaitForCalls;
      ;
    }
  }
}