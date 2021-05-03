namespace BlackjackGameLibrary.Game.Round
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