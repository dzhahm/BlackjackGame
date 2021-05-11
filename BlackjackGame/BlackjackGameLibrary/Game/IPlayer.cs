using BlackjackGameLibrary.Game.Round.Enums;
using System.Collections.Immutable;

namespace BlackjackGameLibrary.Game
{
  public interface IPlayer
  {
    public string Firstname { get; }
    public string Surname { get; }
    public EPlayers PlayerIdentifier { get; }
    ImmutableDictionary<int, ERoundResult> RoundResults { get; }
    public void AddRoundResult(int roundNumber, ERoundResult roundResult);
  }
}