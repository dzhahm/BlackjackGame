using BlackjackGameLibrary.Game.Round.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackjackGameLibrary.Game.Round.Commands
{
  public class UpdateRoundStateAfterPlayerCallCommand
  {
    private readonly Dictionary<EPlayers, EPlayerRoundState> _playerRoundStates;

    public UpdateRoundStateAfterPlayerCallCommand(Dictionary<EPlayers, EPlayerRoundState> playerRoundStates)
    {
      _playerRoundStates = playerRoundStates;
    }

    public void Execute(out ERoundState roundState)
    {
      roundState = ERoundState.WaitForCalls;
      if (_playerRoundStates.All(p => p.Value == EPlayerRoundState.ExceededTwentyOne))
      {
        roundState = ERoundState.AllPlayersExceedTwentyOne;
      }

      else if (_playerRoundStates.All(p => p.Value == EPlayerRoundState.Stand))
      {
        roundState = ERoundState.AllPlayersStand;
      }

      else if (_playerRoundStates.All(c => c.Value == EPlayerRoundState.Stand || c.Value == EPlayerRoundState.ExceededTwentyOne))
      {
        roundState = ERoundState.AtLeastOnePlayerStandAndOtherPlayersExceedTwentyOne;
      }
    }
  }
}