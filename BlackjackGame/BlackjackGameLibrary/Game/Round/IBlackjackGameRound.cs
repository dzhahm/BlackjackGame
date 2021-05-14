using BlackjackGameLibrary.Game.Round.Enums;
using BlackjackGameLibrary.PlayingCards;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Dynamic;

namespace BlackjackGameLibrary.Game.Round
{
  public interface IBlackjackGameRound
  {
    ERoundState RoundState { get; }

    public event EventHandler RoundStateChanged;

    PlayedCard DealersFirstPlayedCard { get; }
    PlayedCard DealersSecondPlayedCard { get; }
    ImmutableDictionary<EPlayers, ERoundResult> PlayerResults { get; }
    ImmutableDictionary<EPlayers, List<Card>> PlayerCards { get; }
    ImmutableDictionary<EPlayers, int> PlayersSumOfCards { get; }
    ImmutableDictionary<EPlayers, EPlayerRoundState> PlayerRoundStates { get; }
    void DealCards();
    void PlayerCall(EPlayers player, ERoundCalls call);
    void FinalizeRoundResults();
  }
}