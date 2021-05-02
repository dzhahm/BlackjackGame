using BlackjackGameLibrary.Game.Round;
using BlackjackGameLibrary.PlayingCards;
using BlackjackGameLibrary.Tools;
using System;
using System.Collections.Generic;

namespace BlackjackGameLibrary.Game
{
  public class BlackjackGame : IBlackjackGame
  {
    private int _numberOfCardDecks;
    private List<Card> _playingCards;

    public int NumberOfCardDecks { get; }
    public List<Card> PlayingCards => _playingCards;
    public int NumberOfPlayers { get; }
    public Dictionary<string, string> PlayerNames { get; }
    public List<IBlackjackGameRound> Rounds { get; }

    public BlackjackGame(int numberOfCardDecks, int numberOfPlayers)
    {
      _numberOfCardDecks = numberOfCardDecks;
      _playingCards = new List<Card>();
      CreatePlayingCards();
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
      throw new NotImplementedException();
    }
  }
}