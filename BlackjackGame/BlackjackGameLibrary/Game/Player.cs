using BlackjackGameLibrary.Game.Round.Enums;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace BlackjackGameLibrary.Game
{
  public class Player : IPlayer
  {
    public string FirstName { get; }
    public string LastName { get; }
    public int PlayerIdentifier { get; }

    private readonly Dictionary<int, ERoundResult> _roundResults;
    public ImmutableDictionary<int, ERoundResult> RoundResults => _roundResults.ToImmutableDictionary();

    public Player(string firstName, string surName, int playerIdentifier)
    {
      FirstName = firstName;
      LastName = surName;
      PlayerIdentifier = playerIdentifier;
      _roundResults = new Dictionary<int, ERoundResult>();
    }

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