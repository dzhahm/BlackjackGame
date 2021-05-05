namespace BlackjackGameLibrary.Game.Round.Enums
{
  public enum ERoundState
  {
    None,
    Initialized,
    CardDeal,
    WaitForCalls,
    AllPlayersStand,
    DealersSecondCardIsOpen,
    FinalizeRoundResults,
    RoundFinished
  }
}