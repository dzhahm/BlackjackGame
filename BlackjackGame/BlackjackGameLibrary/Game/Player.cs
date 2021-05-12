using BlackjackGameLibrary.Game.Round.Enums;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace BlackjackGameLibrary.Game
{
  /// <summary>
  /// Representation of the player in the game
  /// </summary>
  public class Player : IPlayer
  {
    public string FirstName { get; }
    public string LastName { get; }
    public int PlayerIdentifier { get; }

    private readonly Dictionary<int, ERoundResult> _roundResults;
    public ImmutableDictionary<int, ERoundResult> RoundResults => _roundResults.ToImmutableDictionary();

    /// <summary>
    /// Representation of the player in the game
    /// </summary>
    /// <param name="firstName">Name of the player</param>
    /// <param name="surName">Last name of the player</param>
    /// <param name="playerIdentifier">Numerical identifier of the player</param>
    public Player(string firstName, string surName, int playerIdentifier)
    {
      FirstName = firstName;
      LastName = surName;
      PlayerIdentifier = playerIdentifier;
      _roundResults = new Dictionary<int, ERoundResult>();
    }

    /// <summary>
    /// Add the player result of the game round
    /// </summary>
    /// <param name="roundNumber">Identifier of the round in the game</param>
    /// <param name="roundResult">Result of the round for the player</param>
    public void AddRoundResult(int roundNumber, ERoundResult roundResult)
    {
      if (_roundResults.ContainsKey(roundNumber))
      {
        throw new InvalidOperationException("Round result has been already entered for the same round number! It is not allowed to use the same round number identifier for different rounds!");
      }

      _roundResults.Add(roundNumber, roundResult);
    }
  }
}