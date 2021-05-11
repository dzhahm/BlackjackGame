using BlackjackGameLibrary.Game.Round.Enums;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace BlackjackGameLibrary.Game
{
  public class Player : IPlayer
  {
    public string Firstname { get; }
    public string Surname { get; }
    public EPlayers PlayerIdentifier { get; }

    private readonly Dictionary<int, ERoundResult> _roundResults;
    public ImmutableDictionary<int, ERoundResult> RoundResults => _roundResults.ToImmutableDictionary();

    public Player(string firstName, string surName, EPlayers playerIdentifier)
    {
      Firstname = firstName;
      Surname = surName;
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