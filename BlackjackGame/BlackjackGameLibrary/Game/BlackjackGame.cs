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
  /// <summary>
  /// The implementation of the game "Blackjack". It is played with from one to eight card decks.
  /// One to three players are playing against the same player who is the dealer.
  /// The game lasts multiple rounds. Players can join the game at different rounds. 
  /// </summary>
  public class BlackjackGame : IBlackjackGame
  {
    /// <summary>
    /// Number of the card decks used in the game. Ideally, it should be one to eight card decks.
    /// </summary>
    public int NumberOfCardDecks => _numberOfCardDecks;

    private readonly int _numberOfCardDecks;

    /// <summary>
    /// Number of the remaining cards in the game. 
    /// </summary>
    public int NumberOfRemainingCards => _playingCards?.Count ?? 0;

    /// <summary>
    /// List of all cards from all card decks.
    /// </summary>
    public List<Card> PlayingCards => _playingCards;

    private List<Card> _playingCards;

    /// <summary>
    /// Collection of active players in the game. 
    /// </summary>
    public ImmutableDictionary<EPlayers, Player> Players => _players.ToImmutableDictionary();

    private Dictionary<EPlayers, Player> _players;

    /// <summary>
    /// Number of active players in the game. It can change from round to round. 
    /// </summary>
    public int NumberOfPlayers => _players?.Count ?? 0;

    private IBlackjackGameRound _actualGameRound;
    private List<IBlackjackGameRound> _rounds;

    /// <summary>
    /// Actual round in the game. 
    /// </summary>
    public IBlackjackGameRound ActualGameRound => _actualGameRound;

    /// <summary>
    /// Collection of all rounds played in the game. 
    /// </summary>
    public ImmutableList<IBlackjackGameRound> Rounds => _rounds.ToImmutableList();

    /// <summary>
    /// Constructor for the blackjack game. 
    /// </summary>
    /// <param name="numberOfCardDecks">Number of card decks used in the game. Ideally, it should be a number from one to eight.</param>
    public BlackjackGame(int numberOfCardDecks)
    {
      _numberOfCardDecks = numberOfCardDecks;
      InitGame();
    }

    private void InitGame()
    {
      _players = new Dictionary<EPlayers, Player>();
      _rounds = new List<IBlackjackGameRound>();
      _playingCards = new List<Card>();
      CreatePlayingCards();
    }

    /// <summary>
    /// Add a new player to the game. New player can be only added if maximum number of players are not reached. New player will be active in the new round. 
    /// </summary>
    /// <param name="player"></param>
    public void AddNewPlayer(Player player)
    {
      if (_players?.Count == 0)
      {
        _players.Add(EPlayers.Player1, player);
        return;
      }

      if (_players?.Count == 1)
      {
        _players.Add(EPlayers.Player2, player);
        return;
      }

      if (_players?.Count == 2)
      {
        _players.Add(EPlayers.Player3, player);
        return;
      }

      if (_players?.Count == 3)
      {
        throw new InvalidOperationException("Maximum number of allowed players has been reached! More players cannot be added.");
      }
    }

    /// <summary>
    /// Remove a player from the game. Player can be removed from the game after player finishes the actual being played round. Otherwise, player loses the actual round. 
    /// </summary>
    /// <param name="player"></param>
    public void RemovePlayer(Player player)
    {
      if (_players.ContainsValue(player))
      {
        EPlayers playerIdentifier = _players.Keys.First(k => _players[k] == player);
        _players.Remove(playerIdentifier);
      }
      else
      {
        throw new InvalidOperationException($"Player {player.FirstName} does not exist in the current list of players!");
      }
    }


    private void CreatePlayingCards()
    {
      _playingCards = new List<Card>(new MultipleCardDecks(_numberOfCardDecks).Cards);
      ShuffleCards();
    }

    /// <summary>
    /// Fisher-Yates shuffle algorithm is used to shuffle cards after card decks are created. 
    /// </summary>
    public void ShuffleCards()
    {
      new ShuffleAlgorithm().Shuffle(ref _playingCards);
    }

    /// <summary>
    /// Start a new game round.
    /// </summary>
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

    /// <summary>
    /// Finish the actual game round. Game round is only completed after all players finish their calls for the round. 
    /// </summary>
    public void FinishTheRound()
    {
      int roundNumber = _rounds.Count;
      if (_actualGameRound != null)
      {
        foreach (KeyValuePair<EPlayers, ERoundResult> playerResult in _actualGameRound.PlayerResults)
        {
          _players[playerResult.Key].AddRoundResult(roundNumber, playerResult.Value);
        }

        _rounds.Add(_actualGameRound);
      }
      else
      {
      }
    }
  }
}