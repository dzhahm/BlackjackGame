namespace BlackjackGameLibrary.Game.Round.Enums
{
  public enum ERoundState
  {
    None,
    Initialized,
    FirstCardDeal,
    SecondCardDeal,
    WaitForCalls,
    AllPlayersStand,
    DealersSecondCardIsOpen,
    FinalizeRoundResults,
    RoundFinished
  }
}