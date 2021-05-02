﻿using BlackjackGameLibrary.Game.Round;
using BlackjackGameLibrary.PlayingCards;
using System.Collections.Generic;

namespace BlackjackGameLibrary.Game
{
  public interface IBlackjackGame
  {
    int NumberOfCardDecks { get; }

    List<Card> PlayingCards { get; }

    int NumberOfPlayers { get; }

    Dictionary<string, string> PlayerNames { get; }

    IBlackjackGameRound ActualGameRound { get; }

    List<IBlackjackGameRound> Rounds { get; }

    void ShuffleCards();

    void StartNewRound();
  }
}