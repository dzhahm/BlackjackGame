using BlackjackGameLibrary.Game.Round.Enums;
using BlackjackGameLibrary.PlayingCards;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace BlackjackGameLibrary.Game.Round
{
  public interface IBlackjackGameRound
  {
    ERoundState RoundState { get; }
    PlayedCard DealersFirstPlayedCard { get; }
    PlayedCard DealersSecondPlayedCard { get; }
    ImmutableDictionary<EPlayers, ERoundResult> PlayerResults { get; }
    ImmutableDictionary<EPlayers, List<Card>> PlayerCards { get; }
    public Dictionary<EPlayers, int> PlayersSumOfCards { get; }
    ImmutableDictionary<EPlayers, EPlayerRoundState> PlayerRoundStates { get; }
    void DealCards();
    void ProcessPlayerCall(EPlayers player, ERoundCalls call);
    void OpenDealersSecondCard();
    void FinalizeRoundResults();
  }
}