using BlackjackGameLibrary.Game.Round.Enums;

namespace BlackjackGameLibrary.Game.Round.Commands
{
  public class UpdateDealersSecondCardStateAfterPlayerCallCommand
  {
    private readonly ERoundState _roundState;
    private readonly PlayedCard _dealersSecondPlayedCard;

    public UpdateDealersSecondCardStateAfterPlayerCallCommand(ERoundState roundState, PlayedCard dealersSecondPlayedCard)
    {
      _roundState = roundState;
      _dealersSecondPlayedCard = dealersSecondPlayedCard;
    }

    public void Execute()
    {
      if (_roundState == ERoundState.AllPlayersStand || _roundState == ERoundState.AtLeastOnePlayerStandAndOtherPlayersExceedTwentyOne)
      {
        _dealersSecondPlayedCard.IsOpen = true;
      }
    }
  }
}