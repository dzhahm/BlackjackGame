namespace BlackjackGameLibrary.Game.Round.Enums
{
  public enum ERoundState
  {
    None,
    Initialized,
    CardDeal,
    WaitForCalls,
    AtLeastOnePlayerStandAndOtherPlayersExceedTwentyOne,
    AllPlayersStand,
    AllPlayersExceedTwentyOne,
    DealersSecondCardIsOpen,
    FinalizeRoundResults,
    RoundFinished
  }
}