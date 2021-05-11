using BlackjackGameLibrary.Game.Round.Enums;
using System.Collections.Immutable;

namespace BlackjackGameLibrary.Game
{
  public interface IPlayer
  {
    public string FirstName { get; }
    public string LastName { get; }
    public int PlayerIdentifier { get; }
    ImmutableDictionary<int, ERoundResult> RoundResults { get; }
    public void AddRoundResult(int roundNumber, ERoundResult roundResult);
  }
}