using BlackjackGameLibrary.Game.Round;
using BlackjackGameLibrary.Game.Round.Enums;
using BlackjackGameLibrary.PlayingCards;
using BlackjackGameLibrary.Tools;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace BlackjackGameLibrary.Game
{
  public class BlackjackGame : IBlackjackGame
  {
    private const int MaximumNumberOfAllowedPlayers = 3;
    private readonly int _numberOfCardDecks;
    private List<Card> _playingCards;
    public int NumberOfCardDecks => _numberOfCardDecks;

    public int NumberOfRemainingCards => _playingCards?.Count ?? 0;

    public List<Card> PlayingCards => _playingCards;

    public int NumberOfPlayers => _players?.Count ?? 0;

    private List<Player> _players;
    public ImmutableList<Player> Players => _players.ToImmutableList();


    private IBlackjackGameRound _actualGameRound;
    private List<IBlackjackGameRound> _rounds;

    public IBlackjackGameRound ActualGameRound => _actualGameRound;
    public ImmutableList<IBlackjackGameRound> Rounds => _rounds.ToImmutableList();

    public BlackjackGame(int numberOfCardDecks)
    {
      _numberOfCardDecks = numberOfCardDecks;
      InitGame();
    }

    private void InitGame()
    {
      _players = new List<Player>();
      _rounds = new List<IBlackjackGameRound>();
      _playingCards = new List<Card>();
      CreatePlayingCards();
    }

    public void AddNewPlayer(Player player)
    {
      if (_players?.Count < MaximumNumberOfAllowedPlayers)
      {
        if (_players.Any(p => p.PlayerIdentifier == player.PlayerIdentifier))
        {
          throw new InvalidOperationException("New player with the same player identifier can not be added!");
        }

        _players.Add(player);
      }
      else
      {
        throw new InvalidOperationException("Maximum number of allowed players has been reached! More players cannot be added.");
      }
    }

    public void RemovePlayer(Player player)
    {
      if (_players.Contains(player))
      {
        _players.Remove(player);
      }
      else
      {
        throw new InvalidOperationException($"Player {player.Firstname} does not exist in the current list of players!");
      }
    }


    private void CreatePlayingCards()
    {
      _playingCards = new List<Card>(new MultipleCardDecks(_numberOfCardDecks).Cards);
      ShuffleCards();
    }

    /// <summary>
    /// Fisher-Yates shuffle algorithm
    /// </summary>
    public void ShuffleCards()
    {
      new ShuffleAlgorithm().Shuffle(ref _playingCards);
    }

    public void StartNewRound()
    {
      if (NumberOfPlayers > 0)
      {
        _actualGameRound = new BlackjackGameRound(_playingCards, _players.Count);
      }
      else
      {
        throw new InvalidOperationException("Game round cannot be started without any players!. At least one player should be available to start the round");
      }
    }

    public void FinishTheRound()
    {
      int roundNumber = _rounds.Count;
      if (_actualGameRound != null)
      {
        foreach (KeyValuePair<EPlayers, ERoundResult> playerResult in _actualGameRound.PlayerResults)
        {
          _players.First(p => p.PlayerIdentifier == playerResult.Key).AddRoundResult(roundNumber, playerResult.Value);
        }

        _rounds.Add(_actualGameRound);
      }
      else
      {
      }
    }
  }
}