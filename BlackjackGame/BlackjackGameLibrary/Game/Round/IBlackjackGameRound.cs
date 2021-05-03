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
    ImmutableDictionary<EPlayers, ERoundCalls> PlayerCalls { get; }
    void DealCards();
    void GivePlayerAdditionalCard(EPlayers player);
    void UpdatePlayersCall(EPlayers player, ERoundCalls call);
    void OpenDealersSecondCard();
    void FinalizeRoundResults();
  }
}