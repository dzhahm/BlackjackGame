using BlackjackGameLibrary.PlayingCards;
using System.Collections.Generic;

namespace BlackjackGameLibrary.Game.GameRound
{
  public interface IBlackjackGameRound
  {
    CardDuringGame DealersFirstCard { get; }
    CardDuringGame DealersSecondCard { get; }
    ERoundResult Result { get; }
    Dictionary<EPlayers, List<Card>> PlayerCards { get; }
    Dictionary<EPlayers, ERoundCalls> PlayerCalls { get; }
    void DealCards();
    void GivePlayerAdditionalCard(EPlayers player);
    void UpdatePlayersCall(EPlayers player, ERoundCalls call);
    void FindTheWinner();
  }
}